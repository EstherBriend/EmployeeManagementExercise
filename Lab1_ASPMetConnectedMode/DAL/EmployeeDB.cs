using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Lab1_ASPMetConnectedMode.BLL;

namespace Lab1_ASPMetConnectedMode.DAL
{
    public class EmployeeDB
    {
        public static void SaveRecord(Employee emp)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = connDB;
            cmdInsert.CommandText = "INSERT INTO Employees " +
                "VALUES (@EmployeeId, @FirstName, @LastName, @JobTitle)";
            cmdInsert.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
            cmdInsert.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmdInsert.Parameters.AddWithValue("@LastName", emp.LastName);
            cmdInsert.Parameters.AddWithValue("@JobTitle", emp.JobTitle);
            cmdInsert.ExecuteNonQuery();
            connDB.Close();
        }

        public static List<Employee> GetAllEmployees()
        {
            List<Employee> listEmployees = new List<Employee>();
            using (SqlConnection connDB = UtilityDB.ConnectDB())
            {
                SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Employees", connDB);
                SqlDataReader reader = cmdSelectAll.ExecuteReader();
                Employee employee;
                while (reader.Read())
                {
                    employee = new Employee();
                    employee.EmployeeId = Convert.ToInt32(reader["EmployeeID"]);
                    employee.FirstName = reader["FirstName"].ToString();
                    employee.LastName = reader["LastName"].ToString();
                    employee.JobTitle = reader["JobTitle"].ToString();
                    listEmployees.Add(employee);
                }
                return listEmployees;
            }
        }

        public static Employee SearchRecordByID(int id)
        {
            Employee emp = new Employee();
            using(SqlConnection conn = UtilityDB.ConnectDB())
            {
                SqlCommand cmdSearchByID = new SqlCommand();
                cmdSearchByID.Connection = conn;
                cmdSearchByID.CommandText = "SELECT * FROM Employees WHERE EmployeeID = @id";
                cmdSearchByID.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmdSearchByID.ExecuteReader(); ;
                if (reader.Read())
                {
                    emp.EmployeeId = Convert.ToInt32(reader["EmployeeID"]);
                    emp.FirstName = reader["FirstName"].ToString();
                    emp.LastName = reader["LastName"].ToString();
                    emp.JobTitle = reader["JobTitle"].ToString();
                }
                else
                {
                    emp = null;
                }
                return emp;
            }

        }

        public static List<Employee> SearchRecordByString(string searchedString, string columnName)
        {
            List <Employee> listFoundEmployee = new List<Employee>();

            using(SqlConnection conn = UtilityDB.ConnectDB())
            {
                SqlCommand cmdSearch = new SqlCommand();
                cmdSearch.Connection = conn;
                cmdSearch.CommandText = $"SELECT * FROM Employees WHERE {columnName} LIKE @searchedString";
                cmdSearch.Parameters.AddWithValue("@searchedString", $"%{searchedString}%");
                SqlDataReader reader = cmdSearch.ExecuteReader();
                Employee emp;
                while (reader.Read())
                {
                    emp = new Employee();
                    emp.EmployeeId = Convert.ToInt32(reader["EmployeeID"]);
                    emp.FirstName = reader["FirstName"].ToString();
                    emp.LastName = reader["LastName"].ToString();
                    emp.JobTitle = reader["JobTitle"].ToString();
                    listFoundEmployee.Add(emp);
                }
            }
            return listFoundEmployee;
        }

        public static bool IsDuplicateId(int id)
        {
            if(SearchRecordByID(id) == null)
            {
                return false;
            }
            return true;
        }

        public static void DeleteEmployee(int id)
        {
            using(SqlConnection con = UtilityDB.ConnectDB())
            {
                SqlCommand cmdDelete = new SqlCommand();
                cmdDelete.Connection = con;
                cmdDelete.CommandText = "DELETE FROM Employees WHERE EmployeeID = @id";
                cmdDelete.Parameters.AddWithValue("@id", id);
                cmdDelete.ExecuteNonQuery();
            }
        }

        public static void UpdateEmployee(Employee emp)
        {
            //Build sql command depending of the input data
            String sqlCommandText = "UPDATE Employees SET ";

            // Flag to know if it is the first column added to the command text
            bool first = true;

            //Check input for First Name
            if (!string.IsNullOrEmpty(emp.FirstName))
            {
                sqlCommandText += $"FirstName='{emp.FirstName}'";
                first = false;
            }
            //Check input for Last Name
            if (!string.IsNullOrEmpty(emp.LastName))
            {
                if (!first)
                {
                    sqlCommandText += ", ";
                }
                sqlCommandText += $"LastName='{emp.LastName}'";
                first = false;
            }
            //Chek input for Job Title
            if (!String.IsNullOrEmpty(emp.JobTitle))
            {
                if (!first)
                {
                    sqlCommandText += ", ";
                }
                sqlCommandText += $"JobTitle='{emp.JobTitle}'";
                first = false;
            }

            sqlCommandText += $" WHERE EmployeeID={emp.EmployeeId};";

            //Execute the update command
            using (SqlConnection con = UtilityDB.ConnectDB())
            {

                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = con;
                cmdUpdate.CommandText = sqlCommandText;
                cmdUpdate.ExecuteNonQuery();

            }
        }
    }
}