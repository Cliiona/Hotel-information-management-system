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
    public partial class Q_deposit : Form
    {
        public Q_deposit()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection();           //声明一个数据库连接对象

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Q_deposit_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  dataGridView1.setDataBind(null, null);
           // datagridview1.update();
           // dataGridView1.Rows.Clear();
            Con.ConnectionString = "Data Source=(local);Initial Catalog=myhotel;Integrated Security=True";//数据库连接字符串
            Con.Open();
            int j = 0;
            while (dataGridView1.Rows.Count != 0)
            {
                dataGridView1.Rows.RemoveAt(0);
            }
            String  [] b=new String [100];
            int i=0;
            

           SqlCommand cmd = new SqlCommand ("SELECT checkin.c_id from checkin  where( checkin.c_valid=1 and( '"+dateTimePicker1 .Value .ToString ("yyyy-MM-dd")+"' between checkin.c_intime and '2015-12-31')) ",Con);
           //SqlCommand cmd = new SqlCommand("SELECT checkin.c_id from checkin,checkout where( (('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'between checkout.O_intime and checkout.O_time )AND checkin.c_valid=0 and checkin.c_intime=checkout.O_intime )OR(checkin.c_valid=1 and( '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' between checkin.c_intime and '2015-12-30'))) ", Con);
            //SqlDataReader reader = cmd.ExecuteReader();
            SqlDataReader reader =cmd.ExecuteReader ();
           // for(i=0;reader.Read();int++)
             /*  if（reader.Read()）
               {    
                    if (reader["r_no"].ToString() != "")
                     //while(reader.Read())
                     {
                        b[i] = (int)reader[0];
                        i++;

                      }
                }
                else
                {
                  MessageBox.Show("在本时间之前的顾客均结账", "温馨提示");
                  Con.Close();
                  reader.Close();
                    return;
                 }*/
            if (reader.Read())
            {
                while (reader.Read())
                {
                    b[i] = reader[0].ToString ();
                    i++;

                }

            }
            else
            {
                MessageBox.Show("在本时间之前的顾客均结账", "温馨提示");
                Con.Close();
               // reader.Close();
            }

          /*  while (reader.Read())
                 {
                    b[i] = (int)reader[0];
                    i++;

                  }*/
        
            reader.Close();
            for (j = 0; j < i;j++ )
            {
                string no = Convert.ToString(b[j]);
                int sho;
                string shop;
                // string mysql = "select sum(gd_comsump.out_fee) AS '商品消耗费用' from checkin,gd_comsump where checkin.c_id=gd_comsump.c_id ";
                string sql1 = "select customer.c_name from customer where customer.c_id='" + no + "'";
                string sql2 = "select checkin.r_no from checkin,checkout where (checkin.c_id='" + no + "' and checkin.c_valid=1  and( '"+dateTimePicker1 .Value .ToString ("yyyy-MM-dd")+"' between  checkin.c_intime and 'Datetime.Today'))OR(checkout.c_id='" + no + "' and checkin.c_valid=0 and checkin.c_intime=checkout.O_intime and ('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'between checkout.O_intime and checkout.O_time) )";
                string sql3 = "select checkin.c_account from checkin,checkout where (checkin.c_id='" + no + "' and checkin.c_valid=1  and( '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' between checkin.c_intime and 'Datetime.Today'))OR(checkin.c_valid=0 and checkout.c_id='" + no + "' and checkin.c_intime=checkout.O_intime and ('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'between checkout.O_intime and checkout.O_time ))";

                string sql4 = "select sum(Out_fee) from gd_comsump,checkout,checkin where (gd_comsump.c_id='" + no + "'and checkin.c_id='"+no +"' and(gd_comsump.G_time between '1990-01-01' and '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "')and( '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' between  checkin.c_intime and 'Datetime.Today' ) and gd_comsump.G_valid=1) OR(gd_comsump.G_valid=0 and ('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' between checkout.O_intime and checkout.O_time)and (gd_comsump.G_time between checkout.O_intime and '"+dateTimePicker1 .Value .ToString ("yyyy-MM-dd")+"')and gd_comsump.c_id='"+no +"' and checkout.c_id='"+no +"' )";
                SqlCommand myqureycommand4 = new SqlCommand(sql4, Con);
                shop = myqureycommand4.ExecuteScalar().ToString();
                string sql10 = "select * from gd_comsump,checkout,checkin where (gd_comsump.c_id='" + no + "'and checkin.c_id='"+no +"' and(gd_comsump.G_time between '1990-01-01' and '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "')and( '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' between checkin.c_intime and 'Datetime.Today') and gd_comsump.G_valid=1) OR(gd_comsump.G_valid=0 and ('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' between checkout.O_intime and checkout.O_time)and (gd_comsump.G_time between checkout.O_intime and '"+dateTimePicker1 .Value .ToString ("yyyy-MM-dd")+"')and gd_comsump.c_id='"+no + "' and checkout.c_id='"+no +"' )";
                {
                    SqlCommand myqureycommand10 = new SqlCommand(sql10, Con);
                    SqlDataReader reader1 = myqureycommand10.ExecuteReader();
                  //  SqlCommand myqureycommand10 = new SqlCommand(sql10, Con);
                    if (reader1.Read())
                    {
                       // shop = myqureycommand4.ExecuteScalar().ToString();
                        sho = Convert.ToInt16(shop);
                    }
                    else
                    {
                        sho = 0;
                        shop = Convert.ToString(sho);
                    } 
                    reader1.Close(); 
                }
              //  reader1.Close();
                string shopp;
                //reader1.Close();
                string sql5 = "select room.r_price*datediff(day,checkin.c_intime,'"+dateTimePicker1.Value .ToString ("yyyy-MM-dd") +"')  from checkin,room where checkin.r_no=room.r_no and checkin.c_id='" + no + "'";
                SqlCommand myqureycommand1 = new SqlCommand(sql1, Con);
                string cname = myqureycommand1.ExecuteScalar().ToString();

                SqlCommand myqureycommand2 = new SqlCommand(sql2, Con);
                string rroom = myqureycommand2.ExecuteScalar().ToString();
                SqlCommand myqureycommand3 = new SqlCommand(sql3, Con);
                string account = myqureycommand3.ExecuteScalar().ToString();
                if (sho == 0)
                {
                    shopp = Convert.ToString(sho);
                }
                else
                {
                    shopp = shop;
                }
                SqlCommand myqureycommand5 = new SqlCommand(sql5, Con);
                string shoproom = myqureycommand5.ExecuteScalar().ToString();
                //SqlDataReader reader1 = myqureycommand4.ExecuteReader();
                // for(i=0;reader.Read();int++)
                /*  if（reader.Read()）
                  {    
                       if (reader["r_no"].ToString() != "")
                        //while(reader.Read())
                        {
                           b[i] = (int)reader[0];
                           i++;

                         }
                   }
                   else
                   {
                     MessageBox.Show("在本时间之前的顾客均结账", "温馨提示");
                     Con.Close();
                     reader.Close();
                       return;
                    }*/
             /*   if (reader1.Read())
                {
                    sho = Convert.ToInt16(shop);
                }
                else
                {
                    sho = 0;
                }*/
                int acc = Convert.ToInt16(account);
                // int sho = Convert.ToInt16(shop);
                int shor = Convert.ToInt16(shoproom);
                int last = acc-sho-shor;
                // int last=Convert.ToInt32(account)-Convert.ToInt32(shop)-Convert.ToInt32(shoproom);
                string lastsum = Convert.ToString(last);
                //  string lastsum = "no";

                // string cname = "no";
                // string rroom = "345";
                object[] mycell = { cname, no, rroom, account, shop, shoproom, lastsum };
                dataGridView1.Rows.Add(mycell);

                // string 
            }

           // Con.Close();
         

           // int[] arr = "select checkin.c_id from checkin.c_id where checkin.c_valid=1";

           // this.dataGridView1.Rows.Clear();
         //   System.Data.DataTable MyGuestTable=new System.Data.DataTable();

       //   string mysql = "select customer.c_name  AS '顾客姓名',customer.c_id AS '顾客证件号',room.r_no AS'房间号',checkin.c_account AS '预收押金',sum(gd_comsump.out_fee) AS '商品消耗费用',room.r_price*convert(numeric(18,2),(datediff(day,checkin.c_intime,checkin.c_outtime)))AS '住宿金额',(checkin.c_accout-sum(gd_comsump.out_fee)-convert(numeric(18,2),(datediff(day,checkin.c_intime,checkin.c_outtime)) ) AS '余额' from checkin, gd_comsump,customer,room where customer.c_id=checkin.c_id and check c_valid=1 and  gd_comsump.c_id=customer.c_id and gd_comsump.G_valid=1 and checkin.r_no=room.r_no and (gd_comsump.G_time between  checkin.c_intime and '" + dateTimePicker1.Value + "')";
         //   string mysql = "select c_name  AS '顾客姓名',c_id AS '顾客证件号',r_no AS'房间号',c_account AS '预收押金',sum(Out_fee) AS '商品消耗费用'from checkin, gd_comsump,customer,room where customer.c_id=checkin.c_id and check c_valid=1 and  gd_comsump.c_id=customer.c_id and gd_comsump.G_valid=1 and checkin.r_no=room.r_no";
            //  string mysql = "select (datediff("d",(select checkin.c_outtime from checkin),(select checkin.c_intime from checkin )) AS '住宿金额' from  checkin";
         // string mysql = "select room.r_price*datediff(day,checkin.c_outtime,checkin.c_intime) AS 'riqi' from checkin,room where checkin.r_no=room.r_no";
            //string mysql = "select sum(gd_comsump.out_fee) AS '商品消耗费用' from checkin,gd_comsump where checkin.c_id=gd_comsump.c_id ";
          // string mysql = "select checkin.c_account-sum(gd_comsump.out_fee)-room.r_price*convert(numeric(18,2),(datediff(day,checkin.c_intime,checkin.c_outtime))) AS '余额' from checkin, gd_comsump,room,customer where  checkin.c_valid=1 and gd_comsump.G_valid=1 and checkin.r_no=room.r_no and customer.c_id=gd_comsump.c_id and checkin.c_id=cusotmer.c_id and customer.c_name='"+t.Text +"'and (gd_comsump.G_time between  checkin.c_intime and '" + dateTimePicker1.Value + "') ";

            //  string mysql = "select checkin.c_id AS '顾客' from  checkin,customer where checkin.c_id=customer.c_id";
           //  string mysql =;  
           
         //  string mysql="select customer.c_name AS '姓名' ,checkin.c_id AS '证件号',checkin.r_no AS '房间号' from checkin,room,customer where customer.c_id=checkin.c_id AND checkin.r_no=room.r_no";
       //     SqlCommand mycommad = new SqlCommand(mysql, Con);
         //   SqlDataAdapter myadapter = new SqlDataAdapter(mycommad);
          //  DataTable MyQueryTable = new DataTable();
          //  MyQueryTable.Clear();
          //  myadapter.Fill(MyQueryTable);
          //  this.dataGridView1.DataSource = MyQueryTable;
            Con.Close();
          //  DataTable MyQueryTable = new DataTable();
            //SqlCommand myqureycommand = new SqlCommand(mysql,Con);
            //SqlDataAdapter myqueryadapter = new SqlDataAdapter(myqureycommand);
            //MyQueryTable.Clear();
        }

        




        
    }
}
