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

    public class InventoryService : IInventoryService
    {
        private KbbContext _kbbContext;

        public InventoryService(KbbContext kbbContext)
        {
            _kbbContext = kbbContext;
            BuildDummyData();
        }

        public IList<Car> GetCars(string manufacuters = "", string years = "")
        {

            return _kbbContext.Cars.ToList();
        }

        private void BuildDummyData()
        {
            _kbbContext.Cars.Add(new Car { Id = 1, Manufacturer = "GM", Year = 2000, Model = "Model1", Body = BodyStyle.Coupe, Engine = EngineType.V6, ExteriorColor = "Red", Transmission = TransmissionStyle.Automatic, Price = "1000", SpecialProperty = "", ThumbNail = "" });
            _kbbContext.Cars.Add(new Car { Id = 2, Manufacturer = "GM", Year = 2000, Model = "Model1", Body = BodyStyle.Coupe, Engine = EngineType.V6, ExteriorColor = "Red", Transmission = TransmissionStyle.Automatic, Price = "1000", SpecialProperty = "", ThumbNail = "" });
            _kbbContext.Cars.Add(new Car { Id = 3, Manufacturer = "GM", Year = 2000, Model = "Model1", Body = BodyStyle.Coupe, Engine = EngineType.V6, ExteriorColor = "Red", Transmission = TransmissionStyle.Automatic, Price = "1000", SpecialProperty = "", ThumbNail = "" });
            _kbbContext.Cars.Add(new Car { Id = 4, Manufacturer = "GM", Year = 2000, Model = "Model1", Body = BodyStyle.Coupe, Engine = EngineType.V6, ExteriorColor = "Red", Transmission = TransmissionStyle.Automatic, Price = "1000", SpecialProperty = "", ThumbNail = "" });
            _kbbContext.SaveChanges();
        }
    }
}
