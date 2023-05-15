using Employee.MVC.Models;

namespace Employee.MVC.Interface.Services
{
    public interface IEmployeeService
    {
        public Task<List<EmployeeDto>> GetEmployees();
        public Task<EmployeeDto> GetEmployeeById(int id);
    }
}
