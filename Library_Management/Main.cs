using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        ///////////////////////////////////
        
        
        ///////////////////////////

        private void btnSignIN_Click(object sender, EventArgs e)
        {
            LoginForm LForm = new LoginForm();
            LForm.Show();
            this.Hide();
        }

        private void btnSignUP_Click(object sender, EventArgs e)
        {
            RegisterForm RForm = new RegisterForm();
            RForm.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            
                Application.Exit();
            
        }
    }
}

