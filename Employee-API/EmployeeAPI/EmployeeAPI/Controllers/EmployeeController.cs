using Common;
using DTOs;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Services;


namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        
        private readonly IEmployeeService _employeeServices;
        public EmployeeController(IEmployeeService employeeServices, ILogger<EmployeeController> logger)
        {
            _employeeServices = employeeServices;
            _logger = logger;
        }

        [HttpGet("GetAllEmployeeList")]
        public IActionResult GetAllEmployeeList()
        {
            _logger.LogInformation("Fetching all employees...");

            try
            {
                var employees = _employeeServices.GetAllEmployees();

                if (employees == null || !employees.Any())
                {
                    _logger.LogWarning("No employees found in the database.");
                    return NotFound(new ApiResponse<string>(404, "No employees found", null));
                }

                _logger.LogInformation("Fetched {count} employees successfully.", employees.Count());
                return Ok(new ApiResponse<object>(200, "Employees fetched successfully", employees));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching employee list.");
                return StatusCode(500, new ApiResponse<string>(500, "An unexpected error occurred.", null, ex.Message));
            }
        }

        [HttpPost("CreateEmployee")]
        public IActionResult CreateEmployee([FromBody] EmployeeDTO employee)
        {
            _logger.LogInformation("Attempting to create a new employee with email: {email}", employee.Email);

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Validation failed for employee creation: {@employee}", employee);
                return BadRequest(new ApiResponse<string>(400, "Validation failed.", null,
                    string.Join("; ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage))));
            }

            bool emailExists = _employeeServices.GetAllEmployees().Any(x => x.Email == employee.Email && x.IsActive);
            if (emailExists)
            {
                _logger.LogWarning("Attempt to create employee with existing email: {email}", employee.Email);
                return BadRequest(new ApiResponse<string>(400, "Email already exists."));
            }

            var createdEmployee = _employeeServices.CreateEmployee(employee);
            _logger.LogInformation("Employee created successfully with ID: {id}", createdEmployee.EmployeeId);

            return Ok(new ApiResponse<EmployeeDTO>(201, "Employee created successfully.", createdEmployee));
        }

        [HttpGet("GetEmployeeById/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            _logger.LogInformation("Fetching employee with ID: {id}", id);

            var employee = _employeeServices.GetEmployeeById(id);
            if (employee == null)
            {
                _logger.LogWarning("Employee with ID: {id} not found.", id);
                return NotFound(new ApiResponse<string>(404, "Employee not found."));
            }

            _logger.LogInformation("Employee with ID: {id} fetched successfully.", id);
            return Ok(new ApiResponse<EmployeeDTO>(200, "Employee fetched successfully.", employee));
        }

        [HttpPut("UpdateEmployee")]
        public IActionResult UpdateEmployee([FromBody] EmployeeDTO employee)
        {
            _logger.LogInformation("Update employee with ID: {id}", employee.EmployeeId);

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Validation failed while updating employee ID: {id}", employee.EmployeeId);
                return BadRequest(new ApiResponse<string>(400, "Validation failed.", null,
                    string.Join("; ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage))));
            }

            bool emailExists = _employeeServices.GetAllEmployees()
                .Any(x => x.Email == employee.Email && x.IsActive && x.EmployeeId != employee.EmployeeId);
            if (emailExists)
            {
                _logger.LogWarning("Duplicate email detected during update: {email}", employee.Email);
                return BadRequest(new ApiResponse<string>(400, "Email already exists."));
            }

            var updatedEmployee = _employeeServices.UpdateEmployee(employee);
            if (updatedEmployee == null)
            {
                _logger.LogWarning("Employee with ID: {id} not found for update.", employee.EmployeeId);
                return NotFound(new ApiResponse<string>(404, "Employee not found."));
            }

            _logger.LogInformation("Employee with ID: {id} updated successfully.", employee.EmployeeId);
            return Ok(new ApiResponse<EmployeeDTO>(200, "Employee updated successfully.", updatedEmployee));
        }

        [HttpGet("CheckEmailExists")]
        public IActionResult CheckEmailExists([FromQuery] string email)
        {
            _logger.LogInformation("Checking if email exists: {email}", email);

            if (string.IsNullOrWhiteSpace(email))
            {
                _logger.LogWarning("Email check failed: email parameter was empty.");
                return BadRequest(new ApiResponse<string>(400, "Email is required."));
            }

            bool exists = _employeeServices.GetAllEmployees()
                .Any(x => x.Email.ToLower() == email.ToLower() && x.IsActive);

            _logger.LogInformation("Email check result for {email}: {exists}", email, exists);
            return Ok(new ApiResponse<bool>(200,
                exists ? "Email already exists." : "Email is available.", exists));
        }
        [HttpGet("TestError")]
        public IActionResult TestError()
        {
            throw new Exception("Simulated test exception for middleware check");
        }

    }
}
