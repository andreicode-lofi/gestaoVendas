using adm_vendas_webmvc.Models;
using adm_vendas_webmvc.Models.ViewModel;
using adm_vendas_webmvc.Service;
using adm_vendas_webmvc.Service.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace adm_vendas_webmvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellersService _sellersService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellersService sellersService, DepartmentService departmentService)
        {
            _sellersService = sellersService;
            _departmentService = departmentService;
        }

        /// <summary>
        /// Sellers Index
        /// </summary>
        /// <param name=""></param>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await _sellersService.ListAllAsync();
            return View(list);
        }

        /// <summary>
        /// Create Sellers
        /// </summary>
        /// <param name=""></param>
        [HttpGet]
        [Route("Sellers/Create")]
        public async Task<IActionResult> Create()
        {
            var list = await _departmentService.ListAll();//selec list
            
            var viewModel =  new SellerFormViewModel { DepartmentsModel = list };

            return View(viewModel);
        }

        /// <summary>
        ///Post crete Sellers
        /// </summary>
        /// <param name="SellerFormViewModel model"></param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Sellers/Create")]
        public async Task<IActionResult> Create(SellerFormViewModel model)
        {
            if (!ModelState.IsValid)//validação caso js esteja desabilitado no navegador, e não consiga fazer a validação do data annotation, retorne para view create 
            {
                var listDepartments = await _departmentService.ListAll();
                var viewModel = new SellerFormViewModel { SellerModel = model.SellerModel, DepartmentsModel = listDepartments };
                return View(viewModel);
            }

            if(model.SellerModel.Id == null) RedirectToAction(nameof(Error), new { message = "Id not provided" });
            var seller = _sellersService.CreateAsync(model.SellerModel);

            return RedirectToAction("Index");
        }

        /// <summary>
        ///Delete Sellers
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null) RedirectToAction(nameof(Error), new { message = "Id not provided" });

            var seller = await _sellersService.GetByidAsync(id.Value);

            if(seller == null) RedirectToAction(nameof(Error), new { message = "Id not found" }); ;

            return View(seller);
        }

        /// <summary>
        ///Post Delete Sellers
        /// </summary>
        /// <param name="id"></param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Sellers/PostDelete")]
        public async Task<IActionResult> PostDelete(int? id)
        {
            try
            {
                if (id.Value == null) RedirectToAction(nameof(Error), new { message = "Id not provided" });
                await _sellersService.DeleteAsync(id.Value);
                return RedirectToAction("Index");
            }
            catch(IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            
        }

        /// <summary>
        ///Details Sellers
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        [Route("Sellers/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) RedirectToAction(nameof(Error), new { message = "Id not provided" });

            var seller = await _sellersService.GetByidAsync(id.Value);

            if (seller == null) RedirectToAction(nameof(Error), new { message = "Id not found" });

            return View(seller);
        }

        /// <summary>
        ///Edit Sellers
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        [Route("Sellers/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null) RedirectToAction(nameof(Error), new {message = "Id not provided"}); 

            var obj = await _sellersService.GetByidAsync(id.Value);

            if (obj == null) RedirectToAction(nameof(Error), new { message = "Id not found" });  

            List<DepartmentModel> list = await _departmentService.ListAll();// listando select

            SellerFormViewModel viewModel = new SellerFormViewModel
            {
                SellerModel = obj,
                DepartmentsModel = list
            };

            return View(viewModel);
        }

        /// <summary>
        ///Post Edit Sellers
        /// </summary>
        /// <param name="int id, SellerFormViewModel model"></param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Sellers/Edit")]
        public async Task<IActionResult> Edit(int id, SellerFormViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)//validação caso js esteja desabilitado no navegador, e não consiga fazer a validação do data annotation, retorne para view edit 
                {
                    var listDepartments = await _departmentService.ListAll();
                    var seller = new SellerFormViewModel { SellerModel = model.SellerModel, DepartmentsModel = listDepartments };
                    return View(seller);
                }

                if (id != model.SellerModel.Id) RedirectToAction(nameof(Error), new { message = "Id not found" });

                 await _sellersService.UpdateAsync(model.SellerModel);

                return RedirectToAction("Index");
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        /// <summary>
        ///Erro Sellers
        /// </summary>
        /// <param name="string message"></param>
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier

            };

            return View(viewModel);
        }
    }
}
