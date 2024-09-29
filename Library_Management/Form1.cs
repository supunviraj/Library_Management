using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Library_Management
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        /* private int tickCount = 0; // Counter to track timer ticks

         private void timer1_Tick(object sender, EventArgs e)
         {
             tickCount += timer1.Interval; // Increment tickCount based on timer interval

             // Blink Panel2 every 2 seconds (2000 milliseconds)
             if (tickCount % 200 == 0)
             {
                 Panel2.Visible = !Panel2.Visible; // Toggle visibility to blink
             }

             // Add and blink another panel every 4 seconds (4000 milliseconds)
             if (tickCount % 400 == 0)
             {
                 Main lForm = new Main(); // Load the main form
                 lForm.Show();
                 Panel3.Visible = !Panel3.Visible;
                 lForm.Hide();
             }

             // Check if the width of Panel2 has reached the maximum limit (stop animation)
             if (Panel2.Width >= 575)
             {
                 timer1.Stop(); // Stop the timer after completing the animation

                 Main lForm = new Main(); // Load the main form
                 lForm.Show(); // Show the main form
                 this.Hide(); // Hide the current form
             }
         }
        */

        /*
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Increase the panel width by 6 units every tick
            Panel2.Width += 6;

            // Blink effect: toggle the visibility every 2 seconds
            Panel2.Visible = !Panel2.Visible;

            // Check if the panel has reached or exceeded the width limit
            if (Panel2.Width >= 575)
            {
                // Stop the timer
                timer1.Stop();

                // Open the main form and hide the current one
                Main lForm = new Main();
                lForm.Show();
                this.Hide();
            }
        }  */

        private void timer1_Tick(object sender, EventArgs e)
        {
            Panel2.Width += 6;

            if (Panel2.Width >= 800)
            {
                timer1.Stop();

               /* Main lForm = new Main();
                lForm.Show();
                this.Hide();
               */

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Documents\\NEW.mdf;Integrated Security=True;Connect Timeout=30";

            SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();

            String Fristname = txtFristName.Text;
            String SecondName = txtSecondName.Text;

            String Query = "INSERT INTO Names (FristName, SecondName) VALUES ('" + Fristname + "','" + SecondName + "')";

            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Data Has Been Uploaded");

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Documents\\NEW.mdf;Integrated Security=True;Connect Timeout=30";

            SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();

            string Quary = "SELECT * FROM Names";
            SqlCommand cmd = new SqlCommand(Quary, con);

            var reader = cmd.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);

            Panel3.DataSource = table;

            con.Close();




        }

        private void btnShow2_Click(object sender, EventArgs e)
        {
            {
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Documents\\NEW.mdf;Integrated Security=True;Connect Timeout=30";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    try
                    {
                        // Open the database connection
                        con.Open();

                        // Define the SQL query
                        string query = "SELECT * FROM Names";

                        // Create a SqlCommand to execute the query
                        SqlCommand cmd = new SqlCommand(query, con);

                        // Execute the query and get the SqlDataReader object
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Read the data row by row
                            while (reader.Read())
                            {
                                // Add data to the DataGridView
                                dataGridView2.Rows.Add(reader["ID"], reader["FristName"] + " " + reader["SecondName"]);
                            }
                        }

                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
        }

        

    }
}

    

