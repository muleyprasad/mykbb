using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyKbb.Master.Models
{
    public class PaginationViewModel
    {
        public int TotalPageCount { get; set; }
        public int CurrentPageId { get; set; }
        public string PageUrl { get; set; }
    }
}
