using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Data;
using System.Data.SqlClient;
using EmployeeMultilayerModel;
using EmployeeMultilayer.Repository.Common;

namespace EmployeeMultilayerRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public List<EmployeeModel> listOfEmployees = new List<EmployeeModel>();
        public EmployeeRepository() { }
        public List<EmployeeModel> AllEmployees()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employees;Integrated Security=True";

            string queryString = " SELECT* FROM Employee; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfEmployees.Add(new EmployeeModel { EmployeeId = reader.GetGuid(0), FirstName = reader.GetString(1), LastName = reader.GetString(2), Email = reader.GetString(3), DepartmentId = reader.GetGuid(4) });
                }

                reader.Close();

            }
            return listOfEmployees;
        }
        public List<EmployeeModel> EmployeeById(Guid employeeId)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employees;Integrated Security=True";

            string queryString = "SELECT Employee_id, FirstName, LastName, Email FROM Employee WHERE (Employee_id = '" + employeeId + "');";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfEmployees.Add(new EmployeeModel { EmployeeId = reader.GetGuid(0), FirstName = reader.GetString(1), LastName = reader.GetString(2), Email = reader.GetString(3) });
                }

                reader.Close();

                return listOfEmployees;
            }
        }
        public void AddNewEmployee(EmployeeModel employee)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employees;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string queryString = "INSERT INTO Employee (Employee_id, FirstName, LastName, Email, Department_id) VALUES (@EmployeeId, @FirstName, @LastName, @Email, @DepartmentId);";
            SqlCommand command = new SqlCommand(queryString, connection);

            command.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
            command.Parameters.AddWithValue("@FirstName", employee.FirstName);
            command.Parameters.AddWithValue("@LastName", employee.LastName);
            command.Parameters.AddWithValue("@Email", employee.Email);
            command.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
            command.CommandType = System.Data.CommandType.Text;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void UpdateEmployee(Guid id, EmployeeModel employee)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employees;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string queryString = "UPDATE Employee SET  FirstName = @FirstName, LastName = @LastName, Email = @Email, Department_id = @DepartmentId WHERE Employee_id = @EmployeeId;";
            SqlCommand command = new SqlCommand(queryString, connection);

            command.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
            command.Parameters.AddWithValue("@FirstName", employee.FirstName);
            command.Parameters.AddWithValue("@LastName", employee.LastName);
            command.Parameters.AddWithValue("@Email", employee.Email);
            command.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
            command.CommandType = System.Data.CommandType.Text;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public bool DeleteEmployee(Guid employeeId)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employees;Integrated Security=True";

            string checkIdExistence = "SELECT COUNT(*) as count FROM Employee WHERE Employee_id = '" + employeeId + "';";
            ;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(checkIdExistence, connection);
                connection.Open();

                int userCount = (int)command.ExecuteScalar();
                if (userCount == 0)
                {
                    return false;
                }
                string queryString = " DELETE FROM Employee WHERE Employee_id = '" + employeeId + "'; ";

                SqlDataReader reader = command.ExecuteReader();

                return true;
            }
        }
    }
}
