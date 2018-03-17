using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CashierSystem
{
    public partial class Frm_InitData : Form
    {
        ExcelHelper excelHelper = new ExcelHelper();
        Thread thread;
        Frm_InitDataProgressBar frm_InitDataProgressBar = new Frm_InitDataProgressBar();
        public Frm_InitData()
        {
            InitializeComponent();
        }

        private void btnDownStandardTable_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "保存标准商品信息表";
            save.Filter = "Excel文件(*.xlsx)|*.xlsx|Excel文件(*.xls)|*.xls";          
         
            //关闭窗口
            if (save.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            //获取文件地址
            string targetPath = save.FileName;
            string sourceFile = @"商品表.xlsx";
            if (!File.Exists(sourceFile))
            {
                MessageBox.Show("标准数据表丢失,请重新下载安装包或联系开发人员!");
                return;
            }
                  
            bool isrewrite = true; // true=覆盖已存在的同名文件,false则反之
         System.IO.File.Copy(sourceFile, targetPath, isrewrite);          
          MessageBox.Show("下载成功,请按要求填写商品数据");
        }

        private void btnUpLoadDataTable_Click(object sender, EventArgs e)
        {
           
            //开启窗口,让用户选择文件  1 文件夹 2 csv,txt
            OpenFileDialog opfialog = new OpenFileDialog();
            opfialog.Filter = "Excel文件(*.xlsx)|*.xlsx|Excel(*.xls)|*.xls)";
            opfialog.Title = "读取商品表数据";
            opfialog.Multiselect = false;
            if (opfialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string filePath = opfialog.FileName;           
            DataTable dataTable = new DataTable();
            //读取数据
            ThreadStart();//开启线程 显示数据导入页面
            var isSucess=  ExcelHelper.ReadExcel(filePath, dataTable, true);
            if (isSucess)
            {               
                InitGoodsData initGoodsData = new InitGoodsData();                
                if ( initGoodsData.AddGoodsData(dataTable, out List<string> changeMessage,out List<string>insertDataMessage))
                {
                    CloseInitDataProcessBar();//关闭等待框
                    ThreadEnd();//关闭线程
                    MessageBox.Show("保存成功!,请查看导入日志");                  
                    SaveMessage(filePath, changeMessage, insertDataMessage);//写入日志 并打开
                    this.Close();
                   
                }
                else
                {
                    CloseInitDataProcessBar();//关闭等待框
                    ThreadEnd();//关闭线程
                    MessageBox.Show("数据导入失败");                  
                    SaveMessage(filePath, changeMessage, insertDataMessage);//写入日志 并打开
                    this.Close();
                }
            }
            else
            {
                CloseInitDataProcessBar();
                ThreadEnd();//关闭线程
                MessageBox.Show("读取数据失败!!");              
                return;
            }

        }

        private void SaveMessage(string filePath, List<string> changeMessage,  List<string> insertDataMessage)
        {
            FileInfo fileInfo = new FileInfo(filePath);//关于文件信息
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            DirectoryInfo fileDic = fileInfo.Directory;//Excel 文件所件位置
            if (changeMessage.Count != 0)
            {
                var second = DateTime.Now.Second.ToString();                
                var errorMessagePath = fileDic + "/读取数据报告"+ fileName + ".Txt";
                //保存错误信息
                File.WriteAllLines(errorMessagePath, changeMessage.ToArray());
            }
            if (insertDataMessage.Count != 0)
            {
                var second = DateTime.Now.Second.ToString();
                var errorMessagePath = fileDic + "/数据导入报告" + fileName + ".Txt";
                File.WriteAllLines(errorMessagePath, insertDataMessage.ToArray());
            }
            string path = fileDic.ToString();//打开导入日志
            System.Diagnostics.Process.Start("explorer.exe", path);
        }

        private void ThreadStart()
        {
            ThreadStart threadStart = new ThreadStart(CreateInitDataProcessBar);//创建加载数据状态框
             thread = new Thread(threadStart);
            thread.IsBackground = true;//设置为后台线程
            thread.Start(); //启动新线程
          
        }

        private void ThreadEnd()
        {
            if (thread != null)
            {
                thread.Abort();//关闭线程
            }
        }

        private void CreateInitDataProcessBar()
        {
            frm_InitDataProgressBar.ShowDialog();

        }
      
        private void CloseInitDataProcessBar()
        {
           
            frm_InitDataProgressBar.Close();
        }
        private void Frm_InitData_Shown(object sender, EventArgs e)
        {
            this.label1.Focus();
        }

        private void Frm_InitData_Load(object sender, EventArgs e)
        {

        }
    }
}
