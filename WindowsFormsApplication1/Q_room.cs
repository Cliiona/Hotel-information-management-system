using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Q_room : Form
    {
        SqlConnection myCon = new SqlConnection();
        public Q_room()
        {
            InitializeComponent();
        }
        private void Q_room_Load(object sender, EventArgs e)
        {
            init();//调用初始房态表
        }

        //方法：实现一个表的基本配置
        private void tablebuild(DataTable table, string sql)
        {
            SqlCommand mycommad = new SqlCommand(sql, myCon);
            SqlDataAdapter myadapter = new SqlDataAdapter(mycommad);
            table.Clear();
            myadapter.Fill(table);
        }
        //方法：改变表属性
        private DataTable UpdateDataTable(DataTable argDataTable)
        {
            DataTable dtResult = new DataTable();
            //克隆表结构
            dtResult = argDataTable.Clone();
            foreach (DataColumn col in dtResult.Columns)
            {
                if (col.ColumnName == "入住情况")
                {
                    //修改列类型
                    col.DataType = typeof(String);
                }
            }
            foreach (DataRow row in argDataTable.Rows)
            {
                DataRow rowNew = dtResult.NewRow();
                //修改记录值
                int i;
                rowNew[0] = row[0];
                for (i = 2; i < 5; i++)
                {
                    rowNew[i] = row[i];
                }
                if (row["入住情况"].ToString() == "1")
                {
                    rowNew["入住情况"] = "已入住";
                }
                else
                {
                    rowNew["入住情况"] = "空房";
                }
                dtResult.Rows.Add(rowNew);
            }
            //返回希望的结果
            return dtResult;
        }
       //方法：显示房态表
        private void init()
        { 
            myCon.ConnectionString = "Data Source=(local);Initial Catalog=myhotel;Integrated Security=True"; //数据库连接字符串
            myCon.Open();
            DataTable MyQueryTable = new DataTable();
            string mysql = "select room.r_no AS '房间号',room.r_full AS '入住情况',room.r_type AS '房间类型',room.r_price AS '房间价格',room.r_stair AS '房间楼层' FROM room ";
            tablebuild(MyQueryTable, mysql);//调用表配置方法
            MyQueryTable=UpdateDataTable(MyQueryTable);
            this.dataGridView1.DataSource = MyQueryTable;//显示房态表
            myCon.Close();
        }
        //事件函数/鼠标选中表内容事件：显示具体旅客入住信息
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            SqlConnection myCon = new SqlConnection();
            string roomno = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();//获取当前列的房间号
            if ((!string.IsNullOrEmpty (roomno )) )//房间号不为空
            {
                myCon.ConnectionString = "Data Source=(local);Initial Catalog=myhotel;Integrated Security=True"; //数据库连接字符串 
                myCon.Open();
                string mysql = "select c_name AS '客人姓名',c_phone AS '联系电话',checkin.r_no AS '房间号',c_account AS '预收押金',c_intime AS '入住日期',c_outtime AS '离开日期',c_people AS '操作人员',c_remark AS '说明' FROM customer ,checkin WHERE  (checkin.r_no='" + roomno + "' AND customer.c_id=checkin.c_id )AND checkin.c_valid='1'";
             //   + " UNION select v_name AS '客人姓名',v_phone AS '联系电话',v_checkin.r_no AS '房间号',vc_account AS '预收押金',vc_intime AS '入住日期',vc_outtime AS '离开日期',vc_people AS '操作人员',vc_remark AS '说明' FROM vip ,v_checkin WHERE  (v_checkin.r_no='" + roomno + "' AND vip.v_no=v_checkin.v_no) AND v_checkin.vc_v='1'";
                DataTable MyQueryTable = new DataTable();
                tablebuild( MyQueryTable, mysql);
              //  tableadd_type(MyQueryTable);
                this.dataGridView2.DataSource = MyQueryTable;
                myCon.Close();
            }
        }
        //找出已被入住的房间并标记为红色
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == this.dataGridView1.Columns[1].Index)
            {
                try
                {
                    if (e.Value.ToString() == "已入住")
                    {
                        e.CellStyle.BackColor = Color.Red;
                        e.CellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.Green ;
                        e.CellStyle.ForeColor = Color.White;
                    }
                }
                catch
                { 
                
                }
            }
        }
    }
}
