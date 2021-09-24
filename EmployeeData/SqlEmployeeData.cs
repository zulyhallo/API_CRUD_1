using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_1.EmployeeData
{
    public class SqlEmployeeData : IEmployeeData
    {
        private EmployeeContext _employeeContext;
        public SqlEmployeeData(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public Employee AddEmployee(Employee employee)
        {
            employee.ID = Guid.NewGuid();
            _employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            //var existingEmployee = _employeeContext.Employees.Find(employee);
          //  if(existingEmployee != null)
           // {
                _employeeContext.Employees.Remove(employee);
                 _employeeContext.SaveChanges();

            //  }

        }

        public Employee EditEmployee(Employee employee)
        {
            var existingEmployee = _employeeContext.Employees.Find(employee.ID);
            if(existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                _employeeContext.Employees.Update(existingEmployee);
                _employeeContext.SaveChanges();
            }
            return employee;
        }

        public Employee GetEmployeee(Guid ID)
        {
            var employee=_employeeContext.Employees.Find(ID);
            return employee; 
        }

        public List<Employee> GetEmployees()
        {
           return  _employeeContext.Employees.ToList();

        }
    }
}
