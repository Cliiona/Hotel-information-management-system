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
    public partial class V_DEL : Form
    {
        public V_DEL()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //////////////////////////////////////////写注销语句/////////////////////////////////////
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=myhotel;Integrated Security=True");
            conn.Open();
            String S = "delete from vip where v_no='" +textBox1 .Text + "'and v_name='"+textBox2 .Text +"'";
            SqlCommand cmd = new SqlCommand(S, conn);
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("注销成功！", "操作提示",MessageBoxButtons .OK ,MessageBoxIcon.Information );
                this.Close();
            }
            else
            {
                if (MessageBox.Show("注销失败，请重试！", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.Cancel)
                {
                    this.Close(); 
                }
                else 
                {
                    textBox1.Clear();
                    textBox2.Clear();
 
                }
 
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
