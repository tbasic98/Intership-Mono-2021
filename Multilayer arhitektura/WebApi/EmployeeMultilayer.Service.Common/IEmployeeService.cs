using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeMultilayerModel;

namespace EmployeeMultilayer.Service.Common
{
    public interface IEmployeeService
    {
        List<EmployeeModel> AllEmployees();
        List<EmployeeModel> EmployeeById(Guid employeeId);
        void AddNewEmployee(EmployeeModel employee);
        void UpdateEmployee(Guid id, EmployeeModel employee);
        bool DeleteEmployee(Guid employeeId);
    }
}
