namespace CashierSystem
{
    partial class Frm_OrderInfo
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
            this.txtOrder_GoodsName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrder_Count = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOrder_DisCount = new System.Windows.Forms.TextBox();
            this.txtOrder_Price = new System.Windows.Forms.TextBox();
            this.txtOrder_Remark = new System.Windows.Forms.TextBox();
            this.btnOrderEnter = new System.Windows.Forms.Button();
            this.btnOrderCancel = new System.Windows.Forms.Button();
            this.lblReduceCount = new System.Windows.Forms.Label();
            this.lblAdd = new System.Windows.Forms.Label();
            this.lblTips = new System.Windows.Forms.Label();
            this.btnRemoveOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(39, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "商品名称";
            // 
            // txtOrder_GoodsName
            // 
            this.txtOrder_GoodsName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOrder_GoodsName.Location = new System.Drawing.Point(126, 17);
            this.txtOrder_GoodsName.Name = "txtOrder_GoodsName";
            this.txtOrder_GoodsName.ReadOnly = true;
            this.txtOrder_GoodsName.Size = new System.Drawing.Size(151, 26);
            this.txtOrder_GoodsName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(39, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "数量";
            // 
            // txtOrder_Count
            // 
            this.txtOrder_Count.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOrder_Count.Location = new System.Drawing.Point(173, 63);
            this.txtOrder_Count.Name = "txtOrder_Count";
            this.txtOrder_Count.Size = new System.Drawing.Size(54, 26);
            this.txtOrder_Count.TabIndex = 1;
            this.txtOrder_Count.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtOrder_Count_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(39, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "折扣";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(39, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "价格";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(39, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "备注";
            // 
            // txtOrder_DisCount
            // 
            this.txtOrder_DisCount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOrder_DisCount.Location = new System.Drawing.Point(126, 103);
            this.txtOrder_DisCount.Name = "txtOrder_DisCount";
            this.txtOrder_DisCount.Size = new System.Drawing.Size(151, 26);
            this.txtOrder_DisCount.TabIndex = 1;
            this.txtOrder_DisCount.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtOrder_DisCount_MouseUp);
            // 
            // txtOrder_Price
            // 
            this.txtOrder_Price.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOrder_Price.Location = new System.Drawing.Point(126, 151);
            this.txtOrder_Price.Name = "txtOrder_Price";
            this.txtOrder_Price.ReadOnly = true;
            this.txtOrder_Price.Size = new System.Drawing.Size(151, 26);
            this.txtOrder_Price.TabIndex = 1;
            // 
            // txtOrder_Remark
            // 
            this.txtOrder_Remark.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOrder_Remark.Location = new System.Drawing.Point(126, 194);
            this.txtOrder_Remark.Multiline = true;
            this.txtOrder_Remark.Name = "txtOrder_Remark";
            this.txtOrder_Remark.Size = new System.Drawing.Size(151, 64);
            this.txtOrder_Remark.TabIndex = 1;
            // 
            // btnOrderEnter
            // 
            this.btnOrderEnter.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOrderEnter.Location = new System.Drawing.Point(23, 293);
            this.btnOrderEnter.Name = "btnOrderEnter";
            this.btnOrderEnter.Size = new System.Drawing.Size(69, 27);
            this.btnOrderEnter.TabIndex = 2;
            this.btnOrderEnter.Text = "确定";
            this.btnOrderEnter.UseVisualStyleBackColor = true;
            this.btnOrderEnter.Click += new System.EventHandler(this.btnOrderEnter_Click);
            // 
            // btnOrderCancel
            // 
            this.btnOrderCancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOrderCancel.Location = new System.Drawing.Point(208, 293);
            this.btnOrderCancel.Name = "btnOrderCancel";
            this.btnOrderCancel.Size = new System.Drawing.Size(69, 27);
            this.btnOrderCancel.TabIndex = 2;
            this.btnOrderCancel.Text = "取消";
            this.btnOrderCancel.UseVisualStyleBackColor = true;
            this.btnOrderCancel.Click += new System.EventHandler(this.btnOrderCancel_Click);
            // 
            // lblReduceCount
            // 
            this.lblReduceCount.AutoSize = true;
            this.lblReduceCount.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblReduceCount.Location = new System.Drawing.Point(126, 66);
            this.lblReduceCount.Name = "lblReduceCount";
            this.lblReduceCount.Size = new System.Drawing.Size(21, 21);
            this.lblReduceCount.TabIndex = 3;
            this.lblReduceCount.Text = "-";
            this.lblReduceCount.Click += new System.EventHandler(this.lblReduceCount_Click);
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAdd.Location = new System.Drawing.Point(256, 66);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(21, 21);
            this.lblAdd.TabIndex = 3;
            this.lblAdd.Text = "+";
            this.lblAdd.Click += new System.EventHandler(this.lblAdd_Click);
            // 
            // lblTips
            // 
            this.lblTips.AutoSize = true;
            this.lblTips.ForeColor = System.Drawing.Color.Red;
            this.lblTips.Location = new System.Drawing.Point(85, 268);
            this.lblTips.Name = "lblTips";
            this.lblTips.Size = new System.Drawing.Size(35, 12);
            this.lblTips.TabIndex = 4;
            this.lblTips.Text = "提示:";
            // 
            // btnRemoveOrder
            // 
            this.btnRemoveOrder.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRemoveOrder.Location = new System.Drawing.Point(117, 293);
            this.btnRemoveOrder.Name = "btnRemoveOrder";
            this.btnRemoveOrder.Size = new System.Drawing.Size(69, 27);
            this.btnRemoveOrder.TabIndex = 2;
            this.btnRemoveOrder.Text = "删除";
            this.btnRemoveOrder.UseVisualStyleBackColor = true;
            this.btnRemoveOrder.Click += new System.EventHandler(this.btnRemoveOrder_Click);
            // 
            // Frm_OrderInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 332);
            this.Controls.Add(this.lblTips);
            this.Controls.Add(this.lblAdd);
            this.Controls.Add(this.lblReduceCount);
            this.Controls.Add(this.btnRemoveOrder);
            this.Controls.Add(this.btnOrderCancel);
            this.Controls.Add(this.btnOrderEnter);
            this.Controls.Add(this.txtOrder_Remark);
            this.Controls.Add(this.txtOrder_Price);
            this.Controls.Add(this.txtOrder_DisCount);
            this.Controls.Add(this.txtOrder_Count);
            this.Controls.Add(this.txtOrder_GoodsName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_OrderInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "订单修改";
            this.Load += new System.EventHandler(this.Frm_OrderInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOrder_GoodsName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrder_Count;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOrder_DisCount;
        private System.Windows.Forms.TextBox txtOrder_Price;
        private System.Windows.Forms.TextBox txtOrder_Remark;
        private System.Windows.Forms.Button btnOrderEnter;
        private System.Windows.Forms.Button btnOrderCancel;
        private System.Windows.Forms.Label lblReduceCount;
        private System.Windows.Forms.Label lblAdd;
        private System.Windows.Forms.Label lblTips;
        private System.Windows.Forms.Button btnRemoveOrder;
    }
}