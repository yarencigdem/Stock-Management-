using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;

namespace WinFormsApp4
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
            this.Load += new EventHandler(Products_Load); // Form yüklendiğinde çalışacak olay
            LoadAndSaveExcelData();
            dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(dataGridView1_CellDoubleClick);
        }

        private void Products_Load(object sender, EventArgs e)
        {
            LoadData(); // Verileri DataGridView'e yüklemek için LoadData metodunu çağırıyoruz.
        }

        // Yeni LoadData metodu
        private void LoadData()
        {
            using (SqlConnection con = new SqlConnection("Data Source=BRCSBT\\SQLEXPRESS02;Initial Catalog=deneme;Integrated Security=True"))
            {
                try
                {
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM [dbo].[Products]", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    dataGridView1.Rows.Clear(); // Mevcut verileri temizle

                    foreach (DataRow item in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add(); // Yeni satır ekle
                        dataGridView1.Rows[n].Cells[0].Value = item["ProductCode"].ToString();
                        dataGridView1.Rows[n].Cells[1].Value = item["ProductName"].ToString();
                        dataGridView1.Rows[n].Cells[2].Value = item["ReferenceNo"].ToString();
                        dataGridView1.Rows[n].Cells[3].Value = item["Count"].ToString();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private DataTable GetExcelData(string filePath)
        {
            var dt = new DataTable();

            // Excel dosyasını aç
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook;
                if (Path.GetExtension(filePath).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    workbook = new XSSFWorkbook(fileStream); // XLSX dosyası
                }
                else
                {
                    workbook = new HSSFWorkbook(fileStream); // XLS dosyası
                }

                // İlk sayfayı seç
                ISheet sheet = workbook.GetSheetAt(0);

                // Sütun başlıklarını ayarla
                dt.Columns.Add("ProductCode");
                dt.Columns.Add("ProductName");
                dt.Columns.Add("ReferenceNo");
                dt.Columns.Add("Count");

                bool firstRow = true;

                for (int rowIndex = 0; rowIndex <= sheet.LastRowNum; rowIndex++)
                {
                    IRow row = sheet.GetRow(rowIndex);
                    if (row == null) continue;

                    if (firstRow)
                    {
                        firstRow = false; // Başlık satırını atla
                        continue;
                    }

                    DataRow dataRow = dt.NewRow();
                    dataRow["ProductCode"] = row.GetCell(1)?.ToString();
                    dataRow["ReferenceNo"] = row.GetCell(3)?.ToString();
                    dataRow["ProductName"] = row.GetCell(4)?.ToString();
                    dataRow["Count"] = row.GetCell(5)?.ToString();
                    dt.Rows.Add(dataRow);
                }
            }

            return dt;
        }

        private bool IsProductExists(string productCode, SqlConnection connection)
        {
            string query = "SELECT COUNT(*) FROM Products WHERE ProductCode = @ProductCode";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ProductCode", productCode);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }

        private void SaveDataToSql(DataTable dataTable)
        {
            string connectionString = "Data Source=BRCSBT\\SQLEXPRESS02;Initial Catalog=deneme;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (DataRow row in dataTable.Rows)
                {
                    string productCode = row["ProductCode"].ToString();

                    if (IsProductExists(productCode, connection))
                    {
                        continue;
                    }

                    string query = "INSERT INTO Products (ProductCode, ProductName, ReferenceNo, Count) VALUES (@ProductCode, @ProductName, @ReferenceNo, @Count)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductCode", row["ProductCode"]);
                        command.Parameters.AddWithValue("@ProductName", row["ProductName"]);
                        command.Parameters.AddWithValue("@ReferenceNo", row["ReferenceNo"]);
                        command.Parameters.AddWithValue("@Count", row["Count"]);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private void LoadAndSaveExcelData()
        {
            string filePath = @"C:\Users\Burcu Sebit\OneDrive\Masaüstü\Yeni Microsoft Excel Worksheet (5).xlsx";
            DataTable dt = GetExcelData(filePath);
            SaveDataToSql(dt);
        
        }

        private void LoadDataToDataGridView()
        {
            string connectionString = "Data Source=BRCSBT\\SQLEXPRESS02;Initial Catalog=deneme;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Products";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
        // TextBox'lardaki verileri SQL veritabanına kaydeden metot
        private void SaveTextBoxDataToSql()
        {
            string connectionString = "Data Source=BRCSBT\\SQLEXPRESS02;Initial Catalog=deneme;Integrated Security=True"; // Bağlantı dizesini girin
            string productCode = textBox1.Text;  // Barkod numarası
            string productName = textBox2.Text;  // Ürün ismi
            string referenceNo = textBox3.Text;  // Referans numarası
            string count = textBox4.Text;        // Ürün miktarı

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Aynı barkod numarası var mı kontrol et
                if (IsProductExists(productCode, connection))
                {
                    MessageBox.Show("Bu barkod numarasına sahip bir ürün zaten mevcut. Lütfen farklı bir barkod numarası girin.");
                    return; // Aynı barkod varsa işlem yapılmadan çık
                }

                // SQL'e ekleme sorgusu
                string query = "INSERT INTO Products (ProductCode, ProductName, ReferenceNo, Count) VALUES (@ProductCode, @ProductName, @ReferenceNo, @Count)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductCode", productCode);
                    command.Parameters.AddWithValue("@ProductName", productName);
                    command.Parameters.AddWithValue("@ReferenceNo", referenceNo);
                    command.Parameters.AddWithValue("@Count", count);

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Ürün başarıyla kaydedildi.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveTextBoxDataToSql();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString(); // ProductCode
                textBox2.Text = row.Cells[1].Value.ToString(); // ProductName
                textBox3.Text = row.Cells[2].Value.ToString(); // ReferenceNo
                textBox4.Text = row.Cells[3].Value.ToString(); // Count
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=BRCSBT\\SQLEXPRESS02;Initial Catalog=deneme;Integrated Security=True";
            string productCode = textBox1.Text;  // Barkod numarası
            string productName = textBox2.Text;  // Ürün ismi
            string referenceNo = textBox3.Text;  // Referans numarası
            string count = textBox4.Text;        // Ürün miktarı

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL güncelleme sorgusu
                string query = "UPDATE Products SET ProductName = @ProductName, ReferenceNo = @ReferenceNo, Count = @Count WHERE ProductCode = @ProductCode";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductCode", productCode);
                    command.Parameters.AddWithValue("@ProductName", productName);
                    command.Parameters.AddWithValue("@ReferenceNo", referenceNo);
                    command.Parameters.AddWithValue("@Count", count);

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Ürün başarıyla güncellendi.");
                LoadData(); // Güncellemelerden sonra DataGridView'i yenile
            }
        }

        private void DeleteProductFromDatabase(string productCode)
        {
            string connectionString = "Data Source=BRCSBT\\SQLEXPRESS02;Initial Catalog=deneme;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Products WHERE ProductCode = @ProductCode";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductCode", productCode);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Seçilen satırın olup olmadığını kontrol edin
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçilen satırı al
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string productCode = selectedRow.Cells[0].Value.ToString(); // ProductCode

                // Kullanıcıdan onay al
                var result = MessageBox.Show($"Bu ürünü silmek istediğinize emin misiniz? (Product Code: {productCode})", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteProductFromDatabase(productCode);
                    // Silinen ürünün DataGridView'dan kaldırılması
                    dataGridView1.Rows.Remove(selectedRow);
                }
            }
            else
            {
                MessageBox.Show("Silinecek bir ürün seçin.");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SaveTextBoxDataToSql();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Seçilen satırın olup olmadığını kontrol edin
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçilen satırı al
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string productCode = selectedRow.Cells[0].Value.ToString(); // ProductCode

                // Kullanıcıdan onay al
                var result = MessageBox.Show($"Bu ürünü silmek istediğinize emin misiniz? (Product Code: {productCode})", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteProductFromDatabase(productCode);
                    // Silinen ürünün DataGridView'dan kaldırılması
                    dataGridView1.Rows.Remove(selectedRow);
                }
            }
            else
            {
                MessageBox.Show("Silinecek bir ürün seçin.");
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=BRCSBT\\SQLEXPRESS02;Initial Catalog=deneme;Integrated Security=True";
            string productCode = textBox1.Text;  // Barkod numarası
            string productName = textBox2.Text;  // Ürün ismi
            string referenceNo = textBox3.Text;  // Referans numarası
            string count = textBox4.Text;        // Ürün miktarı

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL güncelleme sorgusu
                string query = "UPDATE Products SET ProductName = @ProductName, ReferenceNo = @ReferenceNo, Count = @Count WHERE ProductCode = @ProductCode";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductCode", productCode);
                    command.Parameters.AddWithValue("@ProductName", productName);
                    command.Parameters.AddWithValue("@ReferenceNo", referenceNo);
                    command.Parameters.AddWithValue("@Count", count);

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Ürün başarıyla güncellendi.");
                LoadData(); // Güncellemelerden sonra DataGridView'i yenile
            }
        }
    }
}

