using Lab1_ASPMetConnectedMode.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Lab1_ASPMetConnectedMode.BLL
{
    public class Employee
    {
        //Private class variable
        private int employeeId;
        private string firstName;
        private string lastName;
        private string jobTitle;

        //properties
        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string JobTitle { get => jobTitle; set => jobTitle = value; }

        //custom method

        public void SaveEmployee(Employee emp)
        {
            EmployeeDB.SaveRecord(emp);
        }

        public List<Employee> GetAllEmployees()
        {
            return EmployeeDB.GetAllEmployees();
        }

        public Employee SearchEmployeeByID(int id)
        {
            return EmployeeDB.SearchRecordByID(id);
        }

        public List<Employee> SearchEmployeeWithString(string searchedString, string columName)
        {
            return EmployeeDB.SearchRecordByString(searchedString, columName);

        }

        public bool IsDuplicateEmployeeID(int employeeId)
        {
            return EmployeeDB.IsDuplicateId(employeeId);
        }

        public void Delete(int employeeID)
        {
            EmployeeDB.DeleteEmployee(employeeID);
        }
    }
}