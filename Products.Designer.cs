
namespace WinFormsApp4
{
    partial class Products
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Products));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            button3 = new Button();
            button2 = new Button();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 98);
            label1.Name = "label1";
            label1.Size = new Size(104, 20);
            label1.TabIndex = 0;
            label1.Text = "Product Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 9);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 1;
            label2.Text = "Product Code";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 181);
            label3.Name = "label3";
            label3.Size = new Size(99, 20);
            label3.TabIndex = 2;
            label3.Text = "Reference No";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 265);
            label4.Name = "label4";
            label4.Size = new Size(48, 20);
            label4.TabIndex = 3;
            label4.Text = "Count";
            label4.Click += label4_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(17, 36);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(177, 27);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 121);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(312, 27);
            textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(17, 217);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(177, 27);
            textBox3.TabIndex = 6;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(17, 305);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(114, 27);
            textBox4.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(12, 391);
            button1.Name = "button1";
            button1.Size = new Size(137, 46);
            button1.TabIndex = 8;
            button1.Text = "Product Entry";
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            dataGridView1.Location = new Point(330, 9);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(742, 531);
            dataGridView1.TabIndex = 10;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Column1
            // 
            Column1.HeaderText = "Product Code";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 170;
            // 
            // Column2
            // 
            Column2.HeaderText = "Product Name";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 250;
            // 
            // Column3
            // 
            Column3.HeaderText = "Reference No";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 170;
            // 
            // Column4
            // 
            Column4.HeaderText = "Count";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 125;
            // 
            // button3
            // 
            button3.Location = new Point(88, 462);
            button3.Name = "button3";
            button3.Size = new Size(117, 37);
            button3.TabIndex = 13;
            button3.Text = "Update";
            button3.UseVisualStyleBackColor = true;
            button3.Visible = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(155, 391);
            button2.Name = "button2";
            button2.Size = new Size(141, 46);
            button2.TabIndex = 14;
            button2.Text = "Delete Product";
            button2.UseVisualStyleBackColor = true;
            button2.Visible = false;
            button2.Click += button2_Click;
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
            guna2Button1.Location = new Point(16, 381);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button1.Size = new Size(115, 56);
            guna2Button1.TabIndex = 15;
            guna2Button1.Text = "Add";
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
            guna2Button2.Location = new Point(163, 381);
            guna2Button2.Name = "guna2Button2";
            guna2Button2.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Button2.Size = new Size(112, 56);
            guna2Button2.TabIndex = 16;
            guna2Button2.Text = "Delete";
            guna2Button2.Click += guna2Button2_Click;
            // 
            // guna2Button3
            // 
            guna2Button3.Animated = true;
            guna2Button3.AutoRoundedCorners = true;
            guna2Button3.BorderRadius = 27;
            guna2Button3.CustomizableEdges = customizableEdges5;
            guna2Button3.DisabledState.BorderColor = Color.DarkGray;
            guna2Button3.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button3.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button3.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button3.FillColor = Color.SteelBlue;
            guna2Button3.Font = new Font("Segoe UI", 9F);
            guna2Button3.ForeColor = Color.White;
            guna2Button3.Image = (Image)resources.GetObject("guna2Button3.Image");
            guna2Button3.Location = new Point(77, 462);
            guna2Button3.Name = "guna2Button3";
            guna2Button3.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Button3.Size = new Size(117, 56);
            guna2Button3.TabIndex = 17;
            guna2Button3.Text = "Update";
            guna2Button3.Click += guna2Button3_Click;
            // 
            // Products
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1073, 543);
            Controls.Add(guna2Button3);
            Controls.Add(guna2Button2);
            Controls.Add(guna2Button1);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Products";
            Text = "Products";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
        private DataGridView dataGridView1;
        private Button button3;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private Button button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
    }
}