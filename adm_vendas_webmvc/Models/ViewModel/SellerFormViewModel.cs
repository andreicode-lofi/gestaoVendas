using System.Collections.Generic;

namespace adm_vendas_webmvc.Models.ViewModel
{
    public class SellerFormViewModel
    {
        public SellerModel SellerModel { get; set; }
        public ICollection<DepartmentModel> DepartmentsModel { get; set; }
    }
}
