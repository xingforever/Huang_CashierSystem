namespace CashierSystem
{
    partial class Frm_UserInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbltips = new System.Windows.Forms.Label();
            this.btnEsc = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.txtRmark = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblThrid = new System.Windows.Forms.Label();
            this.lblFirst = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(55, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "*";
            // 
            // lbltips
            // 
            this.lbltips.AutoSize = true;
            this.lbltips.Location = new System.Drawing.Point(218, 190);
            this.lbltips.Name = "lbltips";
            this.lbltips.Size = new System.Drawing.Size(29, 12);
            this.lbltips.TabIndex = 19;
            this.lbltips.Text = "tips";
            this.lbltips.Visible = false;
            // 
            // btnEsc
            // 
            this.btnEsc.Location = new System.Drawing.Point(280, 216);
            this.btnEsc.Name = "btnEsc";
            this.btnEsc.Size = new System.Drawing.Size(86, 35);
            this.btnEsc.TabIndex = 17;
            this.btnEsc.Text = "取消";
            this.btnEsc.UseVisualStyleBackColor = true;
            this.btnEsc.Click += new System.EventHandler(this.btnEsc_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.Transparent;
            this.btnEnter.Location = new System.Drawing.Point(98, 216);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(86, 35);
            this.btnEnter.TabIndex = 18;
            this.btnEnter.Text = "确定";
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // txtRmark
            // 
            this.txtRmark.Location = new System.Drawing.Point(167, 105);
            this.txtRmark.Multiline = true;
            this.txtRmark.Name = "txtRmark";
            this.txtRmark.Size = new System.Drawing.Size(199, 56);
            this.txtRmark.TabIndex = 15;
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUserName.Location = new System.Drawing.Point(167, 24);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(199, 26);
            this.txtUserName.TabIndex = 16;
            // 
            // lblThrid
            // 
            this.lblThrid.AutoSize = true;
            this.lblThrid.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblThrid.Location = new System.Drawing.Point(82, 108);
            this.lblThrid.Name = "lblThrid";
            this.lblThrid.Size = new System.Drawing.Size(40, 16);
            this.lblThrid.TabIndex = 14;
            this.lblThrid.Text = "备注";
            // 
            // lblFirst
            // 
            this.lblFirst.AutoSize = true;
            this.lblFirst.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFirst.Location = new System.Drawing.Point(82, 27);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(56, 16);
            this.lblFirst.TabIndex = 13;
            this.lblFirst.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(82, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "密码";
            // 
            // txtPwd
            // 
            this.txtPwd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPwd.Location = new System.Drawing.Point(167, 69);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(199, 26);
            this.txtPwd.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(55, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "*";
            // 
            // Frm_UserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(421, 263);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbltips);
            this.Controls.Add(this.btnEsc);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.txtRmark);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblThrid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFirst);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_UserInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用户";
            this.Load += new System.EventHandler(this.Frm_UserInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbltips;
        private System.Windows.Forms.Button btnEsc;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.TextBox txtRmark;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblThrid;
        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label3;
    }
}