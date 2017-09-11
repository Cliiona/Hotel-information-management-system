namespace WindowsFormsApplication1
{
    partial class H_bill
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(H_bill));
            this.room = new System.Windows.Forms.ComboBox();
            this.roomBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.myhotelDataSet = new WindowsFormsApplication1.myhotelDataSet();
            this.button1 = new System.Windows.Forms.Button();
            this.cname = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.checkroom = new System.Windows.Forms.CheckBox();
            this.checkname = new System.Windows.Forms.CheckBox();
            this.checkin_report = new System.Windows.Forms.RadioButton();
            this.checkout_report = new System.Windows.Forms.RadioButton();
            this.checkdate = new System.Windows.Forms.CheckBox();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.roomTableAdapter = new WindowsFormsApplication1.myhotelDataSetTableAdapters.roomTableAdapter();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            ((System.ComponentModel.ISupportInitialize)(this.roomBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myhotelDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // room
            // 
            this.room.DataSource = this.roomBindingSource;
            this.room.DisplayMember = "r_no";
            this.room.FormattingEnabled = true;
            this.room.Location = new System.Drawing.Point(26, 97);
            this.room.Name = "room";
            this.room.Size = new System.Drawing.Size(69, 20);
            this.room.TabIndex = 4;
            this.room.Visible = false;
            // 
            // roomBindingSource
            // 
            this.roomBindingSource.DataMember = "room";
            this.roomBindingSource.DataSource = this.myhotelDataSet;
            // 
            // myhotelDataSet
            // 
            this.myhotelDataSet.DataSetName = "myhotelDataSet";
            this.myhotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Snow;
            this.button1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(28, 236);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cname
            // 
            this.cname.Location = new System.Drawing.Point(27, 145);
            this.cname.Name = "cname";
            this.cname.Size = new System.Drawing.Size(90, 21);
            this.cname.TabIndex = 7;
            this.cname.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Snow;
            this.button2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(28, 275);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "打印";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkroom
            // 
            this.checkroom.AutoSize = true;
            this.checkroom.Location = new System.Drawing.Point(8, 79);
            this.checkroom.Name = "checkroom";
            this.checkroom.Size = new System.Drawing.Size(50, 16);
            this.checkroom.TabIndex = 9;
            this.checkroom.Text = "房号";
            this.checkroom.UseVisualStyleBackColor = true;
            this.checkroom.Click += new System.EventHandler(this.checkroom_Click);
            // 
            // checkname
            // 
            this.checkname.AutoSize = true;
            this.checkname.Location = new System.Drawing.Point(8, 123);
            this.checkname.Name = "checkname";
            this.checkname.Size = new System.Drawing.Size(76, 16);
            this.checkname.TabIndex = 10;
            this.checkname.Text = "客户姓名";
            this.checkname.UseVisualStyleBackColor = true;
            this.checkname.Click += new System.EventHandler(this.checkname_Click_1);
            // 
            // checkin_report
            // 
            this.checkin_report.AutoSize = true;
            this.checkin_report.BackColor = System.Drawing.Color.Transparent;
            this.checkin_report.Checked = true;
            this.checkin_report.Location = new System.Drawing.Point(27, 24);
            this.checkin_report.Name = "checkin_report";
            this.checkin_report.Size = new System.Drawing.Size(114, 16);
            this.checkin_report.TabIndex = 11;
            this.checkin_report.TabStop = true;
            this.checkin_report.Text = "打印旅客入住表";
            this.checkin_report.UseVisualStyleBackColor = false;
            // 
            // checkout_report
            // 
            this.checkout_report.AutoSize = true;
            this.checkout_report.Location = new System.Drawing.Point(27, 51);
            this.checkout_report.Name = "checkout_report";
            this.checkout_report.Size = new System.Drawing.Size(114, 16);
            this.checkout_report.TabIndex = 12;
            this.checkout_report.Text = "打印旅客结账表";
            this.checkout_report.UseVisualStyleBackColor = true;
            // 
            // checkdate
            // 
            this.checkdate.AutoSize = true;
            this.checkdate.Location = new System.Drawing.Point(8, 173);
            this.checkdate.Name = "checkdate";
            this.checkdate.Size = new System.Drawing.Size(102, 16);
            this.checkdate.TabIndex = 13;
            this.checkdate.Text = "具体入住时间";
            this.checkdate.UseVisualStyleBackColor = true;
            this.checkdate.Click += new System.EventHandler(this.checkdate_Click);
            // 
            // date
            // 
            this.date.Location = new System.Drawing.Point(26, 195);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(108, 21);
            this.date.TabIndex = 14;
            this.date.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.date);
            this.groupBox1.Controls.Add(this.checkdate);
            this.groupBox1.Controls.Add(this.checkout_report);
            this.groupBox1.Controls.Add(this.checkin_report);
            this.groupBox1.Controls.Add(this.checkname);
            this.groupBox1.Controls.Add(this.checkroom);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.cname);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.room);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(4, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 309);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(194, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(443, 308);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "旅客入住历史记录";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(431, 273);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseDoubleClick);
            // 
            // roomTableAdapter
            // 
            this.roomTableAdapter.ClearBeforeFill = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.UseAntiAlias = true;
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // H_bill
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(647, 345);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(250, 150);
            this.Name = "H_bill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "补打旅客账单";
            this.Load += new System.EventHandler(this.H_bill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.roomBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myhotelDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox room;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox cname;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkroom;
        private System.Windows.Forms.CheckBox checkname;
        private System.Windows.Forms.RadioButton checkin_report;
        private System.Windows.Forms.RadioButton checkout_report;
        private System.Windows.Forms.CheckBox checkdate;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private myhotelDataSet myhotelDataSet;
        private System.Windows.Forms.BindingSource roomBindingSource;
        private WindowsFormsApplication1.myhotelDataSetTableAdapters.roomTableAdapter roomTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;

    }
}