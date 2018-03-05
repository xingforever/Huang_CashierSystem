using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CashierSystem
{
    public partial class Frm_InitData : Form
    {
        ExcelHelper excelHelper = new ExcelHelper();
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
            var isSucess=  ExcelHelper.ReadExcel(filePath, dataTable, true);
            if (isSucess)
            {
                InitGoodsData initGoodsData = new InitGoodsData();
              if( initGoodsData.AddGoodsData(dataTable, out List<string> errorMessage))
                {
                    if (errorMessage.Count!=0)
                    {
                        //保存错误信息
                    }
                }
                else
                {
                    MessageBox.Show("数据导入成功!!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("读取数据失败!!");
                return;
            }

        }
    }
}
