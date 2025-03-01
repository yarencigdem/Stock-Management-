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
    public partial class BarcodeDetailsForm : Form
    {
        private string _barcode;
        private object dataGridViewDetails;

        public BarcodeDetailsForm(string barcode)
        {
            InitializeComponent();
            _barcode = barcode;
            this.Load += new EventHandler(BarcodeDetailsForm_Load);
        }

        private void BarcodeDetailsForm_Load(object sender, EventArgs e)
        {
            LoadProductDetails();
        }

        private void LoadProductDetails()
        {
            using (SqlConnection con = new SqlConnection("Data Source=BRCSBT\\SQLEXPRESS02;Initial Catalog=deneme;Integrated Security=True"))
            {
                try
                {
                    con.Open();

                    // Aynı barkod numarasına sahip ama farklı lot numaralarına sahip ürünleri seç
                    string query = @"
                    SELECT * 
                    FROM [dbo].[stock]
                    WHERE ProductCode = @ProductCode
                    ORDER BY CAST(SKT AS DATE) ASC";

                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    sda.SelectCommand.Parameters.AddWithValue("@ProductCode", _barcode);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    dataGridView1.Rows.Clear(); // Mevcut verileri temizle

                    foreach (DataRow item in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add(); // Yeni satır ekle
                        dataGridView1.Rows[n].Cells[0].Value = item["ProductCode"].ToString();
                        dataGridView1.Rows[n].Cells[1].Value = item["ProductName"].ToString();
                        dataGridView1.Rows[n].Cells[2].Value = item["ProductLotNumber"].ToString();
                        dataGridView1.Rows[n].Cells[3].Value = item["ReferanceNo"].ToString();
                        dataGridView1.Rows[n].Cells[4].Value = item["SKT"].ToString();
                        dataGridView1.Rows[n].Cells[5].Value = Convert.ToDateTime(item["TransDate"]).ToString("yyyy-MM-dd");
                        dataGridView1.Rows[n].Cells[6].Value = item["Quantity"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
    }

}
