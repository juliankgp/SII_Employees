using Employee.MVC.Exceptions;
using Employee.MVC.Interface.Repositories;
using Employee.MVC.Interface.Services;
using Employee.MVC.Models;
using Nelibur.ObjectMapper;

namespace Employee.MVC.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeDataAccess;

        public EmployeeService(IEmployeeRepository employeeDataAccess)
        {
            _employeeDataAccess = employeeDataAccess;
            TinyMapper.Bind<EmployeeModel, EmployeeDto>();
        }

        public async Task<List<EmployeeDto>> GetEmployees()
        {
            try
            {
                var employeesResult = new List<EmployeeDto>();
                var employees = await _employeeDataAccess.GetAllEmployees();

                if (employees.Count < 1)
                    throw new EmployeeNotFoundException();

                employees.ForEach(x =>
                {
                    employeesResult.Add(TinyMapper.Map<EmployeeDto>(x));

                });

                CalculateAnnualSalary(employeesResult);

                return employeesResult;
            }
            catch (EmployeeNotFoundException)
            {
                throw;
            }

        }

        public async Task<EmployeeDto> GetEmployeeById(int id)
        {
            try
            {
                var employeeMod = await _employeeDataAccess.GetEmployeeById(id);
                if (employeeMod is null || string.IsNullOrEmpty(employeeMod.Username))
                    throw new EmployeeNotFoundException();
                var employee = TinyMapper.Map<EmployeeDto>(employeeMod);
                employee.AnnualSalary = CalculateAnnualSalary(employee);
                return employee;
            }
            catch (EmployeeNotFoundException)
            {
                throw;
            }

        }

        private int CalculateAnnualSalary(EmployeeDto employee)
        {
            try
            {
                return employee.Salary * 12;
            }
            catch (AnnualSalaryCalculationException)
            {
                throw;
            }
        }

        private void CalculateAnnualSalary(List<EmployeeDto> employee)
        {
            try
            {
                employee.ForEach(employeeData => { employeeData.AnnualSalary = CalculateAnnualSalary(employeeData); });
            }
            catch (AnnualSalaryCalculationException)
            {
                throw;
            }
        }

    }
}
