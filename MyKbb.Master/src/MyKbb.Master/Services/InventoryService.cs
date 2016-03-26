using MyKbb.Master.DataAccess;
using MyKbb.Master.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyKbb.Master.Services
{
    public interface IInventoryService
    {
        IList<Car> GetCars(string manufacuters = "", string years = "");
    }

    public class InventoryService: IInventoryService
    {
        private KbbContext _kbbContext;

        public InventoryService(KbbContext kbbContext)
        {
            _kbbContext = kbbContext;
        }

        public IList<Car> GetCars(string manufacuters = "", string years = "")
        {

            return null;
        }
    }
}
