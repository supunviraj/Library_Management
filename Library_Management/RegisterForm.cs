using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            Main MForm = new Main();
            MForm.Show();
            this.Hide();
        }

        private void btnSignIN_Click(object sender, EventArgs e)
        {
            LoginForm LForm = new LoginForm();
            LForm.Show();
            this.Hide();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSignUP_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Documents\\NEW.mdf;Integrated Security=True;Connect Timeout=30";
            
            SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();

            String username = txtemail.Text;
            String email = txtusername.Text;
            String password = txtpassword.Text;
          
           

            String Query = "INSERT INTO seen (username, email, password) VALUES ('" + username + "','" + email + "','"+ password + "')";

            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Data Has Been Uploaded");
        }
    }


    
}
