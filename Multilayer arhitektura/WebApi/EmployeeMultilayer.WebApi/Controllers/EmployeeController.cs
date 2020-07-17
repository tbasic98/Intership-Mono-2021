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


namespace EmployeeMultilayer.WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        public List<EmployeeModel> listOfEmployees = new List<EmployeeModel>();
        public List<Employee> employees = new List<Employee>();
        EmployeeMultilayerService.EmployeeService employeeService = new EmployeeMultilayerService.EmployeeService();

        [HttpGet]
        [Route("api/getAllEmployees")]
        public HttpResponseMessage GetAllEmployees()
        {
            listOfEmployees = employeeService.AllEmployees();

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
        public HttpResponseMessage EmployeeById([FromUri] Guid employeeId)
        {
            listOfEmployees = employeeService.EmployeeById(employeeId);
            if (listOfEmployees.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.Found, listOfEmployees);
        }

        [HttpDelete]
        [Route("api/deleteEmployee/{employeeId}")]
        public HttpResponseMessage DeleteEmployee([FromUri] Guid employeeId)
        {
            bool checkId = employeeService.DeleteEmployee(employeeId);
            if (checkId == false)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Delete successful!");
        }

        [HttpPost]
        [Route("api/addEmployee")]
        public HttpResponseMessage AddEmployee([FromBody] EmployeeModel employee)
        {
            employeeService.AddNewEmployee(employee);
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
        public HttpResponseMessage UpdateEmployee([FromUri] Guid id, [FromBody] EmployeeModel employee)
        {
            employeeService.UpdateEmployee(id, employee);
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
