using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormAppEntityFramework.VALIDATION;

namespace WinFormAppEntityFramework.GUI
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            if(Validation.IsValidPhone(txtEmail.Text))
            {
                MessageBox.Show("good email");
            }
            else
            {
                MessageBox.Show("bad email");
            }

        }
    }
}
