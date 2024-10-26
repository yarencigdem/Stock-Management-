namespace WinFormsApp4
{
    partial class StockList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ListViewItem listViewItem1 = new ListViewItem("");
            ListViewItem listViewItem2 = new ListViewItem("");
            ListViewItem listViewItem3 = new ListViewItem("");
            ListViewItem listViewItem4 = new ListViewItem("");
            ListViewItem listViewItem5 = new ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockList));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            listView1 = new ListView();
            button1 = new Button();
            comboBox1 = new ComboBox();
            button2 = new Button();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            comboBoxTimeFilter = new ComboBox();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2, listViewItem3, listViewItem4, listViewItem5 });
            listView1.Location = new Point(12, 99);
            listView1.Name = "listView1";
            listView1.Size = new Size(916, 457);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(102, 29);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(657, 15);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 3;
            // 
            // button2
            // 
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(831, 10);
            button2.Name = "button2";
            button2.Size = new Size(97, 33);
            button2.TabIndex = 6;
            button2.UseVisualStyleBackColor = true;
            button2.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label3.Location = new Point(327, -5);
            label3.Name = "label3";
            label3.Size = new Size(132, 38);
            label3.TabIndex = 7;
            label3.Text = "Stock List";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(485, 35);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(37, 29);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // comboBoxTimeFilter
            // 
            comboBoxTimeFilter.FormattingEnabled = true;
            comboBoxTimeFilter.Items.AddRange(new object[] { "Haftalık", "Aylık", "Yıllık" });
            comboBoxTimeFilter.Location = new Point(308, 36);
            comboBoxTimeFilter.Name = "comboBoxTimeFilter";
            comboBoxTimeFilter.Size = new Size(160, 28);
            comboBoxTimeFilter.TabIndex = 9;
            // 
            // guna2Button1
            // 
            guna2Button1.Animated = true;
            guna2Button1.AutoRoundedCorners = true;
            guna2Button1.BorderRadius = 27;
            guna2Button1.CustomizableEdges = customizableEdges1;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.SteelBlue;
            guna2Button1.Font = new Font("Segoe UI", 9F);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Image = (Image)resources.GetObject("guna2Button1.Image");
            guna2Button1.Location = new Point(12, 2);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button1.Size = new Size(124, 56);
            guna2Button1.TabIndex = 10;
            guna2Button1.Text = "Pdf ";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // guna2Button2
            // 
            guna2Button2.Animated = true;
            guna2Button2.AutoRoundedCorners = true;
            guna2Button2.BorderRadius = 27;
            guna2Button2.CustomizableEdges = customizableEdges3;
            guna2Button2.DisabledState.BorderColor = Color.DarkGray;
            guna2Button2.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button2.FillColor = Color.SteelBlue;
            guna2Button2.Font = new Font("Segoe UI", 9F);
            guna2Button2.ForeColor = Color.White;
            guna2Button2.Image = (Image)resources.GetObject("guna2Button2.Image");
            guna2Button2.Location = new Point(814, 2);
            guna2Button2.Name = "guna2Button2";
            guna2Button2.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Button2.Size = new Size(124, 56);
            guna2Button2.TabIndex = 11;
            guna2Button2.Text = "Print";
          
            // 
            // StockList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(940, 559);
            Controls.Add(guna2Button2);
            Controls.Add(guna2Button1);
            Controls.Add(comboBoxTimeFilter);
            Controls.Add(pictureBox1);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Controls.Add(listView1);
            Name = "StockList";
            Text = "productList";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private Button button1;
        private ComboBox comboBox1;
        protected internal Button button2;
        private Label label3;
        private PictureBox pictureBox1;
        private ComboBox comboBoxTimeFilter;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
    }
}