using adm_vendas_webmvc.Data;
using adm_vendas_webmvc.Models;
using adm_vendas_webmvc.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace adm_vendas_webmvc.Service
{
    public class SellersService
    {
        private readonly DataContext _context;

        public SellersService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<SellerModel>> ListAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task<SellerModel> CreateAsync(SellerModel model)
        {
            try
            {
                _context.Seller.Add(model);
                await _context.SaveChangesAsync();
                return model;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<SellerModel> GetByidAsync(int id)
        {
            return  await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var seller = await _context.Seller.FindAsync(id);
                if (seller != null)
                {
                    _context.Remove(seller);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new IntegrityException("Can´t delete seller because he/she has sales");
            }
           
        }

        public async Task UpdateAsync(SellerModel model)
        {
            var hasAny =  await _context.Seller.AnyAsync(obj => obj.Id == model.Id);// tem esse id no banco ?
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
