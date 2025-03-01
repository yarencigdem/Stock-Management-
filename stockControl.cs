using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp4
{
    public partial class stockControl : Form
    {
        public stockControl()
        {
            InitializeComponent();

            this.Load += new EventHandler(stockControl_Load); // Form yüklendiğinde LoadData'yı çağır
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick; // Double-click olayını ekle
                                                                            //  this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBox5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox5_KeyDown);
        }

        private void LoadData()
        {
            using (SqlConnection con = new SqlConnection("Data Source=BRCSBT\\SQLEXPRESS02;Initial Catalog=deneme;Integrated Security=True"))
            {
                try
                {
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM [dbo].[stock] ORDER BY ProductName", con);
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
        private void stockControl_Load(object sender, EventArgs e)
        {
            LoadData();
            textBox1.Focus();
            // LoadDataToListView();
        }

        private void ProcessBarcodeData(string data)
        {
            try
            {
                // Boşlukları kaldır
                data = data.Replace(" ", "");

                // Barkod (01)
                int startIndex01 = data.IndexOf("(01)") + 4;
                int endIndex17 = data.IndexOf("(17)");
                if (startIndex01 >= 4 && endIndex17 > startIndex01)
                {
                    // textBox1 boşsa veya sadece (01) barkod kısmını içeriyorsa yaz
                    if (string.IsNullOrEmpty(textBox1.Text) || textBox1.Text.Length != 14)
                    {
                        string barcode = data.Substring(startIndex01, endIndex17 - startIndex01);
                        textBox2.Text = barcode;   // Barkod numarası sadece bir kez yazılır
                    }

                    // SKT (17)
                    int startIndex17 = endIndex17 + 4;
                    int endIndex10 = data.IndexOf("(10)");
                    if (startIndex17 >= 4 && endIndex10 > startIndex17)
                    {
                        string stk = data.Substring(startIndex17, endIndex10 - startIndex17);
                        textBox7.Text = stk;       // SKT (son kullanma tarihi)

                        // Lot (10)
                        int startIndex10 = endIndex10 + 4;
                        if (startIndex10 >= 4 && startIndex10 < data.Length)
                        {
                            string lot = data.Substring(startIndex10);
                            textBox4.Text = lot;   // Lot numarası


                            //  MessageBox.Show($"Barkod: {textBox1.Text}\nSKT: {stk}\nLot: {lot}");
                        }
                        else
                        {
                            MessageBox.Show("Hata: Lot numarası ayrıştırılamadı.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hata: SKT numarası ayrıştırılamadı.");
                    }
                }
                else
                {
                    MessageBox.Show("Hata: Barkod numarası ayrıştırılamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void GetProductDetailsFromExcel(string barcode)
        {
            IWorkbook workbook = null;
            ISheet worksheet = null;

            try
            {
                // Excel dosyasını aç
                using (FileStream file = new FileStream(@"C:\Users\Burcu Sebit\OneDrive\Masaüstü\Yeni Microsoft Excel Worksheet (3).xlsx", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    workbook = new XSSFWorkbook(file); // XSSFWorkbook, XLSX dosyaları için
                    worksheet = workbook.GetSheetAt(0); // İlk sayfayı al
                }

                bool found = false;

                // Excel sayfasındaki satırları tara
                for (int i = 0; i <= worksheet.LastRowNum; i++)
                {
                    IRow row = worksheet.GetRow(i);
                    if (row != null)
                    {
                        // Barkod numarasının 3. sütunda olduğunu varsayıyoruz
                        string cellValue = row.GetCell(2)?.ToString();
                        if (cellValue == barcode)
                        {
                            textBox3.Text = row.GetCell(5)?.ToString(); // Ürün adı 6. sütunda
                            textBox6.Text = row.GetCell(4)?.ToString(); // Referans numarası 5. sütunda

                            found = true;
                            break;
                        }
                    }
                }

                if (!found)
                {
                    MessageBox.Show("Barkod numarası bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // textBoxBarcode'daki veriyi işle
            string data = textBox1.Text;

            if (!string.IsNullOrEmpty(data))
            {
                // Barkod verisini işleyip, Excel'den ürün detaylarını getir
                ProcessBarcodeData(data);
                GetProductDetailsFromExcel(textBox2.Text); // textBox1'deki barkod numarasını kullanarak Excel'den veri al
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // textBox1'deki veriyi işleyin
            string data = textBox1.Text;

            if (!string.IsNullOrEmpty(data))
            {
                // Barkod verisini işleyip, Excel'den ürün detaylarını getir
                ProcessBarcodeData(data);
                GetProductDetailsFromExcel(data); // textBox1'deki barkod numarasını kullanarak Excel'den veri al
            }
        }
        /* private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
         {
             // Seçilen satırın indeksini kontrol et
             // Seçilen satırın indeksini kontrol et
             if (e.RowIndex >= 0)
             {
                 // Seçilen satırı al
                 DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                 // Hücre değerlerini al ve TextBox'lara aktar

                 textBox7.Text = row.Cells[4].Value?.ToString(); // SKT
             }
             CheckExpirationDate();

         }*/
        private void CheckExpirationDate()
        {
            string sktBarcode = textBox7.Text.Trim();

            if (sktBarcode.Length != 6)
            {
                MessageBox.Show("Geçersiz SKT formatı. Lütfen 6 haneli bir SKT girin.");
                return;
            }

            try
            {
                // SKT'yi ayırıyoruz
                int year = int.Parse("20" + sktBarcode.Substring(0, 2));  // ilk iki hane yıl (örneğin 2031)
                int month = int.Parse(sktBarcode.Substring(2, 2)); // Sonraki iki hane ay
                int day = int.Parse(sktBarcode.Substring(4, 2)); // son iki hane gün

                // SKT'yi DateTime formatına dönüştürüyoruz
                DateTime expirationDate = new DateTime(year, month, day);

                // Bugünün tarihi ile karşılaştırma
                DateTime today = DateTime.Today;

                // Son kullanma tarihine kaç gün kaldığını hesaplayalım
                TimeSpan timeRemaining = expirationDate - today;
                int daysRemaining = (int)timeRemaining.TotalDays;

                // Eğer ürün son kullanma tarihine yaklaşmışsa (örneğin 30 gün veya daha az kalmışsa)
                if (daysRemaining <= 30)
                {
                    MessageBox.Show($"Ürünün son kullanma tarihi yaklaşıyor! Kalan gün sayısı: {daysRemaining}");
                }
                else
                {
                    MessageBox.Show($"Ürünün son kullanma tarihine {daysRemaining} gün kaldı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

            // Enter tuşuna basıldığında
            if (e.KeyCode == Keys.Enter)
            {
                // Enter tuşunun varsayılan işlemlerini engelleyin
                e.SuppressKeyPress = true;

                // textBox1'deki veriyi işleyin
                string data = textBox1.Text;


                if (!string.IsNullOrEmpty(data))
                {
                    // Barkod verisini işleyip, Excel'den ürün detaylarını getir

                    ProcessBarcodeData(data);
                    GetProductDetailsFromExcel(textBox2.Text); // textBox1'deki barkod numarasını kullanarak Excel'den veri al


                }


            }
        }


        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                e.SuppressKeyPress = true;
                string barcode = textBox2.Text.Trim();
                string productName = textBox3.Text.Trim();
                string quantityText = textBox5.Text.Trim();
                string lotNumber = textBox4.Text.Trim();  // Lot numarasını aldık
                DateTime date = dateTimePicker1.Value;

                if (string.IsNullOrEmpty(barcode))
                {
                    MessageBox.Show("Barkod numarası boş olamaz.");
                    return;
                }

                if (string.IsNullOrEmpty(productName))
                {
                    MessageBox.Show("Ürün adı boş olamaz.");
                    return;
                }

                if (string.IsNullOrEmpty(lotNumber))
                {
                    MessageBox.Show("Lot numarası boş olamaz.");
                    return;
                }

                if (!int.TryParse(quantityText, out int quantity) || quantity <= 0)
                {
                    MessageBox.Show("Geçerli bir miktar giriniz.");
                    return;
                }

                using (SqlConnection con = new SqlConnection("Data Source=BRCSBT\\SQLEXPRESS02;Initial Catalog=deneme;Integrated Security=True"))
                {
                    try
                    {
                        con.Open();
                        // Barkod ve Lot numarasına göre kontrol yapıyoruz
                        string query = @"
                IF EXISTS (SELECT 1 FROM [dbo].[stock] WHERE ProductCode = @ProductCode AND ProductLotNumber = @ProductLotNumber)
                BEGIN
                    -- Aynı barkod ve lot numarasına sahip ürün varsa güncelle
                    UPDATE [dbo].[stock]
                    SET Quantity = Quantity + @Quantity, TransDate = @TransDate
                    WHERE ProductCode = @ProductCode AND ProductLotNumber = @ProductLotNumber
                END
                ELSE
                BEGIN
                    -- Aynı barkod ve lot numarasına sahip ürün yoksa yeni ürün ekle
                    INSERT INTO [dbo].[stock] (ProductCode, ProductName, TransDate, Quantity, ProductLotNumber, ReferanceNo, SKT)
                    VALUES (@ProductCode, @ProductName, @TransDate, @Quantity, @ProductLotNumber, @ReferanceNo, @SKT)
                END";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            // Parametreleri ekliyoruz
                            cmd.Parameters.AddWithValue("@ProductCode", barcode);
                            cmd.Parameters.AddWithValue("@ProductName", productName);
                            cmd.Parameters.AddWithValue("@ProductLotNumber", lotNumber);  // Lot numarasını ekledik
                            cmd.Parameters.AddWithValue("@ReferanceNo", textBox6.Text.Trim());
                            cmd.Parameters.AddWithValue("@SKT", textBox7.Text.Trim());
                            cmd.Parameters.AddWithValue("@TransDate", date);
                            cmd.Parameters.AddWithValue("@Quantity", quantity);

                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Ürün başarıyla eklendi.");
                        LoadData(); // Verileri yeniden yükle
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        textBox7.Clear();
                        textBox1.Focus();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }

            }

        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Seçili satırın olup olmadığını kontrol et
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string barcode = row.Cells["barkod"].Value.ToString();
                string lotNumber = row.Cells["column1"].Value.ToString();

                // Kullanıcıya onay mesajı göster
                DialogResult dialogResult = MessageBox.Show(
                    $"Ürünü (Barkod: {barcode}, Lot No: {lotNumber}) silmek istediğinizden emin misiniz?",
                    "Silme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    // Kullanıcı "Evet" seçerse ürünü sil
                    DeleteProduct(barcode, lotNumber);
                }
            }
        }
        private void DeleteProduct(string barcode, string lotNumber)
        {
            using (SqlConnection con = new SqlConnection("Data Source=BRCSBT\\SQLEXPRESS02;Initial Catalog=deneme;Integrated Security=True"))
            {
                try
                {
                    con.Open();

                    // Ürünü veritabanından sil
                    string deleteQuery = @"
            DELETE FROM [dbo].[stock]
            WHERE ProductCode = @ProductCode AND ProductLotNumber = @ProductLotNumber";

                    using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@ProductCode", barcode);
                        cmd.Parameters.AddWithValue("@ProductLotNumber", lotNumber);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Ürün başarıyla silindi.");
                            RemoveProductFromDataGridView(barcode, lotNumber);
                        }
                        else
                        {
                            MessageBox.Show("Ürün bulunamadı.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void RemoveProductFromDataGridView(string barcode, string lotNumber)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["ProductCode"].Value.ToString() == barcode && row.Cells["ProductLotNumber"].Value.ToString() == lotNumber)
                {
                    dataGridView1.Rows.Remove(row);
                    break;
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

           
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            string barcode = textBox2.Text.Trim();
            string productName = textBox3.Text.Trim();
            string quantityText = textBox5.Text.Trim();
            string lotNumber = textBox4.Text.Trim();  // Lot numarasını aldık
            DateTime date = dateTimePicker1.Value;

            if (string.IsNullOrEmpty(barcode))
            {
                MessageBox.Show("Barkod numarası boş olamaz.");
                return;
            }

            if (string.IsNullOrEmpty(productName))
            {
                MessageBox.Show("Ürün adı boş olamaz.");
                return;
            }

            if (string.IsNullOrEmpty(lotNumber))
            {
                MessageBox.Show("Lot numarası boş olamaz.");
                return;
            }

            if (!int.TryParse(quantityText, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Geçerli bir miktar giriniz.");
                return;
            }

            using (SqlConnection con = new SqlConnection("Data Source=BRCSBT\\SQLEXPRESS02;Initial Catalog=deneme;Integrated Security=True"))
            {
                try
                {
                    con.Open();
                    // Barkod ve Lot numarasına göre kontrol yapıyoruz
                    string query = @"
                IF EXISTS (SELECT 1 FROM [dbo].[stock] WHERE ProductCode = @ProductCode AND ProductLotNumber = @ProductLotNumber)
                BEGIN
                    -- Aynı barkod ve lot numarasına sahip ürün varsa güncelle
                    UPDATE [dbo].[stock]
                    SET Quantity = Quantity + @Quantity, TransDate = @TransDate
                    WHERE ProductCode = @ProductCode AND ProductLotNumber = @ProductLotNumber
                END
                ELSE
                BEGIN
                    -- Aynı barkod ve lot numarasına sahip ürün yoksa yeni ürün ekle
                    INSERT INTO [dbo].[stock] (ProductCode, ProductName, TransDate, Quantity, ProductLotNumber, ReferanceNo, SKT)
                    VALUES (@ProductCode, @ProductName, @TransDate, @Quantity, @ProductLotNumber, @ReferanceNo, @SKT)
                END";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Parametreleri ekliyoruz
                        cmd.Parameters.AddWithValue("@ProductCode", barcode);
                        cmd.Parameters.AddWithValue("@ProductName", productName);
                        cmd.Parameters.AddWithValue("@ProductLotNumber", lotNumber);  // Lot numarasını ekledik
                        cmd.Parameters.AddWithValue("@ReferanceNo", textBox6.Text.Trim());
                        cmd.Parameters.AddWithValue("@SKT", textBox7.Text.Trim());
                        cmd.Parameters.AddWithValue("@TransDate", date);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);

                        cmd.ExecuteNonQuery();
                    }

                   // MessageBox.Show("Ürün başarıyla eklendi.");
                    LoadData(); // Verileri yeniden yükle
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
    }

}

