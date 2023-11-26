using Employees.Contracts;
using Employees.Models;
using Employees.Data;
namespace Employees.Services
{
    public class EmployeeService : IEmployeeService
    {
        EmployeeContext _context = new EmployeeContext();
        public void Create(ref Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }
        public Employee Get(int id)
        {
            return _context.Employees.SingleOrDefault(e => e.Id == id)!;
        }
        public void Update(Employee request)
        {
            _context.Employees.Update(request);
            _context.SaveChanges();
        }

        public void Delete(Employee request)
        {
            _context.Employees.Remove(request);
            _context.SaveChanges();
        }
    }
}
