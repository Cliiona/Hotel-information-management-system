
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using myhotel;

namespace WindowsFormsApplication1
{
    public partial class R_management : Form
    {
        SqlConnection myCon = new SqlConnection();
        
        string CString = "Data Source=(local);Initial Catalog=myhotel;Integrated Security=True";
        
        DataTable table = new DataTable();
        
        public R_management()
        {
            InitializeComponent();
            dateTimePicker2.Value = dateTimePicker1.Value.AddDays(1);
     
        }
        private void R_management_Load(object sender, EventArgs e)
        {
            if (this.groupBox1.Text == "客户结账记录")
            {
                    myCon.ConnectionString = CString;
                    myCon.Open();
                    table.Clear();
                    string s = "select c_type as'用户类型',O_name as'姓名',c_id as '     身份证号     ',r_no as '房号',O_intime as'入住时间',O_time as '离开时间',Outrm_fee as'房费',O_gfee as'消费',Outrm_fee+O_gfee as'总计',Out_remark as'备注' from checkout";
                    SqlCommand com = new SqlCommand(s, myCon);          
                    SqlDataAdapter a = new SqlDataAdapter(com);//告诉适配器数据源是什么
                    a.Fill(table);
                    this.check_in_list.DataSource = table;
                    myCon.Close();
            }
            else if (this.groupBox1.Text == "客户入住记录")
            {
                myCon.ConnectionString = CString;
                myCon.Open();
                table.Clear();
                string mysql1 = "select customer.c_name AS '姓名', customer.c_id AS '     身份证号     ',room.r_no AS '房间号',c_rtype AS '房间类型',checkin.c_intime AS '入住时间',room.r_price AS '房间价格',c_people AS '操作人员',c_remark AS '备注' from room,customer,checkin where checkin.r_no=room.r_no and  customer.c_id=checkin.c_id";
                SqlCommand mycommad1 = new SqlCommand(mysql1, myCon);
                SqlDataAdapter myadapter1 = new SqlDataAdapter(mycommad1);
                DataTable MyQueryTable1 = new DataTable();
                MyQueryTable1.Clear();
                myadapter1.Fill(MyQueryTable1);  
                check_in_list.DataSource = MyQueryTable1;
                myCon.Close();
            }
            else if (this.groupBox1.Text == "物品消耗记录")
            {
                myCon.ConnectionString = CString;
                myCon.Open();
                string mysql2 = "select customer.c_name AS '姓名',customer.c_id AS '     身份证号     ', checkin.r_no AS '房间号',gd_comsump.g_name AS '消费商品',gd_comsump.G_time AS '消费时间', gd_comsump.Out_no AS '消费数目',gd_comsump.Out_fee AS '消费总额' from customer,gd_comsump,checkin where gd_comsump.c_id= customer.c_id  and customer.c_id=checkin.c_id ";
                SqlCommand mycommad2 = new SqlCommand(mysql2, myCon);
                SqlDataAdapter myadapter2 = new SqlDataAdapter(mycommad2);
                DataTable MyQueryTable2 = new DataTable();
                MyQueryTable2.Clear();
                myadapter2.Fill(MyQueryTable2);
                check_in_list.DataSource = MyQueryTable2;
                myCon.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DateTime.Compare(Convert.ToDateTime(dateTimePicker1.Value), Convert.ToDateTime(dateTimePicker2.Value)) < 0)
            {
                if(this.groupBox1.Text == "客户入住记录")
                {
                    myCon.ConnectionString = CString;
                    myCon.Open();

                    string mysql1 = "select customer.c_name AS '姓名', customer.c_id AS '     身份证号     ',room.r_no AS '房间号',c_rtype AS '房间类型',checkin.c_intime AS '入住时间',room.r_price AS '房间价格',c_people AS '操作人员',c_remark AS '备注'  from room,customer,checkin where customer.c_id=checkin.c_id AND checkin.r_no=room.r_no AND (checkin.c_intime between '" + dateTimePicker1.Value + "'and '" + dateTimePicker2.Value + "')";
                    SqlCommand mycommad1 = new SqlCommand(mysql1,myCon);
                    SqlDataAdapter myadapter1 = new SqlDataAdapter(mycommad1);
                    DataTable MyQueryTable1 = new DataTable();
                    MyQueryTable1.Clear();
                    myadapter1.Fill(MyQueryTable1);
                    check_in_list.DataSource = MyQueryTable1;
                    check_in_list.Columns[1].Width = 230;
                    myCon.Close();
                }
                else if (this.groupBox1.Text == "客户结账记录")
                {
                    myCon.ConnectionString = CString;
                    table.Clear();
                    string s1 = "select  c_type as'用户类型',O_name as'姓名',c_id as '     身份证号     ',r_no as '房号',O_intime as'入住时间',O_time as '离开时间',Outrm_fee as'房费',O_gfee as'消费',Outrm_fee+O_gfee as'总计',Out_remark as'备注' from checkout where O_time between '" + dateTimePicker1.Value + "'and '" + dateTimePicker2.Value + "'";
                    SqlCommand com1 = new SqlCommand(s1, myCon);
                    myCon.Open();
                    SqlDataAdapter ad = new SqlDataAdapter(com1);
                    ad.Fill(table);
                    this.check_in_list.DataSource = table;
                    myCon.Close();
                }
                else if (this.groupBox1.Text == "物品消耗记录")
                {
                    myCon.ConnectionString = CString;
                    myCon.Open();
                    string mysql2 = "select customer.c_name AS '姓名',customer.c_id AS '     身份证号     ', room.r_no AS '房间号',gd_comsump.g_name AS '消费商品',gd_comsump.G_time AS '消费时间', gd_comsump.Out_no AS '消费数目',gd_comsump.Out_fee AS '消费总额' from room,customer,gd_comsump,checkin where customer.c_id=gd_comsump.c_id AND customer.c_id=checkin.c_id and checkin.r_no=room.r_no AND (gd_comsump.G_time between '" + dateTimePicker1.Value + "'and '" + dateTimePicker2.Value + "')";
                     SqlCommand mycommad2 = new SqlCommand(mysql2, myCon);
                     SqlDataAdapter myadapter2 = new SqlDataAdapter(mycommad2);
                     DataTable MyQueryTable2 = new DataTable();
                     MyQueryTable2.Clear();
                     myadapter2.Fill(MyQueryTable2);
                     check_in_list.DataSource = MyQueryTable2;
                    myCon.Close();
                }
            }
            else if (DateTime.Compare(Convert.ToDateTime(dateTimePicker2.Value),System.DateTime.Today) < 0)
            {
                MessageBox.Show("离开日期超过今天，请重新选择离开日期","温馨提示");
            }
            else 
            {
                MessageBox.Show("入住日期大于离开日期，请重新选择","温馨提示");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("将数据导入到excel表中打印", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                DataTable myexceltable = new DataTable();
                myexceltable = exporeDataToTable();
                excel myexcel = new excel();
                myexcel.toExcel(myexceltable);
            }

        }
             //方法：将Ddatagrideview数据转换成表
        private DataTable exporeDataToTable()
        {
            //将datagridview中的数据导入到表中  
            DataTable tempTable = new DataTable("tempTable");
            //定义一个模板表，专门用来获取列名  
            DataTable modelTable = new DataTable("ModelTable");
            //创建列  
            for (int column = 0; column < check_in_list.Columns.Count; column++)
            {
                //可见的列才显示出来 
                if (check_in_list.Columns[column].Visible == true)
                {
                    DataColumn tempColumn = new DataColumn(check_in_list.Columns[column].HeaderText, typeof(string));
                    tempTable.Columns.Add(tempColumn);
                    DataColumn modelColumn = new DataColumn(check_in_list.Columns[column].Name, typeof(string));
                    modelTable.Columns.Add(modelColumn);
                }
            }
            //添加datagridview中行的数据到表  
            for (int row = 0; row < (check_in_list.Rows.Count); row++)
            {
                DataRow tempRow = tempTable.NewRow();
                for (int i = 0; i < tempTable.Columns.Count; i++)
                {
                    tempRow[i] = check_in_list.Rows[row].Cells[modelTable.Columns[i].ColumnName].Value;
                }

                if (groupBox1.Text == "客户结账记录")
                {
                    string string1 = tempRow[4].ToString();//有时间量才用
                    tempRow[4] = string1.Substring(0, 10);//有时间量才用
                    string1 = tempRow[5].ToString();//有时间量才用
                    tempRow[5] = string1.Substring(0, 10);//有时间量才用

                }
                else
                {
                    
                   string string1 = tempRow[4].ToString();//有时间量才用
                   tempRow[4] = string1.Substring(0, 10);//有时间量才用

                    
                }

               

                tempTable.Rows.Add(tempRow);
            }
            return tempTable;
        }

       



    }
}
