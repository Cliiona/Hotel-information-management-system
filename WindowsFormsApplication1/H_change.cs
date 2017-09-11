using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; //
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class H_change : Form
    {
        public H_change()
        {
            InitializeComponent();
        }

      
        private void ChangeRoom_Load_1(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“hotelDataSet.checkin”中。您可以根据需要移动或移除它。
            
        }
        
    
        private void Search_Click(object sender, EventArgs e)
        {
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {/*
            SqlConnection co = new SqlConnection("Data Source=.;Initial Catalog=myhotel;Integrated Security=True");
            co.Open();
            String  S = "SELECT c_intime,c_outtime from checkin  where r_no ='" + textBox1.Text + "'";
            SqlCommand ca = new SqlCommand(S, co);
            SqlDataReader DR = ca.ExecuteReader();
            String T1 = DR["c_intime"].ToString();
            String T2 = DR["c_outtime"].ToString();



            //查询。。时间段问题
            S = null;
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=myhotel;Integrated Security=True");
            con.Open();
            if (comboBox1.Text == "单人间")
            {
                S = "SELECT r_no AS '房号',r_price AS '单价',r_stair AS '楼层',r_hold AS '可容纳人数',r_remark AS '备注'    from  room  where (r_full=1 and r_no=(select r_no from checkin where '" + T1 + "'>=c_outtime))OR( r_full=0 and r_type='单人间')OR(r_full=1 and r_no=(select r_no from book where ( b_intime>='" + T2 + "')))";
            }
            if (comboBox1.Text == "标准间")
            {
                S = "SELECT r_no AS '房号',r_price AS '单价',r_stair AS '楼层',r_hold AS '可容纳人数',r_remark AS '备注'    from  room  where (r_full=1 and r_no=(select r_no from checkin where '" + T1 + "'>=c_outtime))OR( r_full=0 and r_type='标准间')OR(r_full=1 and r_no=(select r_no from book where ( b_intime>='" + T2 + "')))";
            }
            if (comboBox1.Text == "三人间")
            {
                S = "SELECT r_no AS '房号',r_price AS '单价',r_stair AS '楼层',r_hold AS '可容纳人数',r_remark AS '备注'    from  room  where (r_full=1 and r_no=(select r_no from checkin where '" + T1 + "'>=c_outtime))OR( r_full=0 AND r_type='三人间')OR(r_full=1 and r_no=(select r_no from book where ( b_intime>='" + T2 + "')))";

            }
            if (comboBox1.Text == "大床房")
            {
                S = "SELECT r_no AS '房号',r_price AS '单价',r_stair AS '楼层',r_hold AS '可容纳人数',r_remark AS '备注'    from  room  where (r_full=1 and r_no=(select r_no from checkin where '" + T1 + "'>=c_outtime))OR( r_full=0 and r_type='大床房')OR(r_full=1 and r_no=(select r_no from book where ( b_intime>='" + T2 + "')))";

            }
            if (comboBox1.Text == "所有房间")
            {
                S = "SELECT r_no AS '房号',r_price AS '单价',r_stair AS '楼层',r_hold AS '可容纳人数',r_remark AS '备注'    from  room  where (r_full=1 and r_no=(select r_no from checkin where '" + T1 + "'>=c_outtime))OR( r_full=0)OR(r_full=1 and r_no=(select r_no from book where ( b_intime>='" + T2 + "')))";

            }

            SqlDataAdapter dat = new SqlDataAdapter(S, con);
            DataSet dst = new DataSet();
            dat.Fill(dst, "room");
            dataGridView2.DataSource = dst.Tables["room"].DefaultView;
            con.Close(); */
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String T1 = null, T2 = null;
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=myhotel;Integrated Security=True");
            conn.Open();
            String S = "SELECT room.r_no as'房号',r_price as'价格',c_account as '预收押金',c_intime as '入住时间',c_outtime as '离开时间' from room ,checkin where room.r_no ='"+textBox1 .Text +"' and checkin.r_no=room.r_no";
            SqlDataAdapter da = new SqlDataAdapter(S, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "checkin");
            dataGridView1.DataSource = ds.Tables["checkin"].DefaultView;
            conn.Close();
            
            SqlConnection co = new SqlConnection("Data Source=.;Initial Catalog=myhotel;Integrated Security=True");
            co.Open();
            S = "SELECT c_intime,c_outtime from checkin  where r_no ='" + textBox1.Text + "'";
            SqlCommand ca = new SqlCommand(S, co);
            SqlDataReader DR = ca.ExecuteReader();
            if (DR.Read())
            {
                T1 = DR["c_intime"].ToString();
                T2 = DR["c_outtime"].ToString();
                
            }
            DR.Close();
            co.Close();
              S = null;
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
            dataGridView2.DataSource = dst.Tables["room"].DefaultView;
            con.Close(); 

            
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int t1 = 0, t2 = 0, t3 = 0, t4 = 0;
            String vipno = null;
            String c1 = null, c2 = null, c3 = null, c4 = null, c5 = null, c6 = null, c7 = null;
            foreach (DataGridViewRow row in this.dataGridView2.Rows)//遍历每行
            {
                
                if (Convert.ToBoolean(row.Cells["Column1"].Value) == true)
                {
                    vipno = row.Cells["房号"].Value.ToString();
                    //  this.dataGridView1.Rows.Remove(row);
                    break;
                }

            }
            if (vipno != null)
            {
                
                 
                if (MessageBox.Show("是否确定将客户从客房" + textBox1.Text + "换至客房" + vipno + "？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=myhotel;Integrated Security=True");
                    conn.Open();
                    String ctime = DateTime.Now.ToString("yyyy-MM-dd");
                    
                
                        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=myhotel;Integrated Security=True");
                        con.Open();
                        String S = "SElect * from checkin where r_no='" + textBox1.Text + "'AND c_valid=1";
                        SqlCommand cc = new SqlCommand(S, con);
                        SqlDataReader DR = cc.ExecuteReader();
                        if (DR.Read())
                        {
                            c1 = DR[0].ToString();
                            c2 = DR[1].ToString();
                            c3 = DR[3].ToString();
                            c4 = DR[4].ToString();
                            c5 = DR[5].ToString();
                            c6 = DR[6].ToString();
                            c7 = DR[8].ToString();
                            DR.Close();
                            con.Close();

                        }
                        S = "update checkin set c_outtime='" + ctime + "',c_valid=2 where r_no='" + textBox1.Text + "'";      //有效性2表示曾住房，但未结账
                        SqlCommand com = new SqlCommand(S, conn);
                        t1 = com.ExecuteNonQuery();
                        S = "update room set r_full=0 where r_no='" + textBox1.Text + "'";
                        SqlCommand co = new SqlCommand(S, conn);
                        t2 = co.ExecuteNonQuery();
                        S = "update room set r_full=1 where r_no='" + vipno + "'";
                        SqlCommand cmd = new SqlCommand(S, conn);
                        t3 = cmd.ExecuteNonQuery();
                        S = "insert into checkin values('" +vipno+ "','" + c2 + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + c3 + "','" + c4 + "','" + c5 + "','" + c6 + "',1,'" + c7 + "')";
                        SqlCommand cm = new SqlCommand(S, conn);
                        t4 = cm.ExecuteNonQuery();
                        if (t1 * t2 * t3 * t4 == 1)
                        {
                            MessageBox.Show("换房成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            textBox1.Clear();
                            comboBox1.SelectedIndex = -1;
                        }
                    
                 
                  
                }

 
            }
            
        }

        
       

    }
}
