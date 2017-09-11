namespace WindowsFormsApplication1
{
    partial class C_reg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(C_reg));
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.good_info = new System.Windows.Forms.DataGridView();
            this.gnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.myhotelDataSet = new WindowsFormsApplication1.myhotelDataSet();
            this.good_consume_list = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.物品消耗记录 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cname = new System.Windows.Forms.ComboBox();
            this.num = new System.Windows.Forms.NumericUpDown();
            this.gname = new System.Windows.Forms.ComboBox();
            this.goodsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.goodsTableAdapter = new WindowsFormsApplication1.myhotelDataSetTableAdapters.goodsTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.good_info)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myhotelDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.good_consume_list)).BeginInit();
            this.物品消耗记录.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(333, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "消费数量：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(333, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "旅客姓名：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(333, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "消费商品：";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.good_info);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(23, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 207);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "酒店常用消费物品价格信息";
            // 
            // good_info
            // 
            this.good_info.AllowUserToAddRows = false;
            this.good_info.AutoGenerateColumns = false;
            this.good_info.BackgroundColor = System.Drawing.SystemColors.Control;
            this.good_info.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.good_info.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.good_info.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gnameDataGridViewTextBoxColumn,
            this.gpriceDataGridViewTextBoxColumn});
            this.good_info.DataSource = this.bindingSource1;
            this.good_info.Location = new System.Drawing.Point(22, 21);
            this.good_info.Name = "good_info";
            this.good_info.RowTemplate.Height = 23;
            this.good_info.Size = new System.Drawing.Size(250, 176);
            this.good_info.TabIndex = 0;
            // 
            // gnameDataGridViewTextBoxColumn
            // 
            this.gnameDataGridViewTextBoxColumn.DataPropertyName = "g_name";
            this.gnameDataGridViewTextBoxColumn.HeaderText = "商品名称";
            this.gnameDataGridViewTextBoxColumn.Name = "gnameDataGridViewTextBoxColumn";
            this.gnameDataGridViewTextBoxColumn.Width = 130;
            // 
            // gpriceDataGridViewTextBoxColumn
            // 
            this.gpriceDataGridViewTextBoxColumn.DataPropertyName = "g_price";
            this.gpriceDataGridViewTextBoxColumn.HeaderText = "商品价格";
            this.gpriceDataGridViewTextBoxColumn.Name = "gpriceDataGridViewTextBoxColumn";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "goods";
            this.bindingSource1.DataSource = this.myhotelDataSet;
            // 
            // myhotelDataSet
            // 
            this.myhotelDataSet.DataSetName = "myhotelDataSet";
            this.myhotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // good_consume_list
            // 
            this.good_consume_list.BackgroundColor = System.Drawing.SystemColors.Control;
            this.good_consume_list.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.good_consume_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.good_consume_list.Location = new System.Drawing.Point(20, 21);
            this.good_consume_list.Name = "good_consume_list";
            this.good_consume_list.RowTemplate.Height = 23;
            this.good_consume_list.Size = new System.Drawing.Size(544, 112);
            this.good_consume_list.TabIndex = 13;
            this.good_consume_list.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.good_consume_list_RowHeaderMouseDoubleClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Snow;
            this.button1.Location = new System.Drawing.Point(550, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "添加";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Snow;
            this.button3.Location = new System.Drawing.Point(550, 151);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(63, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "打印";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // 物品消耗记录
            // 
            this.物品消耗记录.BackColor = System.Drawing.Color.Transparent;
            this.物品消耗记录.Controls.Add(this.good_consume_list);
            this.物品消耗记录.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.物品消耗记录.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.物品消耗记录.Location = new System.Drawing.Point(23, 236);
            this.物品消耗记录.Name = "物品消耗记录";
            this.物品消耗记录.Size = new System.Drawing.Size(589, 156);
            this.物品消耗记录.TabIndex = 17;
            this.物品消耗记录.TabStop = false;
            this.物品消耗记录.Text = "物品消耗记录";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(333, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "消费时间：";
            // 
            // cname
            // 
            this.cname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cname.FormattingEnabled = true;
            this.cname.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cname.Location = new System.Drawing.Point(414, 47);
            this.cname.Name = "cname";
            this.cname.Size = new System.Drawing.Size(101, 20);
            this.cname.TabIndex = 22;
            // 
            // num
            // 
            this.num.Location = new System.Drawing.Point(415, 111);
            this.num.Name = "num";
            this.num.Size = new System.Drawing.Size(68, 21);
            this.num.TabIndex = 1;
            this.num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gname
            // 
            this.gname.DataSource = this.goodsBindingSource;
            this.gname.DisplayMember = "g_name";
            this.gname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gname.FormattingEnabled = true;
            this.gname.Location = new System.Drawing.Point(414, 77);
            this.gname.Name = "gname";
            this.gname.Size = new System.Drawing.Size(103, 20);
            this.gname.TabIndex = 23;
            // 
            // goodsBindingSource
            // 
            this.goodsBindingSource.DataMember = "goods";
            this.goodsBindingSource.DataSource = this.myhotelDataSet;
            // 
            // goodsTableAdapter
            // 
            this.goodsTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 24;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Snow;
            this.button2.Location = new System.Drawing.Point(550, 80);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 23);
            this.button2.TabIndex = 25;
            this.button2.Text = "修改";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(333, 224);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(281, 12);
            this.label11.TabIndex = 45;
            this.label11.Text = "双击行标题可进行修改或删除（仅能修改消耗数目）";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Snow;
            this.button4.Location = new System.Drawing.Point(550, 117);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(63, 23);
            this.button4.TabIndex = 46;
            this.button4.Text = "删除";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // date
            // 
            this.date.Enabled = false;
            this.date.Location = new System.Drawing.Point(415, 150);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(107, 21);
            this.date.TabIndex = 47;
            // 
            // C_reg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(635, 404);
            this.Controls.Add(this.date);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gname);
            this.Controls.Add(this.num);
            this.Controls.Add(this.cname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.物品消耗记录);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(250, 150);
            this.MaximizeBox = false;
            this.Name = "C_reg";
            this.Text = "消费物品登记";
            this.Load += new System.EventHandler(this.cunsume_registration_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.good_info)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myhotelDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.good_consume_list)).EndInit();
            this.物品消耗记录.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView good_info;
        private System.Windows.Forms.DataGridView good_consume_list;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox 物品消耗记录;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cname;
        private System.Windows.Forms.NumericUpDown num;
        private System.Windows.Forms.BindingSource bindingSource1;
        private myhotelDataSet myhotelDataSet;
        private WindowsFormsApplication1.myhotelDataSetTableAdapters.goodsTableAdapter goodsTableAdapter;
        private System.Windows.Forms.ComboBox gname;
        private System.Windows.Forms.BindingSource goodsBindingSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.DataGridViewTextBoxColumn gnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gpriceDataGridViewTextBoxColumn;
    }
}