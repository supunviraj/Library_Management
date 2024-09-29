using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Library_Management
{
    public partial class LoginForm : Form
    {
        
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\NEW.mdf;Integrated Security=True;Connect Timeout=30");

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            Main MForm = new Main();
            MForm.Show();
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

        private void btnSignIN_Click(object sender, EventArgs e)
        {

            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    try

                    {
                        connect.Open();

                        String selectData
                            = "SELECT * FROM seen WHERE username = @username AND password = @password";
                        using (SqlCommand cmd = new SqlCommand(selectData, connect))
                        {
                            cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                            cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count >= 1)

                            {

                                MessageBox.Show("Login Successfully!", "Information Message"
                                    , MessageBoxButtons.OK, MessageBoxIcon.Information);

                                UserForm UForm = new UserForm();
                                UForm.Show();
                                this.Hide();


                            }

                            ///////////////////

                            else if (table.Rows.Count < 1)

                            {

                                String sselectData
                                = "SELECT * FROM admin WHERE username = @username AND password = @password";
                                using (SqlCommand ccmd = new SqlCommand(sselectData, connect))
                                {
                                    ccmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                                    ccmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());

                                    SqlDataAdapter aadapter = new SqlDataAdapter(ccmd);
                                    DataTable ttable = new DataTable();
                                    aadapter.Fill(ttable);

                                    if (ttable.Rows.Count >= 1)
                                    {

                                        string username = ttable.Rows[0]["username"].ToString();
                                        string password = ttable.Rows[0]["password"].ToString();

                                        MessageBox.Show("Login Successfully!", "Information Message"
                                        , MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        Admin mForm = new Admin(username, password);
                                        mForm.Show();
                                        this.Hide();
                                    }


                                }












                             /*   string username = table.Rows[0]["username"].ToString();
                                string password = table.Rows[0]["password"].ToString();

                                int csss = Convert.ToInt32(table.Rows[0]["admin"]);

                                if (csss >= 2)
                                {

                                    MessageBox.Show("Login Successfully!", "Information Message"
                                    , MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    Admin mForm = new Admin(username, password);
                                    mForm.Show();
                                    this.Hide();

                                }
                                else if (csss <= 1)
                                {

                                    

                                } */

                                

                            }











                            else
                            {
                                MessageBox.Show("Incorrect Username/Password", "Error Message"
                                    , MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error connecting Database: " + ex, "Error Message"
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            
            }
        }
    }
}
