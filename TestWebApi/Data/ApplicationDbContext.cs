using Microsoft.EntityFrameworkCore;
using TestWebApi.Models;

namespace TestWebApi.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<MasterTransfomer> MasterTransfomers { get; set; }
        public DbSet<SilicaGel> SilicaGelDetails { get; set; }
        

    }
}
