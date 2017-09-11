using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing ;
using WindowsFormsApplication1;


namespace WindowsFormsApplication1
{
    public partial class H_reg : Form
    {
        public H_reg(String str)
        {
            InitializeComponent();
            people.Text = str;
            dateTimePicker3.Value = dateTimePicker4.Value.AddDays(1);
            comboBox1.Text = "所有房间" ;
        }

        private void Choice_fitRoom(DataTable TABLE, String r_no,String r_type, String Intime, String Outtime)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=myhotel;Integrated Security=True");
            conn.Open();
              
           //为顾客选择合适的房间，参数为临时表，房号，房间类型，入住时间，离开时间
              
            //情况一：给定入住时间（预订），反馈可以订的房号，房型，容纳人数以及最晚离开时间；情况二：情况一的进一步select限制离开时间，反馈同样信息
 
            //step1


        }
        private int Key_check(String str)
        {
            int re;
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=myhotel;Integrated Security=True");
            conn.Open();
            String S = "select count(*) from customer where c_id='" + str + "'";
            SqlCommand cmd = new SqlCommand(S, conn);
            re = (int)cmd.ExecuteScalar();
            return re;
        }

        private void 旅客入住登记_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“myhotelDataSet.checkin”中。您可以根据需要移动或移除它。
         
