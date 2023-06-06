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

namespace final_project.AllUserControl
{
    public partial class UC_Employee : UserControl
    {
        public UC_Employee()
        {
            InitializeComponent();
        }

        private void UC_Employee_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtEmployee.Text!=""&&txtName.Text!=""&&txtGender.Text!=""&&txtAddress.Text!=""&&txtContact.Text!=""&&txtEmail.Text!="")
            {

                int ID = int.Parse(txtEmployee.Text);
                string name = txtName.Text;
                string gender = txtGender.Text;
                string address = txtAddress.Text;
                string contact = txtContact.Text;
                string email = txtEmail.Text;



                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\c#\final project\Mobile shop.mdf;Integrated Security=True;Connect Timeout=30");
                string qry = "INSERT INTO employee VALUES(" + ID + ",'" + name + "','" + gender+ "','" + address + "','" + contact + "','" + email + "')";
                SqlCommand cmd = new SqlCommand(qry, con);


                try
                {

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Inserted Successfully");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error Occured" + ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Fill all the Fields");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\c#\final project\Mobile shop.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "SELECT * FROM employee";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(qry, constring);
                DataSet ds = new DataSet();
                da.Fill(ds, "employee");
                DGV3.DataSource = ds.Tables["employee"];
            }
            catch
            {
                MessageBox.Show("Error occrured");
            }
        }
    }
    }

