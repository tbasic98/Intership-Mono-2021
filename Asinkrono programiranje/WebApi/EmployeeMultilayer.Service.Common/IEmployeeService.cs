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
        Task<List<EmployeeModel>> AllEmployees();
        Task<List<EmployeeModel>> EmployeeById(Guid employeeId);
        Task AddNewEmployee(EmployeeModel employee);
        Task UpdateEmployee(Guid id, EmployeeModel employee);
        Task<bool> DeleteEmployee(Guid employeeId);
    }
}
