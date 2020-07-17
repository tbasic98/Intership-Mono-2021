using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUD.WebApi.Controllers
{
    public class CRUDController : ApiController
    {
        List<Employee> listOfEmployees = new List<Employee>() { new Employee(1, "Ivo", "Andrić", "andric_ivo@gmail.com", "7698kn"), new Employee(2, "Marko", "Marulić", "mmarulic@gmail.com", "6354kn"), new Employee(3, "Petar", "Preradović", "pero@gmail.com", "6354kn"), new Employee(4, "Ivana", "Brlić Mažuranić", "girlsrule@gmail.com", "12000kn") };
        static List<string> listE = new List<string>();
        // GET: api/CRUD
        [HttpGet]
        public HttpResponseMessage FindAll()
        {
            //List<string> result = new List<string>();
            if (listOfEmployees.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, listOfEmployees);
        }

        // DELETE api/CRUD
        [HttpDelete]
        public HttpResponseMessage DeleteEmployee([FromBody] Employee person)
        {
            foreach (Employee employee in listOfEmployees)
            {
                if (employee.Id == person.Id)
                {
                    listOfEmployees.Remove(employee);
                    return Request.CreateResponse(HttpStatusCode.OK, employee.Name + " " + employee.LastName + " has been removed!");
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // GET api/CRUD/1
        //[HttpGet]
        public HttpResponseMessage GetEmployee(int id)
        {
            if(id > listOfEmployees.Count)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, listOfEmployees[id]);
            }
        }

        // PUT: api/CRUD/5
        /*public HttpResponseMessage Put([FromBody] Employee person)
        {
           
        }*/
       
        // POST: api/Default
       public HttpResponseMessage InesrtEmployee([FromBody] Employee person)
        {
            listOfEmployees.Add(person);
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, listOfEmployees[listOfEmployees.Count - 1]);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }


        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Salary { get; set; }


            public Employee(int id, string name, string lastname, string email, string salary)
            {
                this.Id = id;
                this.Name = name;
                this.LastName = lastname;
                this.Email = email;
                this.Salary = salary;
            }
        }
    }
}
