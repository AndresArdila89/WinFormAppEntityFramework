using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormAppEntityFramework.Models;
using WinFormAppEntityFramework.VALIDATION;

namespace WinFormAppEntityFramework
{

    public partial class FormEmployeeProject : Form
    {
        EmployeeProjectDBEntities dBEntities = new EmployeeProjectDBEntities();

        public FormEmployeeProject()
        {
            InitializeComponent();
            comboBoxSearchBy.SelectedIndex = 0;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonList_Click(object sender, EventArgs e)
        {
            // LINQ code
            var listEmp = (from emp in dBEntities.Employees
                           select emp).ToList<Employee>();
            dataGridView1.DataSource = listEmp;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();

            if (Validation.IsValidId(TextBoxEmpId.Text))
            {
                int id = Convert.ToInt32(TextBoxEmpId.Text);

                var idVer = (from empl in dBEntities.Employees
                             where empl.EmployeeId == id
                             select empl).ToList<Employee>();
                if (idVer.Count > 0)
                {
                    MessageBox.Show("Id already exist", "warning");
                    TextBoxEmpId.Clear();
                    TextBoxEmpId.Focus();
                }
                else if (!Validation.IsValidName(textBoxFirstName.Text))
                {
                    MessageBox.Show("Invalid First Name", "warning");
                    textBoxFirstName.Clear();
                    textBoxFirstName.Focus();
                }
                else if (!Validation.IsValidName(textBoxLastName.Text))
                {
                    MessageBox.Show("Invalid Last Name", "warning");
                    textBoxLastName.Clear();
                    textBoxLastName.Focus();
                }
                else if (!Validation.IsValidPhone(textBoxPhone.Text))
                {
                    MessageBox.Show($"Invalid Phone Number {textBoxPhone.Text}", "warning");
                    textBoxPhone.Clear();
                    textBoxPhone.Focus();

                }
                else if (!Validation.IsValidEmail(textBoxEmail.Text))
                {
                    MessageBox.Show("Invalid Email address");
                    textBoxEmail.Clear();
                    textBoxEmail.Focus();
                }
                else
                {
                    emp.EmployeeId = Convert.ToInt32(TextBoxEmpId.Text);
                    emp.FirstName = textBoxFirstName.Text;
                    emp.LastName = textBoxLastName.Text;
                    emp.PhoneNumber = textBoxPhone.Text;
                    emp.Email = textBoxEmail.Text;
                    // Stores the information on the model 
                    dBEntities.Employees.Add(emp);
                    // Stores the information in the database
                    dBEntities.SaveChanges();

                    MessageBox.Show("Employee has been saved SUCCESSFULLY in the database", "Confirmation");

                }
            }
            else
            {
                MessageBox.Show("Invalid ID", "warning");
                TextBoxEmpId.Clear();
                TextBoxEmpId.Focus();
            }


        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            String searchText = textBoxSearch.Text;

            switch (comboBoxSearchBy.SelectedIndex)
            {
                case 0:
                    int id = Convert.ToInt32(textBoxSearch.Text);
                    dataGridView1.DataSource = (from emp in dBEntities.Employees
                                                where emp.EmployeeId == id
                                                select emp).ToList<Employee>();
                    break;
                case 1:
                    dataGridView1.DataSource = (from emp in dBEntities.Employees
                                                where emp.FirstName == textBoxSearch.Text
                                                select emp).ToList<Employee>();
                    break;

                case 2:
                    dataGridView1.DataSource = (from emp in dBEntities.Employees
                                                where emp.LastName == textBoxSearch.Text
                                                select emp).ToList<Employee>();
                    break;
                case 3:
                    dataGridView1.DataSource = (from emp in dBEntities.Employees
                                                where emp.Email == textBoxSearch.Text
                                                select emp).ToList<Employee>();
                    break;
                                                       
            }            
        }
    }
}
