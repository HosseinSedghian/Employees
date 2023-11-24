using Employees.Contracts;
using Employees.Models;

namespace Employees.Services
{
    public interface IEmployeeService
    {
        Employee Create(EmployeeRequest request);
        Employee Get(int id);
        void Update(Employee request);
        void Delete(Employee request);
    }
}
