namespace WindowsFormsApplication1
{
    partial class S_rm_add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(S_rm_add));
            this.notice = new System.Windows.Forms.Label();
            this.aremark = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ahold = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.atype = new System.Windows.Forms.ComboBox();
            this.roompriceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.myhotelDataSet = new WindowsFormsApplication1.myhotelDataSet();
            this.label2 = new System.Windows.Forms.Label();
            this.ano = new System.Windows.Forms.TextBox();
            this.RoomSet = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.aprice = new System.Windows.Forms.ComboBox();
            this.room_priceTableAdapter = new WindowsFormsApplication1.myhotelDataSetTableAdapters.room_priceTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.roompriceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myhotelDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // notice
            // 
            this.notice.AutoSize = true;
            this.notice.BackColor = System.Drawing.Color.Transparent;
            this.notice.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.notice.ForeColor = System.Drawing.Color.Red;
            this.notice.Location = new System.Drawing.Point(14, 17);
            this.notice.Name = "notice";
            this.notice.Size = new System.Drawing.Size(96, 12);
            this.notice.TabIndex = 43;
            this.notice.Text = "请输入房间信息";
            // 
            // aremark
            // 
            this.aremark.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.aremark.Location = new System.Drawing.Point(55, 99);
            this.aremark.MaxLength = 50;
            this.aremark.Name = "aremark";
            this.aremark.Size = new System.Drawing.Size(284, 21);
            this.aremark.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(16, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 12);
            this.label6.TabIndex = 40;
            this.label6.Text = "说明：";
            // 
            // ahold
            // 
            this.ahold.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ahold.Location = new System.Drawing.Point(243, 68);
            this.ahold.MaxLength = 2;
            this.ahold.Name = "ahold";
            this.ahold.Size = new System.Drawing.Size(96, 21);
            this.ahold.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(168, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 38;
            this.label5.Text = "可容纳人数：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(16, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 12);
            this.label4.TabIndex = 36;
            this.label4.Text = "价格：";
            // 
            // atype
            // 
            this.atype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.atype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.atype.DataSource = this.roompriceBindingSource;
            this.atype.DisplayMember = "roomtype";
            this.atype.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.atype.FormattingEnabled = true;
            this.atype.Location = new System.Drawing.Point(243, 41);
            this.atype.MaxLength = 6;
            this.atype.Name = "atype";
            this.atype.Size = new System.Drawing.Size(96, 20);
            this.atype.TabIndex = 34;
            this.atype.SelectedValueChanged += new System.EventHandler(this.type_SelectedValueChanged);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(188, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 12);
            this.label2.TabIndex = 33;
            this.label2.Text = "房型：";
            // 
            // ano
            // 
            this.ano.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ano.Location = new System.Drawing.Point(54, 42);
            this.ano.MaxLength = 3;
            this.ano.Name = "ano";
            this.ano.Size = new System.Drawing.Size(106, 21);
            this.ano.TabIndex = 32;
            // 
            // RoomSet
            // 
            this.RoomSet.AutoSize = true;
            this.RoomSet.BackColor = System.Drawing.Color.Transparent;
            this.RoomSet.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RoomSet.Location = new System.Drawing.Point(16, 45);
            this.RoomSet.Name = "RoomSet";
            this.RoomSet.Size = new System.Drawing.Size(44, 12);
            this.RoomSet.TabIndex = 31;
            this.RoomSet.Text = "房号：";
            // 
            // button_save
            // 
            this.button_save.BackColor = System.Drawing.Color.Snow;
            this.button_save.Location = new System.Drawing.Point(200, 139);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(52, 25);
            this.button_save.TabIndex = 44;
            this.button_save.Text = "保存";
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_clear
            // 
            this.button_clear.BackColor = System.Drawing.Color.Snow;
            this.button_clear.Location = new System.Drawing.Point(78, 139);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(52, 25);
            this.button_clear.TabIndex = 45;
            this.button_clear.Text = "重输";
            this.button_clear.UseVisualStyleBackColor = false;
            // 
            // aprice
            // 
            this.aprice.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.aprice.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.aprice.DataSource = this.roompriceBindingSource;
            this.aprice.DisplayMember = "roomprice";
            this.aprice.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.aprice.FormattingEnabled = true;
            this.aprice.Location = new System.Drawing.Point(54, 69);
            this.aprice.MaxLength = 6;
            this.aprice.Name = "aprice";
            this.aprice.Size = new System.Drawing.Size(106, 20);
            this.aprice.TabIndex = 48;
            // 
            // room_priceTableAdapter
            // 
            this.room_priceTableAdapter.ClearBeforeFill = true;
            // 
            // S_rm_add
            // 
            this.AcceptButton = this.button_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(351, 179);
            this.Controls.Add(this.aprice);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.notice);
            this.Controls.Add(this.aremark);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ahold);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.atype);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ano);
            this.Controls.Add(this.RoomSet);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(500, 150);
            this.Name = "S_rm_add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "添加房间信息";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.S_rm_add_Load);
            ((System.ComponentModel.ISupportInitialize)(this.roompriceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myhotelDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label notice;
        private System.Windows.Forms.TextBox aremark;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ahold;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ano;
        private System.Windows.Forms.Label RoomSet;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_clear;
        public System.Windows.Forms.ComboBox aprice;
        public System.Windows.Forms.ComboBox atype;
        public System.Windows.Forms.Label label2;
        private myhotelDataSet myhotelDataSet;
        private WindowsFormsApplication1.myhotelDataSetTableAdapters.room_priceTableAdapter room_priceTableAdapter;
        private System.Windows.Forms.BindingSource roompriceBindingSource;
    }
}