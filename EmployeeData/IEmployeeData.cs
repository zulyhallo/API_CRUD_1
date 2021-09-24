using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_1.EmployeeData
{
   public  interface IEmployeeData
    {
        List<Employee> GetEmployees();  // çalışanların hepsini 

        Employee GetEmployeee(Guid ID); // id'ye göre çalışanı 

        Employee AddEmployee(Employee employee); // çalışan ekle

        void DeleteEmployee(Employee employee); // çalışan sil

        Employee EditEmployee(Employee employee); // güncelleme yap


     }
}
