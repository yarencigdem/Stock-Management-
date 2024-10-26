using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp4
{
    public partial class RemoveInventory : Form
    {
        public RemoveInventory()
        {
            InitializeComponent();
            this.Load += new EventHandler(stockControl_Load); // Form yüklendiğinde LoadData'yı çağır
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick; // Double-click olayını ekle
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
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM [dbo].[stock]", con);
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

                            //MessageBox.Show($"Barkod: {textBox1.Text}\nSKT: {stk}\nLot: {lot}");
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
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            // Seçilen satırın indeksini kontrol et
            if (e.RowIndex >= 0)
            {
                // Seçilen satırı al
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Hücre değerlerini al ve TextBox'lara aktar

                textBox7.Text = row.Cells[4].Value?.ToString(); // SKT
            }
            CheckExpirationDate();
            /*  if (e.RowIndex >= 0)
              {
                  // Seçilen satırı al
                  DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                  // Barkod numarasını al
                  string selectedBarcode = row.Cells[0].Value?.ToString();

                  // Farklı lot numaralarıyla ürünleri göstermek için yeni formu aç
                  if (!string.IsNullOrEmpty(selectedBarcode))
                  {
                      using (var detailForm = new BarcodeDetailsForm(selectedBarcode))
                      {
                          detailForm.ShowDialog(); // Modal olarak aç
                      }
                  }
              }*/
        }
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
                int day = int.Parse(sktBarcode.Substring(0, 2));  // İlk iki hane gün
                int month = int.Parse(sktBarcode.Substring(2, 2)); // Sonraki iki hane ay
                int year = int.Parse("20" + sktBarcode.Substring(4, 2)); // Son iki hane yıl (örneğin 2031)

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



        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                string data = textBox1.Text;

                if (!string.IsNullOrEmpty(data))
                {
                    ProcessBarcodeData(data);
                    GetProductDetailsFromExcel(textBox2.Text);
                }

                string barcode = textBox2.Text.Trim();
                string productName = textBox3.Text.Trim();
                string quantityText = textBox9.Text = "1";
                string productLotNumber = textBox4.Text.Trim();
                DateTime date = dateTimePicker1.Value;

                if (string.IsNullOrEmpty(barcode))
                {
                    MessageBox.Show("Barkod numarası boş olamaz.");
                    return;
                }

                if (string.IsNullOrEmpty(productLotNumber))
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

                        // En küçük lot numarasını bul
                        string findSmallestLotQuery = @"
SELECT TOP 1 ProductLotNumber, Quantity
FROM [dbo].[stock]
WHERE ProductCode = @ProductCode
ORDER BY RIGHT(ProductLotNumber, 3) ASC";

                        string smallestLotNumber = null;
                        int currentQuantity = 0;

                        using (SqlCommand findCmd = new SqlCommand(findSmallestLotQuery, con))
                        {
                            findCmd.Parameters.AddWithValue("@ProductCode", barcode);
                            SqlDataReader reader = findCmd.ExecuteReader();
                            if (reader.Read())
                            {
                                smallestLotNumber = reader["ProductLotNumber"].ToString();
                                currentQuantity = Convert.ToInt32(reader["Quantity"]);
                            }
                            reader.Close();
                        }

                        if (smallestLotNumber != null)
                        {
                            // Kullanıcıya uyarı mesajı göster
                            DialogResult dialogResult = MessageBox.Show(
                                $"En küçük lot numarasına sahip ürün ({smallestLotNumber}) miktarı azaltılacak. Mevcut miktar: {currentQuantity}. Devam etmek istiyor musunuz?",
                                "Güncelleme Onayı",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning);

                            if (dialogResult == DialogResult.Yes)
                            {
                                // En küçük lot numarasına sahip ürünün miktarını azalt
                                string updateQuantityQuery = @"
UPDATE [dbo].[stock]
SET Quantity = Quantity - @Quantity, TransDate = @TransDate
WHERE ProductCode = @ProductCode AND ProductLotNumber = @ProductLotNumber";

                                using (SqlCommand updateCmd = new SqlCommand(updateQuantityQuery, con))
                                {
                                    updateCmd.Parameters.AddWithValue("@Quantity", quantity);
                                    updateCmd.Parameters.AddWithValue("@ProductCode", barcode);
                                    updateCmd.Parameters.AddWithValue("@ProductLotNumber", smallestLotNumber);
                                    updateCmd.Parameters.AddWithValue("@TransDate", date);

                                    int rowsAffected = updateCmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Ürün miktarı başarıyla azaltıldı.");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Ürün bulunamadı veya yetersiz stok.");
                                    }
                                }
                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                // Hayır seçildiğinde mevcut ürün miktarını azalt
                                string decreaseQuantityQuery = @"
UPDATE [dbo].[stock]
SET Quantity = Quantity - @Quantity
WHERE ProductCode = @ProductCode AND ProductLotNumber = @ProductLotNumber";

                                using (SqlCommand decreaseCmd = new SqlCommand(decreaseQuantityQuery, con))
                                {
                                    decreaseCmd.Parameters.AddWithValue("@Quantity", quantity);
                                    decreaseCmd.Parameters.AddWithValue("@ProductCode", barcode);
                                    decreaseCmd.Parameters.AddWithValue("@ProductLotNumber", productLotNumber);

                                    int rowsAffected = decreaseCmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Mevcut ürün miktarı başarıyla azaltıldı.");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Ürün bulunamadı veya yetersiz stok.");
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("En küçük lot numarasına sahip ürün bulunamadı.");
                        }

                        // Ürün miktarını sıfırlama işlemi
                        string checkQuantityQuery = @"
SELECT Quantity
FROM [dbo].[stock]
WHERE ProductCode = @ProductCode AND ProductLotNumber = @ProductLotNumber";

                        int updatedQuantity = 0;

                        using (SqlCommand checkCmd = new SqlCommand(checkQuantityQuery, con))
                        {
                            checkCmd.Parameters.AddWithValue("@ProductCode", barcode);
                            checkCmd.Parameters.AddWithValue("@ProductLotNumber", productLotNumber);
                            SqlDataReader reader = checkCmd.ExecuteReader();
                            if (reader.Read())
                            {
                                updatedQuantity = Convert.ToInt32(reader["Quantity"]);
                            }
                            reader.Close();
                        }

                        if (updatedQuantity <= 0)
                        {
                            // Miktar sıfır veya negatifse ürünü veritabanından sil
                            string deleteQuery = @"
DELETE FROM [dbo].[stock]
WHERE ProductCode = @ProductCode AND ProductLotNumber = @ProductLotNumber";

                            using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, con))
                            {
                                deleteCmd.Parameters.AddWithValue("@ProductCode", barcode);
                                deleteCmd.Parameters.AddWithValue("@ProductLotNumber", productLotNumber);

                                int rowsAffected = deleteCmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Ürün veritabanından başarıyla silindi.");
                                    RemoveProductFromDataGridView(barcode, productLotNumber);

                                }
                                else
                                {
                                    MessageBox.Show("Ürün bulunamadı.");
                                }
                            }
                        }

                        // Ürün bilgilerini veritabanına ekle
                        string insertOrUpdateQuery = @"
