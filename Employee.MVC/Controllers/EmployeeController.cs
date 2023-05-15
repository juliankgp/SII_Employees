using Api.Logistica.Models.Models;
using Employee.MVC.Interface.Services;
using Employee.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee.MVC.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeRepository)
        {
            _employeeService = employeeRepository;
        }

        [HttpGet]
        [Route("api/employees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetEmployees();
            return Ok(new ResponseModel<List<EmployeeDto>>() { Result = employees, Successfully = true});
        }

        [HttpGet]
        [Route("api/employees/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(new ResponseModel<EmployeeDto>() { Result = employee, Successfully = true});
        }


    }

}
