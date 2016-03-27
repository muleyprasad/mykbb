using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MyKbb.Master.DataAccess;
using MyKbb.Master.Services;
using MyKbb.Master.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MyKbb.Master.Controllers
{
    public class InventoryController : Controller
    {
        private IInventoryService _inventoryService;
        private const int pageSize = 2;
        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }
        // GET: /<controller>/
        public IActionResult Index(string pageId, string manufacturer,string years)
        {
            var viewModel = BuildViewModel(pageId, manufacturer, years);
            return View(viewModel);
        }

        private object BuildViewModel(string pageId, string manufacturer, string years)
        {
            var viewModel = new InventoryViewModel();
            
            var filteredCars = _inventoryService.GetCars(manufacturer, years);
            //build pagination model
            viewModel.Page = GetPageModel(pageId, filteredCars.Count, manufacturer, years);

            //take current page rows from filtered cars list
            //better if paging is done while querying data, but tradeoff is you need to query DB second time
            //to get details for filters
            viewModel.Cars = filteredCars.Skip(viewModel.Page.CurrentPageId * pageSize).Take(pageSize).ToList();
            
            //get distinct manufacturers and their count for current resultset
            viewModel.manufacturerFacet = filteredCars.GroupBy((item => item.manufacturer),
             (key, elements) => new KeyValuePair<string,string>(key, elements.Distinct().Count().ToString()));
            
            //get distinct years and their count for current resultset
            viewModel.YearFacet = filteredCars.GroupBy((item => item.Year),
                         (key, elements) => new KeyValuePair<string, string>(key.ToString(), elements.Distinct().Count().ToString()));

            return viewModel;
        }

        private PaginationViewModel GetPageModel(string pageId, int totalCarCount, string manufacturer, string years)
        {
            var pageModel = new PaginationViewModel();
            pageModel.PageUrl = "~/inventory/" + 
                ((!string.IsNullOrEmpty(manufacturer) || !string.IsNullOrEmpty(years)) ? "?manufacturer=" + manufacturer + "&years=" + years : "");
            pageModel.TotalPageCount = totalCarCount / pageSize;
            pageModel.CurrentPageId = string.IsNullOrEmpty(pageId) ? 0 : Convert.ToInt16(pageId);

            return pageModel;
        }
    }
}
