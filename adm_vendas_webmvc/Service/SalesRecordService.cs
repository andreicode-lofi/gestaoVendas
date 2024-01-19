using adm_vendas_webmvc.Data;
using adm_vendas_webmvc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adm_vendas_webmvc.Service
{
    public class SalesRecordService
    {
        private readonly DataContext _context;

        public SalesRecordService(DataContext context)
        {
            _context = context;
        }


        public async Task<List<SalesRecordModel>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result =  from obj in _context.SalesRecord select obj;//buscar obj por completo
            if (minDate.HasValue)
            {
                result =  result.Where(x => x.Date >= minDate.Value);
            }
            if(maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result
                .Include(obj => obj.SellerModel)
                .Include(x => x.SellerModel.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }


        //Metodo retornando uma pesquisa agrupada
        public async Task<List<IGrouping<DepartmentModel,SalesRecordModel>>> FindByGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;//buscar obj por completo
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            //var retornoSales = await result

            //.Include(x => x.SellerModel)

            //.Include(x => x.SellerModel.Department)

            //.OrderByDescending(x => x.Date)

            //.ToListAsync();

            //return retornoSales.GroupBy(x => x.SellerModel.Department).ToList();
            return await result
                .Include(obj => obj.SellerModel)
                .Include(x => x.SellerModel.Department)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.SellerModel.Department)
                .ToListAsync();
        }
    }
}
