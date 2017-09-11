namespace WindowsFormsApplication1
{
    partial class S_rm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(S_rm));
            this.RoomDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.myhotelDataSet = new WindowsFormsApplication1.myhotelDataSet();
            this.roomtype = new System.Windows.Forms.ComboBox();
            this.roompriceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.roomno = new System.Windows.Forms.TextBox();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.DataGridViewAdd = new System.Windows.Forms.ToolStripButton();
            this.ChangeRoomPrice = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.roomTableAdapter = new WindowsFormsApplication1.myhotelDataSetTableAdapters.roomTableAdapter();
            this.label4 = new System.Windows.Forms.Label();
            this.SearchWay = new System.Windows.Forms.ComboBox();
            this.stair = new System.Windows.Forms.TextBox();
            this.room_priceTableAdapter1 = new WindowsFormsApplication1.myhotelDataSetTableAdapters.room_priceTableAdapter();
            this.Search = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RoomDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myhotelDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roompriceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RoomDataGridView
            // 
            this.RoomDataGridView.AllowUserToAddRows = false;
            this.RoomDataGridView.AutoGenerateColumns = false;
            this.RoomDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.RoomDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.RoomDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RoomDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoomDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.RoomDataGridView.DataSource = this.bindingSource1;
            this.RoomDataGridView.Location = new System.Drawing.Point(12, 59);
            this.RoomDataGridView.Name = "RoomDataGridView";
            this.RoomDataGridView.RowTemplate.Height = 23;
            this.RoomDataGridView.Size = new System.Drawing.Size(480, 259);
            this.RoomDataGridView.TabIndex = 28;
            this.RoomDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoomDataGridView_CellEndEdit);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "r_no";
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(35, 0, 9, 0);
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn1.HeaderText = "房号";
            this.dataGridViewTextBoxColumn1.MaxInputLength = 3;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 54;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "r_type";
            this.dataGridViewTextBoxColumn2.HeaderText = "房型";
            this.dataGridViewTextBoxColumn2.MaxInputLength = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 54;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "r_price";
            this.dataGridViewTextBoxColumn3.HeaderText = "房价";
            this.dataGridViewTextBoxColumn3.MaxInputLength = 3;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 54;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "r_stair";
            this.dataGridViewTextBoxColumn4.HeaderText = "楼层";
            this.dataGridViewTextBoxColumn4.MaxInputLength = 1;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 54;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "r_hold";
            this.dataGridViewTextBoxColumn5.HeaderText = "可容纳人数";
            this.dataGridViewTextBoxColumn5.MaxInputLength = 1;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 90;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "r_full";
            this.dataGridViewTextBoxColumn6.HeaderText = "是否空闲";
            this.dataGridViewTextBoxColumn6.MaxInputLength = 1;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 78;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "r_remark";
            this.dataGridViewTextBoxColumn7.HeaderText = "备注";
            this.dataGridViewTextBoxColumn7.MaxInputLength = 50;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 54;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "room";
            this.bindingSource1.DataSource = this.myhotelDataSet;
            // 
            // myhotelDataSet
            // 
            this.myhotelDataSet.DataSetName = "myhotelDataSet";
            this.myhotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // roomtype
            // 
            this.roomtype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.roomtype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.roomtype.DataSource = this.roompriceBindingSource;
            this.roomtype.DisplayMember = "roomtype";
            this.roomtype.FormattingEnabled = true;
            this.roomtype.Location = new System.Drawing.Point(276, 34);
            this.roomtype.MaxLength = 6;
            this.roomtype.Name = "roomtype";
            this.roomtype.Size = new System.Drawing.Size(90, 20);
            this.roomtype.TabIndex = 19;
            this.roomtype.Visible = false;
            // 
            // roompriceBindingSource
            // 
            this.roompriceBindingSource.DataMember = "room_price";
            this.roompriceBindingSource.DataSource = this.myhotelDataSet;
            // 
            // roomno
            // 
            this.roomno.Location = new System.Drawing.Point(278, 33);
            this.roomno.MaxLength = 3;
            this.roomno.Name = "roomno";
            this.roomno.Size = new System.Drawing.Size(90, 21);
            this.roomno.TabIndex = 17;
            this.roomno.Visible = false;
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "移到第一条记录";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "移到上一条记录";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "当前位置";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(32, 22);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "总项数";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "移到下一条记录";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "移到最后一条记录";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // DataGridViewAdd
            // 
            this.DataGridViewAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DataGridViewAdd.Image = ((System.Drawing.Image)(resources.GetObject("DataGridViewAdd.Image")));
            this.DataGridViewAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DataGridViewAdd.Name = "DataGridViewAdd";
            this.DataGridViewAdd.Size = new System.Drawing.Size(23, 22);
            this.DataGridViewAdd.Text = "DataGridViewAdd";
            this.DataGridViewAdd.Click += new System.EventHandler(this.DataGridViewAdd_Click);
            // 
            // ChangeRoomPrice
            // 
            this.ChangeRoomPrice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ChangeRoomPrice.Image = ((System.Drawing.Image)(resources.GetObject("ChangeRoomPrice.Image")));
            this.ChangeRoomPrice.Name = "ChangeRoomPrice";
            this.ChangeRoomPrice.Size = new System.Drawing.Size(16, 22);
            this.ChangeRoomPrice.Text = "修改房价";
            this.ChangeRoomPrice.MouseEnter += new System.EventHandler(this.ChangeRoomPrice_MouseEnter);
            this.ChangeRoomPrice.MouseLeave += new System.EventHandler(this.ChangeRoomPrice_MouseLeave);
            this.ChangeRoomPrice.Click += new System.EventHandler(this.ChangeRoomPrice_Click);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bindingSource1;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.DataGridViewAdd,
            this.ChangeRoomPrice});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(504, 25);
            this.bindingNavigator1.TabIndex = 15;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // roomTableAdapter
            // 
            this.roomTableAdapter.ClearBeforeFill = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(6, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 12);
            this.label4.TabIndex = 31;
            this.label4.Text = "请选择并输入修改项目：";
            // 
            // SearchWay
            // 
            this.SearchWay.FormattingEnabled = true;
            this.SearchWay.Items.AddRange(new object[] {
            "房型",
            "楼层",
            "房号"});
            this.SearchWay.Location = new System.Drawing.Point(143, 33);
            this.SearchWay.Name = "SearchWay";
            this.SearchWay.Size = new System.Drawing.Size(121, 20);
            this.SearchWay.TabIndex = 32;
            this.SearchWay.SelectedValueChanged += new System.EventHandler(this.SearchWay_SelectedValueChanged);
            // 
            // stair
            // 
            this.stair.Location = new System.Drawing.Point(277, 33);
            this.stair.MaxLength = 1;
            this.stair.Name = "stair";
            this.stair.Size = new System.Drawing.Size(90, 21);
            this.stair.TabIndex = 29;
            this.stair.Visible = false;
            // 
            // room_priceTableAdapter1
            // 
            this.room_priceTableAdapter1.ClearBeforeFill = true;
            // 
            // Search
            // 
            this.Search.BackColor = System.Drawing.Color.Snow;
            this.Search.Location = new System.Drawing.Point(373, 32);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(115, 21);
            this.Search.TabIndex = 34;
            this.Search.Text = "查看房间现有信息";
            this.Search.UseVisualStyleBackColor = false;
            this.Search.Visible = false;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // S_rm
            // 
            this.AcceptButton = this.Search;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(504, 343);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.SearchWay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RoomDataGridView);
            this.Controls.Add(this.stair);
            this.Controls.Add(this.roomtype);
            this.Controls.Add(this.roomno);
            this.Controls.Add(this.bindingNavigator1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(250, 150);
            this.Name = "S_rm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "设置宾馆客房信息";
            this.Load += new System.EventHandler(this.S_rm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RoomDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myhotelDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roompriceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox roomno;//系统自动为我定义的数据集//系统自动为我定义的数据表适配器
        public myhotelDataSet myhotelDataSet1;
        public System.Windows.Forms.DataGridView RoomDataGridView;
        public System.Windows.Forms.ComboBox roomtype;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton DataGridViewAdd;
        private System.Windows.Forms.ToolStripLabel ChangeRoomPrice;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private myhotelDataSet myhotelDataSet;
        private WindowsFormsApplication1.myhotelDataSetTableAdapters.room_priceTableAdapter room_priceTableAdapter;
        private WindowsFormsApplication1.myhotelDataSetTableAdapters.roomTableAdapter roomTableAdapter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox SearchWay;
        private System.Windows.Forms.TextBox stair;
        private System.Windows.Forms.BindingSource roompriceBindingSource;
        private WindowsFormsApplication1.myhotelDataSetTableAdapters.room_priceTableAdapter room_priceTableAdapter1;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;

    }
}