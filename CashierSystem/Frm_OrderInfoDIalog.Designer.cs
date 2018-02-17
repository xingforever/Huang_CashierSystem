namespace CashierSystem
{
    partial class Frm_OrderInfoDIalog
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
            this.btnOrderOK = new System.Windows.Forms.Button();
            this.btnOrderCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(58, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "确认是否下单?";
            // 
            // btnOrderOK
            // 
            this.btnOrderOK.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOrderOK.Location = new System.Drawing.Point(25, 75);
            this.btnOrderOK.Name = "btnOrderOK";
            this.btnOrderOK.Size = new System.Drawing.Size(75, 33);
            this.btnOrderOK.TabIndex = 1;
            this.btnOrderOK.Text = "确定";
            this.btnOrderOK.UseVisualStyleBackColor = true;
            this.btnOrderOK.Click += new System.EventHandler(this.btnOrderOK_Click);
            // 
            // btnOrderCancel
            // 
            this.btnOrderCancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOrderCancel.Location = new System.Drawing.Point(197, 75);
            this.btnOrderCancel.Name = "btnOrderCancel";
            this.btnOrderCancel.Size = new System.Drawing.Size(75, 33);
            this.btnOrderCancel.TabIndex = 1;
            this.btnOrderCancel.Text = "取消";
            this.btnOrderCancel.UseVisualStyleBackColor = true;
            this.btnOrderCancel.Click += new System.EventHandler(this.btnOrderCancel_Click);
            // 
            // Frm_OrderInfoDIalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 120);
            this.Controls.Add(this.btnOrderCancel);
            this.Controls.Add(this.btnOrderOK);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_OrderInfoDIalog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "下单";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOrderOK;
        private System.Windows.Forms.Button btnOrderCancel;
    }
}