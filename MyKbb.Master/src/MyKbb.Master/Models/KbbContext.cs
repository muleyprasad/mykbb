using Microsoft.Data.Entity;

namespace MyKbb.Master.Models
{
    public class KbbContext: DbContext
    {
        public DbSet<Car> Cars { get; set; }
    }
}
