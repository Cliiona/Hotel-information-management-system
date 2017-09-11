using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class S_GD : Form
    {
        public S_GD()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection();           //声明一个数据库连接对象

        


        int count = 5;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private bool isinter(string str)
        {
            try
            {
                float x = float.Parse(str);
            }
            catch
            {
                return false;
            }
            return true;
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Con.ConnectionString = "Data Source=(local);Initial Catalog=myhotel;Integrated Security=True";//数据库连接字符串
            Con.Open();
            string str = textBox3.Text;
            S_GD_Load(null, null);

         
           
           
            //链接并打开数据库
            if (textBox1.Text != "" && textBox3.Text != "")
            {

                SqlCommand selectgood = new SqlCommand("select * from goods where g_name='" + textBox1.Text + "'", Con);
                SqlDataReader Dr = selectgood.ExecuteReader();
                //  SqlCommand selectgood = new SqlCommand("select count * from goods where g_name='" + textBox1.Text + "'", Con);
                S_GD_Load(null, null);

                if (Dr.Read())
                //  if(selectgood)
                {
                    MessageBox.Show("商品名称重复！", "操作提示");
                    textBox1.Clear();

                    textBox3.Clear();
                    Dr.Close();
                    //   return;
                }

                else
                {
                    Dr.Close();
                    //执行添加记录操作
                    string str1 = textBox1.Text.Trim();

                    int  a=str1.Length;
                    if (a <10)
                    {
                        if (isinter(str))
                        {
                            if (MessageBox.Show("确定添加该商品信息？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                string InsertString = "insert into goods values('" + textBox1.Text + "','" + textBox3.Text + "')";//初始房间为空 没人住
                                SqlCommand MyCommand = new SqlCommand(InsertString, Con);//设置Mycommand中commandText和Connection属性，为使用非查询连接配置参数
                                MyCommand.ExecuteNonQuery();//执行非查询连接——>这里为插入

                                //实时将DataSet中内容更新到GirdView
                                goodsTableAdapter.Fill(myhotelDataSet.goods);
                                textBox1.Clear();

                                textBox3.Clear();
                                count = 5;
                                MessageBox.Show("数据添加成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }


                        else
                        {
                            MessageBox.Show("商品价格必须为数字", "操作提示");
                            textBox3.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("商品名称太长，请重新输入", "操作提示");
                        textBox1.Clear();
                    }
                }


            }
            else
            {
                MessageBox.Show("请正确填写商品信息!", "提示");
            }
            //关闭数据库
            Con.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Con.ConnectionString = "Data Source=(local);Initial Catalog=myhotel;Integrated Security=True";//数据库连接字符串
            Con.Open();
        
          string sql = "select g_price from goods where g_name='" + textBox1.Text.Trim() + "'";
            SqlCommand myqureycommand1 = new SqlCommand(sql, Con);
            string price = myqureycommand1.ExecuteScalar().ToString();
            textBox3.Text =price ;
          //  textBox3.Text = "123";
            Con.Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Con.ConnectionString = "Data Source=(local);Initial Catalog=myhotel;Integrated Security=True";//数据库连接字符串
            Con.Open();

         //   string str = textBox3.Text;

            string sql10 = "select count * from goods where g_name='" + textBox1.Text.Trim () + "'";
            SqlCommand myqureycommand10 = new SqlCommand(sql10, Con);
            SqlDataReader reader1 = myqureycommand10.ExecuteReader();
            //  SqlCommand myqureycommand10 = new SqlCommand(sql10, Con);
            if (reader1.Read())
            {
                // shop = myqureycommand4.ExecuteScalar().ToString();

            }
            else
            {
                MessageBox.Show("此商品不存在!", "提示");

                textBox1.Clear();

                textBox3.Clear();
                return;


            }
            


            string str = textBox3.Text;
            //修改信息
            if (isinter(str))
            {
            //    Con.ConnectionString = "Data Source=(local);Initial Catalog=myhotel;Integrated Security=True";//数据库连接字符串
            //    Con.Open();
                if (MessageBox.Show("确定修改该商品信息？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    SqlCommand cmd = new SqlCommand("Update goods set G_price='" + Convert.ToDouble(textBox3.Text) + "' where G_name='" + textBox1.Text + "'", Con);
                    cmd.ExecuteNonQuery();
                    textBox1.Clear();

                    textBox3.Clear();
                }
            }
            else
            {
                MessageBox.Show("商品价格必须为数字", "操作提示");
            }
            S_GD_Load(null, null);
            Con.Close();
           
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Con.ConnectionString = "Data Source=(local);Initial Catalog=myhotel;Integrated Security=True";//数据库连接字符串
            Con.Open();
            if (count < 0)
            {

                MessageBox.Show("您的删除次数过多，已不能进行删除", "警告");
                //ccount=1;
            }
            //if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
            else
            {

                if (textBox1.Text == "")
                {
                    if (MessageBox.Show("确定删除该商品信息？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        SqlCommand cmdd2 = new SqlCommand("delete  from gd_comsump  where gd_comsump.G_name='" + textBox1.Text + "'", Con);
                        cmdd2.ExecuteNonQuery();

                        dataGridView1.Rows.Remove(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex]);//在DataGridView1界面上进行可视化删除

                        goodsTableAdapter.Update(myhotelDataSet.goods);  //将删除变化更新至数据库

                        // goodsTableAdapter.Update(myhotelDataSet1.gd_comsump);

                        // MessageBox.Show("请输入要删除的商品名称", "操作提示");
                    }

                }

                else
                {


                    SqlCommand cmd = new SqlCommand("select * from goods  where G_name='" + textBox1.Text + "'", Con);

                    SqlDataReader Dr = cmd.ExecuteReader();

                    if (Dr.Read())
                    {
                        Dr.Close();
                        if (MessageBox.Show("确定删除该商品信息？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            SqlCommand cmdd1 = new SqlCommand("delete  from gd_comsump  where gd_comsump.G_name='" + textBox1.Text + "'", Con);
                            cmdd1.ExecuteNonQuery();

                            SqlCommand cmdd = new SqlCommand("delete  from goods  where G_name='" + textBox1.Text + "'", Con);
                            cmdd.ExecuteNonQuery();
                            textBox1.Clear();
                        }
                       // SqlCommand cmdd1 = new SqlCommand("create trigger tr_delete on good for delete as delete from gd_comsump where  in(select id from deleted), Con);
                        //cmdd1.ExecuteNonQuery();
                      
                        S_GD_Load(null, null);
                    }

                    else
                    {
                        MessageBox.Show("无此商品", "操作提示");
                        Dr.Close();
                    }
                }
            }

            count = count - 1;


            S_GD_Load(null, null);

            Con.Close();
            //   S_GD_Load(null, null);
        }

        private void S_GD_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“myhotelDataSet1.goods”中。您可以根据需要移动或移除它。
            
            this.goodsTableAdapter.Fill(this.myhotelDataSet.goods);

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string cellvalue;
            string headtext;
            Pen pen = new Pen(Color.Black, 2);
            int colcount = dataGridView1.ColumnCount;//获取打印数据的列数
            int rowcount = dataGridView1.RowCount;//获取打印数据的行数
           for (int i = 0; i <= colcount; i++)
            {
                e.Graphics.DrawLine(pen, 100 + i * 150, 100, 100 + i* 150, 100 + (rowcount + 1) * 70);
            //   headtext = dataGridView1.Columns[0].HeaderText;//获取列标题
//
                //绘制标题栏文字

           //  e.Graphics.DrawString(headtext, new Font("宋体", 20, FontStyle.Regular), Brushes.Black, 100 +0* 100, 100);//绘制列标题

             }
            for (int i = 0; i <= colcount-1 ; i++)
            {
               headtext = dataGridView1.Columns[i].HeaderText;//获取列标题

                //绘制标题栏文字

              e.Graphics.DrawString(headtext, new Font("宋体", 20, FontStyle.Regular), Brushes.Black, 100 + i* 150, 100+20);//绘制列标题
          }
            for (int j= 0; j <= (rowcount+1); j++)
            {
                e.Graphics.DrawLine(pen, 100 , 100+j*70, 100+(colcount)* 150, 100 + j*70);

            }


            for (int j = 0; j < rowcount; j++)  //行循环
            {
                for (int i = 0; i < colcount ; i++)   //列循环
                {
                    cellvalue = dataGridView1.Rows[j].Cells[i].Value.ToString();//获取单元格的值

                    e.Graphics.DrawString(cellvalue, new Font("宋体", 20, FontStyle.Regular), Brushes.Black, 100 + i * 150, 100 + 20+(j+1)*70);

                }
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
            printPreviewDialog1.Document = this.printDocument1;
            printPreviewDialog1.ShowDialog();

           
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Con.ConnectionString = "Data Source=(local);Initial Catalog=myhotel;Integrated Security=True";//数据库连接字符串
            Con.Open();
            string str = textBox3.Text;
            S_GD_Load(null, null);




            //链接并打开数据库
            if (textBox1.Text != "" && textBox3.Text != "")
            {

                SqlCommand selectgood = new SqlCommand("select * from goods where g_name='" + textBox1.Text + "'", Con);
                SqlDataReader Dr = selectgood.ExecuteReader();
                //  SqlCommand selectgood = new SqlCommand("select count * from goods where g_name='" + textBox1.Text + "'", Con);
                S_GD_Load(null, null);

                if (Dr.Read())
                //  if(selectgood)
                {
                    MessageBox.Show("商品名称重复！", "操作提示");
                    textBox1.Clear();

                    textBox3.Clear();
                    Dr.Close();
                    //   return;
                }

                else
                {
                    Dr.Close();
                    //执行添加记录操作
                    string str1 = textBox1.Text.Trim();

                    int a = str1.Length;
                    if (a <= 10)
                    {
                        if (isinter(str))
                        {
                            if (MessageBox.Show("确定添加该商品信息？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                string InsertString = "insert into goods values('" + textBox3.Text + "','" + textBox1.Text + "')";//初始房间为空 没人住
                                SqlCommand MyCommand = new SqlCommand(InsertString, Con);//设置Mycommand中commandText和Connection属性，为使用非查询连接配置参数
                                MyCommand.ExecuteNonQuery();//执行非查询连接——>这里为插入

                                //实时将DataSet中内容更新到GirdView
                                goodsTableAdapter.Fill(myhotelDataSet.goods);
                                textBox1.Clear();

                                textBox3.Clear();
                                count = 5;
                                MessageBox.Show("数据添加成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }


                        else
                        {
                            MessageBox.Show("商品价格必须为数字", "操作提示");
                            textBox3.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("商品名称太长，请重新输入", "操作提示");
                        textBox1.Clear();
                    }
                }


            }
            else
            {
                MessageBox.Show("请正确填写商品信息!", "提示");
            }
            //关闭数据库
            Con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Con.ConnectionString = "Data Source=(local);Initial Catalog=myhotel;Integrated Security=True";//数据库连接字符串
            Con.Open();

            string sql10 = "select count (*) from goods where g_name='" + textBox1.Text.Trim() + "'";

            SqlCommand myqureycommand10 = new SqlCommand(sql10, Con);
            if ((int)myqureycommand10.ExecuteScalar() != 1)
            {
                MessageBox.Show("此商品不存在!", "提示");

                textBox1.Clear();
                textBox3.Clear();
                Con.Close();
                return;


            }

            string sql = "select g_price from goods where g_name='" + textBox1.Text.Trim() + "'";
            SqlCommand myqureycommand1 = new SqlCommand(sql, Con);
            string price = myqureycommand1.ExecuteScalar().ToString();
            textBox3.Text = price;
            //  textBox3.Text = "123";
            Con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Con.ConnectionString = "Data Source=(local);Initial Catalog=myhotel;Integrated Security=True";//数据库连接字符串
            Con.Open();
                
            string str = textBox3.Text;
            //修改信息

            string sql10 = "select count (*) from goods where g_name='" + textBox1.Text.Trim() + "'";
           
            SqlCommand myqureycommand10 = new SqlCommand(sql10, Con);
            if ((int)myqureycommand10.ExecuteScalar() != 1)
            {
                MessageBox.Show("此商品不存在!", "提示");
               
                textBox1.Clear();
                textBox3.Clear();
                Con.Close();
                return;


            }

          
       
            if (isinter(str))
            {
               
                if (MessageBox.Show("确定修改该商品信息？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    SqlCommand cmd = new SqlCommand("Update goods set G_price='" + Convert.ToDouble(textBox3.Text) + "' where G_name='" + textBox1.Text + "'", Con);
                    cmd.ExecuteNonQuery();
                    textBox1.Clear();

                    textBox3.Clear();
                }
            }
            else
            {
                MessageBox.Show("商品价格必须为数字", "操作提示");
            }
            S_GD_Load(null, null);
            Con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Con.ConnectionString = "Data Source=(local);Initial Catalog=myhotel;Integrated Security=True";//数据库连接字符串
            Con.Open();
            if (count < 0)
            {

                MessageBox.Show("您的删除次数过多，已不能进行删除", "警告");
                //ccount=1;
            }
            //if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
            else
            {

                if (textBox1.Text == "")
                {
                    if (MessageBox.Show("确定删除该商品信息？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        SqlCommand cmdd2 = new SqlCommand("delete  from gd_comsump  where gd_comsump.G_name='" + textBox1.Text + "'", Con);
                        cmdd2.ExecuteNonQuery();

                        dataGridView1.Rows.Remove(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex]);//在DataGridView1界面上进行可视化删除

                        goodsTableAdapter.Update(myhotelDataSet.goods);  //将删除变化更新至数据库

                        // goodsTableAdapter.Update(myhotelDataSet1.gd_comsump);

                        // MessageBox.Show("请输入要删除的商品名称", "操作提示");
                    }

                }

                else
                {


                    SqlCommand cmd = new SqlCommand("select * from goods  where G_name='" + textBox1.Text + "'", Con);

                    SqlDataReader Dr = cmd.ExecuteReader();

                    if (Dr.Read())
                    {
                        Dr.Close();
                        if (MessageBox.Show("确定删除该商品信息？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            SqlCommand cmdd1 = new SqlCommand("delete  from gd_comsump  where gd_comsump.G_name='" + textBox1.Text + "'", Con);
                            cmdd1.ExecuteNonQuery();

                            SqlCommand cmdd = new SqlCommand("delete  from goods  where G_name='" + textBox1.Text + "'", Con);
                            cmdd.ExecuteNonQuery();
                            textBox1.Clear();
                        }
                        // SqlCommand cmdd1 = new SqlCommand("create trigger tr_delete on good for delete as delete from gd_comsump where  in(select id from deleted), Con);
                        //cmdd1.ExecuteNonQuery();

                        S_GD_Load(null, null);
                    }

                    else
                    {
                        MessageBox.Show("无此商品", "操作提示");
                        Dr.Close();
                    }
                }
            }

            count = count - 1;


            S_GD_Load(null, null);

            Con.Close();
        }

    
    }
}
