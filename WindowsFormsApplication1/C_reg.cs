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
    public partial class C_reg : Form
    {
        SqlConnection myCon = new SqlConnection();
        public C_reg()
        {
            InitializeComponent();
        }
        bool updata_value = false;
        private void cunsume_registration_Load(object sender, EventArgs e)
        {
            this.goodsTableAdapter.Fill(this.myhotelDataSet.goods);
            initdatatable();//初始化数据商品表
            initdata();//初始化控件数据
        }
        //方法：改变表属性
        private DataTable UpdateDataTable(DataTable argDataTable)
        {
            DataTable dtResult = new DataTable();
            //克隆表结构
            dtResult = argDataTable.Clone();
            foreach (DataColumn col in dtResult.Columns)
            {
                if (col.ColumnName == "是否入账")
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
                for (i = 0; i < 5; i++)
                {
                    rowNew[i] = row[i];
                }
                if (row["是否入账"].ToString() == "1")
                {
                    rowNew["是否入账"] = "未入账";
                }
                else
                {
                    rowNew["是否入账"] = "已入账";
                }
                dtResult.Rows.Add(rowNew);
            }
            //返回希望的结果
            return dtResult;
        }
        //方法：初始化数据商品表
        private void initdatatable()
        { 
            myCon.ConnectionString = "Data Source=(local);Initial Catalog=myhotel;Integrated Security=True";
            myCon.Open();
            string mysql = "select g_name AS '消费商品',c_name AS '消费顾客',Out_no AS '消费数量',out_fee AS '费用',g_time AS '消费时间',g_valid AS '是否入账' from gd_comsump ,customer where  customer.c_id =gd_comsump.c_id ORDER BY g_time desc";
            DataTable MyQueryTable = new DataTable();
            SqlCommand myqureycommand = new SqlCommand(mysql, myCon);
            SqlDataAdapter myqueryadapter = new SqlDataAdapter(myqureycommand);
            MyQueryTable.Clear();
            myqueryadapter.Fill(MyQueryTable);
            MyQueryTable= UpdateDataTable(MyQueryTable);
            this.good_consume_list.DataSource = MyQueryTable;
            good_consume_list.Columns[0].Width = 130;
            myCon.Close();
            num.Value = 0;
            date.Text  = Convert.ToString ( System.DateTime.Now);
        }
        //方法：初始化控件数据
        private void initdata()
        {
            myCon.ConnectionString = "Data Source=(local);Initial Catalog=myhotel;Integrated Security=True";
            myCon.Open();
            SqlCommand mycommand = new SqlCommand("select distinct c_name from checkin,customer where c_valid ='1'and checkin.c_id= customer.c_id",myCon );
            SqlDataAdapter myadapter = new SqlDataAdapter();
            myadapter.SelectCommand = mycommand;
            DataTable mytable = new DataTable();  
            myadapter.Fill(mytable );
            //将dataset中的数据绑定到combobox1中
            cname .DisplayMember = "c_name";
            cname.DataSource =mytable ;
            myCon.Close();
            button2.Visible = false;
            button4.Visible = false;
            num.Value = 0;
           
        }
       
       //事件函数/“添加”按钮点击事件：插入新的消费信息，进行登记，时间默认为当天时间，不允许改动
        private void button1_Click(object sender, EventArgs e)
        {
            if (updata_value == true)
            {
                updata_value = false;
                initdata();
                return;
            }
            if ((!(cname.Text == "")) && (!(gname.Text == "")) && (!(num.Value == 0)))
            {
                string checkstring = "select * from gd_comsump where c_id=(select customer.c_id from customer where customer.c_name = '" + this.cname.Text + "') and g_name='" + gname.Text + "' and g_time='" + date.Value + " '";
                string insertstring = "insert into gd_comsump values ((select customer.c_id from customer where customer.c_name = '" + this.cname.Text + "'),'"+gname .Text +"','" + this.num.Text + "',(select g_price*'"+num.Value +"' from goods where goods.g_name='"+gname.Text +"'),'1','"+date.Value +" ') ";
                myCon.ConnectionString = "Data Source=(local);Initial Catalog=myhotel;Integrated Security=True";
                myCon.Open();
                SqlCommand mycommad1 = new SqlCommand(checkstring, myCon);
                SqlDataAdapter myadapter = new SqlDataAdapter();
                myadapter.SelectCommand = mycommad1;
                DataTable mytable = new DataTable();
                myadapter.Fill(mytable);
                if (mytable.Rows.Count  == 1)
                {
                    MessageBox.Show("今天 '" + this.cname.Text + "'消费的 '" + this.gname.Text + "'已经登记过了", "提示");
                    myCon.Close();
                    return;
                }

                SqlCommand mycommad = new SqlCommand(insertstring, myCon);
                mycommad.ExecuteNonQuery();
                myCon.Close();
                initdatatable();
                MessageBox.Show("添加成功！", "提示");
            }
            else
            {
                MessageBox.Show("输入有误，请检查是否输入有空或消耗数量未选择","错误提示");
            }
        }
        //事件函数/表双击事件：当双击消耗表时，出现修改信息界面
        private void good_consume_list_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        { 
            updata_value = true;
            string g_name = this.good_consume_list.CurrentRow.Cells[0].Value.ToString();
            gname.Text = g_name;
            string c_name = this.good_consume_list.CurrentRow.Cells[1].Value.ToString();
            cname.Text = c_name;
            string out_num = this.good_consume_list.CurrentRow.Cells[2].Value.ToString();
            num.Text = out_num;
            string g_date = this.good_consume_list.CurrentRow.Cells[4].Value.ToString();
            date.Text =g_date;
            if (this.good_consume_list.CurrentRow.Cells[5].Value.ToString() == "未入账")
            {
                gname.Enabled = true;
                cname.Enabled = true;
                num.Enabled = true;
                button2.Visible = true;
            }
            else
            {
                button2.Visible =false;
                gname.Enabled = false;
                cname.Enabled = false;
                num.Enabled = false;
            }
            button4.Visible = true;
        }
        //事件函数/‘修改’按钮点击事件：修改商品消费信息，不允许修改时间
        private void button2_Click(object sender, EventArgs e)
        {
          
           if (MessageBox.Show("确定修改该消费记录记录？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
           {
               if ((!(cname.Text == "")) && (!(gname.Text == "")) && (!(num.Value == 0)))//输入不能为空
               {
                   updata_value = false ;
                   string myupdatasql1 = "DELETE FROM gd_comsump WHERE  g_name='" + gname.Text + "'and gd_comsump.c_id =(select customer.c_id from customer where customer.c_name = '" + this.cname.Text + "') AND g_time='" + date.Value  + " '"; ;
                   string myupdatasql2 = "INSERT gd_comsump VALUES( （select c_id from customer where c_name='" + cname + "'）,'" + gname + "','" + this.num.Text + "',(select g_price*'" + num.Value + "' from goods where goods.g_name='" + gname.Text + "') ,'1','" + date.Value + "'";
                   myCon.ConnectionString = "Data Source=(local);Initial Catalog=myhotel;Integrated Security=True";
                   myCon.Open();
                   SqlCommand mycommad = new SqlCommand(myupdatasql1, myCon);
                   mycommad.ExecuteNonQuery();
                   myCon.Close();
                   initdatatable();
                   gname.Enabled = true;
                   cname.Enabled = true;
                   num.Enabled = true ;
                   button2.Visible = false;
                   button4.Visible = false;
                   MessageBox.Show("修改成功", "提示");
               }
               else
               {
                   MessageBox.Show("输入有误，请检查是否输入有空或消耗数量未选择", "错误提示");
               }
              
           }
           else
           {
               return;
           }
            
        }
        //事件函数/‘删除’按钮点击事件：删除商品消费信息
        private void button4_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("确定删除该消费记录记录？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                updata_value = false ;
                string mydeletesql = "DELETE FROM gd_comsump WHERE  g_name='" + gname.Text + "'and gd_comsump.c_id =(select customer.c_id from customer where customer.c_name = '" + this.cname.Text + "') AND g_time='" + date.Value.Date   + " '";
                myCon.ConnectionString = "Data Source=(local);Initial Catalog=myhotel;Integrated Security=True";
                myCon.Open();
                SqlCommand mycommad = new SqlCommand(mydeletesql, myCon);
                mycommad.ExecuteNonQuery();
                myCon.Close();
                initdatatable();
                gname.Enabled = true;
                cname.Enabled = true;
                num.Enabled = true;
                button2.Visible = false;
                button4.Visible = false;
                MessageBox.Show("删除成功", "提示");
            }
            else
            {
                return;
            }
        }
        //事件函数/“打印”按钮点击事件：打印一段时间内物品消耗登记情况
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("将数据导入到excel表中打印", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                DataTable myexceltable = new DataTable();
                myexceltable = exporeDataToTable();
                excel myexcel = new excel();
                myexcel.toExcel(myexceltable);
            }
        }
       //方法：将good_consume_list数据转换成表
        private DataTable exporeDataToTable()
        {
            //将good_consume_list中的数据导入到表中  
            DataTable tempTable = new DataTable("tempTable");
            //定义一个模板表，专门用来获取列名  
            DataTable modelTable = new DataTable("ModelTable");
            //创建列  
            for (int column = 0; column < good_consume_list.Columns.Count; column++)
            {
                //可见的列才显示出来 
                if (good_consume_list.Columns[column].Visible == true)
                {
                    DataColumn tempColumn = new DataColumn(good_consume_list.Columns[column].HeaderText, typeof(string));
                    tempTable.Columns.Add(tempColumn);
                    DataColumn modelColumn = new DataColumn(good_consume_list.Columns[column].Name, typeof(string));
                    modelTable.Columns.Add(modelColumn);
                }
            }
            //添加good_consume_list中行的数据到表  
            for (int row = 0; row < (good_consume_list.Rows.Count); row++)
            {
                DataRow tempRow = tempTable.NewRow();
                for (int i = 0; i < tempTable.Columns.Count; i++)
                {
                    tempRow[i] = good_consume_list.Rows[row].Cells[modelTable.Columns[i].ColumnName].Value;
                }
                string string1 = tempRow[4].ToString ();
                tempRow[4] = string1.Substring(0,10);
                tempTable.Rows.Add(tempRow);
            }
            return tempTable;
        }      
    }
}
