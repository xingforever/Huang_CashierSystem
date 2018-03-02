namespace CashierSystem
{
    partial class Frm_UnitInfo
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
            this.txtRmark = new System.Windows.Forms.TextBox();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnEsc = new System.Windows.Forms.Button();
            this.lbltips = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblFirst
            // 
            this.lblFirst.AutoSize = true;
            this.lblFirst.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFirst.Location = new System.Drawing.Point(53, 45);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(40, 16);
            this.lblFirst.TabIndex = 0;
            this.lblFirst.Text = "单位";
            // 
            // lblThrid
            // 
            this.lblThrid.AutoSize = true;
            this.lblThrid.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblThrid.Location = new System.Drawing.Point(52, 127);
            this.lblThrid.Name = "lblThrid";
            this.lblThrid.Size = new System.Drawing.Size(40, 16);
            this.lblThrid.TabIndex = 1;
            this.lblThrid.Text = "备注";
            // 
            // txtFirst
            // 
            this.txtFirst.Location = new System.Drawing.Point(138, 42);
            this.txtFirst.Name = "txtFirst";
            this.txtFirst.Size = new System.Drawing.Size(199, 21);
            this.txtFirst.TabIndex = 2;
            // 
            // txtRmark
            // 
            this.txtRmark.Location = new System.Drawing.Point(138, 113);
            this.txtRmark.Multiline = true;
            this.txtRmark.Name = "txtRmark";
            this.txtRmark.Size = new System.Drawing.Size(199, 43);
            this.txtRmark.TabIndex = 2;
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
            this.btnEsc.Click += new System.EventHandler(this.btnEsc_Click);
            // 
            // lbltips
            // 
            this.lbltips.AutoSize = true;
            this.lbltips.Location = new System.Drawing.Point(176, 80);
            this.lbltips.Name = "lbltips";
            this.lbltips.Size = new System.Drawing.Size(29, 12);
            this.lbltips.TabIndex = 4;
            this.lbltips.Text = "tips";
            this.lbltips.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(23, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "*";
            // 
            // Frm_UnitInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(417, 259);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbltips);
            this.Controls.Add(this.btnEsc);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.txtRmark);
            this.Controls.Add(this.txtFirst);
            this.Controls.Add(this.lblThrid);
            this.Controls.Add(this.lblFirst);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_UnitInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商品单位";
            this.Load += new System.EventHandler(this.Frm_UnitInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.Label lblThrid;
        private System.Windows.Forms.TextBox txtFirst;
        private System.Windows.Forms.TextBox txtRmark;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnEsc;
        private System.Windows.Forms.Label lbltips;
        private System.Windows.Forms.Label label1;
    }
}