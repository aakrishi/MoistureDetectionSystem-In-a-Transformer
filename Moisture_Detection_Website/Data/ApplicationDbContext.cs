using Microsoft.EntityFrameworkCore;
using Moisture_Detection_Website.Models;

namespace Moisture_Detection_Website.Data
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<MasterTransformer> MasterTransfomers { get; set; }
        public DbSet<SilicaGel> SilicaGelDetails { get; set; }
    }
}
