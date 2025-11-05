using Microsoft.EntityFrameworkCore;
using MODEL;

namespace EmployeeAPI.Context
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<EmployeeModel> Employees
        {
            get; set;
        }
    }
}
