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
    public partial class S_PW : Form
    {
        public S_PW()
        {
            InitializeComponent();
        }

        private void XT_PW_Load(object sender, EventArgs e)
        {

        }
        private String  Password_check()
        {
            //检查当前密码与用户名是否匹配
            String  re;
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=myhotel;Integrated Security=True");
            conn.Open();
            String S = "select count(*) from stuff where s_pw='" + password.Text + "' AND s_name='" + username + "'";
            SqlCommand cmd = new SqlCommand(S, conn);
            re =cmd.ExecuteScalar().ToString ();
            conn.Close();
            return re;
        }
        /*private void Edit_oldrecord(String key,String pass)
        {
            //修改记录
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=myhotel;Integrated Security=True");
            conn.Open();
            //打开数据库
            SqlDataAdapter da = new SqlDataAdapter("Select * From stuff",conn); //确定数据库操作时从数据源中选出stuff表，填充到数据集
            SqlCommandBuilder build = new SqlCommandBuilder(da);//自动生成更新数据源的SQL语句 
            DataSet ds = new DataSet();//实例化数据集
            da.Fill(ds, "stuff");//将数据填充到数据集
            DataRow[] sat = ds.Tables["stuff"].Select("s_name='"+key+"'");      //把那一行记录select出来，第一行
            sat[0]["s_pw"] = pass;//修改那一行记录
            da.Update(ds,"stuff"); //将变化又更新回数据源
            conn.Close();
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=myhotel;Integrated Security=True");
            con.Open();
            String SQLString = "select count(*) from stuff where s_pw='" + password.Text + "' AND s_name='" + username.Text + "'";

            SqlCommand cmd = new SqlCommand(SQLString, con);
            string t = cmd.ExecuteScalar().ToString();
           //con.Close();
            if (username.Text == "")
            {
                MessageBox.Show("用户名不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                password.Focus();
                return;
            }
            if (password.Text == "")
            {
                MessageBox.Show("请输入当前密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                password.Focus();
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("请输入新密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox3.Focus();
                return;
            }
            if (textBox3.Text == password.Text)
            {
                MessageBox.Show("新密码不能与原密码相同", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error );
                textBox3.Focus();
                return;
            }
            if (textBox4.Text == textBox3.Text)
            {
                
                if (t == "1")
                {
                   
                    SqlCommand com = new SqlCommand("Update stuff set s_pw='" + textBox3.Text + "' where s_name='" + username.Text + "'", con);
                    int to=com.ExecuteNonQuery();
                    con.Close();
                    if (to == 1)
                    {
                        MessageBox.Show("密码修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("系统出错，密码修改失败。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error );
 
                    }

                }
                else
                {
                    MessageBox.Show("用户名或当前密码错误，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error ); 
                }
            }
            else
            {
                MessageBox.Show("两次密码输入不同，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error );
                textBox4.Focus();
                return;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

       
        
    }
}
