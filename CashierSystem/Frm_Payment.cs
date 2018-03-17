using Common;
using Model;
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
    public partial class Frm_Payment : Form
    {
        private Frm_Payment()
        {
            InitializeComponent();
        }

        public static Frm_Payment _form;
        public static ProfitsInfo _profitsInfo;

        public static Frm_Payment Create(ProfitsInfo profitsInfo)
        {
            if (_form == null)
            {
                _form = new Frm_Payment();
            }
            _profitsInfo = profitsInfo;
            return _form;
        }

        private void Frm_Payment_Load(object sender, EventArgs e)
        {
            Init();
        }

        void Init()
        {
            //图片加载 
            if (File.Exists(@"WeiXin.png"))
            {
                picWeiXin.BackgroundImage = Image.FromFile(@"WeiXin.png");
            }
            else
            {
                picWeiXin.BackgroundImage = Image.FromFile(@"AddPic.png");
            }
            if (File.Exists(@"ZhiHuBao.png"))
            {
                picZhiFuBao.BackgroundImage = Image.FromFile(@"ZhiHuBao.png");
            }
            else
            {
                picZhiFuBao.BackgroundImage = Image.FromFile(@"AddPic.png");
            }

            //钱加载
            if (_profitsInfo != null)
            {
                this.lblMoney.Text = _profitsInfo.PayPrices.ToString();
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (_profitsInfo != null)
            {
                _profitsInfo.IsPay = true;
                var isSuccess = DataManager.ProfitsInfoBLL.Add(_profitsInfo);
                if (!isSuccess)
                {
                    MessageBox.Show("利润表数据添加失败,如多次失败请联系管理员");
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("发生意外事件!!!,请关闭重试");
            }
        }

        private void btnUnPay_Click(object sender, EventArgs e)
        {
            if (_profitsInfo != null)
            {
                _profitsInfo.IsPay = false;
                var isSuccess = DataManager.ProfitsInfoBLL.Add(_profitsInfo);
                if (!isSuccess)
                {
                    MessageBox.Show("利润表数据添加失败,如多次失败请联系管理员");
                    return;
                }
                Frm_NoReceiveMoney frm_NoReceiveMoney = Frm_NoReceiveMoney.Create(_profitsInfo.OrderId, _profitsInfo.PayPrices.ToString());
                frm_NoReceiveMoney.ShowDialog(this);
                frm_NoReceiveMoney.Focus();
                //如果登记成功 ,返回true ,可以
                var isSucess = Boolean.Parse(frm_NoReceiveMoney.Tag.ToString());
                if (isSuccess)
                {
                    this.Tag = "true";
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("发生意外事件!!!,请关闭重试");
            }
        }

        private void calc_Click(object sender, EventArgs e)
        {
            CommonHelper.StartCalc();
        }

        private void picWeiXin_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog pOpenFileDialog = new OpenFileDialog();
            pOpenFileDialog.DefaultExt = "png";
            pOpenFileDialog.Filter = "pic files (*.png)|*.png|(*.jpg)|*.jpg";
            pOpenFileDialog.FilterIndex = 1;
            pOpenFileDialog.Multiselect = false;
            if (pOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                var path = pOpenFileDialog.FileName;
                try
                {
                    //读取图片 ,制作缩略图 将缩略图设置为pic图
                    var WeiXinimage = Image.FromFile(path);
                    var trueImage = PictureHelper.GetThumbnailImageKeepRatio(WeiXinimage, 255, 384);
                    if (File.Exists(@"../../fileWeiXin.png"))
                    {
                        File.Delete(@"../../fileWeiXin.png");
                    }
                    trueImage.Save(@"WeiXin.png");
                    picWeiXin.BackgroundImage = Image.FromFile(@"WeiXin.png");
                    return;
                }
                catch (Exception es)
                {

                    MessageBox.Show("设置图片出错 " + es.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


            }
        }

        private void picZhiFuBao_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog pOpenFileDialog = new OpenFileDialog();
            pOpenFileDialog.DefaultExt = "png";
            pOpenFileDialog.Filter = "pic files (*.png)|*.png|(*.jpg)|*.jpg";
            pOpenFileDialog.FilterIndex = 1;
            pOpenFileDialog.Multiselect = false;
            if (pOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                var path = pOpenFileDialog.FileName;
                try
                {
                    //读取图片 ,制作缩略图 将缩略图设置为pic图
                    var ZhiHuBaoimage = Image.FromFile(path);
                    var trueImage = PictureHelper.GetThumbnailImageKeepRatio(ZhiHuBaoimage, 255, 384);
                    if (File.Exists(@"ZhiHuBao.png"))
                    {
                        File.Delete(@"ZhiHuBao.png");
                    }
                    trueImage.Save(@"ZhiHuBao.png");
                    picZhiFuBao.BackgroundImage = Image.FromFile(@"ZhiHuBao.png");
                    return;
                }
                catch (Exception es)
                {

                    MessageBox.Show("设置图片出错 " + es.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


            }
        }

        private void Frm_Payment_FormClosing(object sender, FormClosingEventArgs e)
        {
            _profitsInfo = null;
        }
    }


}
