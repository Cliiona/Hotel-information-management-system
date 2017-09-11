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
    public partial class Q_sum : Form
    {
        public Q_sum()
        {
            InitializeComponent();
        }
        DataTable MyQueryTable =new DataTable ();
        //事件/“查询”按钮点击事件：查询一段时间内的消耗总量
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection();
            myCon.ConnectionString = "Data Source=(local);Initial Catalog=myhotel;Integrated Security=True";
            //数据库连接字符串
            myCon.Open();
            string mysql = "select g_name AS '消费品名称',SUM(Out_no) AS '消耗总数',SUM(Out_fee) AS '总金额' FROM gd_comsump WHERE g_time between'" + startdate.Value + "' and '" + enddate.Value + "' GROUP BY g_name ORDER BY g_name";
            if (DateTime.Compare(startdate.Value.Date , DateTime.Now ) > 0)
            {
                MessageBox.Show("开始日期不能大于当前日期哦！", " 错误提示");
                return;
            }
            if (DateTime.Compare(startdate.Value, enddate.Value) > 0)
            {
                MessageBox.Show("截止日期不能小于开始日期哦！", " 错误提示");
                return;
            }
            SqlCommand mycommad = new SqlCommand(mysql ,myCon );
            SqlDataAdapter myadapter = new SqlDataAdapter(mycommad );
            MyQueryTable.Clear();
            myadapter.Fill(MyQueryTable );
            this.dataGridView1.DataSource = MyQueryTable;
            if (MyQueryTable.Rows.Count == 0)
            {
                MessageBox.Show("在'" + startdate.Value.ToString("yyyy年mm月dd日") + "' 到  '" + enddate.Value.ToString("yyyy年mm月dd日") + "'这段时期内没有商品消耗", " 提示");
                myCon.Close();
                return;
            }
            myCon.Close();
          
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
                tempTable.Rows.Add(tempRow);
            }
            return tempTable;
        }      
    }
}
