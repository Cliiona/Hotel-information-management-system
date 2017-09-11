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
    public partial class V_mgt : Form
    {

        public V_mgt(int a)
        {
            InitializeComponent();
            if (a == 1)
            {
                button2.Enabled = true;//激活注销按钮
            }
         
        }
        private int Record_check(String str)
        {
            int re=1;
            int  t1 = 0, t2 =1, t3 = 1, t4 = 0, t5 = 0, t6 = 0, t7 = 0;
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=myhotel;Integrated Security=True");
            conn.Open();
            String S = "select * from vip where v_id='" + str + "'";
            SqlCommand com = new SqlCommand(S, conn);
            SqlDataReader Dr = com.ExecuteReader();
            if (Dr.Read())
            {
                if (Dr["v_name"].ToString() == textBox2.Text) t1 = 1;
                if (Dr["v_gender"].ToString() == "m" && radioButton2.Checked == true) t2 = 0;
                if (Dr["v_no"].ToString() == textBox4.Text) t4 = 1;
                if (Dr["v_phone"].ToString() == textBox5.Text) t5 = 1;
                if (Dr["v_mail"].ToString() == textBox6.Text) t6 = 1;
                if (Dr["v_remark"].ToString() == textBox7.Text) t7=1;
                if (t1 * t2 * t3 * t4 * t5 * t6 * t7 == 0) re = 0;
            }
            else
            {
                re = 0;
 
            }
            Dr.Close();
            conn.Close();
            return re;
        }

        private void V_mgt_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“myhotelDataSet.vip”中。您可以根据需要移动或移除它。
            this.vipTableAdapter.Fill(this.myhotelDataSet.vip);
            // TODO: 这行代码将数据加载到表“myhotelDataSet.vip”中。您可以根据需要移动或移除它。
        
            // TODO: 这行代码将数据加载到表“myhotelDataSet.vip”中。您可以根据需要移动或移除它。
          
           

        }

  
        private void 添加VIP客户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            info.Visible = true;


        } 
    

     


        private void save_Click(object sender, EventArgs e)
        {
            String t1 = "m";
            if (radioButton2.Checked == true)
            {
                t1 = "f";  //女
            }
            if (Record_check(textBox3.Text) == 0)
           {
             SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=myhotel;Integrated Security=True");
             con.Open();      //打开数据库
             String SQLString = "insert into vip values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + " ','" + textBox5.Text + "','" + t1 + "','" + textBox6.Text + "',1,'" + textBox7.Text + "')";
             SqlCommand cmd = new SqlCommand(SQLString, con);
             int r = cmd.ExecuteNonQuery();//执行对数据库的插入操作

             con.Close();
                if (r == 1)
                {
                    MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vipTableAdapter.Fill(myhotelDataSet.vip);  //将数据库操作及时更新在GridView中
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    // this.Close();
                }
                else
                {
                    MessageBox.Show("保存失败，请重试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }


            }
            else
            {
                MessageBox.Show("该用户已成为VIP用户，不能重复登记！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                radioButton1.Checked = true;
                radioButton2.Checked = false;

            }
            

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            info.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)  //注销
        {
            if (MessageBox.Show("确定要注销该VIP客户？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (DataGridViewRow row in this.dataGridView1.Rows)//遍历每行
                {

                    if (Convert.ToBoolean(row.Cells[0].Value) == true)
                    {
                        String vipno = row.Cells[4].Value.ToString();
                        this.dataGridView1.Rows.Remove(row);
                       
                     

                    }


                }//可视化删除
                vipTableAdapter.Update(myhotelDataSet.vip);  //将删除变化更新至数据库
            }
            
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            //全选、取消全选
            foreach (DataGridViewRow dr in this.dataGridView1.Rows)
            {
                dr.Cells["Column1"].Value = checkBox1.Checked;
            }

        }//全选

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)//反选
        {
            foreach (DataGridViewRow dr in this.dataGridView1.Rows)
            {
                if (dr.Cells["Column1"].Value == null)
                {
                    dr.Cells["Column1"].Value = true;
                }
                else
                {
                    dr.Cells["Column1"].Value = !(bool)dr.Cells["Column1"].Value;
                }
            }

        }


        private void button3_Click(object sender, EventArgs e)  //编辑
        {
            String vipno = null;
            textBox4.ReadOnly = true;

            foreach (DataGridViewRow row in this.dataGridView1.Rows)//遍历每行
            {

                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    vipno = row.Cells[4].Value.ToString();
                  //  this.dataGridView1.Rows.Remove(row);
                    break;
                }
             }
            if (vipno != null)
            {
                String t1 = null, t2 = null, t3 = null, t4 = null, t5 = null, t6 = null, t7 = null;
                SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=myhotel;Integrated Security=True");
                conn.Open();
                String S = "select * from vip where v_no='" + vipno + "'";
                SqlCommand com = new SqlCommand(S, conn);
                SqlDataReader Dr = com.ExecuteReader();
               if (Dr.Read())
                {
                    t1 = Dr["v_name"].ToString();
                    t2 = Dr["v_gender"].ToString();
                    t3 = Dr["v_id"].ToString();
                    t4 = Dr["v_no"].ToString();
                    t5 = Dr["v_phone"].ToString();
                    t6 = Dr["v_mail"].ToString();
                    t7 = Dr["v_remark"].ToString();
                }
                Dr.Close();
                conn.Close();
                if(t2=="f")
                {
                    radioButton2.Checked = true;
                    radioButton1.Checked = false;
                 }
                textBox2.Text = t1;
                textBox3.Text = t3;
                textBox4.Text = t4;
                textBox5.Text = t5;
                textBox6.Text = t6;
                textBox7.Text = t7;
               // vipTableAdapter.Update(myhotelDataSet.vip);  //将删除变化更新至数据库
                info.Visible = true;
                

            }
            else
            {
                MessageBox.Show("请选择要编辑的VIP客户信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            info.Visible = true;
        }
    }
}
