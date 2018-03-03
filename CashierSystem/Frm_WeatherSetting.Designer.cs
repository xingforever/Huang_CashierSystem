namespace CashierSystem
{
    partial class Frm_WeatherSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbxProvice = new System.Windows.Forms.ComboBox();
            this.cbxCity = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEnter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbxProvice
            // 
            this.cbxProvice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProvice.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxProvice.FormattingEnabled = true;
            this.cbxProvice.Location = new System.Drawing.Point(70, 19);
            this.cbxProvice.Name = "cbxProvice";
            this.cbxProvice.Size = new System.Drawing.Size(121, 22);
            this.cbxProvice.TabIndex = 0;
            this.cbxProvice.SelectedIndexChanged += new System.EventHandler(this.cbxProvice_SelectedIndexChanged);
            // 
            // cbxCity
            // 
            this.cbxCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCity.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxCity.FormattingEnabled = true;
            this.cbxCity.Location = new System.Drawing.Point(280, 17);
            this.cbxCity.Name = "cbxCity";
            this.cbxCity.Size = new System.Drawing.Size(121, 22);
            this.cbxCity.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "省份:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(223, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "城市:";
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(431, 17);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 2;
            this.btnEnter.Text = "确定";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // Frm_WeatherSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(518, 57);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxCity);
            this.Controls.Add(this.cbxProvice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_WeatherSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "天气地区设置";
            this.Load += new System.EventHandler(this.Frm_WeatherSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxProvice;
        private System.Windows.Forms.ComboBox cbxCity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEnter;
    }
}