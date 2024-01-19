using adm_vendas_webmvc.Data;
using adm_vendas_webmvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adm_vendas_webmvc.Service
{
    public class DepartmentService
    {
        private readonly DataContext _context;

        public DepartmentService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<DepartmentModel>> ListAll()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
