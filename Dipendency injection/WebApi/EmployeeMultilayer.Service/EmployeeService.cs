using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeMultilayerModel;
using EmployeeMultilayerRepository;
using EmployeeMultilayer.Service.Common;

namespace EmployeeMultilayerService
{
    public class EmployeeService : IEmployeeService
    {
        public List<EmployeeModel> listOfEmployees = new List<EmployeeModel>();
        EmployeeMultilayerRepository.EmployeeRepository employeeRepository = new EmployeeMultilayerRepository.EmployeeRepository();
        public async Task<List<EmployeeModel>> AllEmployees()
        {
            listOfEmployees = await employeeRepository.AllEmployees();
            return listOfEmployees;
        }

        public async Task<List<EmployeeModel>> EmployeeById(Guid employeeId)
        {
            listOfEmployees = await employeeRepository.EmployeeById(employeeId);
            return listOfEmployees;
        }

        public async Task AddNewEmployee(EmployeeModel employee)
        {
            employee.EmployeeId = new Guid();
            await employeeRepository.AddNewEmployee(employee);
        }

        public async Task UpdateEmployee(Guid id, EmployeeModel employee)
        {
            await employeeRepository.UpdateEmployee(id, employee);
        }

        public async Task<bool> DeleteEmployee(Guid employeeId)
        {
            return await (employeeRepository.DeleteEmployee(employeeId));
        }
    }
}

