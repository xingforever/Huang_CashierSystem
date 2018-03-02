namespace CashierSystem
{
    partial class Frm_SortInfo
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
            this.lbltips = new System.Windows.Forms.Label();
            this.btnEsc = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.txtRmark = new System.Windows.Forms.TextBox();
            this.txtFirst = new System.Windows.Forms.TextBox();
            this.lblThrid = new System.Windows.Forms.Label();
            this.lblFirst = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbltips
            // 
            this.lbltips.AutoSize = true;
            this.lbltips.Location = new System.Drawing.Point(208, 73);
            this.lbltips.Name = "lbltips";
            this.lbltips.Size = new System.Drawing.Size(29, 12);
            this.lbltips.TabIndex = 11;
            this.lbltips.Text = "tips";
            this.lbltips.Visible = false;
            // 
            // btnEsc
            // 
            this.btnEsc.Location = new System.Drawing.Point(257, 193);
            this.btnEsc.Name = "btnEsc";
            this.btnEsc.Size = new System.Drawing.Size(86, 35);
            this.btnEsc.TabIndex = 9;
            this.btnEsc.Text = "取消";
            this.btnEsc.UseVisualStyleBackColor = true;
            this.btnEsc.Click += new System.EventHandler(this.btnEsc_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.Transparent;
            this.btnEnter.Location = new System.Drawing.Point(102, 193);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(86, 35);
            this.btnEnter.TabIndex = 10;
            this.btnEnter.Text = "确定";
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // txtRmark
            // 
            this.txtRmark.Location = new System.Drawing.Point(153, 105);
            this.txtRmark.Multiline = true;
            this.txtRmark.Name = "txtRmark";
            this.txtRmark.Size = new System.Drawing.Size(199, 56);
            this.txtRmark.TabIndex = 7;
            // 
            // txtFirst
            // 
            this.txtFirst.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFirst.Location = new System.Drawing.Point(153, 34);
            this.txtFirst.Name = "txtFirst";
            this.txtFirst.Size = new System.Drawing.Size(199, 26);
            this.txtFirst.TabIndex = 8;
            // 
            // lblThrid
            // 
            this.lblThrid.AutoSize = true;
            this.lblThrid.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblThrid.Location = new System.Drawing.Point(68, 108);
            this.lblThrid.Name = "lblThrid";
            this.lblThrid.Size = new System.Drawing.Size(40, 16);
            this.lblThrid.TabIndex = 6;
            this.lblThrid.Text = "备注";
            // 
            // lblFirst
            // 
            this.lblFirst.AutoSize = true;
            this.lblFirst.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFirst.Location = new System.Drawing.Point(68, 37);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(40, 16);
            this.lblFirst.TabIndex = 5;
            this.lblFirst.Text = "类别";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(41, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "*";
            // 
            // Frm_SortInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(421, 263);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbltips);
            this.Controls.Add(this.btnEsc);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.txtRmark);
            this.Controls.Add(this.txtFirst);
            this.Controls.Add(this.lblThrid);
            this.Controls.Add(this.lblFirst);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Frm_SortInfo";
            this.Text = "商品类别";
            this.Load += new System.EventHandler(this.Frm_SortInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltips;
        private System.Windows.Forms.Button btnEsc;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.TextBox txtRmark;
        private System.Windows.Forms.TextBox txtFirst;
        private System.Windows.Forms.Label lblThrid;
        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.Label label1;
    }
}