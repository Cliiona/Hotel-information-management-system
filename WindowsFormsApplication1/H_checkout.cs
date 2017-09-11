using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing .Printing ;

namespace WindowsFormsApplication1
{
    public partial class H_checkout : Form
    {
        public H_checkout()
        {
            InitializeComponent();
        }

        int flag = 0; //用来标识是否为vip结账
        SqlConnection myCon = new SqlConnection();
        string CString = "Data Source=(local);Initial Catalog=myhotel;Integrated Security=True";

        private void H_checkout_Load(object sender, EventArgs e)
        {
            
        }

        //改变客户类型触发事件
        private void vip_CheckedChanged(object sender, EventArgs e)
        {
            roomno_Validated(null, null);
        }

        private void roomno_Validated(object sender, EventArgs e)
        {
            string romno = null;
            if (roomno.Text != "")
            {
                condb();
           //判断 是否换过房 若有则获取曾住房号
                string judge = "select r_no from checkin AS CH where( CH.c_id=(select CHE.c_id from checkin AS CHE where (CHE.r_no='"+roomno.Text+"' and CHE.c_valid=1))and CH.c_valid=2)";
                SqlCommand judg = new SqlCommand(judge,myCon);
                SqlDataReader rd = judg.ExecuteReader();
               if(rd.Read())
               {
                   romno = rd[0].ToString();
               }
               rd.Close();
                if (romno==null ) //(rd.Read())//
                {
         //********没有换过房************

                    //房价的计算
                    int d = 0;//存放入住的天数,若不初始化则会在计算房费时提醒未定义变量d
                    int rp;//房价
                    //condb();//连接数据库
                    string datestring = "select datediff(day,(select c_intime from checkin where r_no='" + roomno.Text + "'AND c_valid=1),'" + System.DateTime.Today + "')";
                    string rpstring = "select * from room where r_no='" + roomno.Text + "'";
                    string idstring = "select * from checkin where r_no='" + roomno.Text + "'AND c_valid=1";
                    SqlCommand com = new SqlCommand(datestring, myCon);
                    //计算出的具体天数

                    SqlDataReader rd1 = com.ExecuteReader();

                    if (rd1.Read())
                    {
                        if (rd1[0].ToString() != "")//若未找到记录则要提示
                        {
                            d = (int)rd1[0];
                        }
                        else
                        {
                            MessageBox.Show("当前客房暂未有人入住，请重新输入房号", "温馨提示");
                            rd1.Close();
                            return;//这样就不会执行下面代码了
                        }
                    }
                    rd1.Close();

                    //计算全部房费
                    SqlCommand cacu = new SqlCommand(rpstring, myCon);
                    using (SqlDataReader rdc = cacu.ExecuteReader())
                    {
                        if (rdc.Read())
                        {
                            rp = Int16.Parse(rdc["r_price"].ToString());
                            roomfee.Text = (d * rp).ToString();
                        }
                        rdc.Close();
                    }

                    //查找客户ID和押金
                    SqlCommand id = new SqlCommand(idstring, myCon);

                    using (SqlDataReader ird = id.ExecuteReader())
                    {
                        if (ird.Read())
                        {
                            cid.Text = ird["c_id"].ToString().Trim();
                            remark.Text = ird["c_remark"].ToString().Trim();
                            intime.Text = ird["c_intime"].ToString().Trim();
                            deposit.Text = ird["c_account"].ToString().Trim();
                            rtype.Text = ird["c_rtype"].ToString().Trim();
                            //提前退房要修改checkin中的outtime
                            if (DateTime.Compare(Convert.ToDateTime(ird["c_intime"]), System.DateTime.Today) > 0)
                            {
                                //！！！不知道 提前退房的换房客户 能不能跑。。待定
                                using (myCon)
                                {
                                    string upcheckin = "update checkin set c_outtime='" + System.DateTime.Today + "'where c_id='" + ird["c_id"].ToString() + "' AND c_valid!='0'";
                                    SqlCommand upc = new SqlCommand(upcheckin, myCon);
                                    upc.ExecuteNonQuery();
                                    ird.Close();
                                }
                            }
                        }
                        ird.Close();
                    }

                    //查询和计算物品消费
                    string ipstring = "select sum(Out_fee) from gd_comsump where c_id=(select c_id from checkin where r_no='" + roomno.Text + "') AND G_valid=1";
                    SqlCommand icom = new SqlCommand(ipstring, myCon);
                    using (SqlDataReader icrd = icom.ExecuteReader())
                    {

                        if (icrd.Read())
                        {
                            itemfee.Text = icrd[0].ToString();
                            icrd.Close();
                        }
                        //判断是否有物品消费，避免字符串为空时致错
                        if (itemfee.Text != "")
                        {
                            totalfee.Text = (Convert.ToDouble(itemfee.Text) + Convert.ToDouble(roomfee.Text)).ToString();
                        }
                        else
                        {
                            itemfee.Text = "0";
                            totalfee.Text = Convert.ToDouble(roomfee.Text).ToString();
                        }
                    }

                    //查看该房间的住户是否为VIP
                    string vor = "select * from customer where c_id=(select c_id from checkin where r_no='" + roomno.Text + "')";
                    SqlCommand oh = new SqlCommand(vor, myCon);
                    using (SqlDataReader ord = oh.ExecuteReader())
                    {
                        if (ord.Read())
                        {
                            string v = ord["type"].ToString();
                            if (v != "VIP")//普通客户
                            {
                                flag = 0;
                                disprice.Text = "消费总计：";
                                discount.Text = totalfee.Text;
                                cname.Text=ord["c_name"].ToString();
                                ord.Close();//非常关键！！！
                                vip.Checked = false;
                            }
                            else
                            {
                                flag = 1;
                                disprice.Text = "折后金额：";
                                discount.Text = (Convert.ToDouble(totalfee.Text) * 0.88).ToString();
                                cname.Text = ord["c_name"].ToString();
                                ord.Close();//非常关键！！！
                                vip.Checked = true;

                            }
                            balance.Text = (Convert.ToDouble(discount.Text) - Convert.ToDouble(deposit.Text)).ToString();
                        }
                        myCon.Close();
                    }
                }
                else if(romno!=null )
                {

      //********换过一次***************
                    //房价的计算
                    int d = 0;//存放入住的天数,若不初始化则会在计算房费时提醒未定义变量d
                    int rp;//房价
                    condb();//连接数据库
                    string datestring = "select datediff(day,(select c_intime from checkin where r_no='" + roomno.Text + "'AND c_valid=1),'" + System.DateTime.Today + "')";
                    string datastring2 = "select datediff(day,(select c_intime from checkin where r_no='" + romno + "'AND c_valid=2),(select c_outtime from checkin where r_no='" + romno + "'AND c_valid=2))";
                    string rpstring = "select * from room where r_no='" + roomno.Text + "'";//房价相同
                    string idstring = "select * from checkin where r_no='" + roomno.Text + "'AND c_valid=1";
                    string idstring2 = "select * from checkin where r_no='" +romno+ "'AND c_valid=2";
                    SqlCommand com = new SqlCommand(datestring, myCon);
                    SqlCommand com2=new SqlCommand(datastring2,myCon);
                    //计算出的具体天数
                    SqlDataReader rd1 = com.ExecuteReader();
                    if (rd1.Read())
                    {
                        d=(int)rd1[0];

                        //if (rd1[0].ToString() != "")//若未找到记录则要提示
                        //{
                        //    d = (int)rd1[0];
                        //}
                        //else
                        //{
                        //    MessageBox.Show("当前客房暂未有人入住，请重新输入房号", "温馨提示");
                        //    rd1.Close();
                        //    return;//这样就不会执行下面代码了
                        //}
                    }
                    //rd1.Close();
                    rd1.Dispose();
                    rd1 = com2.ExecuteReader();
                    if(rd1.Read())
                    {
                        if (rd1[0] != null)
                        {
                            d += Convert.ToInt32(rd1[0].ToString());//求得入住总天数
                        }
                    }
                    rd1.Close();

                    //计算全部房费
                    SqlCommand cacu = new SqlCommand(rpstring, myCon);
                    using (SqlDataReader rdc = cacu.ExecuteReader())
                    {
                        if (rdc.Read())
                        {
                            rp = Int16.Parse(rdc["r_price"].ToString());
                            roomfee.Text = (d * rp).ToString();
                        }
                    }

                    //查找客户ID和押金
                    SqlCommand id = new SqlCommand(idstring, myCon);
                    SqlCommand id2 = new SqlCommand(idstring2,myCon);
                    using (SqlDataReader ird = id.ExecuteReader())
                    {
                        if (ird.Read())
                        {
                            cid.Text = ird["c_id"].ToString().Trim();
                            remark.Text = ird["c_remark"].ToString().Trim();
                            rtype.Text=ird["c_rtype"].ToString().Trim();
                            //intime.Text = ird["c_intime"].ToString().Trim();
                            deposit.Text = ird["c_account"].ToString().Trim();//在第一天中找到押金
                        }
                    }

                    SqlDataReader ird2 = id2.ExecuteReader();
                    if (ird2.Read())
                    {
                        //intime.Text = ird["c_intime"].ToString().Trim();
                        if (DateTime.Compare(Convert.ToDateTime(ird2["c_outtime"]), System.DateTime.Today) > 0)
                        {
                            //提前退房要修改checkin中的outtime
                            //！！！不知道 提前退房的换房客户 能不能跑。。待定
                            using (myCon)
                            {
                                string upcheckin = "update checkin set c_outtime='" + System.DateTime.Today + "'where c_id='" + ird2["c_id"].ToString() + "' AND c_valid!='0'";
                                SqlCommand upc = new SqlCommand(upcheckin, myCon);
                                upc.ExecuteNonQuery();
                                ird2.Close();
                            }
                        }
                        
                    }
                    ird2.Close();
                    //查询和计算物品消费
                    double fee = 0;
                    
                    string ipstring = "select sum(Out_fee) from gd_comsump where c_id=(select c_id from checkin where r_no='" + roomno.Text + "') AND G_valid=1";
                    string ipstring2 = "select sum(Out_fee) from gd_comsump where c_id=(select c_id from checkin where r_no='" + romno + "') AND G_valid=1";
                    SqlCommand icom = new SqlCommand(ipstring, myCon);
                    SqlCommand icom2 = new SqlCommand(ipstring2,myCon);
                    using (SqlDataReader icrd = icom.ExecuteReader())
                    {
                        if (icrd.Read())
                        {
                            if (icrd[0].ToString() != "")
                            {
                                fee = Convert.ToDouble(icrd[0].ToString());                      
                            }
                            //itemfee.Text = icrd[0].ToString();
                            
                        }
                    }
                    using(SqlDataReader icrd2= icom2.ExecuteReader())
                    {
                        if (icrd2.Read())
                        {
                            if(icrd2[0].ToString()!="")
                            {
                                fee += Convert.ToDouble(icrd2.ToString());
                            }
                            
                        }
                    }


                    //totalfee.Text = (fee+Convert.ToDouble(roomfee.Text)).ToString();

                    //判断是否有物品消费，避免字符串为空时致错
                    if (fee!=0)
                    {
                        itemfee.Text = fee.ToString(); ;
                        totalfee.Text = (Convert.ToDouble(itemfee.Text) + Convert.ToDouble(roomfee.Text)).ToString();
                    }
                    else
                    {
                        itemfee.Text = "0";
                        totalfee.Text = Convert.ToDouble(roomfee.Text).ToString();
                    }

                    //查看该房间的住户是否为VIP
                    string vor = "select * from customer where c_id=(select c_id from checkin where r_no='" + roomno.Text + "')";
                    SqlCommand oh = new SqlCommand(vor, myCon);
                    using (SqlDataReader ord = oh.ExecuteReader())
                    {
                        if (ord.Read())
                        {
                            string v = ord["type"].ToString();
                            if (v != "VIP")//普通客户
                            {
                                flag = 0;
                                disprice.Text = "消费总计：";
                                discount.Text = totalfee.Text;
                                cname.Text=ord["c_name"].ToString();
                                ord.Close();//非常关键！！！
                                vip.Checked = false;
                            }
                            else
                            {
                                flag = 1;
                                disprice.Text = "折后金额：";
                                discount.Text = (Convert.ToDouble(totalfee.Text) * 0.88).ToString();
                                cname.Text = ord["c_name"].ToString();
                                ord.Close();//非常关键！！！
                                vip.Checked = true;

                            }
                            balance.Text = (Convert.ToDouble(discount.Text) - Convert.ToDouble(deposit.Text)).ToString();
                        }
                        myCon.Close();
                    }
                }
            

         
                   
            }          
        }

