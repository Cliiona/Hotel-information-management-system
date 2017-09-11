using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace myhotel
{
    class excel
    {
        public void toExcel(DataTable tempTable)
        {
            //将datagridView中的数据导出到一张表中  


            // tempTable = UpdateDataTable(tempTable );

            //导出信息到Excel表  

            Microsoft.Office.Interop.Excel.ApplicationClass myExcel;

            Microsoft.Office.Interop.Excel.Workbooks myWorkBooks;

            Microsoft.Office.Interop.Excel.Workbook myWorkBook;//获取工作簿

            Microsoft.Office.Interop.Excel.Worksheet myWorkSheet; //获取工作表

            char myColumns;

            Microsoft.Office.Interop.Excel.Range myRange;

            object[,] myData = new object[500, 35];

            int i, j;//j代表行,i代表列  

            myExcel = new Microsoft.Office.Interop.Excel.ApplicationClass();

            //显示EXCEL  

            myExcel.Visible = true;

            if (myExcel == null)
            {
                MessageBox.Show("本地Excel程序无法启动!请检查您的Microsoft Office正确安装并能正常使用", "提示");
                return;
            }
            myWorkBooks = myExcel.Workbooks;

            myWorkBook = myWorkBooks.Add(System.Reflection.Missing.Value);

            myWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)myWorkBook.Worksheets[1];

            myColumns = (char)(tempTable.Columns.Count + 64);//设置列  

            myRange = myWorkSheet.get_Range("A1", myColumns.ToString() + "5");//设置列宽  
            int count = 0;

            //设置列名  

            foreach (DataColumn myNewColumn in tempTable.Columns)
            {
                myData[0, count] = myNewColumn.ColumnName;
                count = count + 1;
            }

            //输出datagridview中的数据记录并放在一个二维数组中  

            j = 1;

            foreach (DataRow myRow in tempTable.Rows)//循环行  
            {

                for (i = 0; i < tempTable.Columns.Count; i++)//循环列  
                {

                    myData[j, i] = @"" + myRow[i].ToString() + @"";

                }

                j++;

            }

            //将二维数组中的数据写到Excel中  

            myRange = myRange.get_Resize(tempTable.Rows.Count + 1, tempTable.Columns.Count);//创建列和行  
            myRange.NumberFormatLocal = "@";
            myRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;//设置边框
            myRange.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;//设置边框粗细
            myRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;//对齐方式
            myRange.Value2 = myData;
            myRange.EntireColumn.AutoFit();



        }
        


    }
}
