namespace WinFormsApp4
{
    partial class stockControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(stockControl));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            splitContainer1 = new SplitContainer();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            dateTimePicker2 = new DateTimePicker();
            label10 = new Label();
            label9 = new Label();
            textBox9 = new TextBox();
            label8 = new Label();
            label7 = new Label();
            textBox7 = new TextBox();
            textBox6 = new TextBox();
            pictureBox2 = new PictureBox();
            button1 = new Button();
            label6 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label5 = new Label();
            textBox5 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            add = new Button();
            dataGridView1 = new DataGridView();
            barkod = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            transDate = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackgroundImage = (Image)resources.GetObject("splitContainer1.Panel1.BackgroundImage");
            splitContainer1.Panel1.Controls.Add(guna2Button1);
            splitContainer1.Panel1.Controls.Add(dateTimePicker2);
            splitContainer1.Panel1.Controls.Add(label10);
            splitContainer1.Panel1.Controls.Add(label9);
            splitContainer1.Panel1.Controls.Add(textBox9);
            splitContainer1.Panel1.Controls.Add(label8);
            splitContainer1.Panel1.Controls.Add(label7);
            splitContainer1.Panel1.Controls.Add(textBox7);
            splitContainer1.Panel1.Controls.Add(textBox6);
            splitContainer1.Panel1.Controls.Add(pictureBox2);
            splitContainer1.Panel1.Controls.Add(button1);
            splitContainer1.Panel1.Controls.Add(label6);
            splitContainer1.Panel1.Controls.Add(dateTimePicker1);
            splitContainer1.Panel1.Controls.Add(label5);
            splitContainer1.Panel1.Controls.Add(textBox5);
            splitContainer1.Panel1.Controls.Add(label4);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(textBox4);
            splitContainer1.Panel1.Controls.Add(textBox3);
            splitContainer1.Panel1.Controls.Add(textBox2);
            splitContainer1.Panel1.Controls.Add(textBox1);
            splitContainer1.Panel1.Controls.Add(add);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dataGridView1);
            splitContainer1.Size = new Size(1579, 764);
            splitContainer1.SplitterDistance = 524;
            splitContainer1.TabIndex = 0;
            // 
            // guna2Button1
            // 
            guna2Button1.Animated = true;
            guna2Button1.AutoRoundedCorners = true;
            guna2Button1.BackgroundImageLayout = ImageLayout.Zoom;
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
            guna2Button1.Location = new Point(367, 696);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button1.Size = new Size(149, 56);
            guna2Button1.TabIndex = 28;
            guna2Button1.Text = "Stock In";
            guna2Button1.Click += guna2Button1_Click_1;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(159, 500);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(250, 27);
            dateTimePicker2.TabIndex = 26;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(30, 572);
            label10.Name = "label10";
            label10.Size = new Size(82, 20);
            label10.TabIndex = 25;
            label10.Text = "Calibration";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(30, 505);
            label9.Name = "label9";
            label9.Size = new Size(117, 20);
            label9.TabIndex = 24;
            label9.Text = "Production Date";
            label9.Click += label9_Click;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(159, 569);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(156, 27);
            textBox9.TabIndex = 23;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(36, 441);
            label8.Name = "label8";
            label8.Size = new Size(34, 20);
            label8.TabIndex = 21;
            label8.Text = "SKT";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(30, 386);
            label7.Name = "label7";
            label7.Size = new Size(99, 20);
            label7.TabIndex = 20;
            label7.Text = "Reference No";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(146, 438);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(166, 27);
            textBox7.TabIndex = 19;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(146, 383);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(166, 27);
            textBox6.TabIndex = 18;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(276, 69);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(26, 23);
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(333, 127);
            button1.Name = "button1";
            button1.Size = new Size(76, 29);
            button1.TabIndex = 14;
            button1.Text = "barcode";
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            button1.Click += button1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 685);
            label6.Name = "label6";
            label6.Size = new Size(79, 20);
            label6.TabIndex = 13;
            label6.Text = "Trans Date";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(26, 708);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(245, 27);
            dateTimePicker1.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(36, 637);
            label5.Name = "label5";
            label5.Size = new Size(65, 20);
            label5.TabIndex = 11;
            label5.Text = "Quantity";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(146, 634);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(156, 27);
            textBox5.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 33);
            label4.Name = "label4";
            label4.Size = new Size(98, 20);
            label4.TabIndex = 9;
            label4.Text = "Barkod Alanı ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 336);
            label3.Name = "label3";
            label3.Size = new Size(88, 20);
            label3.TabIndex = 8;
            label3.Text = "Lot Number";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 281);
            label2.Name = "label2";
            label2.Size = new Size(104, 20);
            label2.TabIndex = 7;
            label2.Text = "Product Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 224);
            label1.Name = "label1";
            label1.Size = new Size(99, 20);
            label1.TabIndex = 6;
            label1.Text = "Product Code";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(146, 336);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(166, 27);
            textBox4.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(146, 274);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(166, 27);
            textBox3.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(146, 221);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(166, 27);
            textBox2.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(21, 65);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(232, 27);
            textBox1.TabIndex = 2;
            // 
            // add
            // 
            add.Image = (Image)resources.GetObject("add.Image");
            add.Location = new Point(441, 647);
            add.Name = "add";
            add.Size = new Size(80, 43);
            add.TabIndex = 0;
            add.UseVisualStyleBackColor = true;
            add.Visible = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { barkod, name, Column1, column2, Column3, transDate, Quantity, Column5, Column4 });
            dataGridView1.Location = new Point(-6, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1060, 752);
            dataGridView1.TabIndex = 0;
            // 
            // barkod
            // 
            barkod.HeaderText = "barkod";
            barkod.MinimumWidth = 6;
            barkod.Name = "barkod";
            barkod.Width = 125;
            // 
            // name
            // 
            name.HeaderText = "name";
            name.MinimumWidth = 6;
            name.Name = "name";
            name.Width = 125;
            // 
            // Column1
            // 
            Column1.HeaderText = "lot";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 125;
            // 
            // column2
            // 
            column2.HeaderText = "Reference No";
            column2.MinimumWidth = 6;
            column2.Name = "column2";
            column2.Width = 125;
            // 
            // Column3
            // 
            Column3.HeaderText = "SKT";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 125;
            // 
            // transDate
            // 
            transDate.HeaderText = "TransDate";
            transDate.MinimumWidth = 6;
            transDate.Name = "transDate";
            transDate.Width = 125;
            // 
            // Quantity
            // 
            Quantity.HeaderText = "Quantity";
            Quantity.MinimumWidth = 6;
            Quantity.Name = "Quantity";
            Quantity.Width = 125;
            // 
            // Column5
            // 
            Column5.HeaderText = "Calibration";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.Width = 125;
            // 
            // Column4
            // 
            Column4.HeaderText = "ProductionDate";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 125;
            // 
            // stockControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1579, 764);
            Controls.Add(splitContainer1);
            Name = "stockControl";
            Text = "stockControl";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button add;
        private DataGridView dataGridView1;
        private Label label2;
        private Label label1;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label3;
        private Label label4;
        private DateTimePicker dateTimePicker1;
        private Label label5;
        private TextBox textBox5;
        private Label label6;
        private Button button1;
        private PictureBox pictureBox2;
        private Label label8;
        private Label label7;
        private TextBox textBox7;
        private TextBox textBox6;
        private object toolTip;
        private Label label10;
        private Label label9;
        private TextBox textBox9;
        private DateTimePicker dateTimePicker2;
        private DataGridViewTextBoxColumn barkod;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn transDate;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column4;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}