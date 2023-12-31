﻿using Employees.Contracts;
using Employees.Models;
using Employees.Data;

namespace Employees.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeContext _context;
        public EmployeeService(EmployeeContext context)
        {
            _context = context;
        }
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

        public List<Employee> GetAll()
        {
            return _context.Employees.Select(e => e).ToList();
        }

        public void DeleteAll()
        {
            foreach (var employee in _context.Employees)
            {
                _context.Employees.Remove(employee);
            }
            _context.SaveChanges();
        }
    }
}
