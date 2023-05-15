using Employee.MVC.Models;

namespace Employee.MVC.Interface.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeModel>> GetAllEmployees();
        Task<EmployeeModel> GetEmployeeById(int id);
    }
}
