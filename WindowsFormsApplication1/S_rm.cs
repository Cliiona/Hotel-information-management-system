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
    public partial class S_rm : Form
    {
        SqlConnection myCon = new SqlConnection();
        string CString = "Data Source=(local);Initial Catalog=myhotel;Integrated Security=True"; //数据库连接字符串
        public S_rm()
        {
            InitializeComponent();
        }
  
        //String AdapterString = "SELECT * FROM room";
        //SqlDataAdapter radapter = new SqlDataAdapter(AdapterString, myCon);
        //radapter.Fill( myhotelDataSet, "room");// Fill 是DataAdapter的一个方法 ，因rDataGridView与roomBingdingSource(属于myhotelDataSet)相连接，故后者更新，前者也随之更新 

        public void S_rm_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“myhotelDataSet.room_price”中。您可以根据需要移动或移除它。
            //this.room_priceTableAdapter1.Fill(this.myhotelDataSet.room_price);
            this.roomTableAdapter.Fill(this.myhotelDataSet.room);
        }

        //删除点击的一行房间记录
        private void RoomDelete_Click(object sender, EventArgs e)
        {
             if (MessageBox.Show("确定删除该房间记录？","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question ) == DialogResult.OK)
              {
                  RoomDataGridView.Rows.Remove(RoomDataGridView.Rows[RoomDataGridView.CurrentCell.RowIndex]);//在DataGridView1界面上进行可视化删除
                  roomTableAdapter.Update(myhotelDataSet.room);  //将删除变化更新至数据库
              }
        }

        //打开修改房费界面
        private void ChangeRoomPrice_Click(object sender, EventArgs e)
        {
            S_rm_cp f = new S_rm_cp(S_rm_Load);                                    //定义界面
            f.MdiParent = this.MdiParent;                                 //子界面
            f.Show();
        }
        
        //打开添加界面
        private void DataGridViewAdd_Click(object sender, EventArgs e)
        {
            S_rm_add f = new S_rm_add(S_rm_Load);//实时将DataSet中内容更新到GirdView
            f.MdiParent = this.MdiParent;                                 //子界面
            f.Show();
        }

        //修改房价按钮颜色变化
        private void ChangeRoomPrice_MouseEnter(object sender, EventArgs e)
        {
            ChangeRoomPrice.ForeColor = System .Drawing .Color.RoyalBlue;
        }
        private void ChangeRoomPrice_MouseLeave(object sender, EventArgs e)
        {
            ChangeRoomPrice.ForeColor = System.Drawing.Color.Black;
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

        private void SearchWay_SelectedValueChanged(object sender, EventArgs e)
        {
            Search.Visible = true;
            if(SearchWay.Text!=null)
            {
                if (SearchWay.Text == "房型")
                {                
                    roomtype.Visible = true;
                    roomno.Visible =false;
                    stair.Visible = false;
                }
                else if (SearchWay.Text == "房号")
                {
                    roomtype.Visible = false;
                    roomno.Visible = true;
                    stair.Visible = false;
                }
                else if (SearchWay.Text == "楼层")
                {
                    roomtype.Visible = false;
                    roomno.Visible = false;
                    stair.Visible = true;
                }
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            if ((roomtype.Text.Length + roomno.Text.Length+stair.Text.Length)>0)
            {
                condb();
                DataTable showtable = new DataTable();
                if (SearchWay.Text == "房型")
                {
                    string SelectString = "select * FROM room where r_type='" + roomtype.Text + "'";
                    SqlCommand com = new SqlCommand(SelectString, myCon);
                    SqlDataAdapter showa = new SqlDataAdapter(com);//确定这个适配器作为那个连接的适配器
                    showa.Fill(showtable);
                }
                else if (SearchWay.Text == "房号")
                {
                    string SelectString = "select * FROM room where r_no='" + roomno.Text + "'";
                    SqlCommand com = new SqlCommand(SelectString, myCon);
                    SqlDataAdapter showa = new SqlDataAdapter(com);//确定这个适配器作为那个连接的适配器
                    showa.Fill(showtable);
                }
                else if (SearchWay.Text == "楼层")
                {
                    string SelectString = "select * FROM room where r_stair='" + stair.Text + "'";
                    SqlCommand com = new SqlCommand(SelectString, myCon);
                    SqlDataAdapter showa = new SqlDataAdapter(com);//确定这个适配器作为那个连接的适配器
                    showa.Fill(showtable);
                }
                this.RoomDataGridView.DataSource = showtable;
                myCon.Close();
            }
            else
            {
                MessageBox.Show("请输入具体的查询方式","空值提醒");
            }
           
        }

        private void RoomDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (RoomDataGridView.CurrentCell.Value.ToString() != "")
            {
                if (MessageBox.Show("确认修改改房间信息？", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    condb();
                    string rn = this.RoomDataGridView.CurrentRow.Cells[0].Value.ToString();//房号
                    string rt = this.RoomDataGridView.CurrentRow.Cells[1].Value.ToString();//房型
                    string rh = this.RoomDataGridView.CurrentRow.Cells[1].Value.ToString();//hold
                    string rm = this.RoomDataGridView.CurrentRow.Cells[1].Value.ToString();//remark
                    switch (RoomDataGridView.CurrentRow.Index)
                    {
                        case 2: string update = "update room set r_type='" + rt + "' where r_no='" + rn + "'"; break;
                            SqlCommand ex = new SqlCommand(update, myCon);
                            ex.ExecuteNonQuery();
                        case 5: string update1 = "update room set r_hold='" + rh + "' where r_no='" + rn + "'"; break;
                            SqlCommand ex1 = new SqlCommand(update1, myCon);
                            ex.ExecuteNonQuery();
                        case 7: string update2 = "update room set r_remark='" + rm + "' where r_no='" + rn + "'"; break;
                            SqlCommand ex2 = new SqlCommand(update2, myCon);
                            ex.ExecuteNonQuery();
                    }
                    myCon.Close();
                }
                else
                {
                    S_rm_Load(null, null);
                }
            }
            else
            {
                MessageBox.Show("不可输入空值!","温馨提示");
            }
            
        }
    }
}
