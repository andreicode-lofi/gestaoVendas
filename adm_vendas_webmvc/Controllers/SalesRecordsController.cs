using adm_vendas_webmvc.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace adm_vendas_webmvc.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("SalesRecords/SimpleSearch")]
        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-mm-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-mm-dd");

            var result = await _salesRecordService.FindByDateAsync(minDate, maxDate);

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("SalesRecords/GroupingSearch")]
        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if(!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-mm-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-mm-dd");

            var result = await _salesRecordService.FindByGroupingAsync(minDate, maxDate);
            return View(result);
        }
    }
}
