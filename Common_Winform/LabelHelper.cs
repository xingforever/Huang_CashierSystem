using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Common_Winform
{
    public class LabelHelper
    {
        public Label label;
       
        public LabelHelper(Label label)
        {
            this.label = label;
        }
        /// <summary>
        /// 获取自动换行的labdel
        /// </summary>
        /// <param name="theLabel">Label控件</param>
        /// <param name="str">显示字符串</param>
        /// <param name="rowNum">每行显示字符</param>
        /// <param name="rowHeight">行高</param>
        /// <returns></returns>
        public static   Label GetAutoSizeLabel(Label theLabel ,string str="",int rowNum = 10,int rowHeight=30)
        {
            
            int LblNum = str.Length;//Label内容长度
            float FontWidth = theLabel.Width / theLabel.Text.Length;//每个字符的宽度          
            int ColNum = (LblNum - (LblNum / rowNum) * rowNum) == 0 ? (LblNum / rowNum) : (LblNum / rowNum) + 1;//列数
            theLabel.AutoSize = false;    //设置AutoSize
            theLabel.Width = (int)(FontWidth * 10.0);//设置显示宽度
            theLabel.Height = rowHeight * ColNum;  //设置显示高度
            return theLabel;
        }

      
    }
}
