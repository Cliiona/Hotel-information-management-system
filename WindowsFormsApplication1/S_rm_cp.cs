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
    public partial class S_rm_cp : Form
    {
        public delegate void RoomFresh(object sender, EventArgs e);//委托声明
        event RoomFresh afterpress;//定义委托事件

        SqlConnection myCon = new SqlConnection();
        string CString = "Data Source=(local);Initial Catalog=myhotel;Integrated Security=True";
        public S_rm_cp(RoomFresh e)
        {
            InitializeComponent();
            afterpress += e;
        }
        private void S_rm_cp_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“myhotelDataSet.room_price”中。您可以根据需要移动或移除它。
            this.room_priceTableAdapter.Fill(this.myhotelDataSet.room_price);
        }
        //修改房价价格 
        private void cpSave_Click(object sender, EventArgs e)
        {
            
            myCon.ConnectionString = CString;
            string UpdateString1 = "UPDATE room_price SET roomprice = '" + NewPrice.Text + "' where room_price.roomtype = '" + RoomChange .Text  + "' ";
            string UpdateString2 = "UPDATE room SET r_price='" + NewPrice.Text + "' where r_type = '" + RoomChange.Text + "'";
            if ( RoomChange .Text !="" & cpSave.Text != ""& NewPrice .Text !="")
            {
                myCon.Open();
                SqlCommand mycommad = new SqlCommand(UpdateString1, myCon);
                mycommad.ExecuteNonQuery();
                SqlCommand com = new SqlCommand(UpdateString2,myCon);
                com.ExecuteNonQuery();
                myCon.Close();
                afterpress(null, null);
                this.Hide();
            }
            else
            {
                MessageBox.Show("房型和房价都不能为空值，请重输","空值提醒");
            }
        }
    }
}
