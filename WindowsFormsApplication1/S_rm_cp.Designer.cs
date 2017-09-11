namespace WindowsFormsApplication1
{
    partial class S_rm_cp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(S_rm_cp));
            this.label1 = new System.Windows.Forms.Label();
            this.RoomChange = new System.Windows.Forms.ComboBox();
            this.roompriceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.myhotelDataSet = new WindowsFormsApplication1.myhotelDataSet();
            this.label2 = new System.Windows.Forms.Label();
            this.NewPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cpSave = new System.Windows.Forms.Button();
            this.room_priceTableAdapter = new WindowsFormsApplication1.myhotelDataSetTableAdapters.room_priceTableAdapter();
            this.OP = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.roompriceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myhotelDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 12);
            this.label1.TabIndex = 0;
            this.label1.Tag = "";
            this.label1.Text = "请选择要改价的房型:";
            // 
            // RoomChange
            // 
            this.RoomChange.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.RoomChange.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.RoomChange.DataSource = this.roompriceBindingSource;
            this.RoomChange.DisplayMember = "roomtype";
            this.RoomChange.FormattingEnabled = true;
            this.RoomChange.Location = new System.Drawing.Point(144, 20);
            this.RoomChange.Name = "RoomChange";
            this.RoomChange.Size = new System.Drawing.Size(87, 20);
            this.RoomChange.TabIndex = 2;
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
            this.label2.Location = new System.Drawing.Point(28, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 12);
            this.label2.TabIndex = 3;
            this.label2.Tag = "";
            this.label2.Text = "请输入新的价格:";
            // 
            // NewPrice
            // 
            this.NewPrice.Location = new System.Drawing.Point(144, 69);
            this.NewPrice.Name = "NewPrice";
            this.NewPrice.Size = new System.Drawing.Size(86, 21);
            this.NewPrice.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(55, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 5;
            this.label3.Tag = "";
            this.label3.Text = "原价格：";
            // 
            // cpSave
            // 
            this.cpSave.BackColor = System.Drawing.Color.Snow;
            this.cpSave.Location = new System.Drawing.Point(101, 102);
            this.cpSave.Name = "cpSave";
            this.cpSave.Size = new System.Drawing.Size(52, 30);
            this.cpSave.TabIndex = 7;
            this.cpSave.Text = "保存";
            this.cpSave.UseVisualStyleBackColor = false;
            this.cpSave.Click += new System.EventHandler(this.cpSave_Click);
            // 
            // room_priceTableAdapter
            // 
            this.room_priceTableAdapter.ClearBeforeFill = true;
            // 
            // OP
            // 
            this.OP.DataSource = this.roompriceBindingSource;
            this.OP.DisplayMember = "roomprice";
            this.OP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OP.Enabled = false;
            this.OP.FormattingEnabled = true;
            this.OP.Location = new System.Drawing.Point(144, 44);
            this.OP.Name = "OP";
            this.OP.Size = new System.Drawing.Size(87, 20);
            this.OP.TabIndex = 8;
            // 
            // S_rm_cp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(256, 144);
            this.Controls.Add(this.OP);
            this.Controls.Add(this.cpSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NewPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RoomChange);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(500, 300);
            this.Name = "S_rm_cp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "修改房价";
            this.Load += new System.EventHandler(this.S_rm_cp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.roompriceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myhotelDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox RoomChange;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NewPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cpSave;
        private myhotelDataSet myhotelDataSet;
        private System.Windows.Forms.BindingSource roompriceBindingSource;
        private WindowsFormsApplication1.myhotelDataSetTableAdapters.room_priceTableAdapter room_priceTableAdapter;
        private System.Windows.Forms.ComboBox OP;
    }
}