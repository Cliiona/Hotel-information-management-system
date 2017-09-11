namespace WindowsFormsApplication1
{
    partial class H_checkout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(H_checkout));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cer = new System.Windows.Forms.Label();
            this.roomno = new System.Windows.Forms.TextBox();
            this.cid = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.roomfee = new System.Windows.Forms.TextBox();
            this.itemfee = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.totalfee = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.remark = new System.Windows.Forms.TextBox();
            this.discount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.deposit = new System.Windows.Forms.TextBox();
            this.balance = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.disprice = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.today = new System.Windows.Forms.DateTimePicker();
            this.intime = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.vip = new System.Windows.Forms.CheckBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.rtype = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(101, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "结账日期：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(101, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "酒店房号：";
            // 
            // cer
            // 
            this.cer.AutoSize = true;
            this.cer.Location = new System.Drawing.Point(10, 51);
            this.cer.Name = "cer";
            this.cer.Size = new System.Drawing.Size(89, 12);
            this.cer.TabIndex = 2;
            this.cer.Text = "客户身份证号：";
            // 
            // roomno
            // 
            this.roomno.Location = new System.Drawing.Point(172, 65);
            this.roomno.MaxLength = 3;
            this.roomno.Name = "roomno";
            this.roomno.Size = new System.Drawing.Size(118, 21);
            this.roomno.TabIndex = 62;
            this.roomno.Validated += new System.EventHandler(this.roomno_Validated);
            // 
            // cid
            // 
            this.cid.Location = new System.Drawing.Point(105, 48);
            this.cid.MaxLength = 20;
            this.cid.Name = "cid";
            this.cid.Size = new System.Drawing.Size(132, 21);
            this.cid.TabIndex = 63;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.roomfee);
            this.groupBox1.Controls.Add(this.itemfee);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.totalfee);
            this.groupBox1.Location = new System.Drawing.Point(318, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 104);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "已发生费用核对";
            // 
            // roomfee
            // 
            this.roomfee.Location = new System.Drawing.Point(107, 51);
            this.roomfee.Name = "roomfee";
            this.roomfee.Size = new System.Drawing.Size(118, 21);
            this.roomfee.TabIndex = 77;
            // 
            // itemfee
            // 
            this.itemfee.Location = new System.Drawing.Point(107, 27);
            this.itemfee.Name = "itemfee";
            this.itemfee.Size = new System.Drawing.Size(118, 21);
            this.itemfee.TabIndex = 76;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 74;
            this.label7.Text = "店内消费：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 75;
            this.label6.Text = "住宿费：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(37, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 82;
            this.label11.Text = "消费总计：";
            // 
            // totalfee
            // 
            this.totalfee.Location = new System.Drawing.Point(108, 76);
            this.totalfee.Name = "totalfee";
            this.totalfee.Size = new System.Drawing.Size(118, 21);
            this.totalfee.TabIndex = 84;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.remark);
            this.groupBox2.Controls.Add(this.discount);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.deposit);
            this.groupBox2.Controls.Add(this.balance);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.disprice);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(319, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 123);
            this.groupBox2.TabIndex = 65;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "结算信息";
            // 
            // remark
            // 
            this.remark.Location = new System.Drawing.Point(106, 93);
            this.remark.Name = "remark";
            this.remark.Size = new System.Drawing.Size(118, 21);
            this.remark.TabIndex = 88;
            // 
            // discount
            // 
            this.discount.Location = new System.Drawing.Point(106, 48);
            this.discount.Name = "discount";
            this.discount.Size = new System.Drawing.Size(118, 21);
            this.discount.TabIndex = 73;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(65, 96);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 87;
            this.label12.Text = "说明：";
            // 
            // deposit
            // 
            this.deposit.Location = new System.Drawing.Point(106, 24);
            this.deposit.Name = "deposit";
            this.deposit.Size = new System.Drawing.Size(118, 21);
            this.deposit.TabIndex = 83;
            // 
            // balance
            // 
            this.balance.Location = new System.Drawing.Point(106, 71);
            this.balance.Name = "balance";
            this.balance.Size = new System.Drawing.Size(118, 21);
            this.balance.TabIndex = 86;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 12);
            this.label9.TabIndex = 85;
            this.label9.Text = "结账总额(应收)：";
            // 
            // disprice
            // 
            this.disprice.AutoSize = true;
            this.disprice.Location = new System.Drawing.Point(41, 50);
            this.disprice.Name = "disprice";
            this.disprice.Size = new System.Drawing.Size(65, 12);
            this.disprice.TabIndex = 68;
            this.disprice.Text = "折后金额：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(40, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 81;
            this.label10.Text = "已收押金：";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Snow;
            this.button1.Location = new System.Drawing.Point(39, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 66;
            this.button1.Text = "打印";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.Snow;
            this.Save.Location = new System.Drawing.Point(164, 225);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(86, 23);
            this.Save.TabIndex = 67;
            this.Save.Text = "保存";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(101, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 70;
            this.label5.Text = "入住日期：";
            // 
            // today
            // 
            this.today.Location = new System.Drawing.Point(172, 17);
            this.today.Name = "today";
            this.today.Size = new System.Drawing.Size(118, 21);
            this.today.TabIndex = 71;
            // 
            // intime
            // 
            this.intime.Enabled = false;
            this.intime.Location = new System.Drawing.Point(172, 41);
            this.intime.Name = "intime";
            this.intime.Size = new System.Drawing.Size(118, 21);
            this.intime.TabIndex = 72;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.cname);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cer);
            this.groupBox3.Controls.Add(this.cid);
            this.groupBox3.Location = new System.Drawing.Point(21, 121);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(249, 76);
            this.groupBox3.TabIndex = 75;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "退房客户信息核对";
            // 
            // cname
            // 
            this.cname.Location = new System.Drawing.Point(105, 21);
            this.cname.MaxLength = 32000;
            this.cname.Name = "cname";
            this.cname.Size = new System.Drawing.Size(132, 21);
            this.cname.TabIndex = 65;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 64;
            this.label3.Text = "客户姓名：";
            // 
            // vip
            // 
            this.vip.AutoSize = true;
            this.vip.BackColor = System.Drawing.Color.Transparent;
            this.vip.Enabled = false;
            this.vip.Location = new System.Drawing.Point(21, 51);
            this.vip.Name = "vip";
            this.vip.Size = new System.Drawing.Size(66, 16);
            this.vip.TabIndex = 76;
            this.vip.Text = "VIP结账";
            this.vip.UseVisualStyleBackColor = false;
            this.vip.CheckedChanged += new System.EventHandler(this.vip_CheckedChanged);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(101, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 77;
            this.label4.Text = "房间类型：";
            // 
            // rtype
            // 
            this.rtype.Location = new System.Drawing.Point(172, 90);
            this.rtype.MaxLength = 10;
            this.rtype.Name = "rtype";
            this.rtype.Size = new System.Drawing.Size(118, 21);
            this.rtype.TabIndex = 78;
            // 
            // H_checkout
            // 
            this.AcceptButton = this.Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(607, 266);
            this.Controls.Add(this.rtype);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.vip);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.intime);
            this.Controls.Add(this.today);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.roomno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(250, 150);
            this.Name = "H_checkout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "旅客结账退房";
            this.Load += new System.EventHandler(this.H_checkout_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label cer;
        private System.Windows.Forms.TextBox roomno;
        private System.Windows.Forms.TextBox cid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Label disprice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker today;
        private System.Windows.Forms.DateTimePicker intime;
        private System.Windows.Forms.TextBox discount;
        private System.Windows.Forms.TextBox roomfee;
        private System.Windows.Forms.TextBox itemfee;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox remark;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox balance;
        private System.Windows.Forms.TextBox deposit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox totalfee;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox vip;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.TextBox cname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox rtype;
    }
}