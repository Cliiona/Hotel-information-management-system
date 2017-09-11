using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient ;
using System.Drawing;
using System.Drawing.Printing ;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class H_bill : Form
    {
        public H_bill()
        {
            InitializeComponent();
        }

        SqlConnection myCon = new SqlConnection();
        private void H_bill_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“myhotelDataSet.room”中。您可以根据需要移动或移除它。
            this.roomTableAdapter.Fill(this.myhotelDataSet.room);

        }
        //方法：实现一个表的基本配置
        private void tablebuild(DataTable table, string sql)
        {
            SqlCommand mycommad = new SqlCommand(sql, myCon);
            SqlDataAdapter myadapter = new SqlDataAdapter(mycommad);
            table.Clear();
            myadapter.Fill(table);
        }
        //方法：初始化数据
        private void init()
        {
            cname.Clear();
            room.Update();
        }
        //事件函数/“查询”按钮点击事件
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkdate.Checked == false  && checkname.Checked == false  && checkroom.Checked == false )
            {
                MessageBox.Show("请输入查询信息！", " 错误提示");
                return;
            }           
            if (checkdate.Checked == true && DateTime.Compare(date.Value.Date, DateTime.Today) > 0)
            {
                MessageBox.Show("时间不能大于当前日期！", " 错误提示");
                return;
            }
            //判断是否勾选了房间号和客户姓名
            if (checkroom.Checked == false)
            {
                room.Text = "%%";
            }
            else
            {
                if (room.Text == "")
                {
                    MessageBox.Show("房间号输入为空！", " 错误提示");
                    return;
                }
            }
            if (checkname.Checked == false)
            {
                cname.Text = "%%";
            }
            else 
            {
                if (room.Text == "")
                {
                    MessageBox.Show("客户姓名输入为空！", " 错误提示");
                    return;
                }            
            }

            string string1 = "select c_name AS '客户姓名',checkin.c_id AS '身份证号',r_no AS '房间号',c_rtype AS '房间类型',c_intime AS '入住时间',c_outtime AS '离开时间',c_account AS '押金' from checkin ,customer where r_no LIKE '%" + room.Text  + "%' and checkin.c_id = customer.c_id and c_name LIKE'%"+cname.Text +"%'and ('" + date.Value + "'between c_intime and c_outtime)";
            string string2 = "select c_name AS '客户姓名',checkin.c_id AS '身份证号',r_no AS '房间号',c_rtype AS '房间类型',c_intime AS '入住时间',c_outtime AS '离开时间',c_account AS '押金' from checkin ,customer where r_no LIKE '%" + room.Text + "%'and checkin.c_id = customer.c_id and c_name LIKE'%" + cname.Text + "%'";
            string string3 = "select o_name AS '客户姓名',checkout.c_id AS '身份证号',checkout.r_no AS '房间号',r_type AS '房间类型',o_intime AS '入住时间',o_time AS '离开时间',o_sum AS '消费总金额' from checkout ,room where checkout.r_no LIKE '%" + room.Text + "%'and checkout.r_no = room.r_no and  o_name LIKE'%" + cname.Text + "%'and ('" + date.Value + "'between  o_intime and o_time)";
            string string4 = "select o_name AS '客户姓名',checkout.c_id AS '身份证号',checkout.r_no AS '房间号',r_type AS '房间类型',o_intime AS '入住时间',o_time AS '离开时间',o_sum AS '消费总金额' from checkout ,room where checkout.r_no LIKE '%" + room.Text + "%'and checkout.r_no =room.r_no and o_name LIKE'%" + cname.Text + "%'";
            myCon.ConnectionString = "Data Source=(local);Initial Catalog=myhotel;Integrated Security=True";//数据库连接字符串 
            myCon.Open();
            DataTable MyQueryTable = new DataTable();
            //选择打印入住报表
            if(checkin_report.Checked==true )
            {
                if (checkdate.Checked == true)
                {
                    tablebuild(MyQueryTable, string1);//选中日期
                }
                else
                {
                    tablebuild(MyQueryTable, string2);//未选中日期
                }     
            }
            //选择打印结账报表
            else if (checkout_report.Checked == true)
            {
                if (checkdate.Checked == true)
                {
                    tablebuild(MyQueryTable, string3);//选中日期
                }
                else
                {
                    tablebuild(MyQueryTable, string4);//未选中日期
                }                             
            } 
            init();//初始化数据
            //判断查询结果是否为空
            if (MyQueryTable.Rows.Count == 0)
            {
                  MessageBox.Show("没有查询到相关记录", " 提示");
                  myCon.Close ();                
                  return ;
            }
            this.dataGridView1.DataSource = MyQueryTable;
            myCon.Close ();
        }
        //事件函数/‘房间号’选择按钮点击事件：显示相应文本框
        private void checkroom_Click(object sender, EventArgs e)
        {
            if (checkroom.Checked == true)
            {
                room.Visible = true;
            }
            else
            {
                room.Visible = false ;
            }
        }
        //事件函数/‘客户姓名’选择按钮点击事件：显示相应文本框
        private void checkname_Click_1(object sender, EventArgs e)
        {
            if (checkname.Checked == true)
            {
                cname.Visible = true;
            }
            else
            {
                cname.Visible = false;
            }
        }
        //事件函数/‘具体时间’选择按钮点击事件：显示相应文本框
        private void checkdate_Click(object sender, EventArgs e)
        {
            if (checkdate.Checked == true)
            {
                date.Visible = true;
            }
            else
            {
                date.Visible = false;
            }
        }
        bool doubleclick = false;//全局变量，用来判断数据是否生成
        String S=null ;
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("请先查询选择要打印的数据！", " 错误提示");
                return;
            }
            if (doubleclick == false)
            {
                MessageBox.Show("请双击选中要打印的行！", " 错误提示");
                return;
            }
          
            printDialog1.ShowDialog();
            PaperSize mysize = new PaperSize();
            mysize.Height = 600;
            mysize.Width = 1000;  
            printDocument1.DefaultPageSettings.PaperSize  = mysize ;
          
            //printDialog1.PrinterSettings .PaperSizes  = new PaperSize("Custom", 826, 492);
            printPreviewDialog1.Document = this.printDocument1;
            printPreviewDialog1.ShowDialog();
        }
        int printrow;//全局变量，打印的行号
        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i=dataGridView1.CurrentRow.Index;
            if(i==dataGridView1.Rows.Count - 1)
            {
               doubleclick = false ;
               return ;
            }
            doubleclick = true;
            printrow = i;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
        
            
            
        
            Pen pen = new Pen(Color.Black, 2);
            e.Graphics.DrawString("Myhotel宾馆欢饮您下次入住", new Font("宋体", 20, FontStyle.Regular), Brushes.Red,600, 500);
            e.Graphics.DrawString("打印日期：" + DateTime.Now + "", new Font("宋体", 20, FontStyle.Regular), Brushes.Red, 500, 550);
            e.Graphics.DrawString("酒店地址：湖北省武汉市华中科技大学", new Font("宋体", 20, FontStyle.Regular), Brushes.Red, 80, 500);

            e.Graphics.DrawString("客户姓名：" + dataGridView1.CurrentRow.Cells[0].Value.ToString()+"", new Font("宋体", 20, FontStyle.Regular), Brushes.Black, 165, 220);
            e.Graphics.DrawString("住宿房间：" + dataGridView1.CurrentRow.Cells[2].Value .ToString() + "", new Font("宋体", 20, FontStyle.Regular), Brushes.Black, 500, 220);
            e.Graphics.DrawString("房间类型：" + dataGridView1.CurrentRow.Cells[3].Value .ToString() + "", new Font("宋体", 20, FontStyle.Regular), Brushes.Black,500, 290);
            e.Graphics.DrawString("证件编号：" + dataGridView1.CurrentRow.Cells[1].Value .ToString() + "", new Font("宋体", 20, FontStyle.Regular), Brushes.Black, 165, 360);
            e.Graphics.DrawString("证件类型：居民身份证", new Font("宋体", 20, FontStyle.Regular), Brushes.Black, 500, 360);
            e.Graphics.DrawString("入住时间：" + dataGridView1.CurrentRow.Cells[4].Value .ToString().Substring (0,10) + "", new Font("宋体", 20, FontStyle.Regular), Brushes.Black, 170, 430);
            e.Graphics.DrawString("离开时间：" + dataGridView1.CurrentRow.Cells[5].Value .ToString().Substring (0,10) + "", new Font("宋体", 20, FontStyle.Regular), Brushes.Black, 500, 430); 
            for (int i = 0; i <= 4; i++)
            {
                e.Graphics.DrawLine(pen, 150, 200 + i * 70,850, 200 + i * 70);
            }
            for (int j = 0; j <=2; j++)
            {
                e.Graphics.DrawLine(pen, 150+350*j, 200,150+350*j,480 );
            } 
            if (checkin_report.Checked == true)
            {
                e.Graphics.DrawString("预收押金：" + dataGridView1.CurrentRow.Cells[6].Value .ToString() + "", new Font("宋体", 20, FontStyle.Regular), Brushes.Black, 170, 290);
                e.Graphics.DrawString("Myhotel宾馆有限公司旅客入住单", new Font("宋体", 40, FontStyle.Regular), Brushes.Black, 100, 100);
            }
            else
            {
                e.Graphics.DrawString("消费金额：" + dataGridView1.CurrentRow.Cells[6].Value .ToString() + "", new Font("宋体", 20, FontStyle.Regular), Brushes.Black, 170, 290);
                e.Graphics.DrawString("Myhotel酒店有限公司旅客结账单", new Font("宋体", 40, FontStyle.Regular), Brushes.Black, 100, 100);
            }
        }  
    }
}
