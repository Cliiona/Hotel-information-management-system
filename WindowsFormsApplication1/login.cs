using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();

        }
        private int counts = 5;


        private void login_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“myhotelDataSet.stuff”中。您可以根据需要移动或移除它。
            this.stuffTableAdapter.Fill(this.myhotelDataSet.stuff);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            int t1 = 0, t2 = 0, t3 = 0, t4 = 0, t5 = 0, t6 = 0;
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=myhotel;Integrated Security=True");
            con.Open();
            String SQLString = "select count(*) from stuff where s_pw='" + password.Text + "' AND s_name='" + username.Text + "'";

            SqlCommand cmd = new SqlCommand(SQLString, con);
            string t = cmd.ExecuteScalar().ToString();
            con.Close();
            counts--;
            if (t == "1")
            {
                SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=myhotel;Integrated Security=True");
                conn.Open();
                String S = "select Evip,Qmoney,Rmanage,Dper,Droom,Dgoods from stuff where s_pw='" + password.Text + "' AND s_name='" + username.Text + "'";
                SqlCommand com = new SqlCommand(S, conn);
                SqlDataReader Dr = com.ExecuteReader();
                if (Dr.Read())
                {
                    t1 = (int)Dr["Evip"];
                    t2 = (int)Dr["Qmoney"];
                    t3 = (int)Dr["Rmanage"];
                    t4 = (int)Dr["Dper"];
                    t5 = (int)Dr["Droom"];
                    t6 = (int)Dr["Dgoods"];
                }
                Dr.Close();
                conn.Close();
                this.Hide();
                entrance f = new entrance(username.Text.Trim());
                //权限导入
                if (t1 == 1)
                {
                    //设置注销VIP权限
                    f.v_de.Enabled = true;

                }
                if (t2 == 1)
                {
                    f.查询客户押金ToolStripMenuItem.Enabled = true; //打开查询客户押金权限
                }
                if (t3 == 1)
                {
                    f.REPORT.Enabled = true;//打开报表管理权限
                }
                if (t4 == 1)
                {
                    f.QX.Enabled = true;//打开操作权限设置权限
                }
                if (t5 == 1)
                {
                    f.RO.Enabled = true;//打开客房信息设置权限
                }
                if (t6 == 1)
                {
                    f.消费物品设置ToolStripMenuItem.Enabled = true;//打开商品信息设置权限
                }

                f.Show();//到下一个界面
            }
            else
            {
                if (counts == 0)
                {
                    this.Close();
                }
                MessageBox.Show("密码错误或者用户名不存在，请重新输入.您还有" + counts + "次机会！", "提示");

                password.Clear();

            }

        }


     
    }
}
