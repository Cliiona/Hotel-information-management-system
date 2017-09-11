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
    public partial class S_QX : Form
    {
        public S_QX()
        {
            InitializeComponent();

        }

        private int Key_check(String str)
        {
            int re;
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=myhotel;Integrated Security=True");
            conn.Open();
            String S = "select count(*) from stuff where s_name='" +str+ "'";
            SqlCommand cmd = new SqlCommand(S, conn);
            re = (int)cmd.ExecuteScalar();
            return re;
        }
        private int counts = 5;//限制连续删除操作
        private void S_QX_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“myhotelDataSet.stuff”中。您可以根据需要移动或移除它。
            this.stuffTableAdapter.Fill(this.myhotelDataSet.stuff);
            // TODO: 这行代码将数据加载到表“myhotelDataSet.stuff”中。您可以根据需要移动或移除它。
            this.stuffTableAdapter.Fill(this.myhotelDataSet.stuff);
            // TODO: 这行代码将数据加载到表“myhotelDataSet.stuff”中。您可以根据需要移动或移除它。
            this.stuffTableAdapter.Fill(this.myhotelDataSet.stuff);
            // TODO: 这行代码将数据加载到表“testDataSet.Entity_1”中。您可以根据需要移动或移除它。
            
            // TODO: 这行代码将数据加载到表“myhotelDataSet.user”中。您可以根据需要移动或移除它。
            
            // TODO: 这行代码将数据加载到表“myhotelDataSet.user”中。您可以根据需要移动或移除它。
          

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            int t1 = 0, t2 = 0, t3 = 0, t4 = 0, t5 = 0, t6 = 0;
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=myhotel;Integrated Security=True");
            con.Open();      //打开数据库
            counts = 5;//保持counts的值不会轻易减少

            //检查权限选择情况
            if (checkBox1.Checked == true)
            {
                t1 = 1;
            }
            if (checkBox2.Checked == true)
            {
                t2 = 1;
            }
            if (checkBox3.Checked == true)
            {
                t3 = 1;
            }
            if (checkBox4.Checked == true)
            {
                t4= 1;
            }
            if (checkBox5.Checked == true)
            {
                t5 = 1;
            }
            if (checkBox6.Checked == true)
            {
                t6 = 1;
            }
            
            //判断是否执行添加操作

            if (TextBox1.Text.Length <= 10 && TextBox2.Text.Length >= 6 && TextBox2.Text.Length <= 20 && TextBox3.Text.Length <= 200 && Key_check(TextBox1.Text)==0)
            {
                String SQLString = "insert into stuff values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + " ','" + t1 + "','" + t2 + "','" + t3 + "','" + t4 + "','" + t5 + "','" + t6 + "')";
                SqlCommand cmd = new SqlCommand(SQLString, con);
                cmd.ExecuteNonQuery();//执行对数据库的插入操作
                stuffTableAdapter.Fill(myhotelDataSet.stuff);  //将数据库操作及时更新在GridView中
 
            }
            else if (TextBox1.Text.Length==0)
            {
                MessageBox.Show("用户名不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (TextBox1.Text.Length > 10)
            {
                MessageBox.Show("用户名超过长度限制！","提示",MessageBoxButtons.OK,MessageBoxIcon.Error  );
            }
            else if (TextBox2.Text.Length<6||TextBox2.Text.Length>20 )
            {
                MessageBox.Show("密码长度在6—20位之间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            else if (TextBox3.Text.Length>200)
            {
                MessageBox.Show("说明不能超过200个字符！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            else if (Key_check(TextBox1.Text) > 0)
            {
                MessageBox.Show("用户名已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
 
            }


            //con.Close();  //关掉数据库连接

            //清空文本框内容
            TextBox1.Clear();
            TextBox2.Clear();
            TextBox3.Clear();
            checkBox3.Checked = false;
            checkBox2.Checked = false;
            checkBox1.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;

 
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[0].Value.ToString () != "李显贵")
            {
                if (counts > 0)
                {
                    if (MessageBox.Show("确定要删除该用户？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        dataGridView1.Rows.Remove(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex]);//在DataGridView1界面上进行可视化删除
                        stuffTableAdapter.Update(myhotelDataSet.stuff);  //将删除变化更新至数据库
                        counts--;
                    }
                }
                else
                {
                    MessageBox.Show("您的删除操作过于频繁，被系统禁止！", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                }
 
            }
        
            
        }

      
   }
}
