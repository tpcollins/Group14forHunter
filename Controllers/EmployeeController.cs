using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GETEmployee: api/Employee
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Employees> Get()
        {
            Employees employee = new Employees();
            return employee.ReadBehavior.ReadAllEmployees();
        }

        // GETEmployee: api/Employee/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "Get-Employee")]
        public string Get(int id)
        {
            //Return all individual Employee item
            return "value";
        }

        // POST: api/Employee
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] Employees employee)
        {
            employee.CreateBehavior.CreateEmployees(employee);
        }

        // PUT: api/Employee/5
        [EnableCors("AnotherPolicy")]
        [HttpPut]
        public void Put([FromBody] Employees employee)
        {
            //Console.WriteLine("code is running");
            employee.UpdateBehavior.UpdateEmployee(employee);
        }

        // DELETE: api/Employee/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete()]
        public void Delete([FromBody] Employees employee)
        {
            Employees delEmp = new Employees();
            delEmp.DeleteBehavior.DeleteEmployee(employee.EmployeeID);
        }
    }
}
