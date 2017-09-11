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
    public partial class S_rm_add : Form
    {
        public delegate void RoomFresh(object sender, EventArgs e);//委托声明
        event RoomFresh afterpress;//定义委托事件
        
        SqlConnection myCon = new SqlConnection();
        string CString = "Data Source=(local);Initial Catalog=myhotel;Integrated Security=True"; //数据库连接字符串


        public S_rm_add(RoomFresh e)
        {
            InitializeComponent();
            afterpress += e;

            //this.atype.Items.Equals(c.Items);//把另一个窗体的集合赋值给我
            //SIndex=Standard();
        }
        
        //窗体在第一次出现时触发事件
        private void S_rm_add_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“myhotelDataSet.room_price”中。您可以根据需要移动或移除它。
            this.room_priceTableAdapter.Fill(this.myhotelDataSet.room_price);
            

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (ano.Text == "" || atype.Text == "" || aprice.Text == "" || ahold.Text == "")
            {
                this.notice.Text = "除备注外不能为空";
            }

            else if (this.ano.Text[0] > '4' || this.ano.Text[1] > '1' || Convert.ToInt16(this.ano.Text) >= 420 || Convert.ToInt16(this.ano.Text) < 101|| this.ano.Text.Length!=3)
            {
                this.notice.Text = "房号为三位数，首位为楼层（1-4），后两位为房间号（1-19）";
            }

            else
            {
                //链接并打开数据库
                if (myCon.State == ConnectionState.Closed)//其中ConnectionState是一个枚举类型.Closed为其成员之一
                {
                    myCon.ConnectionString = CString;
                    myCon.Open();
                }
                             
                //查看是否有重复记录
                string CheckString = "SELECT * FROM ROOM WHERE R_NO='"+this.ano.Text+"'";
                SqlCommand CheckCommand = new SqlCommand(CheckString, myCon);
                SqlDataReader CheckReader=CheckCommand.ExecuteReader();//因nonquery不能执行select语句，故选择reader方法，返回值为sqldatareader类型

                //根据SqldataReader中Read方法，检测是否有重复记录
                if (CheckReader.Read())
                {
                    MessageBox.Show("房号已存在，请重新输入！","记录重复提示");
                    CheckReader.Close();//关闭SqlDataReader对象
                }
                //执行添加记录操作,关闭数据库
                else
                {
                    CheckReader.Close();//关闭SqlDataReader对象
                    string InsertString = "INSERT INTO ROOM VALUES('" + this.ano.Text + "','" + this.atype.Text + "','" + this.aprice.Text + "','" + this.ano.Text[0] + "','" + this.ahold.Text + "','0','" + this.aremark.Text + "')";//初始房间为空 没人住
                    SqlCommand MyCommand = new SqlCommand(InsertString, myCon);//设置Mycommand中commandText和Connection属性，为使用非查询连接配置参数
                    MyCommand.ExecuteNonQuery();//执行非查询连接——>这里为插入
                    //CheckReader.Close();
                    myCon.Close();
                    afterpress(null, null);
                    this.Hide();
                    //S_rm f = new S_rm();
                    //f.Show();
                }
                
                
            }
        }


        private void type_SelectedValueChanged(object sender, EventArgs e)//没有选择SelectionChangeCommitted的原因是会产生延迟！知道读到上一个状态的内容
        {
            //for (i = 0; i < atype.Items.Count;i++ )
            //{
            //    if (atype.Text == atype.Items[i])
            //    {
            //        aprice.Text = aprice.Items[i].ToString ();
            //        break;
            //    }
                
            //}

            //这里死活用不了switch case的原因是：case后只能接常量值（int：21，string：”21“），不能带有任何变量
        }





    }
}
