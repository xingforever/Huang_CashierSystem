namespace CashierSystem
{
    partial class Frm_Samll
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
            this.lblFirst = new System.Windows.Forms.Label();
            this.lblThrid = new System.Windows.Forms.Label();
            this.txtFirst = new System.Windows.Forms.TextBox();
            this.txtThrid = new System.Windows.Forms.TextBox();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnEsc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFirst
            // 
            this.lblFirst.AutoSize = true;
            this.lblFirst.Location = new System.Drawing.Point(53, 45);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(41, 12);
            this.lblFirst.TabIndex = 0;
            this.lblFirst.Text = "label1";
            // 
            // lblThrid
            // 
            this.lblThrid.AutoSize = true;
            this.lblThrid.Location = new System.Drawing.Point(53, 116);
            this.lblThrid.Name = "lblThrid";
            this.lblThrid.Size = new System.Drawing.Size(41, 12);
            this.lblThrid.TabIndex = 1;
            this.lblThrid.Text = "label2";
            // 
            // txtFirst
            // 
            this.txtFirst.Location = new System.Drawing.Point(138, 42);
            this.txtFirst.Name = "txtFirst";
            this.txtFirst.Size = new System.Drawing.Size(199, 21);
            this.txtFirst.TabIndex = 2;
            // 
            // txtThrid
            // 
            this.txtThrid.Location = new System.Drawing.Point(138, 113);
            this.txtThrid.Multiline = true;
            this.txtThrid.Name = "txtThrid";
            this.txtThrid.Size = new System.Drawing.Size(199, 43);
            this.txtThrid.TabIndex = 2;
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.Transparent;
            this.btnEnter.Location = new System.Drawing.Point(87, 201);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(86, 35);
            this.btnEnter.TabIndex = 3;
            this.btnEnter.Text = "确定";
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnEsc
            // 
            this.btnEsc.Location = new System.Drawing.Point(242, 201);
            this.btnEsc.Name = "btnEsc";
            this.btnEsc.Size = new System.Drawing.Size(86, 35);
            this.btnEsc.TabIndex = 3;
            this.btnEsc.Text = "取消";
            this.btnEsc.UseVisualStyleBackColor = true;
            // 
            // Frm_Samll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(417, 259);
            this.Controls.Add(this.btnEsc);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.txtThrid);
            this.Controls.Add(this.txtFirst);
            this.Controls.Add(this.lblThrid);
            this.Controls.Add(this.lblFirst);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Samll";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "**";
            this.Load += new System.EventHandler(this.Frm_Add_Samll_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.Label lblThrid;
        private System.Windows.Forms.TextBox txtFirst;
        private System.Windows.Forms.TextBox txtThrid;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnEsc;
    }
}