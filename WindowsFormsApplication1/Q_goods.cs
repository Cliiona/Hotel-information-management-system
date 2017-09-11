using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient ;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using myhotel;

namespace WindowsFormsApplication1
{
    public partial class Q_goods : Form
    {
        bool specificgoods = false;//定义全局变量specificgoods，用于检测是否选择了某种商品的查询
        SqlConnection myCon = new SqlConnection();
        public Q_goods()
        {
            InitializeComponent();
        }
        private void Q_goods_Load(object sender, EventArgs e)
        {        
            this.goodsTableAdapter.Fill(this.myhotelDataSet.goods); //将商品名数据加载到comboxz中
        }
        //方法：实现一个表的基本配置
        private void tablebuild(DataTable table, string sql)
        {
            SqlCommand mycommad = new SqlCommand(sql, myCon);
            SqlDataAdapter myadapter = new SqlDataAdapter(mycommad);
            table.Clear();
            myadapter.Fill(table);
        }
         //若查询结果为空，出现提示
        private void zero(DataTable MyQueryTable)
        {
            if (MyQueryTable.Rows.Count == 0)
            {
                MessageBox.Show("在'" + startdate.Value.ToString("yyyy年mm月dd日") + "' 到  '" + enddate.Value.ToString("yyyy年mm月dd日") + "'这段时期内没有商品消耗", " 提示");
            }
        }
       //事件函数/查询按钮点击事件
        private void button1_Click(object sender, EventArgs e)
        {
            //时间输入正确判断
             if (DateTime.Compare(startdate.Value.Date , DateTime.Today ) > 0)
            {
                MessageBox.Show("开始日期不能大于当前日期哦！", " 错误提示");
                return;
            }
            if (DateTime.Compare(startdate.Value, enddate.Value) > 0)
            {
                MessageBox.Show("截止日期不能小于开始日期哦！", " 错误提示");
                return;
            }
            myCon.ConnectionString = "Data Source=(local);Initial Catalog=myhotel;Integrated Security=True";
            myCon.Open();  
            DataTable MyQueryTable = new DataTable();
            //查询历史记录
            if (history.Checked == true)
            {
                string hisquerystring1 = "select g_name as'商品名称',out_no as'消耗数目',out_fee as '总金额',g_time as'消费时间' from gd_comsump where g_valid='0' and (g_time between'" + startdate.Value + "' and '" + enddate.Value + "' )";
                string hisquerystring2 = "select g_name as'商品名称',out_no as'消耗数目',out_fee as '总金额',g_time as'消费时间'  from gd_comsump where g_valid='0' and g_name='" + gname.Text + "' and (g_time between'" + startdate.Value + "' and '" + enddate.Value + "' )";
                //查询历史记录/非详细商品
                if (specificgoods == false )
                {
                    tablebuild(MyQueryTable, hisquerystring1);//调用配置表方法
                    zero(MyQueryTable);//若查询结果为空，出现提示
      
                }
                //查询历史记录/详细商品
                else
                {
                    tablebuild(MyQueryTable, hisquerystring2);//调用配置表方法
                    zero(MyQueryTable);//若查询结果为空，出现提示
                }    
            }
            //查询当前未结账商品消耗
            else if (current.Checked == true)
            {
                string curquerystring1 = "select g_name as'商品名称',out_no as'消耗数目',out_fee as '总金额',g_time as'消费时间'  from gd_comsump where g_valid='1' and (g_time between'" + startdate.Value + "' and '" + enddate.Value + "' )";
                string curquerystring2 = "select g_name as'商品名称',out_no as'消耗数目',out_fee as '总金额',g_time as'消费时间'  from gd_comsump where g_valid='1' and g_name='" + gname.Text + "' and (g_time between'" + startdate.Value + "' and '" + enddate.Value + "' )";
                //查询当前未结账商品消耗/非详细商品
                if (specificgoods == false )
                {
                    tablebuild(MyQueryTable, curquerystring1);//调用配置表方法
                    zero(MyQueryTable);//若查询结果为空，出现提示

                }
                //查询当前未结账商品消耗/详细商品
                else
                {
                    tablebuild(MyQueryTable, curquerystring2);//调用配置表方法
                    zero(MyQueryTable);//若查询结果为空，出现提示
                }
                
            }
            //查询所有记录
            else  if (all.Checked == true)
            {
                string allquerystring1 = "select g_name as'商品名称',out_no as'消耗数目',out_fee as '总金额',g_time as'消费时间' from gd_comsump where (g_time between'" + startdate.Value + "' and '" + enddate.Value + "' )";
                string allquerystring2 = "select g_name as'商品名称',out_no as'消耗数目',out_fee as '总金额',g_time as'消费时间'  from gd_comsump where  g_name='" + gname.Text + "' and (g_time between'" + startdate.Value + "' and '" + enddate.Value + "' )";
           
               //查询所有商品消耗/非详细商品
                if (specificgoods == false )
                {
                    tablebuild(MyQueryTable, allquerystring1);//调用配置表方法
                    zero(MyQueryTable);//若查询结果为空，出现提示
                }
                //查询所有商品消耗/详细商品
                else
                {
                    tablebuild(MyQueryTable, allquerystring2);//调用配置表方法
                    zero(MyQueryTable);//若查询结果为空，出现提示
                }
            }
            this.dataGridView1.DataSource = MyQueryTable;//显示临时表
            myCon.Close();
        }
       //事件函数/"查询具体某类商品"点击事件
        private void label3_Click(object sender, EventArgs e)
        {
            if (specificgoods == false)
            {
                specificgoods = true;
                gname.Visible = true;
                label4.Visible = true;
            }
            else
            {
                specificgoods = false ;
                gname.Visible = false ;
                label4.Visible = false ;
            }
        }
      //事件/“打印”按钮点击事件：打印一段时间内的消耗总量报表
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
            for (int column = 0; column < dataGridView1.Columns.Count; column++)
            {
                //可见的列才显示出来 
                if (dataGridView1.Columns[column].Visible == true)
                {
                    DataColumn tempColumn = new DataColumn(dataGridView1.Columns[column].HeaderText, typeof(string));
                    tempTable.Columns.Add(tempColumn);
                    DataColumn modelColumn = new DataColumn(dataGridView1.Columns[column].Name, typeof(string));
                    modelTable.Columns.Add(modelColumn);
                }
            }
            //添加datagridview中行的数据到表  
            for (int row = 0; row < (dataGridView1.Rows.Count - 1); row++)
            {
                DataRow tempRow = tempTable.NewRow();
                for (int i = 0; i < tempTable.Columns.Count; i++)
                {
                    tempRow[i] = dataGridView1.Rows[row].Cells[modelTable.Columns[i].ColumnName].Value;
                }
                string string1 = tempRow[3].ToString();//有时间量才用
                tempRow[3] = string1.Substring(0,10);//有时间量才用
                tempTable.Rows.Add(tempRow);
            }
            return tempTable;
        }      
    }
}
