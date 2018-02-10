using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Common_Winform
{
    public class DataGridViewHelper
    {

        DataGridView MyDataGridView = new DataGridView();
        /// <summary>
        /// 用于辅助
        /// </summary>
        public int HelperValue = int.MaxValue;

       public  DataGridViewHelper()
        {

        }
        public DataGridViewHelper(DataGridView dataGridView )
        {
            MyDataGridView = dataGridView;
        }

        public DataGridView Init(DataGridView pDataGridView, DataTable dataTable)
        {
            MyDataGridView = null;
            MyDataGridView = pDataGridView;
            MyDataGridView.AllowUserToOrderColumns = false;//关闭列间排序
            MyDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//填充           
            pDataGridView.DataSource = dataTable;
            return MyDataGridView;
        }

        /// <summary>
        /// 初始化表格
        /// </summary>
        /// <param name="pDataGridView">表格控件</param>
        /// <param name="handerNames">标题行</param>
        /// <param name="dataTable">数据表</param>
        ///  <param name="hideColumn">隐藏列数的列表</param>
        /// <param name="usingNo">是否启用行标题</param>
        /// <returns></returns>
        public DataGridView Init(DataGridView pDataGridView,List<string>name, List<string> handerNames, DataTable dataTable,List<int>hideColumn=null, bool usingNo = true ,bool usingChk=false)
        {
            MyDataGridView = null;
            MyDataGridView = pDataGridView;           
            BindingSource bs = new BindingSource();           
            bs.DataSource = dataTable;
            MyDataGridView.DataSource = bs;//填充数据
            MyDataGridView.BackgroundColor = Color.WhiteSmoke;//DataGridView 背景色白色
            MyDataGridView.AllowUserToOrderColumns = false;//关闭列间排序
            MyDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//填充表格
            MyDataGridView.ColumnHeadersVisible = true;//列标题可见
            MyDataGridView.RowHeadersVisible = true;//行标题可见
            MyDataGridView.EnableHeadersVisualStyles = false;//禁用默认标题样式
            MyDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", 15, FontStyle.Bold);//自定义标题样式
            MyDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//标题居中
            MyDataGridView.MultiSelect = false;//仅单选
            MyDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//整行被选中
            MyDataGridView.ReadOnly = true;
            if (usingNo)
            {
                MyDataGridView.RowPostPaint += DataGridView_RowPostPaint;//行标题
            }
            if (usingChk)
            {
                DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                MyDataGridView.Columns.Add(col);
                MyDataGridView.MultiSelect = false;//仅单选
                MyDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//整行被选中
                 //加载 单击选中事件 
                MyDataGridView.Click += DataGridView_Click;
            }
            
            for (int i = 0; i < handerNames.Count; i++)
            {
                if (dataTable .Columns.Count<=i)
                {
                    continue;//表列数大于标题数               
                }
              
                MyDataGridView.Columns[i].Name = name[i];
                MyDataGridView.Columns[i].HeaderText = handerNames[i];
                MyDataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                MyDataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (hideColumn != null)
            {
                for (int i = 0; i < hideColumn.Count; i++)
                {
                    MyDataGridView.Columns[hideColumn[i]].Visible = false;
                }
            }



            //奇偶行不同颜色
            ChangeColor();

            
            return MyDataGridView;
        }

        /// <summary>
        /// 初始化DataGridView
        /// </summary>
        /// <param name="pDataGridView">DataGridView</param>
        /// <param name="nameList">名字列表</param>
        /// <param name="handerNames">标题列表</param>
        /// <param name="hideColumn">隐藏列</param>
        /// <param name="usingNo">使用标题行</param>    
        /// <returns></returns>
        public DataGridView Init(DataGridView pDataGridView, List<string> nameList, List<string> handerNames, List<int> hideColumn = null, bool usingNo = true)
        {
            MyDataGridView = null;
            MyDataGridView = pDataGridView;
            MyDataGridView.BackgroundColor = Color.WhiteSmoke;//DataGridView 背景色白色
            MyDataGridView.AllowUserToOrderColumns = false;//关闭列间排序
            MyDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//填充表格
            MyDataGridView.ColumnHeadersVisible = true;//列标题可见
            MyDataGridView.RowHeadersVisible = true;//行标题可见
            MyDataGridView.EnableHeadersVisualStyles = false;//禁用默认标题样式
            MyDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", 15, FontStyle.Bold);//自定义标题样式
            MyDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//标题居中
            MyDataGridView.MultiSelect = false;//仅单选
            MyDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//整行被选中
            MyDataGridView.ReadOnly = true;
            if (usingNo)
            {
                MyDataGridView.RowPostPaint += DataGridView_RowPostPaint;//行标题
            }
            if (nameList.Count==handerNames.Count&&nameList.Count>0)
            {
                for (int i = 0; i < nameList.Count; i++)
                {
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;//关闭列内排序
                    col.DataPropertyName =nameList[i];
                    col.Name = nameList[i];
                    col.HeaderText = handerNames[i];
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    MyDataGridView.Columns.Add(col);
                }
               
            }
            
            if (hideColumn != null)
            {
                for (int i = 0; i < hideColumn.Count; i++)
                {
                    MyDataGridView.Columns[hideColumn[i]].Visible = false;
                }
            }
           
            
            return MyDataGridView;
        }

        /// <summary>
        /// 填充数据
        /// </summary>
        /// <param name="pDataGridView"></param>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public DataGridView FillData(DataGridView pDataGridView,DataTable dataTable)
        {
            MyDataGridView = null;
            MyDataGridView = pDataGridView;
            BindingSource bs = new BindingSource();
            bs.DataSource = dataTable;
            MyDataGridView.DataSource = bs;//填充数据
            ChangeColor();
            return MyDataGridView;
        }







        /// <summary>
        /// 传入datagridview添加行号，然后重新加载进去
        /// </summary>
        /// <param name="dg"></param>
        /// <param name="e"></param>
        public static void TableEditByOld(System.Windows.Forms.DataGridView dg, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dg.RowHeadersWidth - 4, e.RowBounds.Height);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dg.RowHeadersDefaultCellStyle.Font, rectangle, dg.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
            }
            catch (Exception exp)
            {
                //MessageBox.Show(exp.Message);
                //  Log.LogError.AddLogError("错误信息", exp, _Path);
            }
        }

        /// <summary>
        /// 自动 行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //自动编号，与数据无关
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
               e.RowBounds.Location.Y,
               MyDataGridView.RowHeadersWidth - 4,
               e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics,
                  (e.RowIndex + 1).ToString(),
                   MyDataGridView.RowHeadersDefaultCellStyle.Font,
                   rectangle,
                   MyDataGridView.RowHeadersDefaultCellStyle.ForeColor,
                   TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        /// <summary>
        /// 单击事件 选择框的改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_Click(object sender, EventArgs e)
        {
            DataGridViewRow dataGridViewRow = null;
            if (this.MyDataGridView.SelectedRows.Count > 0)
            {
                dataGridViewRow = this.MyDataGridView.SelectedRows[0];
            }
            //该行第一个如果是选择框则 
            if (dataGridViewRow==null)
            {
                return;
            }
            bool?  isCheck = Convert.ToBoolean(dataGridViewRow.Cells[0].Value);
            if (isCheck!=null )
            {
                if ((bool)isCheck)
                {
                    dataGridViewRow.Cells[0].Value = (object)false;
                }
                else
                {
                    dataGridViewRow.Cells[0].Value = (object)true;

                }
            }
        }

       

        private void ChangeColor()
        {
            for (int i = 0; i < MyDataGridView.RowCount; i++)
            {
                //偶数行
                if (i%2==0)
                {
                    MyDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    MyDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                }
            }
        }



    }
}
