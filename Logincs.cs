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


namespace WinFormsApp4
{
    public partial class Logincs : Form
    {
        public Logincs()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=BRCSBT\\SQLEXPRESS02;Initial Catalog=deneme;Integrated Security=True"))
            {
                // Parametrik sorgu
                string query = "SELECT * FROM [deneme].[dbo].[login] WHERE UserName = @UserName AND Password = @Password";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Parametreleri ekliyoruz
                    cmd.Parameters.AddWithValue("@UserName", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Password", textBox2.Text);

                    // Bağlantıyı açıyoruz
                    con.Open();

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    // Kullanıcı bulunursa (dt.Rows.Count > 0), giriş başarılı sayılır
                    if (dt.Rows.Count > 0)
                    {

                        StockMain main = new StockMain();
                        main.Show();
                    }
                    else
                    {
                        // Hatalı giriş
                        MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        button1_Click(sender, e);
                    }
                }
            }

        }

        private void NewMethod()
        {
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
