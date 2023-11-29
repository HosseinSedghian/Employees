using Microsoft.EntityFrameworkCore;
using Employees.Models;

namespace Employees.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options)
            : base(options) { }
        public DbSet<Employee> Employees { get; set; }
    }
}
