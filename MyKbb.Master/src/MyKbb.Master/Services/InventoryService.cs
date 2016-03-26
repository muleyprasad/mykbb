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
        int TotalCarCount();
        IList<Car> GetCars(int pageNum = 0, int pageSize = 2, string manufacuters = "", string years = "");
    }

    public class InventoryService : IInventoryService
    {
        private KbbContext _kbbContext;

        public InventoryService(KbbContext kbbContext)
        {
            _kbbContext = kbbContext;
            BuildDummyData();
        }

        public int TotalCarCount()
        {
            return _kbbContext.Cars.ToList().Count;
        }

        public IList<Car> GetCars(int pageNum = 0, int pageSize = 2, string manufacuters = "", string years = "")
        {

            return _kbbContext.Cars.OrderBy(c=>c.Id).Skip(pageNum * pageSize).Take(pageSize).ToList();
        }

        private void BuildDummyData()
        {
            _kbbContext.Cars.Add(new Car
            {
                Id = 1,
                Manufacturer = "GM",
                Year = 2000,
                Model = "Model101",
                Body = BodyStyle.Coupe,
                Engine = EngineType.V6,
                ExteriorColor = "Red",
                Transmission = TransmissionStyle.Automatic,
                Price = "10000",
                SpecialProperty = "",
                ThumbNail = "coupe.jpg"
            });
            _kbbContext.Cars.Add(new Car
            {
                Id = 2,
                Manufacturer = "Toyota",
                Year = 2010,
                Model = "Model102",
                Body = BodyStyle.Truck,
                Engine = EngineType.V6,
                ExteriorColor = "Red",
                Transmission = TransmissionStyle.Automatic,
                Price = "11000",
                SpecialProperty = "",
                ThumbNail = "truck.jpg"
            });
            _kbbContext.Cars.Add(new Car
            {
                Id = 3,
                Manufacturer = "Nissan",
                Year = 2012,
                Model = "Model103",
                Body = BodyStyle.Van,
                Engine = EngineType.V6,
                ExteriorColor = "Red",
                Transmission = TransmissionStyle.Automatic,
                Price = "11000",
                SpecialProperty = "",
                ThumbNail = "van.jpg"
            });
            _kbbContext.Cars.Add(new Car
            {
                Id = 4,
                Manufacturer = "Ford",
                Year = 2012,
                Model = "Model104",
                Body = BodyStyle.Coupe,
                Engine = EngineType.V6,
                ExteriorColor = "Red",
                Transmission = TransmissionStyle.Automatic,
                Price = "10000",
                SpecialProperty = "",
                ThumbNail = "coupe.jpg"
            });
            _kbbContext.Cars.Add(new Car
            {
                Id = 5,
                Manufacturer = "GM",
                Year = 2000,
                Model = "Model105",
                Body = BodyStyle.Coupe,
                Engine = EngineType.V6,
                ExteriorColor = "Red",
                Transmission = TransmissionStyle.Automatic,
                Price = "11000",
                SpecialProperty = "",
                ThumbNail = "coupe.jpg"
            });
            _kbbContext.Cars.Add(new Car
            {
                Id = 6,
                Manufacturer = "Toyota",
                Year = 2010,
                Model = "Model106",
                Body = BodyStyle.Truck,
                Engine = EngineType.V6,
                ExteriorColor = "Red",
                Transmission = TransmissionStyle.Automatic,
                Price = "10000",
                SpecialProperty = "",
                ThumbNail = "truck.jpg"
            });
            _kbbContext.Cars.Add(new Car
            {
                Id = 7,
                Manufacturer = "Nissan",
                Year = 2012,
                Model = "Model107",
                Body = BodyStyle.Van,
                Engine = EngineType.V6,
                ExteriorColor = "Red",
                Transmission = TransmissionStyle.Automatic,
                Price = "10000",
                SpecialProperty = "",
                ThumbNail = "van.jpg"
            });
            _kbbContext.Cars.Add(new Car
            {
                Id = 8,
                Manufacturer = "Ford",
                Year = 2012,
                Model = "Model108",
                Body = BodyStyle.Coupe,
                Engine = EngineType.V6,
                ExteriorColor = "Red",
                Transmission = TransmissionStyle.Automatic,
                Price = "10000",
                SpecialProperty = "",
                ThumbNail = "coupe.jpg"
            });
            _kbbContext.SaveChanges();
        }
    }
}