        public void condb()
        {
            if (myCon.State == ConnectionState.Closed)//其中ConnectionState是一个枚举类型.Closed为其成员之一
            {
                myCon.ConnectionString = CString;
                myCon.Open();
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            myCon.Open();
      //判断是否已退房
            string check="select * from checkout where c_id='"+roomno.Text+"' and O_intime='"+intime.Value+"'";
            SqlCommand ch=new SqlCommand(check,myCon);
            SqlDataReader rch=ch.ExecuteReader();
            if (rch.Read())
            {
                MessageBox.Show("该房间客户今日已完成退房！", "温馨提示");
                rch.Close();
            }
            else
            {
                rch.Close();
                string save = "insert into checkout values('" + cid.Text + "','" + roomno.Text + "','" + roomfee.Text + "','" + remark.Text + "','" + itemfee.Text + "','" + today.Value + "','" + intime.Value + "','" + totalfee.Text + "',(select c_name from customer where c_id='" + cid.Text + "'),(select type from customer where c_id='" + cid.Text + "'))";
                SqlCommand savecon = new SqlCommand(save, myCon);
                savecon.ExecuteNonQuery();
            }
   //修改其他表格有效值
            string modify1 = "update room set r_full=0 where r_no='"+roomno.Text+"'and r_full!=0";
            string modify2 ="update checkin set c_valid=0 where r_no='"+roomno.Text+"'and c_valid!=0";
            string modify3 ="update gd_comsump set G_valid=0 where c_id='"+cid.Text+"'and G_valid=1";
            SqlCommand mod1 = new SqlCommand(modify1,myCon);
            SqlCommand mod2 = new SqlCommand(modify2, myCon);
            SqlCommand mod3 = new SqlCommand(modify3, myCon);
            mod1.ExecuteNonQuery();
            mod2.ExecuteNonQuery();
            mod3.ExecuteNonQuery();
            myCon.Close();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {


            printDialog1.ShowDialog();
            PaperSize mysize = new PaperSize();
            mysize.Height = 600;
            mysize.Width = 1000;
            printDocument1.DefaultPageSettings.PaperSize = mysize;

            //printDialog1.PrinterSettings .PaperSizes  = new PaperSize("Custom", 826, 492);
            printPreviewDialog1.Document = this.printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           Pen pen = new Pen(Color.Black, 2);
            e.Graphics.DrawString("Myhotel宾馆欢饮您下次入住", new Font("宋体", 20, FontStyle.Regular), Brushes.Red, 600, 500);
            e.Graphics.DrawString("打印日期：" + DateTime.Now + "", new Font("宋体", 20, FontStyle.Regular), Brushes.Red, 500, 550);
            e.Graphics.DrawString("酒店地址：湖北省武汉市华中科技大学", new Font("宋体", 20, FontStyle.Regular), Brushes.Red, 80, 500);

            e.Graphics.DrawString("客户姓名：" + cname.Text + "", new Font("宋体", 20, FontStyle.Regular), Brushes.Black, 165, 220);
            e.Graphics.DrawString("住宿房间：" + roomno.Text + "", new Font("宋体", 20, FontStyle.Regular), Brushes.Black, 500, 220);
            e.Graphics.DrawString("房间类型：" + rtype.Text + "", new Font("宋体", 20, FontStyle.Regular), Brushes.Black, 500, 290);
            e.Graphics.DrawString("证件编号：" + cid.Text + "", new Font("宋体", 20, FontStyle.Regular), Brushes.Black, 165, 360);
            e.Graphics.DrawString("证件类型：居民身份证", new Font("宋体", 20, FontStyle.Regular), Brushes.Black, 500, 360);

            for (int i = 0; i <= 4; i++)
            {
                e.Graphics.DrawLine(pen, 150, 200 + i * 70, 850, 200 + i * 70);
            }
            for (int j = 0; j <= 2; j++)
            {
                e.Graphics.DrawLine(pen, 150 + 350 * j, 200, 150 + 350 * j, 480);
            }
         
                e.Graphics.DrawString("入住时间：" + intime.Value.ToString("yyyy-MM-dd") + "", new Font("宋体", 20, FontStyle.Regular), Brushes.Black, 170, 430);
                e.Graphics.DrawString("离开时间：" + today.Value.ToString("yyyy-MM-dd") + "", new Font("宋体", 20, FontStyle.Regular), Brushes.Black, 500, 430);
                e.Graphics.DrawString("消费金额：" + balance.Text + "", new Font("宋体", 20, FontStyle.Regular), Brushes.Black, 170, 290);
                e.Graphics.DrawString("Myhotel宾馆有限公司旅客结账单", new Font("宋体", 40, FontStyle.Regular), Brushes.Black, 100, 100);

            
          
            
        
        
        }

       


        }




    }
