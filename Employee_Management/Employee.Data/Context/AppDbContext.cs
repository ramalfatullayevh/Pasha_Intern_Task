using Employee.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee.Data.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employe> Employees { get; set; }
    }

}
