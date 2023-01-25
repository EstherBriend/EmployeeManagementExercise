using Lab1_ASPMetConnectedMode.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Lab1_ASPMetConnectedMode.VALIDATION;
using System.Drawing;
using Lab1_ASPMetConnectedMode.DAL;

namespace Lab1_ASPMetConnectedMode.GUI
{
    public partial class WebFormEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnListAll_Click(object sender, EventArgs e)
        {
            showAllEmployees();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();

            string tempInput = "";
            //Validate ID
            tempInput = txtEmployeeId.Text.Trim();
            if (!Validator.IsValidId(tempInput))
            {
                MessageBox.Show("Employee ID must be 4-digits.", "Invalid ID");
                txtEmployeeId.Text = "";
                txtEmployeeId.Focus();
                return;
            }

            employee.EmployeeId = Convert.ToInt32(tempInput);

            // Check duplicate ID
            if (employee.IsDuplicateEmployeeID(employee.EmployeeId)){
                MessageBox.Show("This ID already exist.", "Duplicate ID");
                txtEmployeeId.Text = "";
                txtEmployeeId.Focus();
                return;
            }

            // Validate First Name
            tempInput = txtFirstName.Text.Trim();
            if (!Validator.IsValidName(tempInput))
            {
                MessageBox.Show("First Name must contains only letter or space to separate name components.", "Invalid First Name");
                txtFirstName.Text = "";
                txtFirstName.Focus();
                return;
            }

            employee.FirstName = tempInput;

            // Validate Last Name
            tempInput = txtLastName.Text.Trim();
            if (!Validator.IsValidName(tempInput))
            {
                MessageBox.Show("Last Name must contains only letter or space to separate name components.", "Invalid Last Name");
                txtLastName.Text = "";
                txtLastName.Focus();
                return;
            }

            employee.LastName = tempInput;

            // Validate Job Title
            tempInput = txtJobTitle.Text.Trim();
            if (String.IsNullOrWhiteSpace(tempInput)){
                MessageBox.Show("Job Title cannot be empty", "Invalid Job Title");
                txtJobTitle.Focus();
                return;
            }
            employee.JobTitle = tempInput;

            // Save new employee
            employee.SaveEmployee(employee);
            MessageBox.Show("The new employee has been saved");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // Create list for showing the result in the grid view
            List<Employee> listFoundEmployee = new List<Employee>();

            //Create an employee to access the method of the class Employee
            Employee emp = new Employee();

            // Retrieve user input
            string tempInput = "";
            tempInput = txtSearch.Text.Trim();

            // Search by ID
            if (DropDownSearchBy.Text == "ID")
            {
                // Validate ID input
                if (!Validator.IsValidId(tempInput))
                {
                    MessageBox.Show("Employee ID must be 4-digits.", "Invalid ID");
                    txtSearch.Text = "";
                    txtSearch.Focus();
                    return;
                }

                int searchedID = Convert.ToInt32(tempInput);

                // Search employee by ID
                emp = emp.SearchEmployeeByID(searchedID);
                if (emp != null) // Employee found
                {
                    listFoundEmployee.Add(emp);
                }
                else // Employee not found
                {
                    MessageBox.Show("No employee with matching ID", "No result found");
                    txtSearch.Text = "";
                    txtSearch.Focus();
                }
            }

            // Search by First Name
            if(DropDownSearchBy.SelectedValue == "First Name")
            {

                //Validate Name input
                if (!Validator.IsValidName(tempInput))
                {
                    MessageBox.Show("First Name must contains only letter or space to separate name components.", "Invalid First Name");
                    txtSearch.Text = "";
                    txtSearch.Focus();
                    return;
                }

                string searchedFirstName = tempInput;

                // Search employee by First Name
                listFoundEmployee = emp.SearchEmployeeWithString(searchedFirstName, "FirstName");
            }

            // Search by Last Name
            if(DropDownSearchBy.SelectedValue == "Last Name")
            {
                //Validate Name input
                if (!Validator.IsValidName(tempInput))
                {
                    MessageBox.Show("Last Name must contains only letter or space to separate name components.", "Invalid Last Name");
                    txtSearch.Text = "";
                    txtSearch.Focus();
                    return;
                }
                string searchedLastName = tempInput;

                // Search employee by Last Name
                listFoundEmployee = emp.SearchEmployeeWithString(searchedLastName, "LastName");
            }

            // Search by Job Title
            if(DropDownSearchBy.SelectedValue == "Job Title")
            {
                string searchedJobTitle = tempInput;
                // Search employee by Job Title
                listFoundEmployee = emp.SearchEmployeeWithString(searchedJobTitle, "JobTitle");
            }


            // Show result
            if (listFoundEmployee != null) // Employee(s) found
            {
                GridViewEmployees.DataSource = listFoundEmployee;
                GridViewEmployees.DataBind();
            }
            else // Employee not found
            {
                MessageBox.Show($"No employee with matching {DropDownSearchBy.Text}", "No result found");
                txtSearch.Text = "";
                txtSearch.Focus();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // Create an employee to access employee method
            Employee emp = new Employee();
            
            // Validate EmployeeID input
            string tempInput = txtEmployeeId.Text.Trim();

            if (!Validator.IsValidId(tempInput))
            {
                MessageBox.Show("Employee ID cannot be null and must be 4-digits.", "Invalid ID");
                txtSearch.Text = "";
                txtSearch.Focus();
                return;
            }

            int searchedID = Convert.ToInt32(tempInput);

            // Check if EmployeeID exist

            if (emp.IsDuplicateEmployeeID(emp.EmployeeId))
            {
                MessageBox.Show("This ID does not exist.", "ID not found");
                txtEmployeeId.Text = "";
                txtEmployeeId.Focus();
                return;
            }

            // Delete the employee
            emp.Delete(searchedID);
            MessageBox.Show("Employee deleted", "Successful deletion");
            showAllEmployees();

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            // Create an employee to access employee method
            Employee emp = new Employee();

            // Validate EmployeeID input
            string tempInput = txtEmployeeId.Text.Trim();

            if (!Validator.IsValidId(tempInput))
            {
                MessageBox.Show("Employee ID cannot be null and must be 4-digits.", "Invalid ID");
                txtSearch.Text = "";
                txtSearch.Focus();
                return;
            }

            int searchedID = Convert.ToInt32(tempInput);

            // Check if EmployeeID exist

            if (emp.IsDuplicateEmployeeID(emp.EmployeeId))
            {
                MessageBox.Show("This ID does not exist.", "ID not found");
                txtEmployeeId.Text = "";
                txtEmployeeId.Focus();
                return;
            }

            //Update Employee

        }

        protected void showAllEmployees()
        {
            Employee employee = new Employee();
            GridViewEmployees.DataSource = employee.GetAllEmployees();
            GridViewEmployees.DataBind();
        }
    }
}