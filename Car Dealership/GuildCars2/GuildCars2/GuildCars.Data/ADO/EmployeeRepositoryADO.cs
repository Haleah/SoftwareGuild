using GuildCars.Data.Interface;
using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.ADO
{
    public class EmployeeRepositoryADO : IEmployeeRepository
    {
        public void CreateEmployee(Employees employee)
        {
            //Setting up the connection string as in the settings file
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                //Setting up the stored procedure command
                SqlCommand cmd = new SqlCommand("CreateEmployee", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@lastName", employee.LastName);
                cmd.Parameters.AddWithValue("@firstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@email", employee.Email);
                cmd.Parameters.AddWithValue("@role", employee.Role);

                //Opens the connection to the database
                cn.Open();

                cmd.ExecuteNonQuery();

                cn.Close();
            }
        }

        public void DeleteEmployee(Employees employee)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DeleteEmployee", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@employeeId", employee.EmployeeId);

                cn.Open();

                cmd.ExecuteNonQuery();

                cn.Close();
            }
        }

        public List<Employees> ReadAllEmployees()
        {

            //Creates the list for the SQL commands
            List<Employees> Employee = new List<Employees>();

            //Setting up the connection string as in the settings file
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                //Setting up the stored procedure command
                SqlCommand cmd = new SqlCommand("ReadAllEmployee", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Opens the connection to the database
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Employees currentEmployee = new Employees();
                        currentEmployee.EmployeeId = (int)dr["EmployeeId"];
                        currentEmployee.LastName = dr["LastName"].ToString();
                        currentEmployee.FirstName = dr["FirstName"].ToString();
                        currentEmployee.Email = dr["Email"].ToString();
                        currentEmployee.Role = dr["Role"].ToString() == "Admin";
                        
                        //Load the object into the list

                        Employee.Add(currentEmployee);
                    }
                }
                cn.Close();
            }
            return Employee;
        }

        public Employees ReadByEmployeeId(int employeeId)
        {
            //Creates the list for the SQL commands
            Employees Employee = new Employees();

            //Setting up the connection string as in the settings file
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                //Setting up the stored procedure command
                SqlCommand cmd = new SqlCommand("ReadByEmployeeId", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@employeeId", employeeId);

                //Opens the connection to the database
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Employees currentEmployee = new Employees();
                        currentEmployee.EmployeeId = (int)dr["EmployeeId"];
                        currentEmployee.LastName = dr["LastName"].ToString();
                        currentEmployee.FirstName = dr["FirstName"].ToString();
                        currentEmployee.Email = dr["Email"].ToString();
                        currentEmployee.Role = dr["Role"].ToString() == "Admin";

                        //Load the object into the obj
                        Employee = currentEmployee;
                    }
                }
                cn.Close();
            }
            return Employee;
        }

        public void UpdateEmployee(Employees employee)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UpdateEmployee", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@employeeId", employee.EmployeeId);
                cmd.Parameters.AddWithValue("@lastName", employee.LastName);
                cmd.Parameters.AddWithValue("@firstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@email", employee.Email);
                cmd.Parameters.AddWithValue("@role", employee.Role);

                cn.Open();

                cmd.ExecuteNonQuery();

                cn.Close();
            }
        }
    }
}
