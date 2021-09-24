using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_1.EmployeeData
{
    public class MockEmployeeData : IEmployeeData // interface'i implementation
    {
        public List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                ID=Guid.NewGuid(),
                Name="Employee One"
            },
             new Employee()
            {
                ID=Guid.NewGuid(),
                Name="Employee Two"
            },
                   new Employee()
            {
                ID=Guid.NewGuid(),
                Name="Employee Three"
            }
        };
         
        public Employee AddEmployee(Employee employee)
        {
            employee.ID = Guid.NewGuid();
            employees.Add(employee);
            return employee;

        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public Employee EditEmployee(Employee employee)
        {
            var existingEmployee = GetEmployeee(employee.ID);
            existingEmployee.Name = employee.Name;
            return existingEmployee;


        }

        public Employee GetEmployeee(Guid ID)
        {
            return employees.SingleOrDefault(x => x.ID == ID);
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
