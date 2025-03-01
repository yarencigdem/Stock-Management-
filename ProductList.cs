using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System;

using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;



using iText.Layout;

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Operators;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;

namespace WinFormsApp4
{
    public partial class ProductList : Form
    {
        public ProductList()
        {
            InitializeComponent();
            InitializeListView(); // Liste görünümünü ayarlama
            LoadDataToListView(); // Verileri yükleme
            this.Load += new System.EventHandler(this.ProductList_Load);
        }
        private void ProductList_Load(object sender, EventArgs e)
        {
            LoadDataToListView(); // Form yüklendiğinde verileri yükle
        }
        private void LoadDataToListView()
        {
            using (SqlConnection con = new SqlConnection("Data Source=BRCSBT\\SQLEXPRESS02;Initial Catalog=deneme;Integrated Security=True"))
            {
                try
                {
                    con.Open();

                    // SQL sorgusunu oluşturun
                    string query = "SELECT ProductCode, ProductName, ReferenceNo, Count FROM [dbo].[Products]";

                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    // Mevcut verileri temizle
                    listView1.Items.Clear();

                    foreach (DataRow item in dt.Rows)
                    {
                        ListViewItem listItem = new ListViewItem(item["ProductCode"] != DBNull.Value ? item["ProductCode"].ToString() : "");
                        listItem.SubItems.Add(item["ProductName"] != DBNull.Value ? item["ProductName"].ToString() : "");
                        listItem.SubItems.Add(item["ReferenceNo"] != DBNull.Value ? item["ReferenceNo"].ToString() : "");
                        listItem.SubItems.Add(item["Count"] != DBNull.Value ? item["Count"].ToString() : "0");

                        listView1.Items.Add(listItem);
                    }

                    // Veri yoksa kullanıcıya bilgi verin
                    if (listView1.Items.Count == 0)
                    {
                        MessageBox.Show("Kayıt bulunamadı.");
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
            listView1.Columns.Add("Product Code", 200);
            listView1.Columns.Add("Product Name", 250);
            listView1.Columns.Add("Reference No", 200);
            listView1.Columns.Add("Count", 120);
        }

     
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            GeneratePdfReport();
        }
        private void GeneratePdfReport()
        {
            string pdfPath = @"C:\Temp\ProductReport.pdf";
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
                  
                    document.Add(new Paragraph($"Product Report ")
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
    }
}
