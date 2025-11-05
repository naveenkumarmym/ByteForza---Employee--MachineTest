

using DTOs;
using Repository.Context;
using MODEL;

namespace Repository
{
    public class EmployeeRepository :IEmployeeRepository
    {
        private readonly EmployeeDbContext _employeeDb;
        public EmployeeRepository( EmployeeDbContext employeeDb)
        {
            _employeeDb = employeeDb;

        }

        public List<EmployeeModel> GetAllEmployees()
        {
            var empList = _employeeDb.Employees.ToList();

            return empList;
        }
        public EmployeeModel CreateEmployee(EmployeeDTO employee)
        {
            EmployeeModel emp = new EmployeeModel()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                DateOfBirth = employee.DateOfBirth,
                IsActive = employee.IsActive,
                CreatedDate = DateTime.Now
            };
            _employeeDb.Employees.Add(emp);
            _employeeDb.SaveChanges();
            return emp;
        }
        public EmployeeModel GetEmployeeById(int id)
        {
            var emp = _employeeDb.Employees.Find(id);
            return emp;
        }
        public EmployeeModel UpdateEmployee(EmployeeDTO employee)
        {
            var emp = _employeeDb.Employees.Find(employee.EmployeeId);
            if (emp == null)
            {
                return null;
            }
            emp.FirstName = employee.FirstName;
            emp.LastName = employee.LastName;
            emp.Email = employee.Email;
            emp.DateOfBirth = employee.DateOfBirth;
            emp.IsActive = employee.IsActive;
            _employeeDb.SaveChanges();
            return emp;
        }

        public string DeleteEmployee(int id)
        {
            var emp = _employeeDb.Employees.Find(id);
            if (emp == null)
            {
                return "Employee not found";
            }
            emp.IsActive = false;
            _employeeDb.SaveChanges();
            return emp.FirstName + " " + emp.LastName + " deleted successfully";
        }

    }
}
