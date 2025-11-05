
using DTOs;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IEmployeeRepository
    {
        public List<EmployeeModel> GetAllEmployees();
        public EmployeeModel CreateEmployee(EmployeeDTO employee);
        public EmployeeModel GetEmployeeById(int id);
        public EmployeeModel UpdateEmployee(EmployeeDTO employee);
        public string DeleteEmployee(int id);
    }
}
