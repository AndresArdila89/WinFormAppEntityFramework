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

namespace WinFormAppEntityFramework
{

    public partial class FormEmployeeProject : Form
    {
        EmployeeProjectDBEntities dBEntities = new EmployeeProjectDBEntities();

        public FormEmployeeProject()
        {
            InitializeComponent();
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

            emp.EmployeeId = Convert.ToInt32(TextBoxEmpId.Text);
            emp.FirstName = textBoxFirstName.Text;
            emp.LastName = textBoxLastName.Text;
            emp.PhoneNumber = textBoxPhone.Text;
            emp.Email = textBoxEmail.Text;
            // Stores the information on the model 
            dBEntities.Employees.Add(emp);
            // Stores the information in the database
            dBEntities.SaveChanges();

            MessageBox.Show("Employee has been saved SUCCESSFULLY in the database","Confirmation");
        }
    }
}