IF NOT EXISTS (SELECT 1 FROM [dbo].[stock] WHERE ProductCode = @ProductCode AND ProductLotNumber = @ProductLotNumber)
BEGIN
    INSERT INTO [dbo].[stock] (ProductCode, ProductName, TransDate, Quantity, ProductLotNumber, ReferanceNo, SKT)
    VALUES (@ProductCode, @ProductName, @TransDate, @Quantity, @ProductLotNumber, @ReferanceNo, @SKT)
END";

                        using (SqlCommand insertCmd = new SqlCommand(insertOrUpdateQuery, con))
                        {
                            insertCmd.Parameters.AddWithValue("@ProductCode", barcode);
                            insertCmd.Parameters.AddWithValue("@ProductName", productName);
                            insertCmd.Parameters.AddWithValue("@TransDate", date);
                            insertCmd.Parameters.AddWithValue("@Quantity", quantity);
                            insertCmd.Parameters.AddWithValue("@ProductLotNumber", productLotNumber);
                            insertCmd.Parameters.AddWithValue("@ReferanceNo", textBox6.Text.Trim());
                            insertCmd.Parameters.AddWithValue("@SKT", textBox7.Text.Trim());

                            insertCmd.ExecuteNonQuery();
                        }

                        LoadData(); // Verileri yeniden yükle
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        textBox7.Clear();
                        textBox9.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            }
        }

        private void RemoveProductFromDataGridView(string barcode, string productLotNumber)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["ProductCode"].Value.ToString() == barcode && row.Cells["ProductLotNumber"].Value.ToString() == productLotNumber)
                {
                    dataGridView1.Rows.Remove(row);
                    break;
                }
            }
        }




        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            // Enter tuşuna basıldığında
            if (e.KeyCode == Keys.Enter)
            {
                // Enter tuşunun varsayılan işlemlerini engelleyin
                e.SuppressKeyPress = true;

                // textBox1'deki veriyi işleyin
                string barcode = textBox2.Text.Trim();
                string productName = textBox3.Text.Trim();
                string quantityText = textBox5.Text.Trim();
                string productLotNumber = textBox4.Text.Trim(); // Lot numarasını al
                DateTime date = dateTimePicker1.Value;

                if (string.IsNullOrEmpty(barcode))
                {
                    MessageBox.Show("Barkod numarası boş olamaz.");
                    return;
                }

                if (string.IsNullOrEmpty(productLotNumber))
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

                        // Stok güncelleme işlemi
                        /*    string updateQuery = @"
                    IF EXISTS (SELECT 1 FROM [dbo].[stock] WHERE ProductCode = @ProductCode AND ProductLotNumber = @ProductLotNumber)
                    BEGIN
                        -- Aynı barkod ve lot numarasına sahip ürün varsa güncelle
                        UPDATE [dbo].[stock]
                        SET Quantity = Quantity - @Quantity, TransDate = @TransDate
                        WHERE ProductCode = @ProductCode AND ProductLotNumber = @ProductLotNumber
                    END
                    ELSE
                    BEGIN
                        -- Aynı barkod ve lot numarasına sahip ürün yoksa yeni ürün ekle
                        INSERT INTO [dbo].[stock] (ProductCode, ProductName, TransDate, Quantity, ProductLotNumber, ReferanceNo, SKT)
                        VALUES (@ProductCode, @ProductName, @TransDate, @Quantity, @ProductLotNumber, @ReferanceNo, @SKT)
                    END";*/
                        string updateQuery = @"
 IF EXISTS (SELECT 1 FROM [dbo].[stock] WHERE ProductCode = @ProductCode AND ProductLotNumber = @ProductLotNumber)
 BEGIN
     -- Aynı barkod ve lot numarasına sahip ürün varsa güncelle
     UPDATE [dbo].[stock]
     SET Quantity = Quantity - @Quantity, TransDate = @TransDate
     WHERE ProductCode = @ProductCode AND ProductLotNumber = @ProductLotNumber
 END";

                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
                        {
                            // Parametreleri ekleyin
                            updateCmd.Parameters.AddWithValue("@Quantity", quantity);
                            updateCmd.Parameters.AddWithValue("@ProductCode", barcode);
                            updateCmd.Parameters.AddWithValue("@ProductName", productName); // Ürün adı ekleyin
                            updateCmd.Parameters.AddWithValue("@ProductLotNumber", productLotNumber); // Lot numarasını ekleyin
                            updateCmd.Parameters.AddWithValue("@TransDate", date);
                            updateCmd.Parameters.AddWithValue("@ReferanceNo", textBox6.Text.Trim()); // Referans numarasını ekleyin
                            updateCmd.Parameters.AddWithValue("@SKT", textBox7.Text.Trim()); // SKT bilgisini ekleyin

                            int rowsAffected = updateCmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                //  MessageBox.Show("Ürün miktarı başarıyla azaltıldı.");
                            }
                            else
                            {
                                MessageBox.Show("Ürün bulunamadı veya yetersiz stok.");
                            }
                        }

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

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            string barcode = textBox2.Text.Trim();
            string productName = textBox3.Text.Trim();
            string quantityText = textBox5.Text.Trim();
            string productLotNumber = textBox4.Text.Trim(); // Lot numarasını al
            DateTime date = dateTimePicker1.Value;

            if (string.IsNullOrEmpty(barcode))
            {
                MessageBox.Show("Barkod numarası boş olamaz.");
                return;
            }

            if (string.IsNullOrEmpty(productLotNumber))
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

                    // Stok güncelleme işlemi
                    string updateQuery = @"
                IF EXISTS (SELECT 1 FROM [dbo].[stock] WHERE ProductCode = @ProductCode AND ProductLotNumber = @ProductLotNumber)
                BEGIN
                    -- Aynı barkod ve lot numarasına sahip ürün varsa güncelle
                    UPDATE [dbo].[stock]
                    SET Quantity = Quantity - @Quantity, TransDate = @TransDate
                    WHERE ProductCode = @ProductCode AND ProductLotNumber = @ProductLotNumber
                END
                ELSE
                BEGIN
                    -- Aynı barkod ve lot numarasına sahip ürün yoksa yeni ürün ekle
                    INSERT INTO [dbo].[stock] (ProductCode, ProductName, TransDate, Quantity, ProductLotNumber, ReferanceNo, SKT)
                    VALUES (@ProductCode, @ProductName, @TransDate, @Quantity, @ProductLotNumber, @ReferanceNo, @SKT)
                END";

                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
                    {
                        // Parametreleri ekleyin
                        updateCmd.Parameters.AddWithValue("@Quantity", quantity);
                        updateCmd.Parameters.AddWithValue("@ProductCode", barcode);
                        updateCmd.Parameters.AddWithValue("@ProductName", productName); // Ürün adı ekleyin
                        updateCmd.Parameters.AddWithValue("@ProductLotNumber", productLotNumber); // Lot numarasını ekleyin
                        updateCmd.Parameters.AddWithValue("@TransDate", date);
                        updateCmd.Parameters.AddWithValue("@ReferanceNo", textBox6.Text.Trim()); // Referans numarasını ekleyin
                        updateCmd.Parameters.AddWithValue("@SKT", textBox7.Text.Trim()); // SKT bilgisini ekleyin

                        int rowsAffected = updateCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // MessageBox.Show("Ürün miktarı başarıyla azaltıldı.");
                        }
                        else
                        {
                            MessageBox.Show("Ürün bulunamadı veya yetersiz stok.");
                        }
                    }

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
