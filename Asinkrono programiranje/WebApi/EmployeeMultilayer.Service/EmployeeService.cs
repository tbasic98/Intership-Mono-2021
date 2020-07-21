using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeMultilayerModel;
using EmployeeMultilayerRepository;
using EmployeeMultilayer.Service.Common;
using EmployeeMultilayer.Repository.Common;

namespace EmployeeMultilayerService
{
    public class EmployeeService : IEmployeeService
    {
        public EmployeeService(IEmployeeRepository repository)
        {
            this.repository = repository;
        }
        protected IEmployeeRepository repository { set; get; }
        public List<EmployeeModel> listOfEmployees = new List<EmployeeModel>();
        //EmployeeMultilayerRepository.EmployeeRepository employeeRepository = new EmployeeMultilayerRepository.EmployeeRepository();
        public async Task<List<EmployeeModel>> AllEmployees()
        {
            listOfEmployees = await repository.AllEmployees();
            return listOfEmployees;
        }

        public async Task<List<EmployeeModel>> EmployeeById(Guid employeeId)
        {
            listOfEmployees = await repository.EmployeeById(employeeId);
            return listOfEmployees;
        }

        public async Task AddNewEmployee(EmployeeModel employee)
        {
            employee.EmployeeId = new Guid();
            await repository.AddNewEmployee(employee);
        }

        public async Task UpdateEmployee(Guid id, EmployeeModel employee)
        {
            await repository.UpdateEmployee(id, employee);
        }

        public async Task<bool> DeleteEmployee(Guid employeeId)
        {
            return await (repository.DeleteEmployee(employeeId));
        }
    }
}

