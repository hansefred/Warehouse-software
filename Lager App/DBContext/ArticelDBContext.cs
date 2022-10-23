using Lager_App.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Lager_App.DBContext
{
    public class ArticelDBContext : DbContext
    {
        public DbSet<Articel>? Articels { get; set; }


        public ArticelDBContext(DbContextOptions options) : base(options)
        {

        }
    }
}
