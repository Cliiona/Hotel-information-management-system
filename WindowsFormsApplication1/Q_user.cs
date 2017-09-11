using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient ;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Q_user : Form
    {
        SqlConnection myCon = new SqlConnection();  //实例化数据库连接类
        bool specificdate = false;  //定义一个全局变量，表示是否选择‘具体到时间’
        public Q_user()
        {
            InitializeComponent();
        }
        //方法：实现一个表的基本配置
        private void tablebuild(DataTable table, string sql)
        {
             SqlCommand mycommad = new SqlCommand(sql, myCon);
             SqlDataAdapter myadapter = new SqlDataAdapter(mycommad);
             table.Clear();
               myadapter.Fill(table);
        }
     
        //方法：实现一个表添加“客户类型”
        private void tableadd_type(DataTable table)
        {
            table.Columns.Add("客户类型", typeof(string));
            table.Columns["客户类型"].SetOrdinal(1);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string mysql_searchvip = "select v_no from vip WHERE v_name='" + table.Rows[i]["客户姓名"] + "'";
                DataTable MyQueryTable_searchvip = new DataTable();
                tablebuild( MyQueryTable_searchvip,  mysql_searchvip);
                if (MyQueryTable_searchvip.Rows.Count == 0)
                {
                    table.Rows[i]["客户类型"] = "普通客户";
                }
                else
                {
                    table.Rows[i]["客户类型"] = "VIP客户";
                }
            }
        }
        //方法/窗口数据或控件属性重置
        private void chongzhi()
        {
            name.Text =null ;
            room.Text =null ;
            phone.Text =null ;
            id.Text =null ;
            startdate.Text = null;
            ctype.Text = null;
            enddate.Text = null;
            account.Text = null;
            people.Text = null;
            remark.Text = null;
        }
        //事件函数/‘查询’按钮点击事件：实现各种情况查询
        private void button1_Click(object sender, EventArgs e)
        {
            chongzhi(); //调用界面数据显示重置方法
            myCon.ConnectionString = "Data Source=(local);Initial Catalog=myhotel;Integrated Security=True";
            myCon.Open();//连接数据库 
            //判断输入正确与否
            if (info.Text  == "") 
            {
              MessageBox.Show("输入有误，请检查是否输入有空", "错误提示");
              myCon.Close();
              return;
            }
            DataTable MyQueryTable = new DataTable();//建立表
            //查询历史信息
             if (history.Checked == true)
             {
                
                //查询历史信息/按客户姓名查询
                if (comboBox1.SelectedIndex == 0)
                {
                    string mysql = "select c_name AS '客户姓名',type AS '客户类型',r_no AS '房间号',c_phone AS '联系电话',checkin.c_id AS '身份证号',c_intime AS '入住时间',c_outtime AS '离开时间',c_account AS '预收押金',c_people AS '操作人员',c_remark AS '说明' from checkin,customer where checkin.c_id = customer.c_id AND c_name='" + info.Text + "' AND (c_valid in('0','2')) AND ('" + datetime.Value + "'between c_intime and c_outtime) ";
                    string mysql_nodate = "select c_name AS '客户姓名',type AS '客户类型',r_no AS '房间号',c_phone AS '联系电话',checkin.c_id AS '身份证号',c_intime AS '入住时间',c_outtime AS '离开时间',c_account AS '预收押金',c_people AS '操作人员',c_remark AS '说明' from checkin,customer where checkin.c_id = customer.c_id AND c_name='" + info.Text + "'and (c_valid in('0','2'))";
                    //查询历史信息/按客户姓名查询/具体时间
                    if (specificdate == true)
                    {
                       //判断日期输入是否正确
                        if (DateTime.Compare(datetime.Value.Date, DateTime.Today) > 0)
                        {
                            MessageBox.Show("日期不能大于当前日期！", " 错误提示");
                            myCon.Close();
                            return ;
                        }
                        tablebuild(MyQueryTable, mysql);//调用表配置方法
                        //判断查询结果是否为空
                        if (MyQueryTable.Rows.Count == 0)
                        {
                            MessageBox.Show("没有顾客'" + info.Text + "'在'" + datetime.Value.ToString("yyyy年mm月dd日") + "'的入住信息", " 提示");
                            myCon.Close();
                            return;
                        }
                    }
                    //查询历史信息/按客户姓名查询/不带有时间限制
                    else
                    {
                        tablebuild(MyQueryTable, mysql_nodate);//调用表配置方法
                        //判断查询结果是否为空
                        if (MyQueryTable.Rows.Count == 0)
                        {
                            MessageBox.Show("没有顾客'" + info.Text + "'在本旅馆的入住信息", " 提示");
                            myCon.Close();
                            return;
                        }
                    }                                             
                }
                //查询历史信息/按房间号查询
                else
                {

                    string mysql = "select c_name AS '客户姓名',type AS '客户类型',r_no AS '房间号',c_phone AS '联系电话',checkin.c_id AS '身份证号',c_intime AS '入住时间',c_outtime AS '离开时间',c_account AS '预收押金',c_people AS '操作人员',c_remark AS '说明' from checkin ,customer where (c_valid in('0','2')) AND r_no='" + info.Text + "'  AND ('" + datetime.Value + "'between c_intime and c_outtime) AND customer.c_id =checkin.c_id";
                    string mysql_nodate = "select c_name AS '客户姓名',type AS '客户类型',r_no AS '房间号',c_phone AS '联系电话',checkin.c_id AS '身份证号',c_intime AS '入住时间',c_outtime AS '离开时间',c_account AS '预收押金',c_people AS '操作人员',c_remark AS '说明' from checkin,customer where checkin.c_id = customer.c_id AND checkin.r_no='" + info.Text + "' AND (c_valid in('0','2'))";
                    //查询历史信息/按房间号查询/具体时间        
                    if (specificdate == true)
                    {

                        //判断日期输入是否正确
                        if (DateTime.Compare(datetime.Value.Date, DateTime.Today) > 0)
                        {
                            MessageBox.Show("日期不能大于当前日期哦！", " 错误提示");
                            myCon.Close();
                         
                            return;
                        }
                        tablebuild(MyQueryTable, mysql);//调用表配置方法
                        //判断查询结果是否为空
                        if (MyQueryTable.Rows.Count == 0)
                        {
                            MessageBox.Show("没有房间号为'" + info.Text + "'在'" + datetime.Value.ToString("yyyy年mm月dd日") + "'的入住信息", " 提示");
                            myCon.Close();
                            return;
                        }
                    }
                    //查询历史信息/按房间号查询/不带有时间限制
                    else
                    {
                        tablebuild(MyQueryTable, mysql_nodate);//调用表配置方法
                        //判断查询结果是否为空
                        if (MyQueryTable.Rows.Count == 0)
                        {
                            MessageBox.Show("没有房间号为'" + info.Text + "'在本旅馆的入住信息", " 提示");
                            myCon.Close();
                            return;
                        }
                    }
                 } 
                
              }

            //查询当前入住信息
            else if (current.Checked  ==true )
            {
                //查询当前入住信息/按客户姓名查询
                if (comboBox1.SelectedIndex == 0)
                {
                    string mysql = "select c_name AS '客户姓名',type AS '客户类型',r_no AS '房间号',c_phone AS '联系电话',checkin.c_id AS '身份证号',c_intime AS '入住时间',c_outtime AS '离开时间',c_account AS '预收押金',c_people AS '操作人员',c_remark AS '说明' from checkin,customer where checkin.c_id = customer.c_id AND c_name='" + info.Text + "' AND c_valid='1'";
                    tablebuild(MyQueryTable, mysql);//调用表配置方法
                    //判断查询结果是否为空
                    if (MyQueryTable.Rows.Count == 0)
                    {
                        MessageBox.Show("没有顾客'" + info.Text + "'当前入住本旅馆", " 提示");
                        myCon.Close();
                        return;
                    }
             }
                //查询当前入住信息/按房间号查询
                else
                {
                    string mysql = "select c_name AS '客户姓名',type AS '客户类型',r_no AS '房间号',c_phone AS '联系电话',checkin.c_id AS '身份证号',c_intime AS '入住时间',c_outtime AS '离开时间',c_account AS '预收押金',c_people AS '操作人员',c_remark AS '说明' from checkin ,customer where  customer.c_id =checkin.c_id AND r_no='" + info.Text + "'AND c_valid='1'";
                   tablebuild(MyQueryTable, mysql);//调用表配置方法    
                   //判断查询结果是否为空
                   if (MyQueryTable.Rows.Count == 0)
                   {
                       MessageBox.Show("房间号为'" + info.Text + "'当前没有人入住", " 提示");
                       myCon.Close();
                       return;
                   }
                }               
            } 
            this.dataGridView1.DataSource = MyQueryTable;//显示临时表
            myCon.Close();
         
        }
        //事件函数/查询方式combox内容改变事件
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            info.Clear();
            if (comboBox1.SelectedIndex == 0)
            {
                choice.Text = "输入客户姓名：";
                
            }
            else
            {
                choice.Text = "输入房间号：";
            }
        }
     
        //事件函数/双击表行标题内容事件：显示具体信息，触发修改事件
        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string c_name = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            name.Text = c_name;
            string c_type = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            ctype.Text = c_type;
            string c_room = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            room.Text = c_room;
            string c_phone = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            phone.Text = c_phone;
            string c_id = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            id.Text = c_id;
            string c_startdate = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            startdate.Text = c_startdate.Substring (0,10);
            string c_enddate = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            enddate.Text   =c_enddate.Substring (0,10);
            string c_account = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            account.Text = c_account;
            string c_people = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
            people.Text = c_people;
            string c_remark = this.dataGridView1.CurrentRow.Cells[9].Value.ToString();
         
        }
     
        //事件函数/‘当前在住旅客信息查询’按钮值改变事件：提供具体时间查询
        private void current_CheckedChanged(object sender, EventArgs e)
        {
            if (current.Checked == true)
            {
                label10.Visible = false;
                label10.Enabled = false;
                datetime.Visible= false ;
            }    
        }
        //事件函数/‘历史在住旅客信息查询’按钮值改变事件：不提供具体时间查询
        private void history_CheckedChanged(object sender, EventArgs e)
        {
            if (history.Checked == true)
            {
                label10.Visible = true;
                label10.Enabled = true;
                datetime.Visible = false ;
            }
        }
        //事件函数/‘具体时间查询’点击事件：查询具体时间或取消
        private void label10_Click(object sender, EventArgs e)
        {
            if (specificdate == false)
            {
                datetime.Visible = true;
                specificdate = true;
            }
            else
            {
                datetime.Visible = false;
                specificdate = false;
            }
        }


    }
}
