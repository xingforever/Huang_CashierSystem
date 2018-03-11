namespace CashierSystem
{
    partial class Frm_InitData
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnDownStandardTable = new System.Windows.Forms.Button();
            this.btnUpLoadDataTable = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(197, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "商品数据快速初始化";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(63, 43);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(523, 144);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "1.此部分为快速加载商品数据功能\r\n\r\n2.软件提供标准数据格式Excel表并有数据填写注意\r\n\r\n3.将商品数据填写完成后,点击加载数据,将开始加载数据\r\n\r\n" +
    "4但某些数据不合格,软件将记录该数据所在Excel行,并生成错误日志\r\n";
            // 
            // btnDownStandardTable
            // 
            this.btnDownStandardTable.Location = new System.Drawing.Point(76, 207);
            this.btnDownStandardTable.Name = "btnDownStandardTable";
            this.btnDownStandardTable.Size = new System.Drawing.Size(137, 33);
            this.btnDownStandardTable.TabIndex = 2;
            this.btnDownStandardTable.Text = "下载标准数据表";
            this.btnDownStandardTable.UseVisualStyleBackColor = true;
            this.btnDownStandardTable.Click += new System.EventHandler(this.btnDownStandardTable_Click);
            // 
            // btnUpLoadDataTable
            // 
            this.btnUpLoadDataTable.Location = new System.Drawing.Point(390, 207);
            this.btnUpLoadDataTable.Name = "btnUpLoadDataTable";
            this.btnUpLoadDataTable.Size = new System.Drawing.Size(137, 33);
            this.btnUpLoadDataTable.TabIndex = 2;
            this.btnUpLoadDataTable.Text = "上传商品数据表";
            this.btnUpLoadDataTable.UseVisualStyleBackColor = true;
            this.btnUpLoadDataTable.Click += new System.EventHandler(this.btnUpLoadDataTable_Click);
            // 
            // Frm_InitData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 259);
            this.Controls.Add(this.btnUpLoadDataTable);
            this.Controls.Add(this.btnDownStandardTable);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Frm_InitData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Frm_InitData";
            this.Shown += new System.EventHandler(this.Frm_InitData_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnDownStandardTable;
        private System.Windows.Forms.Button btnUpLoadDataTable;
    }
}