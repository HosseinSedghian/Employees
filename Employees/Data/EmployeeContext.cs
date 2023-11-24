using Microsoft.EntityFrameworkCore;
using Employees.Models;

namespace Employees.Data
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=127.0.0.1;Initial Catalog=Employees;User Id=sa;Password=HS1212hs;TrustServerCertificate=True");
        }
    }
}
