
using DTOs;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EmployeeService :IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public List<EmployeeDTO> GetAllEmployees()
        {
            var empList = _employeeRepository.GetAllEmployees()
        .Select(e => new EmployeeDTO
        {
            EmployeeId = e.EmployeeId,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Email = e.Email,
            DateOfBirth = e.DateOfBirth,
            IsActive = e.IsActive,
        })
        .ToList();
            return empList;
        }
        public EmployeeDTO CreateEmployee(EmployeeDTO employeeDto)
        {
            var createdEmployee = _employeeRepository.CreateEmployee(employeeDto);
            return new EmployeeDTO
            {
                EmployeeId = createdEmployee.EmployeeId,
                FirstName = createdEmployee.FirstName,
                LastName = createdEmployee.LastName,
                Email = createdEmployee.Email,
                DateOfBirth = createdEmployee.DateOfBirth,
                IsActive = createdEmployee.IsActive
            };
        }
        public EmployeeDTO GetEmployeeById(int id)
        {
            var emp = _employeeRepository.GetEmployeeById(id);
            if (emp == null)
            {
                return null;
            }
            return new EmployeeDTO
            {
                EmployeeId = emp.EmployeeId,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                Email = emp.Email,
                DateOfBirth = emp.DateOfBirth,
                IsActive = emp.IsActive
            };
        }
        public EmployeeDTO UpdateEmployee(EmployeeDTO employeeDto)
        {
            var updatedEmployee = _employeeRepository.UpdateEmployee(employeeDto);
            if (updatedEmployee == null)
            {
                return null;
            }
            return new EmployeeDTO
            {
                EmployeeId = updatedEmployee.EmployeeId,
                FirstName = updatedEmployee.FirstName,
                LastName = updatedEmployee.LastName,
                Email = updatedEmployee.Email,
                DateOfBirth = updatedEmployee.DateOfBirth,
                IsActive = updatedEmployee.IsActive
            };
        }
        public string DeleteEmployee(int id)
        {
            return _employeeRepository.DeleteEmployee(id);
        }
    }
}
