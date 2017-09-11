namespace WindowsFormsApplication1
{
    partial class H_bcheckin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(H_bcheckin));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ValidRoom = new System.Windows.Forms.DataGridView();
            this.RoomType = new System.Windows.Forms.ComboBox();
            this.roompriceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.myhotelDataSet = new WindowsFormsApplication1.myhotelDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CusType = new System.Windows.Forms.Label();
            this.memo = new System.Windows.Forms.Label();
            this.RoomNo = new System.Windows.Forms.TextBox();
            this.ID = new System.Windows.Forms.ComboBox();
            this.OutTime = new System.Windows.Forms.DateTimePicker();
            this.InTime = new System.Windows.Forms.DateTimePicker();
            this.Staff = new System.Windows.Forms.TextBox();
            this.Remark = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.PhoneNo = new System.Windows.Forms.TextBox();
            this.CName = new System.Windows.Forms.TextBox();
            this.Deposit = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textbox = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.IDlabel = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.Print = new System.Windows.Forms.Button();
            this.room_priceTableAdapter = new WindowsFormsApplication1.myhotelDataSetTableAdapters.room_priceTableAdapter();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ValidRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roompriceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myhotelDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.ValidRoom);
            this.groupBox2.Controls.Add(this.RoomType);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(268, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 302);
            this.groupBox2.TabIndex = 64;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "今日酒店空房信息";
            // 
            // ValidRoom
            // 
            this.ValidRoom.AllowUserToAddRows = false;
            this.ValidRoom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.ValidRoom.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ValidRoom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ValidRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ValidRoom.Location = new System.Drawing.Point(13, 42);
            this.ValidRoom.Name = "ValidRoom";
            this.ValidRoom.RowHeadersVisible = false;
            this.ValidRoom.RowTemplate.Height = 23;
            this.ValidRoom.Size = new System.Drawing.Size(253, 243);
            this.ValidRoom.TabIndex = 2;
            // 
            // RoomType
            // 
            this.RoomType.DataSource = this.roompriceBindingSource;
            this.RoomType.DisplayMember = "roomtype";
            this.RoomType.FormattingEnabled = true;
            this.RoomType.Location = new System.Drawing.Point(105, 17);
            this.RoomType.Name = "RoomType";
            this.RoomType.Size = new System.Drawing.Size(94, 20);
            this.RoomType.TabIndex = 1;
            this.RoomType.SelectedValueChanged += new System.EventHandler(this.RoomType_SelectedValueChanged);
            // 
            // roompriceBindingSource
            // 
            this.roompriceBindingSource.DataMember = "room_price";
            this.roompriceBindingSource.DataSource = this.myhotelDataSet;
            // 
            // myhotelDataSet
            // 
            this.myhotelDataSet.DataSetName = "myhotelDataSet";
            this.myhotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "酒店房间类型：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.CusType);
            this.groupBox1.Controls.Add(this.memo);
            this.groupBox1.Controls.Add(this.RoomNo);
            this.groupBox1.Controls.Add(this.ID);
            this.groupBox1.Controls.Add(this.OutTime);
            this.groupBox1.Controls.Add(this.InTime);
            this.groupBox1.Controls.Add(this.Staff);
            this.groupBox1.Controls.Add(this.Remark);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.PhoneNo);
            this.groupBox1.Controls.Add(this.CName);
            this.groupBox1.Controls.Add(this.Deposit);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.textbox);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.IDlabel);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(27, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 306);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "预订旅客入住";
            // 
            // CusType
            // 
            this.CusType.AutoSize = true;
            this.CusType.Location = new System.Drawing.Point(75, 56);
            this.CusType.Name = "CusType";
            this.CusType.Size = new System.Drawing.Size(0, 12);
            this.CusType.TabIndex = 65;
            // 
            // memo
            // 
            this.memo.AutoSize = true;
            this.memo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.memo.ForeColor = System.Drawing.Color.Red;
            this.memo.Location = new System.Drawing.Point(6, 282);
            this.memo.Name = "memo";
            this.memo.Size = new System.Drawing.Size(19, 12);
            this.memo.TabIndex = 62;
            this.memo.Text = "..";
            // 
            // RoomNo
            // 
            this.RoomNo.Enabled = false;
            this.RoomNo.Location = new System.Drawing.Point(73, 128);
            this.RoomNo.MaxLength = 3;
            this.RoomNo.Name = "RoomNo";
            this.RoomNo.Size = new System.Drawing.Size(156, 21);
            this.RoomNo.TabIndex = 61;
            // 
            // ID
            // 
            this.ID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ID.FormattingEnabled = true;
            this.ID.Location = new System.Drawing.Point(73, 25);
            this.ID.MaxLength = 18;
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(156, 20);
            this.ID.TabIndex = 58;
            this.ID.SelectedValueChanged += new System.EventHandler(this.ID_SelectedValueChanged);
            this.ID.Validated += new System.EventHandler(this.ID_Validated);
            // 
            // OutTime
            // 
            this.OutTime.Location = new System.Drawing.Point(73, 205);
            this.OutTime.Name = "OutTime";
            this.OutTime.Size = new System.Drawing.Size(156, 21);
            this.OutTime.TabIndex = 56;
            // 
            // InTime
            // 
            this.InTime.Enabled = false;
            this.InTime.Location = new System.Drawing.Point(73, 178);
            this.InTime.Name = "InTime";
            this.InTime.Size = new System.Drawing.Size(156, 21);
            this.InTime.TabIndex = 55;
            // 
            // Staff
            // 
            this.Staff.Location = new System.Drawing.Point(73, 232);
            this.Staff.Name = "Staff";
            this.Staff.Size = new System.Drawing.Size(156, 21);
            this.Staff.TabIndex = 53;
            // 
            // Remark
            // 
            this.Remark.Location = new System.Drawing.Point(73, 257);
            this.Remark.Name = "Remark";
            this.Remark.Size = new System.Drawing.Size(156, 21);
            this.Remark.TabIndex = 52;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(26, 133);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(44, 12);
            this.label27.TabIndex = 34;
            this.label27.Text = "房号：";
            // 
            // PhoneNo
            // 
            this.PhoneNo.Location = new System.Drawing.Point(73, 103);
            this.PhoneNo.MaxLength = 15;
            this.PhoneNo.Name = "PhoneNo";
            this.PhoneNo.Size = new System.Drawing.Size(156, 21);
            this.PhoneNo.TabIndex = 51;
            // 
            // CName
            // 
            this.CName.Location = new System.Drawing.Point(73, 77);
            this.CName.MaxLength = 10;
            this.CName.Name = "CName";
            this.CName.Size = new System.Drawing.Size(156, 21);
            this.CName.TabIndex = 49;
            // 
            // Deposit
            // 
            this.Deposit.Location = new System.Drawing.Point(73, 153);
            this.Deposit.MaxLength = 5;
            this.Deposit.Name = "Deposit";
            this.Deposit.Size = new System.Drawing.Size(156, 21);
            this.Deposit.TabIndex = 48;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(10, 237);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 12);
            this.label17.TabIndex = 44;
            this.label17.Text = "操作人员：";
            // 
            // textbox
            // 
            this.textbox.AutoSize = true;
            this.textbox.Location = new System.Drawing.Point(10, 109);
            this.textbox.Name = "textbox";
            this.textbox.Size = new System.Drawing.Size(70, 12);
            this.textbox.TabIndex = 43;
            this.textbox.Text = "联系电话：";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(26, 260);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(38, 12);
            this.label19.TabIndex = 42;
            this.label19.Text = "备注:";
            // 
            // IDlabel
            // 
            this.IDlabel.AutoSize = true;
            this.IDlabel.Location = new System.Drawing.Point(10, 28);
            this.IDlabel.Name = "IDlabel";
            this.IDlabel.Size = new System.Drawing.Size(70, 12);
            this.IDlabel.TabIndex = 40;
            this.IDlabel.Text = "身份证号：";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(10, 83);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(70, 12);
            this.label22.TabIndex = 39;
            this.label22.Text = "客人姓名：";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(10, 211);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(70, 12);
            this.label23.TabIndex = 38;
            this.label23.Text = "离开日期：";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(10, 186);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(70, 12);
            this.label24.TabIndex = 37;
            this.label24.Text = "入住日期：";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(10, 160);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(70, 12);
            this.label25.TabIndex = 36;
            this.label25.Text = "预收押金：";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(10, 56);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(70, 12);
            this.label26.TabIndex = 35;
            this.label26.Text = "客户类型：";
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.Snow;
            this.Save.Location = new System.Drawing.Point(422, 329);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(55, 21);
            this.Save.TabIndex = 62;
            this.Save.Text = "保存";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Print
            // 
            this.Print.BackColor = System.Drawing.Color.Snow;
            this.Print.Location = new System.Drawing.Point(338, 329);
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(55, 21);
            this.Print.TabIndex = 61;
            this.Print.Text = "打印";
            this.Print.UseVisualStyleBackColor = false;
            // 
            // room_priceTableAdapter
            // 
            this.room_priceTableAdapter.ClearBeforeFill = true;
            // 
            // H_bcheckin
            // 
            this.AcceptButton = this.Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(572, 363);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Print);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(250, 150);
            this.Name = "H_bcheckin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "预订客户入住";
            this.Load += new System.EventHandler(this.H_bcheckin_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ValidRoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roompriceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myhotelDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView ValidRoom;
        private System.Windows.Forms.ComboBox RoomType;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker OutTime;
        private System.Windows.Forms.DateTimePicker InTime;
        private System.Windows.Forms.TextBox Staff;
        private System.Windows.Forms.TextBox Remark;
        private System.Windows.Forms.TextBox PhoneNo;
        private System.Windows.Forms.TextBox CName;
        private System.Windows.Forms.TextBox Deposit;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label textbox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label IDlabel;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Print;
        private System.Windows.Forms.ComboBox ID;
        private myhotelDataSet myhotelDataSet;
        private System.Windows.Forms.BindingSource roompriceBindingSource;
        private WindowsFormsApplication1.myhotelDataSetTableAdapters.room_priceTableAdapter room_priceTableAdapter;
        private System.Windows.Forms.TextBox RoomNo;
        private System.Windows.Forms.Label memo;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label CusType;
    }
}