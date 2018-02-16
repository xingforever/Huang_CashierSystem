namespace CashierSystem
{
    partial class Frm_NoReceiveMoney
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
            this.btnNoMCancel = new System.Windows.Forms.Button();
            this.btnNoMEnter = new System.Windows.Forms.Button();
            this.txtNoM_Remark = new System.Windows.Forms.TextBox();
            this.txtNoM_Money = new System.Windows.Forms.TextBox();
            this.txtNoM_Phone = new System.Windows.Forms.TextBox();
            this.txtNoM_CustomerName = new System.Windows.Forms.TextBox();
            this.txtNoM_OrderId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNoM_Tips = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNoMCancel
            // 
            this.btnNoMCancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNoMCancel.Location = new System.Drawing.Point(172, 307);
            this.btnNoMCancel.Name = "btnNoMCancel";
            this.btnNoMCancel.Size = new System.Drawing.Size(69, 27);
            this.btnNoMCancel.TabIndex = 13;
            this.btnNoMCancel.Text = "取消";
            this.btnNoMCancel.UseVisualStyleBackColor = true;
            // 
            // btnNoMEnter
            // 
            this.btnNoMEnter.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNoMEnter.Location = new System.Drawing.Point(26, 307);
            this.btnNoMEnter.Name = "btnNoMEnter";
            this.btnNoMEnter.Size = new System.Drawing.Size(69, 27);
            this.btnNoMEnter.TabIndex = 14;
            this.btnNoMEnter.Text = "确定";
            this.btnNoMEnter.UseVisualStyleBackColor = true;
            this.btnNoMEnter.Click += new System.EventHandler(this.btnNoMEnter_Click);
            // 
            // txtNoM_Remark
            // 
            this.txtNoM_Remark.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNoM_Remark.Location = new System.Drawing.Point(110, 204);
            this.txtNoM_Remark.Multiline = true;
            this.txtNoM_Remark.Name = "txtNoM_Remark";
            this.txtNoM_Remark.Size = new System.Drawing.Size(151, 64);
            this.txtNoM_Remark.TabIndex = 8;
            // 
            // txtNoM_Money
            // 
            this.txtNoM_Money.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNoM_Money.Location = new System.Drawing.Point(110, 161);
            this.txtNoM_Money.Name = "txtNoM_Money";
            this.txtNoM_Money.Size = new System.Drawing.Size(151, 26);
            this.txtNoM_Money.TabIndex = 9;
            this.txtNoM_Money.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtNoM_Money_MouseUp);
            // 
            // txtNoM_Phone
            // 
            this.txtNoM_Phone.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNoM_Phone.Location = new System.Drawing.Point(110, 113);
            this.txtNoM_Phone.Name = "txtNoM_Phone";
            this.txtNoM_Phone.Size = new System.Drawing.Size(151, 26);
            this.txtNoM_Phone.TabIndex = 10;
            // 
            // txtNoM_CustomerName
            // 
            this.txtNoM_CustomerName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNoM_CustomerName.Location = new System.Drawing.Point(110, 73);
            this.txtNoM_CustomerName.Name = "txtNoM_CustomerName";
            this.txtNoM_CustomerName.Size = new System.Drawing.Size(151, 26);
            this.txtNoM_CustomerName.TabIndex = 11;
            // 
            // txtNoM_OrderId
            // 
            this.txtNoM_OrderId.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNoM_OrderId.Location = new System.Drawing.Point(110, 27);
            this.txtNoM_OrderId.Name = "txtNoM_OrderId";
            this.txtNoM_OrderId.ReadOnly = true;
            this.txtNoM_OrderId.Size = new System.Drawing.Size(151, 26);
            this.txtNoM_OrderId.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(23, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "备注";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(23, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "待收账";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(23, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "电话";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(23, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "客户姓名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(23, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "订单号";
            // 
            // lblNoM_Tips
            // 
            this.lblNoM_Tips.AutoSize = true;
            this.lblNoM_Tips.Location = new System.Drawing.Point(38, 277);
            this.lblNoM_Tips.Name = "lblNoM_Tips";
            this.lblNoM_Tips.Size = new System.Drawing.Size(41, 12);
            this.lblNoM_Tips.TabIndex = 15;
            this.lblNoM_Tips.Text = "label6";
            this.lblNoM_Tips.Visible = false;
            // 
            // Frm_NoReceiveMoney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 346);
            this.Controls.Add(this.lblNoM_Tips);
            this.Controls.Add(this.btnNoMCancel);
            this.Controls.Add(this.btnNoMEnter);
            this.Controls.Add(this.txtNoM_Remark);
            this.Controls.Add(this.txtNoM_Money);
            this.Controls.Add(this.txtNoM_Phone);
            this.Controls.Add(this.txtNoM_CustomerName);
            this.Controls.Add(this.txtNoM_OrderId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Frm_NoReceiveMoney";
            this.Text = "待收账信息";
            this.Load += new System.EventHandler(this.Frm_NoReceiveMoney_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNoMCancel;
        private System.Windows.Forms.Button btnNoMEnter;
        private System.Windows.Forms.TextBox txtNoM_Remark;
        private System.Windows.Forms.TextBox txtNoM_Money;
        private System.Windows.Forms.TextBox txtNoM_Phone;
        private System.Windows.Forms.TextBox txtNoM_CustomerName;
        private System.Windows.Forms.TextBox txtNoM_OrderId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNoM_Tips;
    }
}