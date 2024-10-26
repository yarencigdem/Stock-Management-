using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;


using iText.Layout;
using iText.Layout.Element;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Operators;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;



namespace WinFormsApp4
{
    public partial class StockList : Form
    {
        public StockList()
        {
            InitializeComponent();
            InitializeListView(); // Liste görünümünü ayarlama
            LoadPrinters(); // Yazıcıları yükleme
            this.Load += new System.EventHandler(this.productList_Load);

            // Zaman filtresi ComboBox'ını ayarla
            comboBoxTimeFilter.Items.AddRange(new string[] { "Haftalık", "Aylık", "Yıllık" });
            comboBoxTimeFilter.SelectedIndex = 0; // Varsayılan olarak "Haftalık" seçili olsun
            comboBoxTimeFilter.SelectedIndexChanged += new EventHandler(comboBoxTimeFilter_SelectedIndexChanged);
        }

        private void productList_Load(object sender, EventArgs e)
        {
            LoadDataToListView(); // Form yüklendiğinde verileri yükle
        }

        private void comboBoxTimeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataToListView(); // Zaman filtresi değiştiğinde verileri yeniden yükle
        }

        private void LoadDataToListView()
        {
            using (SqlConnection con = new SqlConnection("Data Source=BRCSBT\\SQLEXPRESS02;Initial Catalog=deneme;Integrated Security=True"))
            {
                try
                {
                    con.Open();

                    // Seçilen zaman dilimini al
                    string selectedTimeFilter = comboBoxTimeFilter.SelectedItem.ToString();

                    // Zaman filtresi için tarih aralığını belirle
                    string dateCondition = "";

                    if (selectedTimeFilter == "Haftalık")
                    {
                        dateCondition = "WHERE TransDate >= DATEADD(week, -1, GETDATE())";
                    }
                    else if (selectedTimeFilter == "Aylık")
                    {
                        dateCondition = "WHERE TransDate >= DATEADD(month, -1, GETDATE())";
                    }
                    else if (selectedTimeFilter == "Yıllık")
                    {
                        dateCondition = "WHERE TransDate >= DATEADD(year, -1, GETDATE())";
                    }

                    // SQL sorgusunu zaman filtresiyle birlikte oluştur
                    string query = $"SELECT * FROM [dbo].[stock] {dateCondition} ORDER BY ProductName";

                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    // Mevcut verileri temizle
                    listView1.Items.Clear();

                    foreach (DataRow item in dt.Rows)
                    {
                        ListViewItem listItem = new ListViewItem(item["ProductCode"] != DBNull.Value ? item["ProductCode"].ToString() : "");
                        listItem.SubItems.Add(item["ProductName"] != DBNull.Value ? item["ProductName"].ToString() : "");
                        listItem.SubItems.Add(item["ProductLotNumber"] != DBNull.Value ? item["ProductLotNumber"].ToString() : "");
                        listItem.SubItems.Add(item["ReferanceNo"] != DBNull.Value ? item["ReferanceNo"].ToString() : "");
                        listItem.SubItems.Add(item["SKT"] != DBNull.Value ? item["SKT"].ToString() : "");
                        listItem.SubItems.Add(item["TransDate"] != DBNull.Value ? Convert.ToDateTime(item["TransDate"]).ToString("yyyy-MM-dd") : "");
                        listItem.SubItems.Add(item["Quantity"] != DBNull.Value ? item["Quantity"].ToString() : "0");


                        listView1.Items.Add(listItem);
                    }

                    // Veri yoksa kullanıcıya bilgi verin
                    if (listView1.Items.Count == 0)
                    {
                        MessageBox.Show("Seçilen zaman diliminde kayıt bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }







        private void InitializeListView()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("Product Code", 120);
            listView1.Columns.Add("Product Name", 150);
            listView1.Columns.Add("Product Lot Number", 120);
            listView1.Columns.Add("Reference No", 120);
            listView1.Columns.Add("Expiry Date", 120);
            listView1.Columns.Add("Transaction Date", 120);
            listView1.Columns.Add("Quantity", 80);
        }

        private void LoadPrinters()
        {
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                comboBox1.Items.Add(printer);
            }

            // Varsayılan olarak ilk yazıcıyı seçin
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            GeneratePdfReport();
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            PrintPdf(@"C:\Temp\ListViewReport.pdf");

        }


        private void GeneratePdfReport()
        {
            string pdfPath = @"C:\Temp\ListViewReport.pdf";
            string directory = System.IO.Path.GetDirectoryName(pdfPath);

            // Eğer dizin mevcut değilse oluşturun
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Document ve writer nesnelerini oluşturun
            using (PdfWriter writer = new PdfWriter(new FileStream(pdfPath, FileMode.Create, FileAccess.Write)))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf, PageSize.A4.Rotate());

                    // Seçilen zaman filtresini başlığa ekleyin
                    string selectedTimeFilter = comboBoxTimeFilter.SelectedItem.ToString();
                    document.Add(new Paragraph($"ListView Report - {selectedTimeFilter}")
                        .SetFontSize(20)
                        .SetBold());

                    // ListView'deki verileri tabloya ekleyin
                    Table table = new Table(listView1.Columns.Count);

                    // Başlıkları ekleyin
                    foreach (ColumnHeader column in listView1.Columns)
                    {
                        table.AddHeaderCell(new Cell().Add(new Paragraph(column.Text)));
                    }

                    // Satırları ekleyin
                    foreach (ListViewItem item in listView1.Items)
                    {
                        foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                        {
                            table.AddCell(new Cell().Add(new Paragraph(subItem.Text)));
                        }
                    }

                    // Table'ı belgeye ekleyin ve PDF dosyasını tamamlayın
                    document.Add(table);
                    document.Close(); // Document kapatılması PDF dosyasının oluşturulması için gereklidir.
                }
            }

            MessageBox.Show("ListView raporu başarıyla PDF'ye dönüştürüldü.");
        }
        private void PrintPdf(string pdfPath)
        {
            try
            {
                string selectedPrinter = comboBox1.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(selectedPrinter))
                {
                    MessageBox.Show("Lütfen bir yazıcı seçin.");
                    return;
                }

                System.Diagnostics.ProcessStartInfo printProcess = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = pdfPath,
                    Verb = "print",
                    UseShellExecute = true,
                    Arguments = $"/p \"{selectedPrinter}\""
                };

                using (System.Diagnostics.Process process = System.Diagnostics.Process.Start(printProcess))
                {
                    process.WaitForExit(); // Yazdırma işleminin bitmesini bekle
                }

                MessageBox.Show("PDF başarıyla yazdırıldı.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yazdırma hatası: " + ex.Message);
            }
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
