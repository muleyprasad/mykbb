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
            var viewModel = new InventoryViewModel();
            viewModel.TotalPages = _inventoryService.TotalCarCount() / pageSize;
            viewModel.CurrentPageId = string.IsNullOrEmpty(pageId) ? 0: Convert.ToInt16(pageId);
            viewModel.Cars = _inventoryService.GetCars(pageNum: viewModel.CurrentPageId, pageSize: pageSize);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(InventoryViewModel model)
        {
            var viewModel = new InventoryViewModel();
            viewModel.Cars = _inventoryService.GetCars();
            return View(viewModel);
        }
    }
}
