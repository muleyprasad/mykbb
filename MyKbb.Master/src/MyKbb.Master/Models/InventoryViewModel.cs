using MyKbb.Master.DataAccess.Models;
using System.Collections.Generic;

namespace MyKbb.Master.Models
{
    public class InventoryViewModel
    {
        public IList<Car> Cars { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPageId { get; set; }
        public KeyValuePair<string,string> ManufacturerFacet { get; set; }
        public KeyValuePair<string, string> YearFacet { get; set; }
    }
}
