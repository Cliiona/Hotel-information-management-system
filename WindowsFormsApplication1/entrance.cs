using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class entrance : Form
    {
        public entrance(String str)
        {
            InitializeComponent();
            linkLabel1.Text = str;
            axWindowsMediaPlayer1.URL = @"E:\夜的第五章\课设\myhotel\WindowsFormsApplication1\bin\Debug\merry.mp3";
            axWindowsMediaPlayer1.Ctlcontrols.play();
            axWindowsMediaPlayer1.Ctlcontrols.pause();
            axWindowsMediaPlayer1.Ctlcontrols.stop();



            //显示房态
            SqlConnection myCon = new SqlConnection();
            myCon.ConnectionString = "Data Source=(local);Initial Catalog=myhotel;Integrated Security=True";
            myCon.Open();
            string roomstate = "select r_full from room order by r_no ASC";//按房号升序排列房间状态
            SqlCommand com = new SqlCommand(roomstate, myCon);
            int[] rf = new int[100];
            DataTable table = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(com);
            ad.Fill(table);
            //myCon.Close();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                rf[i] = Convert.ToInt16(table.Rows[i][0]);
            }
            foreach (Control item in this.groupBox1.Controls)
            {

                if (item.GetType() == typeof(Label) && item.Name != "currentu")
                {
                    if (item.Name.Length == 7)
                    {
                        int ind = int.Parse(item.Name.Substring(5, 2))-1;
                        switch (rf[ind])
                        {
                            case 0: item.BackColor = System.Drawing.Color.Yellow; break;
                            case 1: item.BackColor = System.Drawing.Color.Black; break;
                            case 2: item.BackColor = System.Drawing.Color.Pink; break;
                        }
                    }
                    else if (item.Name.Length == 6)
                    {
                        int ind = int.Parse(item.Name.Substring(5, 1))-1;
                        switch (rf[ind])
                        {
                            case 0: item.BackColor = System.Drawing.Color.Yellow; break;
                            case 1: item.BackColor = System.Drawing.Color.Black; break;
                            case 2: item.BackColor = System.Drawing.Color.Pink; break;
                        }
                    }


                }

                //显示房价
                //myCon.Open();
                string rp = "select * from room_price";
                SqlCommand com1 = new SqlCommand(rp,myCon);
                table.Clear();
                SqlDataAdapter ad1 = new SqlDataAdapter(com1);
                ad1.Fill(table);
                for (int i = 0; i < table.Rows.Count;i++ )
                {
                    switch (table.Rows[i]["roomtype"].ToString())
                    {
                        case "单人间": psingle.Text = table.Rows[i]["roomprice"].ToString(); break;
                        case "标准间": pstandard.Text = table.Rows[i]["roomprice"].ToString(); break;
                        case "三人间": ptriple.Text = table.Rows[i]["roomprice"].ToString(); break;
                        case "大床房": pbig.Text = table.Rows[i]["roomprice"].ToString(); break;
                    }

                }
                
                myCon.Close();


            }
        }
        private void roomstate()
        {
                        //显示房态
            SqlConnection myCon = new SqlConnection();
            myCon.ConnectionString = "Data Source=(local);Initial Catalog=myhotel;Integrated Security=True";
            myCon.Open();
            string roomstate = "select r_full from room order by r_no ASC";//按房号升序排列房间状态
            SqlCommand com = new SqlCommand(roomstate, myCon);
            int[] rf = new int[100];
            DataTable table = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(com);
            ad.Fill(table);
            //myCon.Close();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                rf[i] = Convert.ToInt16(table.Rows[i][0]);
            }
            foreach (Control item in this.groupBox1.Controls)
            {

                if (item.GetType() == typeof(Label) && item.Name != "currentu")
                {
                    if (item.Name.Length == 7)
                    {
                        int ind = int.Parse(item.Name.Substring(5, 2))-1;
                        switch (rf[ind])
                        {
                            case 0: item.BackColor = System.Drawing.Color.Yellow; break;
                            case 1: item.BackColor = System.Drawing.Color.Black; break;
                            case 2: item.BackColor = System.Drawing.Color.Pink; break;
                        }
                    }
                    else if (item.Name.Length == 6)
                    {
                        int ind = int.Parse(item.Name.Substring(5, 1))-1;
                        switch (rf[ind])
                        {
                            case 0: item.BackColor = System.Drawing.Color.Yellow; break;
                            case 1: item.BackColor = System.Drawing.Color.Black; break;
                            case 2: item.BackColor = System.Drawing.Color.Pink; break;
                        }
                    }


                }

                //显示房价
                //myCon.Open();
                string rp = "select * from room_price";
                SqlCommand com1 = new SqlCommand(rp,myCon);
                table.Clear();
                SqlDataAdapter ad1 = new SqlDataAdapter(com1);
                ad1.Fill(table);
                for (int i = 0; i < table.Rows.Count;i++ )
                {
                    switch (table.Rows[i]["roomtype"].ToString())
                    {
                        case "单人间": psingle.Text = table.Rows[i]["roomprice"].ToString(); break;
                        case "标准间": pstandard.Text = table.Rows[i]["roomprice"].ToString(); break;
                        case "三人间": ptriple.Text = table.Rows[i]["roomprice"].ToString(); break;
                        case "大床房": pbig.Text = table.Rows[i]["roomprice"].ToString(); break;
                    }

                }
                
                myCon.Close();


            }
        }

        private void init()
        {
            string mysql = "select r_no as '房间号',c_name as '客户姓名'from book,customer where book.c_id=customer.c_id and b_intime='" + DateTime.Today + "'ORDER BY r_no ";
            string mysql1 = "select r_no as '房间号',c_name as '客户姓名'from checkin,customer where checkin.c_id=customer.c_id and c_valid=1 ORDER BY r_no ";
            string delectout_time = "delete from book where( b_intime between  '" + DateTime.Today.AddDays(-10) + "' and '" + DateTime.Today.AddDays(-1) + "')";
            SqlConnection myCon = new SqlConnection();
            myCon.ConnectionString = "Data Source=(local);Initial Catalog=myhotel;Integrated Security=True";
            //数据库连接字符串
            myCon.Open();
            SqlCommand mycommad2 = new SqlCommand(delectout_time, myCon);
            SqlDataAdapter myadapter2 = new SqlDataAdapter(mycommad2);
            mycommad2.ExecuteNonQuery();
            SqlCommand mycommad = new SqlCommand(mysql, myCon);
            SqlDataAdapter myadapter = new SqlDataAdapter(mycommad);
            DataTable MyQueryTable = new DataTable();
            SqlCommand mycommad1 = new SqlCommand(mysql1, myCon);
            SqlDataAdapter myadapter1 = new SqlDataAdapter(mycommad1);
            DataTable MyQueryTable1 = new DataTable();

            MyQueryTable.Clear();
            MyQueryTable1.Clear();
            myadapter.Fill(MyQueryTable);
            myadapter1.Fill(MyQueryTable1);
            this.dataGridView1.DataSource = MyQueryTable1;
            this.dataGridView2.DataSource = MyQueryTable;
        }
        SqlConnection myCon = new SqlConnection();

        private void 操作权限设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            S_QX f2 = new S_QX();             //调用权限界面
                        //子界面
            f2.Show();
        }

        private void 修改用户密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            S_PW f3 = new S_PW();             //定义界面
                          //子界面
            f3.Show();
        }

        private void 宾馆客房设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            S_rm f4 = new S_rm();             //定义界面
                      //子界面
            f4.ShowDialog();
            roomstate();
        }

        private void 消费物品设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
            S_GD f5 = new S_GD();             //定义界面
                         //子界面
            f5.Show();
        }

        private void 系统帮助信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            S_HP f6 = new S_HP();             //定义界面
                        //子界面
            f6.Show();
        }

        private void vIP客户登记ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            int a = 0;
            if (v_de.Enabled == true)
            {
                a = 1;
            }
            V_mgt f7 = new V_mgt(a);             //定义界面
      
            //子界面
            f7.Show();
        }

      

        private void v_de_Click(object sender, EventArgs e)
        {
         
            V_DEL f7 = new V_DEL();             //定义界面
                          //子界面
            f7.Show();
        }

        private void 查询客户信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            Q_user f = new Q_user();             //定义界面
                           //子界面
            f.Show();
        }

        private void 查询客房信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Q_room f = new Q_room();             //定义界面
            
            f.Show();//子界面
            
        }

        private void 查询物品消耗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            Q_goods f = new Q_goods();             //定义界面
           // f.MdiParent = this;                 //子界面
            f.Show();
            
        }

        private void 查询消耗总量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            Q_sum f = new Q_sum();             //定义界面
                         //子界面
            f.Show();
        }

        private void 查询客户押金ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Q_deposit f = new Q_deposit();             //定义界面
                         //子界面
            f.Show();
        }

        private void 客房入住报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            R_management f = new R_management();             //定义界面
                                                        //子界面
            f.groupBox1.Text = "客户入住记录";
            f.Text = "客户入住报表";
            //数据库相关操作
            f.Show();
        }

        private void 消费物品报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            R_management f = new R_management();             //定义界面
                                                         //子界面
            f.groupBox1.Text = "物品消耗记录";
            f.Text = "物品消耗报表";
            //数据库相关操作
            f.Show();
        }

        private void 客户结账报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            R_management f = new R_management();             //定义界面
                         //子界面
            f.groupBox1.Text = "客户结账记录";
            f.Text = "客户结账报表";
            //数据库相关操作
            f.Show();
        }

        private void 消费物品登记ToolStripMenuItem_Click(object sender, EventArgs e)
        {
      
            C_reg f = new C_reg();             //定义界面
                            //子界面
            f.Show();
        }

        private void 客户入住登记ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            H_reg f = new H_reg(linkLabel1 .Text );             //定义界面
                            //子界面
            f.ShowDialog();
            init();
            roomstate();
        }

        private void 客户预定登记ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            H_reg f = new H_reg(linkLabel1.Text);             //定义界面
                            //子界面
            f.Text = "客户预订登记";
            f.groupBox1.Text = "客户预订信息";
            f.account.Enabled = false;
            f.people.Enabled = false;
            f.button2.Enabled = false;
            //数据相关操作
            f.ShowDialog ();
            init();
            roomstate();
        }

        private void 客户结账登记ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            H_checkout f = new H_checkout();             //定义界面
                             //子界面
            f.ShowDialog ();
            init();
            roomstate();
        }

        private void 预定客户入住ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            H_bcheckin f = new H_bcheckin(linkLabel1 .Text );             //定义界面
                           //子界面
            f.ShowDialog();
            init();
            roomstate();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
            S_PW f = new S_PW();
            
            f.Show();
        }


        private void entrance_Load(object sender, EventArgs e)
        {

        }


       

        private void entrance_FormClosing(object sender, FormClosingEventArgs e)
        {
           
                Application.Exit();
            
             
        }

        private void 客户换房登记ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            H_change f = new H_change();             //定义界面
            //子界面
            f.ShowDialog ();
            init();
            roomstate();

        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("您确定要退出系统？", "提示", MessageBoxButtons.OK , MessageBoxIcon.Question) == DialogResult.OK )
            {
                Application.Exit();
            }
            
        }

        private void 打印客户账单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            H_bill f = new H_bill();
            f.Show();
        }

        private void entrance_Load_1(object sender, EventArgs e)
        {
            this.axWindowsMediaPlayer1.URL = @"E:\夜的第五章\课设\myhotel\WindowsFormsApplication1\merry christmas.mp3";
            this.axWindowsMediaPlayer1.Ctlcontrols.play();
            this.axWindowsMediaPlayer1.Ctlcontrols.pause();
            this.axWindowsMediaPlayer1.Ctlcontrols.stop();
            init();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            H_reg f = new H_reg(linkLabel1 .Text );             //定义界面
            //子界面
            f.ShowDialog();
            init();
            roomstate();
           
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            H_reg f = new H_reg(linkLabel1 .Text );             //定义界面
            //子界面
            f.ShowDialog();
            init();
            roomstate();
           

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            H_reg f = new H_reg(linkLabel1.Text);             //定义界面
            //子界面
            f.Text = "客户预订登记";
            f.groupBox1.Text = "客户预订信息";
            f.account.Enabled = false;
            f.people.Enabled = false;
            f.button2.Enabled = false;
            //数据相关操作
            f.ShowDialog();
            init();
            roomstate();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            H_change f = new H_change();             //定义界面
            //子界面
            f.ShowDialog();
            init();
            roomstate();


        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            H_change f = new H_change();             //定义界面
            //子界面
            f.ShowDialog();
            init();
            roomstate();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            H_checkout f = new H_checkout();             //定义界面
            //子界面
            f.ShowDialog();
            init();
            roomstate();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            H_checkout f = new H_checkout();             //定义界面
            //子界面
            f.ShowDialog();
            init();
            roomstate();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            C_reg f = new C_reg();
            f.Show();

        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            C_reg f = new C_reg();
            f.Show();

        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            H_bill f = new H_bill();
            f.Show ();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            H_bill f = new H_bill();
            f.Show();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop ();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            S_PW f = new S_PW();
            f.Show ();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            H_reg f = new H_reg(linkLabel1.Text);             //定义界面
            //子界面
            f.Text = "客户预订登记";
            f.groupBox1.Text = "客户预订信息";
            f.account.Enabled = false;
            f.people.Enabled = false;
            f.button2.Enabled = false;
            //数据相关操作
            f.ShowDialog();
            init();
            roomstate();
        }

     
      
    }
}
