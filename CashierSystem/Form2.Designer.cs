namespace CashierSystem
{
    partial class Form2
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoodsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoodsType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SurplusCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WholeSalerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.GoodsName,
            this.SortName,
            this.UnitName,
            this.GoodsType,
            this.PayPrice,
            this.SurplusCount,
            this.WholeSalerName,
            this.Remark});
            this.dataGridView1.Location = new System.Drawing.Point(60, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(715, 380);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID编号";
            this.ID.Name = "ID";
            // 
            // GoodsName
            // 
            this.GoodsName.DataPropertyName = "GoodsName";
            this.GoodsName.HeaderText = "商品名";
            this.GoodsName.Name = "GoodsName";
            // 
            // SortName
            // 
            this.SortName.DataPropertyName = "SortName";
            this.SortName.HeaderText = "类别";
            this.SortName.Name = "SortName";
            // 
            // UnitName
            // 
            this.UnitName.DataPropertyName = "UnitName";
            this.UnitName.HeaderText = "单位";
            this.UnitName.Name = "UnitName";
            // 
            // GoodsType
            // 
            this.GoodsType.DataPropertyName = "GoodsType";
            this.GoodsType.HeaderText = "规格";
            this.GoodsType.Name = "GoodsType";
            // 
            // PayPrice
            // 
            this.PayPrice.DataPropertyName = "PayPrice";
            this.PayPrice.HeaderText = "售价";
            this.PayPrice.Name = "PayPrice";
            // 
            // SurplusCount
            // 
            this.SurplusCount.DataPropertyName = "SurplusCount";
            this.SurplusCount.HeaderText = "库存";
            this.SurplusCount.Name = "SurplusCount";
            // 
            // WholeSalerName
            // 
            this.WholeSalerName.DataPropertyName = "WholeSalerName";
            this.WholeSalerName.HeaderText = "供货商";
            this.WholeSalerName.Name = "WholeSalerName";
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "备注";
            this.Remark.Name = "Remark";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 461);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GoodsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SortName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GoodsType;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SurplusCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn WholeSalerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
    }
}