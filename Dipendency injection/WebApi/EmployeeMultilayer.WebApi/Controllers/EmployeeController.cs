using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using AutoMapper;
using EmployeeMultilayerService;
using EmployeeMultilayerModel;
using System.Threading.Tasks;



namespace EmployeeMultilayer.WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        public List<EmployeeModel> listOfEmployees = new List<EmployeeModel>();
        public List<Employee> employees = new List<Employee>();
        EmployeeMultilayerService.EmployeeService employeeService = new EmployeeMultilayerService.EmployeeService();

        [HttpGet]
        [Route("api/getAllEmployees")]
        public async Task<HttpResponseMessage> GetAllEmployees()
        {
            listOfEmployees = await employeeService.AllEmployees();

            if (listOfEmployees.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            var config = new MapperConfiguration(cfg => { _ = cfg.CreateMap<EmployeeModel, Employee>(); });
            IMapper iMapper = config.CreateMapper();

            foreach (EmployeeModel employee in listOfEmployees)
            {
                Employee person = iMapper.Map<EmployeeModel, Employee>(employee);
                employees.Add(person);
            }

            return Request.CreateResponse(HttpStatusCode.OK, listOfEmployees);
        }

        [HttpGet]
        [Route("api/employeeById/{employeeId}")]
        public async Task<HttpResponseMessage> EmployeeById([FromUri] Guid employeeId)
        {
            listOfEmployees = await employeeService.EmployeeById(employeeId);
            if (listOfEmployees.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.Found, listOfEmployees);
        }

        [HttpDelete]
        [Route("api/deleteEmployee/{employeeId}")]
        public async Task<HttpResponseMessage> DeleteEmployee([FromUri] Guid employeeId)
        {
            bool checkId = await employeeService.DeleteEmployee(employeeId);
            if (checkId == false)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Delete successful!");
        }

        [HttpPost]
        [Route("api/addEmployee")]
        public async Task<HttpResponseMessage> AddEmployee([FromBody] EmployeeModel employee)
        {
            await employeeService.AddNewEmployee(employee);
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successful");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        [Route("api/updateEmployee/{id}")]
        public async Task<HttpResponseMessage> UpdateEmployee([FromUri] Guid id, [FromBody] EmployeeModel employee)
        {
            await employeeService.UpdateEmployee(id, employee);
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successful");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        public class Employee
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            
        }
    }
}
