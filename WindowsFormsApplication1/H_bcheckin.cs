using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class H_bcheckin : Form
    {

        SqlConnection myCon = new SqlConnection();
        DataTable table = new DataTable();
        string CString = "Data Source=(local);Initial Catalog=myhotel;Integrated Security=True";
        int flag;//用来避免没有选择就显示的combobox

        public H_bcheckin(String str)
        {
            InitializeComponent();
          //  Staff.ReadOnly = true;
            Staff.Text = str;
            OutTime.Value = InTime.Value.AddDays(1);
           
           /* condb();
            myclear();//清空输入框
            table.Clear();
            InTime.Value = System.DateTime.Today;//设置入住时间为当日日期
            this.room_priceTableAdapter.Fill(this.myhotelDataSet.room_price);
            //将有效预定的客户id放入身份证号的datasource中
            string ivalid = "select c_id from book where b_intime='" + System.DateTime.Today + "' and b_valid=1";
            SqlCommand icom = new SqlCommand(ivalid, myCon);
            SqlDataAdapter iad = new SqlDataAdapter(icom);
            iad.Fill(table);
            ID.DataSource = table;
            ID.DisplayMember = "c_id";
            flag = 0;
            ID.SelectedIndex = -1;
            flag = 1;
            myCon.Close();*/

            //不选择下拉列表不显示
            this.RoomType.SelectedIndex = -1;
        }

        public void H_bcheckin_Load(object sender, EventArgs e)
        {
          
            condb();
            myclear();//清空输入框
            table.Clear();
            InTime.Value = System.DateTime.Today;//设置入住时间为当日日期
            this.room_priceTableAdapter.Fill(this.myhotelDataSet.room_price);
            //将有效预定的客户id放入身份证号的datasource中
            string ivalid = "select c_id from book where b_intime='"+System.DateTime.Today+"' and b_valid=1";
            SqlCommand icom = new SqlCommand(ivalid,myCon);
            SqlDataAdapter iad = new SqlDataAdapter(icom);
            iad.Fill(table);
            ID.DataSource = table;
            ID.DisplayMember = "c_id";
            flag = 0;
            ID.SelectedIndex = -1;
            flag = 1;
            myCon.Close();
          
            //不选择下拉列表不显示
            this.RoomType.SelectedIndex = -1;
            
        }

        //右半屏幕
        private void RoomType_SelectedValueChanged(object sender, EventArgs e)
        {
            condb();
            //显示空闲的特定类型的房间
            string SelectString = "select r_no AS '房号',r_price AS '房价',r_hold AS '可容纳人数',r_stair AS '楼层' from room where r_full='0' AND r_type='" + RoomType.Text + "'";
            SqlCommand MyCom = new SqlCommand(SelectString, myCon);
            //建立临时表
            SqlDataAdapter MyAdapter = new SqlDataAdapter(MyCom);
            DataTable ShowTable = new DataTable();
            MyAdapter.Fill(ShowTable);
            this.ValidRoom.DataSource = ShowTable;
            myCon.Close();
            
        }
        private void ID_SelectedValueChanged(object sender, EventArgs e)
        {
            condb();//调用数据库连接方法
            if (flag==1)
            {
                string SelectString1 = "select customer.c_name,customer.c_phone,book.r_no,book.b_intime,book.b_outtime,book.b_remark,book.b_rtype FROM customer,book WHERE customer.c_id='" + ID.Text + "'AND book.c_id='" + ID.Text + "' AND b_valid=1 and book.b_intime='"+System.DateTime.Today+"'";
                
                SqlCommand com1 = new SqlCommand(SelectString1, myCon);
                
                SqlDataReader rd =com1.ExecuteReader();

                if (rd.Read())
                {
                    if (rd["r_no"].ToString() != "")
                    {
                        CusType .Text=rd["b_rtype"].ToString();
                        CName.Text = rd["c_name"].ToString();
                        PhoneNo.Text = rd["c_phone"].ToString();
                        RoomNo.Text = rd["r_no"].ToString();
                        InTime.Text = rd["b_intime"].ToString();
                        OutTime.Text = rd["b_outtime"].ToString();
                        Remark.Text = rd["b_remark"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("此用户暂时没有预定，或者已完成入住！","温馨提示");
                    }
                    
                }
                rd.Close();
            }
        }


        //保存入住界面
        private void Save_Click(object sender, EventArgs e)
        {
            if ( ID.Text != "" & CName.Text != "" & PhoneNo.Text != "" & RoomNo.Text != "" & Deposit.Text != "" & Staff.Text != "")
            {
                //将入住记录存入checkin中
                condb();
                string InsertString1 = "insert into checkin values('" + RoomNo.Text + "','" + ID.Text + "','" + InTime.Value.ToString("yyyy-MM-dd") + "','" + OutTime.Value.ToString("yyyy-MM-dd") + "','" + Deposit.Text + "','" + Staff.Text + "','" + Remark.Text + "','1',(select b_rtype from book where c_id='" + ID.Text + "'))";
                SqlCommand insert1 = new SqlCommand(InsertString1, myCon);
                insert1.ExecuteNonQuery();

                //删除book中该客户的预定记录,但不会删除后面的预定情况
                SqlCommand up1 = new SqlCommand("delete from book where r_no='"+RoomNo.Text+"' and b_valid=1 and b_intime='"+System.DateTime.Today+"'",myCon);
                up1.ExecuteNonQuery();

                //修改room的r_full （2->1）
                SqlCommand up2 = new SqlCommand("update room set r_full=1 where r_no='"+RoomNo.Text+"'and r_full=2",myCon);
                up2.ExecuteNonQuery();

                myCon.Close();
                MessageBox.Show("入住成功！", "温馨提示");
                H_bcheckin_Load(null, null);//刷新页面

            }
            else
            {
                memo.Text = "除备注外不能为空";
            }
        }

        //数据库连接方法，方便调用，节约代码
        public void condb()
        {
            if (myCon.State == ConnectionState.Closed)//其中ConnectionState是一个枚举类型.Closed为其成员之一
            {
                myCon.ConnectionString = CString;
                myCon.Open();
            }
        }

        //清空输入
        public void myclear()
        {
           // ID.Text = "";
            CName.Clear();
            PhoneNo.Clear();
            RoomNo.Clear();
            Deposit.Clear();
            Staff.Clear();
            Remark.Clear();
        }

        private void ID_Validated(object sender, EventArgs e)
        {
            if (ID.Text != "")
            {
                int f = 0;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (table.Rows[i][0].ToString().Trim() == ID.Text.ToString().Trim())
                    {
                        f = 1;
                        ///////ID_SelectedValueChanged(null, null);千万不能触发！系统会自动触发的
                        break;
                    }
                }
                if (f == 0)
                {
                    MessageBox.Show("该顾客今日没有预定记录", "温馨提示");
                    myclear();
                }
            }
        }
    }
}
