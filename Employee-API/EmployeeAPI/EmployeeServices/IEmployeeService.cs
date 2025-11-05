using DTOs;

namespace Services
{
    public interface IEmployeeService
    {
        public List<EmployeeDTO> GetAllEmployees();
        public EmployeeDTO CreateEmployee(EmployeeDTO employee);

        public EmployeeDTO GetEmployeeById(int id);

        public EmployeeDTO UpdateEmployee(EmployeeDTO employee);
        public string DeleteEmployee(int id);
    }
}
