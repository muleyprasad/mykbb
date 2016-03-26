using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyKbb.Master.Models
{
    public enum BodyStyle
    {
        Coupe,
        Van,
        Truck
    }

    public enum TransmissionStyle
    {
        Manual,
        Automatic
    }
    public enum EngineType
    {
        V6,
        V8
    }
    public class Car
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public BodyStyle Body { get; set; }
        public string ExteriorColor { get; set; }
        public TransmissionStyle Transmission { get; set; }
        public EngineType Engine { get; set; }
        public string ThumbNail { get; set; }
        public string Price { get; set; }
        public string SpecialProperty { get; set; }
    }
}
