using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp4
{
    public partial class StockMain : Form
    {
        private int childFormNumber = 0;

        public StockMain()
        {
            InitializeComponent();
        }
        private void OpenForm(Form formToOpen)
        {
            // Panelin genişliğini ve formun boyutlarını alın
            int panelWidth = guna2Panel1.Width; // Panelin genişliği
            int formWidth = formToOpen.Width;
            int formHeight = formToOpen.Height;

            // Formun sol konumunu panelin sağından başlatın
            int x = guna2Panel1.Right; // Panelin sağındaki konum
                                  // Formu dikey olarak ortalayın
            int y = (this.ClientSize.Height - formHeight) / 2;

            formToOpen.StartPosition = FormStartPosition.Manual;
            formToOpen.Location = new Point(x, y);

            formToOpen.Show();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*  Products pro = new Products();
              pro.MdiParent = this;
              pro.StartPosition = FormStartPosition.CenterScreen;
              pro.Show();*/
        }

        private void StockMain_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde yapılacak işlemler buraya eklenebilir
        }

        private void StockMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure Want To Exit?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true; // Kapanma işlemini iptal et
            }
            // Yes seçilirse, form kapanmaya devam eder
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void productListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* ProductList pro = new ProductList();
             pro.MdiParent = this;
             pro.StartPosition = FormStartPosition.CenterScreen;
             pro.Show();*/
        }

        private void addInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* stockControl sto = new stockControl();
             sto.MdiParent = this;
             sto.StartPosition = FormStartPosition.CenterScreen;
             sto.Show();*/
        }

        private void stockListToolStripMenuItem_Click(object sender, EventArgs e)
        {
          /*  StockList list = new StockList();
            list.MdiParent = this;
            list.StartPosition = FormStartPosition.CenterScreen;
            list.Show();*/
        }

        private void removeInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* RemoveInventory removeInventory = new RemoveInventory();
             removeInventory.MdiParent = this;
             removeInventory.StartPosition = FormStartPosition.CenterScreen;
             removeInventory.Show();*/
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {

            Products pro = new Products();
            pro.MdiParent = this;
            pro.StartPosition = FormStartPosition.CenterScreen;
            pro.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
          
            stockControl sto = new stockControl();
            sto.MdiParent = this;
            sto.StartPosition = FormStartPosition.CenterScreen;
            sto.Show();
            OpenForm(sto);
                




        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            RemoveInventory removeInventory = new RemoveInventory();
            removeInventory.MdiParent = this;
            removeInventory.StartPosition = FormStartPosition.CenterScreen;
            removeInventory.Show();
            OpenForm(removeInventory);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ProductList pro = new ProductList();
            pro.MdiParent = this;
            pro.StartPosition = FormStartPosition.CenterScreen;
            pro.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            StockList list = new StockList();
            list.MdiParent = this;
            list.StartPosition = FormStartPosition.CenterScreen;
            list.Show();
        }
    }


}