using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeMultilayerModel;

namespace EmployeeMultilayer.Repository.Common
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeModel>> AllEmployees();

        Task<List<EmployeeModel>> EmployeeById(Guid employeeId);

        Task AddNewEmployee(EmployeeModel employee);

        Task UpdateEmployee(Guid id, EmployeeModel employee);

        Task<bool> DeleteEmployee(Guid employeeId);
    }
}
