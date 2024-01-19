using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace adm_vendas_webmvc.Models
{
                 //vendedor
    public class SellerModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="{0} required")]
        [Display(Name="Name")]
        [StringLength(60, MinimumLength = 3, ErrorMessage ="Name size should be between {2} and {1}")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="Enter a valid email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name ="Birth Date")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage ="{0} required")]
        [Display(Name = "Base salary")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        public double BaseSalary { get; set; }
 
        public DepartmentModel Department { get; set; }

        public int DepartmentModelId { get; set; }

        //vendas
        public ICollection<SalesRecordModel> Sales { get; set; } = new List<SalesRecordModel>();





        public SellerModel()
        {
            
        }

        public SellerModel(int id, string name, string email, DateTime birthDate, double baseSalary, DepartmentModel department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

                              //vendas
        public void AddSales(SalesRecordModel model)
        {
            Sales.Add(model);
        }

        //vendedor
        public void RemoveSales(SalesRecordModel model)
        {
            //removendo a venda
            Sales.Remove(model);
        }

        public double TotalSales(DateTime initial,  DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
        
    }

 }
