using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Internal;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


namespace EmployeDatabase.WebApi.Controllers
{
    public class EmployeeController : ApiController
    {

        static SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmployeeDatabase;Integrated Security=True");
        static List<Employee> listOfEmployees = new List<Employee>();

        [HttpGet]
        [Route("api/GetMix")]
        public HttpResponseMessage GetMix()
        {
            connection.Open();
            List<string> result = new List<string>();

            SqlCommand command = new SqlCommand
                (
                    " SELECT CompanyName, DepartmentName, FirstName, LastName, Email " +
                    " FROM Company c, Department d, Employee e " +
                    " WHERE c.Company_id = d.Company_id " +
                    " AND c.Company_id = e.Company_id; ",
                    connection
                );

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result.Add(reader.GetString(0) + "  " + reader.GetString(1) + "  " + reader.GetString(2) + "  " + reader.GetString(3) + "  " + reader.GetString(4));
                }
            }

            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            finally
            {
                connection.Close();
                reader.Close();
            }
        }

        [HttpGet]
        [Route("api/GetEmployees")]
        public HttpResponseMessage GetEmployees()
        {
            connection.Open();
            List<string> result = new List<string>();

            SqlCommand command = new SqlCommand
                (
                    " SELECT* FROM Employee; ",
                    connection
                );

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result.Add(reader.GetInt32(0) + "  " + reader.GetString(1) + "  " + reader.GetString(2) + "  " + reader.GetString(3) + "  " + reader.GetInt32(4));
                }
            }

            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            finally
            {
                connection.Close();
                reader.Close();
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteEmployee([FromUri] int id)
        {
            connection.Open();
            string Sql = "DELETE FROM Employee WHERE Employee_id = @Val1;";

            SqlCommand command = new SqlCommand(Sql, connection);

            command.Parameters.AddWithValue("@Val1", id);

            try
            {
                command.ExecuteNonQuery();
                return Request.CreateResponse(HttpStatusCode.OK, "Successful");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            finally
            {
                connection.Close();
            }
        }

        [HttpPost]
        public HttpResponseMessage PostEmployee([FromBody] Company comp)
        {
            connection.Open();
            string Sql = "INSERT INTO Company(Company_id, CompanyName) VALUES(@Val1, @Val2);";

            SqlCommand command = new SqlCommand(Sql, connection);

            command.Parameters.AddWithValue("@Val1", comp.Company_id);
            command.Parameters.AddWithValue("@Val2", comp.CompanyName);

            try
            {
                command.ExecuteNonQuery();
                return Request.CreateResponse(HttpStatusCode.OK, "Successful");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            finally
            {
                connection.Close();
            }
        }


        [HttpPut]
        public HttpResponseMessage PutEmployee([FromBody] Department dept)
        {
            connection.Open();
            string Sql = "UPDATE Department SET DepartmentName = @Val1, Company_id = @Val2 WHERE Department_id = @Val3;";

            SqlCommand command = new SqlCommand(Sql, connection);

            command.Parameters.AddWithValue("@Val1", dept.DepartmentName);
            command.Parameters.AddWithValue("@Val2", dept.Company_id);
            command.Parameters.AddWithValue("@Val3", dept.Department_id);

            command.CommandType = System.Data.CommandType.Text;

            try
            {
                command.ExecuteNonQuery();
                return Request.CreateResponse(HttpStatusCode.OK, "Successful");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            finally
            {
                connection.Close();
            }
        }

        public class Employee
        {
            public int Employee_id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public int Department_id { get; set; }

            public Employee(int id, string firstName, string lastName, string email, int department_id)
            {
                this.Employee_id = id;
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Email = email;
                this.Department_id = department_id;
            }
        }
        public class Company
        {
            public int Company_id { get; set; }
            public string CompanyName { get; set; }

            public Company(int id, string companyName)
            {
                this.Company_id = id;
                this.CompanyName = companyName;
            }
        }
        public class Department
        {
            public int Department_id { get; set; }
            public string DepartmentName { get; set; }
            public int Company_id { get; set; }

            public Department(int id, string departmentName, int company_id)
            {
                this.Department_id = id;
                this.DepartmentName = departmentName;
                this.Company_id = company_id;
            }
        }
    }
}
