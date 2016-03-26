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
        int TotalCarCount(string manufacturer = "", string years = "");
        IList<Car> GetCars(string manufacturer = "", string years = "");
    }

    public class InventoryService : IInventoryService
    {
        private KbbContext _kbbContext;

        public InventoryService(KbbContext kbbContext)
        {
            _kbbContext = kbbContext;
            BuildDummyData();
        }

        public int TotalCarCount(string manufacturer = "", string years = "")
        {
            return GetQuery(manufacturer, years).ToList().Count;
        }

        public IList<Car> GetCars(string manufacturer = "", string years = "")
        {
            //ToDo: refactor to construct lambda based on params

            return GetQuery(manufacturer, years).ToList();
        }

        private IQueryable<Car> GetQuery(string manufacturer = "", string years = "")
        {
            //ToDo: refactor to construct lambda based on params

            string[] manu;
            string[] yer;

            if (string.IsNullOrEmpty(manufacturer) && string.IsNullOrEmpty(years))
            {
                return _kbbContext.Cars.OrderBy(c => c.Id);
            }
            else if (!string.IsNullOrEmpty(manufacturer))
            {
                manu = manufacturer.Split(',');
                return _kbbContext.Cars.Where(c => manu.Contains(c.manufacturer))
                .OrderBy(c => c.Id);
            }
            else if (!string.IsNullOrEmpty(years))
            {
                yer = years.Split(',');
                return _kbbContext.Cars.Where(c => yer.Contains(c.Year.ToString()))
                .OrderBy(c => c.Id);
            }
            else if (!string.IsNullOrEmpty(manufacturer) && !string.IsNullOrEmpty(years))
            {
                manu = manufacturer.Split(',');
                yer = years.Split(',');
                return _kbbContext.Cars.Where(c => manu.Contains(c.manufacturer) && yer.Contains(c.Year.ToString()))
                .OrderBy(c => c.Id);
            }
            return null;
        }
        private void BuildDummyData()
        {
            _kbbContext.Cars.Add(new Car
            {
                Id = 1,
                manufacturer = "Toyota",
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
                manufacturer = "Toyota",
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
                manufacturer = "Nissan",
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
                manufacturer = "Ford",
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
                manufacturer = "Toyota",
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
                manufacturer = "Toyota",
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
                manufacturer = "Nissan",
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
                manufacturer = "Ford",
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
