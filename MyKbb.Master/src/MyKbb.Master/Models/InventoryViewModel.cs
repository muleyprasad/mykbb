using MyKbb.Master.DataAccess.Models;
using System.Collections.Generic;

namespace MyKbb.Master.Models
{
    public class InventoryViewModel
    {
        public IList<Car> Cars { get; set; }
        public PaginationViewModel Page { get; set; }
        public IEnumerable<KeyValuePair<string,string>> manufacturerFacet { get; set; }
        public IEnumerable<KeyValuePair<string, string>> YearFacet { get; set; }
    }
}
