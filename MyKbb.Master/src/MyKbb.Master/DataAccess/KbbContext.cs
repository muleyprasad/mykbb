using Microsoft.Data.Entity;
using MyKbb.Master.DataAccess.Models;

namespace MyKbb.Master.DataAccess
{
    public class KbbContext: DbContext
    {
        public DbSet<Car> Cars { get; set; }
    }
}
