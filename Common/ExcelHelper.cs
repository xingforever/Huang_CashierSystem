using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Office.Interop.Excel;


namespace Common
{
   public  class ExcelHelper
    {
        static object missing = System.Reflection.Missing.Value;
        /// <summary>
        /// 读取Excel
        /// </summary>
        /// <param name="filePath">文件地址</param>
        /// <param name="dataTable">表格</param>
        /// <param name="hasTitle">是否含有标题</param>
        /// <returns></returns>
        public static bool ReadExcel(string filePath, System.Data.DataTable dataTable, bool hasTitle)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application
                {
                    Visible = false,
                    UserControl = true
                };//lauch excel application
                  // 以只读的形式打开EXCEL文件                
                Workbook wb = excel.Application.Workbooks.Open(filePath, missing, true, missing, missing, missing,
                 missing, missing, missing, true, missing, missing, missing, missing, missing);
                Worksheet ws = (Worksheet)wb.Worksheets[1];//编号从1开始
                Range usedRange = ws.UsedRange;
                //清除旧数据
                dataTable.Rows.Clear();
                dataTable.Columns.Clear();
                //获得行列范围
                int Rowmin = int.MaxValue, Rowmax = 0, Colmin = int.MaxValue, Colmax = 0;
                foreach (Range cell in usedRange.Cells)
                {
                    var value = GetData(cell);
                    if (value != null)
                    {
                        if (Rowmin > cell.Row) Rowmin = cell.Row;
                        if (Rowmax < cell.Row) Rowmax = cell.Row;
                        if (Colmin > cell.Column) Colmin = cell.Column;
                        if (Colmax < cell.Column) Colmax = cell.Column;
                    }
                }
                var iColCount = Colmax - Colmin + 1;
                var iRowCount = Rowmax - Rowmin + 1;
                string[] Tiltes = null;
                if (hasTitle) Tiltes = GetTitleName(usedRange, iColCount, Rowmin, Colmin);
                //创建列
                for (int i = 0; i < iColCount; i++)
                {
                    //设置表头
                    if (Tiltes != null && Tiltes[i] != null)
                    {
                        dataTable.Columns.Add(Tiltes[i]);
                    }
                    else
                    {
                        dataTable.Columns.Add();
                    }                
                }
                //创建行
                if (Tiltes != null) iRowCount--;
                for (int i = 0; i < iRowCount; i++)
                {
                    DataRow row = dataTable.NewRow();//创建新行  
                    dataTable.Rows.Add(row);
                }
                foreach (Range cell in usedRange.Cells)
                {
                    var value = GetData(cell);//取某单元的值
                    if (value != null)//有值
                    {
                        var i = cell.Row - Rowmin;
                        var j = cell.Column - Colmin;
                        if (Tiltes != null)
                        {
                            i--;
                            if (i < 0) continue;
                        }
                        dataTable.Rows[i][j] = value;
                    }
                }
                //关闭Excel 进程
                CloseExcelProcess(excel);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        /// <summary>
        /// 保存Excel
        /// </summary>
        /// <param name="filePath">文件地址</param>
        /// <param name="dataTable">表格</param>
        /// <returns></returns>
        public static bool WriteExcel(string filePath, System.Data.DataTable dataTable,bool hasTitle)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//启动Excel
                excel.Visible = false;
                excel.UserControl = true;
                Workbook wBook = excel.Workbooks.Add(true);
                Worksheet wSheet = wBook.Worksheets[1] as Worksheet;
                int row = 0;
                if (hasTitle)
                {
                    row = 1;
                    foreach (DataColumn Column in dataTable.Columns)
                    {
                        var name = Column.ColumnName;
                        wSheet.Cells[row, Column.Ordinal+1] = name;
                    }
                }
                foreach (DataRow Row in dataTable.Rows)
                {
                    row += 1;
                    var itemArray = Row.ItemArray;
                    for (int i = 0; i < itemArray.Length; i++)
                    {
                        wSheet.Cells[row, i+1] = itemArray[i].ToString();
                    }
                  
                 }
                //线类型设置
                wSheet.UsedRange.Borders.LineStyle = XlLineStyle.xlContinuous;
                //水平居中
                wSheet.UsedRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                //垂直居中
                wSheet.UsedRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
                //设置禁止弹出保存和覆盖的询问提示框   
                excel.DisplayAlerts = false;
                excel.AlertBeforeOverwriting = false;
                //保存excel文件   
                wBook.SaveAs(filePath);
                wBook.Close();
                //退出处理
                CloseExcelProcess(excel);
                
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        /// <summary>
        /// 退出Excel
        /// </summary>
        /// <param name="excel"></param>
        static  void CloseExcelProcess(Microsoft.Office.Interop.Excel.Application excel)
        {
            //退出处理
            excel.Quit();
            var generation = System.GC.GetGeneration(excel);
            System.GC.Collect(generation);
        }
        /// <summary>
        /// 获取单元格值
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private static object GetData(Range cell)
        {
            var value = cell.Value;//取某单元的值
            if (value != null)//有值
            {
                //检查是否为空白符
                string s = value as string;
                if (s != null)
                {
                    s = s.Trim();
                    if (s != "")
                    {
                        value = s;
                    }
                    else
                    {
                        value = null;
                    }
                }
            }
            return value;
        }
        /// <summary>
        /// 获取标题
        /// </summary>
        /// <param name="usedRange"></param>
        /// <param name="Cols"></param>
        /// <param name="FirstRow"></param>
        /// <param name="FirstCol"></param>
        /// <returns></returns>
        static  string[] GetTitleName(Range usedRange, int Cols, int FirstRow, int FirstCol)
        {
            var a = new string[Cols];
            foreach (Range cell in usedRange.Cells)
            {
                if (cell.Row == FirstRow)
                {
                    var v = GetData(cell);
                    if (v != null)
                    {
                        a[cell.Column - FirstCol] = v.ToString();
                    }
                }
            }
            return a;
        }
    }
}
