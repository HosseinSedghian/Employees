﻿namespace Employees.Models
{
    public class Employee
    {
        public Employee()
        {

        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