            // TODO: 这行代码将数据加载到表“myhotelDataSet.room”中。您可以根据需要移动或移除它。
       

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=myhotel;Integrated Security=True");
            con.Open();      //打开数据连接
            String SQL=null ;
           
           
            //保存  入住登记或者预订登记
            if (groupBox1.Text == "客户入住信息")//判断是入住还是预订
            {
                SQL = "UPDATE room set r_full=1 where r_no='" + textBox18.Text + "' ";
                SqlCommand com = new SqlCommand(SQL, con);
                com.ExecuteNonQuery();      //改变TABLE room的属性值
             
                
                    //普通客户，调用TABLE checkin
                if (Key_check(id.Text) == 0)
                {
                    SQL = "insert into customer values('" + name.Text + "','" + id.Text + "','" + phone.Text + "','" + comboBox3.Text + "')";
                    SqlCommand cmd = new SqlCommand(SQL, con);
                    cmd.ExecuteNonQuery();

                }

                    
                    SQL = "insert into checkin values('" + textBox18.Text + "','" + id.Text + "','" + dateTimePicker4.Value.ToString("yyyy-MM-dd") + "','" + dateTimePicker3.Value.ToString("yyyy-MM-dd") + "','" + account.Text + "','" + people.Text + "','" + remark.Text + "',1,'" + textBox1.Text + "')";
                    SqlCommand cm = new SqlCommand(SQL, con);
                    //cm.ExecuteNonQuery();
                    if (cm.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //textBox13.Clear();
                        textBox18.Clear();
                        textBox8.Clear();
                        textBox1.Clear();
                        account.Clear();
                        id.Clear();
                        phone.Clear();
                        people.Clear();
                        remark.Clear();
                        name.Clear();

                    }
                    else
                    {
                        MessageBox.Show("保存失败，请重试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    }

                
               
            }
            else
            {
                ////////////////////////预订登记////////////////////
               
                
                    //普通用户调用TABLE book
                    SQL = "UPDATE room set r_full=2 where r_no='" + textBox18.Text + "' ";      //预订属性值full为2
                    SqlCommand comd = new SqlCommand(SQL, con);
                    comd.ExecuteNonQuery();      //改变TABLE room的属性值
                    if (Key_check(id.Text) == 0)
                    {
                        SQL = "insert into customer values('" + name.Text + "','" + id.Text + "','" + phone.Text + "','" + comboBox3.Text + "')";
                        SqlCommand cmd = new SqlCommand(SQL, con);
                        cmd.ExecuteNonQuery();
                    }
                   

                    SQL = "insert into book values('" + id.Text + "','" +textBox18 .Text  + "','" + dateTimePicker4.Value.ToString("yyyy-MM-dd") + "','" + dateTimePicker3.Value.ToString("yyyy-MM-dd") + "','" + remark.Text + "',1,'" + textBox1.Text + "')";
                    SqlCommand cm = new SqlCommand(SQL, con);
                  //  cm.ExecuteNonQuery();
                    if (cm.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("预订成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //textBox13.Clear();
                        textBox18.Clear();
                        textBox8.Clear();
                        textBox1.Clear();
                        account.Clear();
                        id.Clear();
                        phone.Clear();
                        people.Clear();
                        remark.Clear();
                        name.Clear();

                    }
                    else
                    {
                        MessageBox.Show("预订失败，请重试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    }
                
                
                con.Close();
            }

        }

        

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=myhotel;Integrated Security=True");
            con.Open();      //打开数据连接
            String SQL = null;
            SQL = "select r_type from room where r_no='" + textBox18.Text + "' ";
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader DR = com.ExecuteReader();
            if (DR.Read())
            {
                textBox1.Text = DR["r_type"].ToString();
            }
            con.Close();

        }

        private void dateTimePicker3_MouseEnter(object sender, EventArgs e)
        {
            dateTimePicker3.MinDate =dateTimePicker4.Value.AddDays (1);
        }

        private void dateTimePicker3_MouseDown(object sender, MouseEventArgs e)
        {
           // dateTimePicker3.MinDate = dateTimePicker4.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String S = null;
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=myhotel;Integrated Security=True");
            con.Open();
            if (comboBox1.Text == "单人间")
            {
                S = "SELECT r_no AS '房号',r_price AS '单价',r_stair AS '楼层',r_hold AS '可容纳人数',r_remark AS '备注'    from  room  where  r_full=0 and r_type='单人间'";
            }
            if (comboBox1.Text == "标准间")
            {
                S = "SELECT r_no AS '房号',r_price AS '单价',r_stair AS '楼层',r_hold AS '可容纳人数',r_remark AS '备注'    from  room  where  r_full=0 and r_type='标准间'";
            }
            if (comboBox1.Text == "三人间")
            {
                S = "SELECT r_no AS '房号',r_price AS '单价',r_stair AS '楼层',r_hold AS '可容纳人数',r_remark AS '备注'    from  room  where  r_full=0 AND r_type='三人间'";

            }
            if (comboBox1.Text == "大床房")
            {
                S = "SELECT r_no AS '房号',r_price AS '单价',r_stair AS '楼层',r_hold AS '可容纳人数',r_remark AS '备注'    from  room  where  r_full=0 and r_type='大床房'";

            }
            if (comboBox1.Text == "所有房间")
            {
                S = "SELECT r_no AS '房号',r_price AS '单价',r_stair AS '楼层',r_hold AS '可容纳人数',r_remark AS '备注'    from  room  where  r_full=0";

            }

            SqlDataAdapter dat = new SqlDataAdapter(S, con);
            DataSet dst = new DataSet();
            dat.Fill(dst, "room");
            dataGridView1.DataSource = dst.Tables["room"].DefaultView;
            con.Close(); 

           
                


            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
            PaperSize mysize = new PaperSize();
            mysize.Height = 600;
            mysize.Width = 1000;
            printDocument1.DefaultPageSettings.PaperSize = mysize;

            //printDialog1.PrinterSettings .PaperSizes  = new PaperSize("Custom", 826, 492);
            printPreviewDialog1.Document = this.printDocument1;
            printPreviewDialog1.ShowDialog();
        }
      




        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            
            Pen pen = new Pen(Color.Black, 2);
            e.Graphics.DrawString("Myhotel宾馆欢饮您下次入住", new Font("宋体", 20, FontStyle.Regular), Brushes.Red, 600, 500);
            e.Graphics.DrawString("打印日期：" + DateTime.Now + "", new Font("宋体", 20, FontStyle.Regular), Brushes.Red, 500, 550);
            e.Graphics.DrawString("酒店地址：湖北省武汉市华中科技大学", new Font("宋体", 20, FontStyle.Regular), Brushes.Red, 80, 500);

            e.Graphics.DrawString("客户姓名：" +name .Text + "", new Font("宋体", 20, FontStyle.Regular), Brushes.Black, 165, 220);
            e.Graphics.DrawString("住宿房间：" +textBox18 .Text + "", new Font("宋体", 20, FontStyle.Regular), Brushes.Black, 500, 220);
            e.Graphics.DrawString("房间类型：" + comboBox3.Text  + "", new Font("宋体", 20, FontStyle.Regular), Brushes.Black, 500, 290);
            e.Graphics.DrawString("证件编号：" + id.Text  + "", new Font("宋体", 20, FontStyle.Regular), Brushes.Black, 165, 360);
            e.Graphics.DrawString("证件类型：居民身份证", new Font("宋体", 20, FontStyle.Regular), Brushes.Black, 500, 360);
           
            for (int i = 0; i <= 4; i++)
            {
                e.Graphics.DrawLine(pen, 150, 200 + i * 70, 850, 200 + i * 70);
            }
            for (int j = 0; j <= 2; j++)
            {
                e.Graphics.DrawLine(pen, 150 + 350 * j, 200, 150 + 350 * j, 480);
            }
            if (groupBox1.Text == "客户入住信息")
            {
                e.Graphics.DrawString("入住时间：" + dateTimePicker4.Value.ToString("yyyy-MM-dd") + "", new Font("宋体", 20, FontStyle.Regular), Brushes.Black, 170, 430);
                e.Graphics.DrawString("预离时间：" + dateTimePicker3.Value.ToString("yyyy-MM-dd") + "", new Font("宋体", 20, FontStyle.Regular), Brushes.Black, 500, 430);
                e.Graphics.DrawString("预收押金：" + account.Text + "", new Font("宋体", 20, FontStyle.Regular), Brushes.Black, 170, 290);
                e.Graphics.DrawString("Myhotel宾馆有限公司旅客入住单", new Font("宋体", 40, FontStyle.Regular), Brushes.Black, 100, 100);
            }
            else
            {
                e.Graphics.DrawString("预住时间：" + dateTimePicker4.Value.ToString("yyyy-MM-dd") + "", new Font("宋体", 20, FontStyle.Regular), Brushes.Black, 170, 430);
                e.Graphics.DrawString("预离时间：" + dateTimePicker3.Value.ToString("yyyy-MM-dd") + "", new Font("宋体", 20, FontStyle.Regular), Brushes.Black, 500, 430);
                e.Graphics.DrawString("预收押金：" + account.Text + "", new Font("宋体", 20, FontStyle.Regular), Brushes.Black, 170, 290);
                e.Graphics.DrawString("Myhotel宾馆有限公司旅客入住单", new Font("宋体", 40, FontStyle.Regular), Brushes.Black, 100, 100);
 
            }
          
            
        
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            String S=null ;
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=myhotel;Integrated Security=True");
            con.Open();
            if (comboBox1.Text == "单人间")
            {
                S = "SELECT r_no AS '房号',r_price AS '单价',r_stair AS '楼层',r_hold AS '可容纳人数',r_remark AS '备注'    from  room  where  r_full=0 and r_type='单人间'";
            }
            if (comboBox1.Text == "标准间")
            {
                S = "SELECT r_no AS '房号',r_price AS '单价',r_stair AS '楼层',r_hold AS '可容纳人数',r_remark AS '备注'    from  room  where  r_full=0 and r_type='标准间'";
            }
            if (comboBox1.Text == "三人间")
            {
                S = "SELECT r_no AS '房号',r_price AS '单价',r_stair AS '楼层',r_hold AS '可容纳人数',r_remark AS '备注'    from  room  where  r_full=0 AND r_type='三人间'";

            }
            if (comboBox1.Text == "大床房")
            {
                S = "SELECT r_no AS '房号',r_price AS '单价',r_stair AS '楼层',r_hold AS '可容纳人数',r_remark AS '备注'    from  room  where  r_full=0 and r_type='大床房'";

            }
            if (comboBox1.Text == "所有房间")
            {
                S = "SELECT r_no AS '房号',r_price AS '单价',r_stair AS '楼层',r_hold AS '可容纳人数',r_remark AS '备注'    from  room  where  r_full=0";

            }

            SqlDataAdapter dat = new SqlDataAdapter(S, con);
            DataSet dst = new DataSet();
            dat.Fill(dst, "room");
            dataGridView1.DataSource = dst.Tables["room"].DefaultView;
            con.Close(); 

        }
        }  

      
    }

