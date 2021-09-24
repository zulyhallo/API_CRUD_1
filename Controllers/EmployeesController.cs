using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_1.EmployeeData;
using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeData _employeeData;
       public EmployeesController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;

        }

        [HttpGet]
        [Route("api/[controller]")]

        public IActionResult GetEmployees()
        {
            return Ok (_employeeData.GetEmployees());
             
        }
        [HttpGet]
        [Route("api/[controller]/ID")]

        public IActionResult GetEmployee(Guid ID)
        {
            var employee = _employeeData.GetEmployeee(ID);
            if(employee != null)
                {
                return Ok(employee);
            }
            return NotFound($"Employee with ID : {ID} was not found  ");

        }

        [HttpPost]
        [Route("api/[controller]")]

        public IActionResult GetEmployee( Employee employee)
        {
            _employeeData.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.ID,
                employee);
          

        }


        [HttpDelete]
        [Route("api/[controller]/{ID}")]

        public IActionResult DeleteEmployee(Guid ID)
        {
            var employeee = _employeeData.GetEmployeee(ID);
            if (employeee != null)
            {
                _employeeData.DeleteEmployee(employeee);
                return Ok();
            }
            return NotFound($"Employee with ID : {ID} was not found  ");

        }
        [HttpPatch]
        [Route("api/[controller]/{ID}")]

        public IActionResult EditEmployee(Guid ID,Employee employee)
        {
            var existingEmployee = _employeeData.GetEmployeee(ID);
            if (existingEmployee != null)
            {
                employee.ID = existingEmployee.ID;
                _employeeData.EditEmployee(employee);
                return Ok();
            }
            return NotFound($"Employee with ID : {ID} was not found  ");

        }
    }
}
