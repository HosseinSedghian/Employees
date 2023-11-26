using Employees.Contracts;
using Employees.Models;

namespace Employees.Services
{
    public interface IEmployeeService
    {
        void Create(ref Employee employee);
        Employee Get(int id);
        void Update(Employee request);
        void Delete(Employee request);
    }
}
