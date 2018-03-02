using Common_API;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CashierSystem
{
    public partial class Frm_WeatherSetting : Form
    {
        public Frm_WeatherSetting()
        {
            InitializeComponent();
        }

        public void Init()
        {
            cbxProvice.DataSource = WeatherHelper.GetSupportProvince().ToList();
            cbxProvice.SelectedIndex = 0;
            cbxCity.DataSource = WeatherHelper.GetSupportCity(cbxProvice.SelectedValue.ToString());
            cbxCity.SelectedIndex = 0;
        }

        private void Frm_WeatherSetting_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            Huang_System f1 = (Huang_System)this.Owner;//将本窗体的拥有者强制设为Form1类的实例
            Setting.City = cbxCity.SelectedValue.ToString();
            f1.LoadWeather();
            var dic = Setting.SettingToDic();
            Common.XMLHelper.WriteXML(dic);
            this.Close();

        }

        private void cbxProvice_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxCity.DataSource = WeatherHelper.GetSupportCity(cbxProvice.SelectedValue.ToString());
            cbxCity.SelectedIndex = 0;
        }
    }
}
