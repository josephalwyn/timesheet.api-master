using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using timesheet.business;

namespace timesheet.api.controllers
{
    [Route("api/v1/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll(string text)
        {
            var items = this.employeeService.GetEmployees();
            return new ObjectResult(items);
        }
        [HttpGet("gettimesheet")]
        public IActionResult GetTimeSheet(int id)
        {
            var items = this.employeeService.GetTimesheet(id);
            return new ObjectResult(items);
        }
        [HttpGet("gettasklist")]
        public IActionResult GetTask()
        {
            var items = this.employeeService.GetTask();
            return new ObjectResult(items);
        }

        [HttpPost("updatetask")]
        public IActionResult UpdateTask([FromBody]Timesheeetmodel taskdetails)
        {
           

         


            var items = this.employeeService.UpdateTask(taskdetails);
            return new ObjectResult(items);
        }
    }
}