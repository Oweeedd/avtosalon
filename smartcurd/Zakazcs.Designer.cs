namespace smartcurd
{
    partial class Zakaz
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
            this.savezakaz = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.exitzakaz = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataclosmaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.clientzakazcomboBox = new System.Windows.Forms.ComboBox();
            this.dataopenmaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.avtozakazcomboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // savezakaz
            // 
            this.savezakaz.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.savezakaz.Location = new System.Drawing.Point(154, 63);
            this.savezakaz.Margin = new System.Windows.Forms.Padding(2);
            this.savezakaz.Name = "savezakaz";
            this.savezakaz.Size = new System.Drawing.Size(90, 28);
            this.savezakaz.TabIndex = 34;
            this.savezakaz.Text = "Сохранить";
            this.savezakaz.UseVisualStyleBackColor = true;
            this.savezakaz.Click += new System.EventHandler(this.savezakaz_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "ID Авто";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "ID Клиентa";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(3, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(181, 25);
            this.label7.TabIndex = 5;
            this.label7.Text = "Дата открытия";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(3, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(181, 25);
            this.label8.TabIndex = 6;
            this.label8.Text = "Дата закрытия";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // exitzakaz
            // 
            this.exitzakaz.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitzakaz.Location = new System.Drawing.Point(408, 63);
            this.exitzakaz.Margin = new System.Windows.Forms.Padding(2);
            this.exitzakaz.Name = "exitzakaz";
            this.exitzakaz.Size = new System.Drawing.Size(90, 28);
            this.exitzakaz.TabIndex = 35;
            this.exitzakaz.Text = "Выход";
            this.exitzakaz.UseVisualStyleBackColor = true;
            this.exitzakaz.Click += new System.EventHandler(this.exitzakaz_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(198, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Оформление заказа";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OliveDrab;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 60);
            this.panel1.TabIndex = 33;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.Controls.Add(this.dataclosmaskedTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.clientzakazcomboBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataopenmaskedTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.avtozakazcomboBox, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 107);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(537, 102);
            this.tableLayoutPanel1.TabIndex = 32;
            // 
            // dataclosmaskedTextBox
            // 
            this.dataclosmaskedTextBox.Location = new System.Drawing.Point(190, 78);
            this.dataclosmaskedTextBox.Mask = "00.00.0000";
            this.dataclosmaskedTextBox.Name = "dataclosmaskedTextBox";
            this.dataclosmaskedTextBox.Size = new System.Drawing.Size(343, 20);
            this.dataclosmaskedTextBox.TabIndex = 4;
            this.dataclosmaskedTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // clientzakazcomboBox
            // 
            this.clientzakazcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clientzakazcomboBox.FormattingEnabled = true;
            this.clientzakazcomboBox.Location = new System.Drawing.Point(189, 27);
            this.clientzakazcomboBox.Margin = new System.Windows.Forms.Padding(2);
            this.clientzakazcomboBox.Name = "clientzakazcomboBox";
            this.clientzakazcomboBox.Size = new System.Drawing.Size(344, 21);
            this.clientzakazcomboBox.TabIndex = 2;
            // 
            // dataopenmaskedTextBox
            // 
            this.dataopenmaskedTextBox.Location = new System.Drawing.Point(190, 53);
            this.dataopenmaskedTextBox.Mask = "00.00.0000";
            this.dataopenmaskedTextBox.Name = "dataopenmaskedTextBox";
            this.dataopenmaskedTextBox.Size = new System.Drawing.Size(343, 20);
            this.dataopenmaskedTextBox.TabIndex = 3;
            this.dataopenmaskedTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // avtozakazcomboBox
            // 
            this.avtozakazcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.avtozakazcomboBox.FormattingEnabled = true;
            this.avtozakazcomboBox.Location = new System.Drawing.Point(189, 2);
            this.avtozakazcomboBox.Margin = new System.Windows.Forms.Padding(2);
            this.avtozakazcomboBox.Name = "avtozakazcomboBox";
            this.avtozakazcomboBox.Size = new System.Drawing.Size(344, 21);
            this.avtozakazcomboBox.TabIndex = 1;
            this.avtozakazcomboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.avtozakazcomboBox_KeyPress);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(248, 63);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 28);
            this.button1.TabIndex = 36;
            this.button1.Text = "Добавить клиента";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Zakaz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 212);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.savezakaz);
            this.Controls.Add(this.exitzakaz);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Zakaz";
            this.Text = "Zakazcs";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button savezakaz;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Button exitzakaz;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.ComboBox clientzakazcomboBox;
        public System.Windows.Forms.ComboBox avtozakazcomboBox;
        private System.Windows.Forms.MaskedTextBox dataopenmaskedTextBox;
        private System.Windows.Forms.MaskedTextBox dataclosmaskedTextBox;
        public System.Windows.Forms.Button button1;
    }
}