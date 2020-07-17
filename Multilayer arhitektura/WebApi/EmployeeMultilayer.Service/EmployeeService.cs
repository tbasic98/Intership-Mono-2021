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
        public EmployeeService() { }

        public List<EmployeeModel> AllEmployees()
        {
            listOfEmployees = employeeRepository.AllEmployees();
            return listOfEmployees;
        }

        public List<EmployeeModel> EmployeeById(Guid employeeId)
        {
            listOfEmployees = employeeRepository.EmployeeById(employeeId);
            return listOfEmployees;
        }

        public void AddNewEmployee(EmployeeModel employee)
        {
            employee.EmployeeId = new Guid();
            employeeRepository.AddNewEmployee(employee);
        }

        public void UpdateEmployee(Guid id, EmployeeModel employee)
        {
            employeeRepository.UpdateEmployee(id, employee);
        }

        public bool DeleteEmployee(Guid employeeId)
        {
            return (employeeRepository.DeleteEmployee(employeeId));
        }
    }
}

