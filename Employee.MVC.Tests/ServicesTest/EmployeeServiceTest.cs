using Api.Logistica.Models.Models;
using Employee.MVC.Exceptions;
using Employee.MVC.Interface.Repositories;
using Employee.MVC.Models;
using Employee.MVC.Services;
using Moq;

namespace Employee.MVC.Tests.ServicesTest
{
    public class EmployeeServiceTest
    {
        [Fact]
        public void Employees_ShouldReturnEmployeeNotFoundException()
        {
            // Arrange
            var employeeRepositorieServiceMock = new Mock<IEmployeeRepository>();
            employeeRepositorieServiceMock.Setup(m => m.GetAllEmployees())
                .ReturnsAsync(() => new List<EmployeeModel>());

            var employeeService = new EmployeeService(employeeRepositorieServiceMock.Object);

            // Assert Act
            Assert.ThrowsAsync<EmployeeNotFoundException>(() => employeeService.GetEmployees());

        }    
        
        
        [Fact]
        public void Employees_ShouldReturnCorrectEmployeeList()
        {
            // Arrange
            var employeeRepositorieServiceMock = new Mock<IEmployeeRepository>();
            employeeRepositorieServiceMock.Setup(m => m.GetAllEmployees())
                .ReturnsAsync(() => new List<EmployeeModel>() {new EmployeeModel() });

            var employeeService = new EmployeeService(employeeRepositorieServiceMock.Object);

            // Act
            var result = employeeService.GetEmployees().Result;

            // Assert
            Assert.IsType<List<EmployeeDto>>(result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task GetEmployeeById_ValidId_ReturnsEmployeeDto(int id)
        {
            // Arrange
            var employeeRepositoryMock = new Mock<IEmployeeRepository>();
            var employeeService = new EmployeeService(employeeRepositoryMock.Object);

            var employeeModel = new EmployeeModel
            {
                Id = id,
                Name = "Juan Diaz",
                Username = "jdiaz",
                Salary = 5000
            };

            employeeRepositoryMock.Setup(repo => repo.GetEmployeeById(id))
                .ReturnsAsync(employeeModel);

            // Act
            var result = await employeeService.GetEmployeeById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(9999)]
        public async Task GetEmployeeById_InvalidId_ThrowsEmployeeNotFoundException(int id)
        {
            // Arrange
            var employeeRepositoryMock = new Mock<IEmployeeRepository>();
            var employeeService = new EmployeeService(employeeRepositoryMock.Object);

            employeeRepositoryMock.Setup(repo => repo.GetEmployeeById(id))
                .ReturnsAsync((EmployeeModel)null);

            // Act & Assert
            await Assert.ThrowsAsync<EmployeeNotFoundException>(() => employeeService.GetEmployeeById(id));
        }

    }
}



