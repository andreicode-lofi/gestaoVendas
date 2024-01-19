using System;
using System.Collections.Generic;
using System.Linq;

namespace adm_vendas_webmvc.Models
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SellerModel> Sellers { get; set; } = new List<SellerModel>();



        public DepartmentModel()
        {
            
        }

        public DepartmentModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddDepartament(SellerModel model)
        {
            Sellers.Add(model);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(sr => sr.TotalSales(initial, final));
        }
    }
}
