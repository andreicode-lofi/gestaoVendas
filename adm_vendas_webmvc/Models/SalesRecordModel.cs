using adm_vendas_webmvc.Models.Enums;
using System;

namespace adm_vendas_webmvc.Models
{
    public class SalesRecordModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Double Amount { get; set; }
        public SaleStatus Status { get; set; }
        public SellerModel SellerModel { get; set; }





        public SalesRecordModel()
        {
           
        }

        public SalesRecordModel(int id, DateTime date, double amount, SaleStatus status, SellerModel sellerModel)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            SellerModel = sellerModel;
        }

       
    }
}
