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
        public IActionResult Index(string pageId)
        {
            var viewModel = BuildViewModel(pageId);
            return View(viewModel);
        }

        private object BuildViewModel(string pageId)
        {
            var viewModel = new InventoryViewModel();
            var pageModel = new PaginationViewModel();

            //build pagination model
            pageModel.PageUrl = "~/inventory/";
            pageModel.TotalPageCount = _inventoryService.TotalCarCount() / pageSize;
            pageModel.CurrentPageId = string.IsNullOrEmpty(pageId) ? 0 : Convert.ToInt16(pageId);
            //build inventory list view model
            viewModel.Cars = _inventoryService.GetCars(pageNum: pageModel.CurrentPageId, pageSize: pageSize);
            viewModel.Page = pageModel;
            //get distinct manufacturers and their count for current resultset
            viewModel.ManufacturerFacet = viewModel.Cars.GroupBy((item => item.Manufacturer),
             (key, elements) => new KeyValuePair<string,string>(key, elements.Distinct().Count().ToString()));
            //get distinct years and their count for current resultset
            viewModel.YearFacet = viewModel.Cars.GroupBy((item => item.Year),
                         (key, elements) => new KeyValuePair<string, string>(key.ToString(), elements.Distinct().Count().ToString()));

            return viewModel;
        }

    }
}
