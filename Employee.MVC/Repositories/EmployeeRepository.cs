using Employee.MVC.Interface.Repositories;
using Employee.MVC.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Employee.MVC.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HttpClient _httpClient;

        private readonly IConfiguration _configuration;

        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_configuration.GetValue<string>("EmployeeAPI:Url"));
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<EmployeeModel>> GetAllEmployees()
        {
            var url = "";
            var response = await _httpClient.GetAsync("/users"); 
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var employees = JsonConvert.DeserializeObject<List<EmployeeModel>>(content);
            return employees != null ? employees : new List<EmployeeModel>();
        }

        public async Task<EmployeeModel> GetEmployeeById(int id)
        {
            var response = await _httpClient.GetAsync($"/users?id={id}"); 
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var employee = JsonConvert.DeserializeObject<List<EmployeeModel>>(content);
            return employee.FirstOrDefault();
        }
    }
}
