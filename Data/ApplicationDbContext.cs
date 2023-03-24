using Assesment.Model;
using Microsoft.EntityFrameworkCore;

namespace Assesment.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }
        public DbSet <Employee> employee { get; set; }
        public DbSet<Department> department   { get; set; }
    }
}
