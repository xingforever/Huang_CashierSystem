namespace CashierSystem
{
    partial class Frm_Payment
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.calc = new System.Windows.Forms.Label();
            this.btnUnPay = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.lblMoney = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picWeiXin = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.picZhiFuBao = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWeiXin)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picZhiFuBao)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.calc);
            this.panel1.Controls.Add(this.btnUnPay);
            this.panel1.Controls.Add(this.btnPay);
            this.panel1.Controls.Add(this.lblMoney);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 427);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(509, 78);
            this.panel1.TabIndex = 0;
            // 
            // calc
            // 
            this.calc.AutoSize = true;
            this.calc.Location = new System.Drawing.Point(330, 16);
            this.calc.Name = "calc";
            this.calc.Size = new System.Drawing.Size(41, 12);
            this.calc.TabIndex = 3;
            this.calc.Text = "计算器";
            this.calc.Click += new System.EventHandler(this.calc_Click);
            // 
            // btnUnPay
            // 
            this.btnUnPay.Location = new System.Drawing.Point(348, 41);
            this.btnUnPay.Name = "btnUnPay";
            this.btnUnPay.Size = new System.Drawing.Size(75, 34);
            this.btnUnPay.TabIndex = 2;
            this.btnUnPay.Text = "未收款";
            this.btnUnPay.UseVisualStyleBackColor = true;
            this.btnUnPay.Click += new System.EventHandler(this.btnUnPay_Click);
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(56, 41);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(75, 34);
            this.btnPay.TabIndex = 2;
            this.btnPay.Text = "已收款";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // lblMoney
            // 
            this.lblMoney.AutoSize = true;
            this.lblMoney.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMoney.ForeColor = System.Drawing.Color.Red;
            this.lblMoney.Location = new System.Drawing.Point(169, 10);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(49, 19);
            this.lblMoney.TabIndex = 1;
            this.lblMoney.Text = "1000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(268, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "元";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "应收款:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.picWeiXin);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(254, 427);
            this.panel2.TabIndex = 1;
            // 
            // picWeiXin
            // 
            this.picWeiXin.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.picWeiXin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picWeiXin.Location = new System.Drawing.Point(0, 0);
            this.picWeiXin.Name = "picWeiXin";
            this.picWeiXin.Size = new System.Drawing.Size(254, 393);
            this.picWeiXin.TabIndex = 2;
            this.picWeiXin.TabStop = false;
            this.picWeiXin.DoubleClick += new System.EventHandler(this.picWeiXin_DoubleClick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 393);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(254, 34);
            this.panel4.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(90, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "微信支付";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.picZhiFuBao);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(255, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(254, 427);
            this.panel3.TabIndex = 2;
            // 
            // picZhiFuBao
            // 
            this.picZhiFuBao.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.picZhiFuBao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picZhiFuBao.Location = new System.Drawing.Point(0, 0);
            this.picZhiFuBao.Name = "picZhiFuBao";
            this.picZhiFuBao.Size = new System.Drawing.Size(254, 393);
            this.picZhiFuBao.TabIndex = 1;
            this.picZhiFuBao.TabStop = false;
            this.picZhiFuBao.DoubleClick += new System.EventHandler(this.picZhiFuBao_DoubleClick);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 393);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(254, 34);
            this.panel5.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(70, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "支付宝支付";
            // 
            // Frm_Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 505);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Payment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Frm_Payment";
            this.Load += new System.EventHandler(this.Frm_Payment_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picWeiXin)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picZhiFuBao)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picWeiXin;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox picZhiFuBao;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label calc;
        private System.Windows.Forms.Button btnUnPay;
    }
}