namespace CashierSystem
{
    partial class Huang_System
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Huang_System));
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabGoodsInfo = new System.Windows.Forms.TabPage();
            this.dgvGoodsInfo = new System.Windows.Forms.DataGridView();
            this.pnlGoodsInfoSearch = new System.Windows.Forms.Panel();
            this.pnlGoodsBalance = new System.Windows.Forms.Panel();
            this.tabTodaySales = new System.Windows.Forms.TabPage();
            this.tabGoodsManager = new System.Windows.Forms.TabPage();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tabSales = new System.Windows.Forms.TabPage();
            this.tabGoodsUnit = new System.Windows.Forms.TabPage();
            this.dgvUnitInfo = new System.Windows.Forms.DataGridView();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tspAddUnitInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tspEditUnitInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tspDeleteUnitInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabGoodSort = new System.Windows.Forms.TabPage();
            this.tabWholeSalerInfo = new System.Windows.Forms.TabPage();
            this.tabUserInfoManager = new System.Windows.Forms.TabPage();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabMain.SuspendLayout();
            this.tabGoodsInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoodsInfo)).BeginInit();
            this.tabGoodsManager.SuspendLayout();
            this.tabGoodsUnit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnitInfo)).BeginInit();
            this.statusStrip2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(850, 78);
            this.panel1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 420);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(850, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabGoodsInfo);
            this.tabMain.Controls.Add(this.tabTodaySales);
            this.tabMain.Controls.Add(this.tabGoodsManager);
            this.tabMain.Controls.Add(this.tabSales);
            this.tabMain.Controls.Add(this.tabGoodsUnit);
            this.tabMain.Controls.Add(this.tabGoodSort);
            this.tabMain.Controls.Add(this.tabWholeSalerInfo);
            this.tabMain.Controls.Add(this.tabUserInfoManager);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 78);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(850, 342);
            this.tabMain.TabIndex = 2;
            this.tabMain.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabMain_Selected);
            // 
            // tabGoodsInfo
            // 
            this.tabGoodsInfo.Controls.Add(this.dgvGoodsInfo);
            this.tabGoodsInfo.Controls.Add(this.pnlGoodsInfoSearch);
            this.tabGoodsInfo.Controls.Add(this.pnlGoodsBalance);
            this.tabGoodsInfo.Location = new System.Drawing.Point(4, 22);
            this.tabGoodsInfo.Name = "tabGoodsInfo";
            this.tabGoodsInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabGoodsInfo.Size = new System.Drawing.Size(842, 316);
            this.tabGoodsInfo.TabIndex = 0;
            this.tabGoodsInfo.Text = "商品信息";
            this.tabGoodsInfo.UseVisualStyleBackColor = true;
            // 
            // dgvGoodsInfo
            // 
            this.dgvGoodsInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoodsInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGoodsInfo.Location = new System.Drawing.Point(3, 82);
            this.dgvGoodsInfo.Name = "dgvGoodsInfo";
            this.dgvGoodsInfo.RowTemplate.Height = 23;
            this.dgvGoodsInfo.Size = new System.Drawing.Size(636, 231);
            this.dgvGoodsInfo.TabIndex = 3;
            // 
            // pnlGoodsInfoSearch
            // 
            this.pnlGoodsInfoSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGoodsInfoSearch.Location = new System.Drawing.Point(3, 3);
            this.pnlGoodsInfoSearch.Name = "pnlGoodsInfoSearch";
            this.pnlGoodsInfoSearch.Size = new System.Drawing.Size(636, 79);
            this.pnlGoodsInfoSearch.TabIndex = 2;
            // 
            // pnlGoodsBalance
            // 
            this.pnlGoodsBalance.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlGoodsBalance.Location = new System.Drawing.Point(639, 3);
            this.pnlGoodsBalance.Name = "pnlGoodsBalance";
            this.pnlGoodsBalance.Size = new System.Drawing.Size(200, 310);
            this.pnlGoodsBalance.TabIndex = 1;
            this.pnlGoodsBalance.Tag = "商品结算信息";
            // 
            // tabTodaySales
            // 
            this.tabTodaySales.Location = new System.Drawing.Point(4, 22);
            this.tabTodaySales.Name = "tabTodaySales";
            this.tabTodaySales.Padding = new System.Windows.Forms.Padding(3);
            this.tabTodaySales.Size = new System.Drawing.Size(842, 316);
            this.tabTodaySales.TabIndex = 5;
            this.tabTodaySales.Text = "今日销售记录";
            this.tabTodaySales.UseVisualStyleBackColor = true;
            // 
            // tabGoodsManager
            // 
            this.tabGoodsManager.Controls.Add(this.toolStrip2);
            this.tabGoodsManager.Location = new System.Drawing.Point(4, 22);
            this.tabGoodsManager.Name = "tabGoodsManager";
            this.tabGoodsManager.Padding = new System.Windows.Forms.Padding(3);
            this.tabGoodsManager.Size = new System.Drawing.Size(842, 316);
            this.tabGoodsManager.TabIndex = 1;
            this.tabGoodsManager.Text = "商品管理";
            this.tabGoodsManager.UseVisualStyleBackColor = true;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(836, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tabSales
            // 
            this.tabSales.Location = new System.Drawing.Point(4, 22);
            this.tabSales.Name = "tabSales";
            this.tabSales.Padding = new System.Windows.Forms.Padding(3);
            this.tabSales.Size = new System.Drawing.Size(842, 316);
            this.tabSales.TabIndex = 6;
            this.tabSales.Text = "销售记录";
            this.tabSales.UseVisualStyleBackColor = true;
            // 
            // tabGoodsUnit
            // 
            this.tabGoodsUnit.Controls.Add(this.dgvUnitInfo);
            this.tabGoodsUnit.Controls.Add(this.statusStrip2);
            this.tabGoodsUnit.Controls.Add(this.panel2);
            this.tabGoodsUnit.Location = new System.Drawing.Point(4, 22);
            this.tabGoodsUnit.Name = "tabGoodsUnit";
            this.tabGoodsUnit.Padding = new System.Windows.Forms.Padding(3);
            this.tabGoodsUnit.Size = new System.Drawing.Size(842, 316);
            this.tabGoodsUnit.TabIndex = 2;
            this.tabGoodsUnit.Text = "商品单位";
            this.tabGoodsUnit.UseVisualStyleBackColor = true;
            // 
            // dgvUnitInfo
            // 
            this.dgvUnitInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnitInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUnitInfo.Location = new System.Drawing.Point(3, 34);
            this.dgvUnitInfo.Name = "dgvUnitInfo";
            this.dgvUnitInfo.RowTemplate.Height = 23;
            this.dgvUnitInfo.Size = new System.Drawing.Size(836, 257);
            this.dgvUnitInfo.TabIndex = 2;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip2.Location = new System.Drawing.Point(3, 291);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(836, 22);
            this.statusStrip2.TabIndex = 1;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabel1.Text = "  ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(20, 17);
            this.toolStripStatusLabel2.Text = "共";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(22, 17);
            this.toolStripStatusLabel3.Text = "50";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(20, 17);
            this.toolStripStatusLabel4.Text = "行";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(836, 31);
            this.panel2.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspAddUnitInfo,
            this.tspEditUnitInfo,
            this.tspDeleteUnitInfo,
            this.toolStripMenuItem5,
            this.toolStripMenuItem4,
            this.toolStripMenuItem6,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(834, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tspAddUnitInfo
            // 
            this.tspAddUnitInfo.Image = ((System.Drawing.Image)(resources.GetObject("tspAddUnitInfo.Image")));
            this.tspAddUnitInfo.Name = "tspAddUnitInfo";
            this.tspAddUnitInfo.Size = new System.Drawing.Size(60, 23);
            this.tspAddUnitInfo.Tag = "添加";
            this.tspAddUnitInfo.Text = "添加";
            this.tspAddUnitInfo.Click += new System.EventHandler(this.tspAddUnitInfo_Click);
            // 
            // tspEditUnitInfo
            // 
            this.tspEditUnitInfo.Image = ((System.Drawing.Image)(resources.GetObject("tspEditUnitInfo.Image")));
            this.tspEditUnitInfo.Name = "tspEditUnitInfo";
            this.tspEditUnitInfo.Size = new System.Drawing.Size(60, 23);
            this.tspEditUnitInfo.Text = "编辑";
            this.tspEditUnitInfo.Click += new System.EventHandler(this.tspEditUnitInfo_Click);
            // 
            // tspDeleteUnitInfo
            // 
            this.tspDeleteUnitInfo.Image = ((System.Drawing.Image)(resources.GetObject("tspDeleteUnitInfo.Image")));
            this.tspDeleteUnitInfo.Name = "tspDeleteUnitInfo";
            this.tspDeleteUnitInfo.Size = new System.Drawing.Size(60, 23);
            this.tspDeleteUnitInfo.Text = "删除";
            this.tspDeleteUnitInfo.Click += new System.EventHandler(this.tspDeleteUnitInfo_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(120, 23);
            this.toolStripMenuItem5.Text = "                         ";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem4.Image")));
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(28, 23);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(136, 23);
            this.toolStripMenuItem6.ToolTipText = "输入名称";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(60, 23);
            this.toolStripMenuItem1.Text = "刷新";
            // 
            // tabGoodSort
            // 
            this.tabGoodSort.Location = new System.Drawing.Point(4, 22);
            this.tabGoodSort.Name = "tabGoodSort";
            this.tabGoodSort.Padding = new System.Windows.Forms.Padding(3);
            this.tabGoodSort.Size = new System.Drawing.Size(842, 316);
            this.tabGoodSort.TabIndex = 3;
            this.tabGoodSort.Text = "商品类别";
            this.tabGoodSort.UseVisualStyleBackColor = true;
            // 
            // tabWholeSalerInfo
            // 
            this.tabWholeSalerInfo.Location = new System.Drawing.Point(4, 22);
            this.tabWholeSalerInfo.Name = "tabWholeSalerInfo";
            this.tabWholeSalerInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabWholeSalerInfo.Size = new System.Drawing.Size(842, 316);
            this.tabWholeSalerInfo.TabIndex = 4;
            this.tabWholeSalerInfo.Text = "供货商信息";
            this.tabWholeSalerInfo.UseVisualStyleBackColor = true;
            // 
            // tabUserInfoManager
            // 
            this.tabUserInfoManager.Location = new System.Drawing.Point(4, 22);
            this.tabUserInfoManager.Name = "tabUserInfoManager";
            this.tabUserInfoManager.Padding = new System.Windows.Forms.Padding(3);
            this.tabUserInfoManager.Size = new System.Drawing.Size(842, 316);
            this.tabUserInfoManager.TabIndex = 7;
            this.tabUserInfoManager.Text = "账号管理";
            this.tabUserInfoManager.UseVisualStyleBackColor = true;
            // 
            // Huang_System
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 442);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "Huang_System";
            this.Text = "Huang_System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Huang_System_Load);
            this.tabMain.ResumeLayout(false);
            this.tabGoodsInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoodsInfo)).EndInit();
            this.tabGoodsManager.ResumeLayout(false);
            this.tabGoodsManager.PerformLayout();
            this.tabGoodsUnit.ResumeLayout(false);
            this.tabGoodsUnit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnitInfo)).EndInit();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabGoodsInfo;
        private System.Windows.Forms.DataGridView dgvGoodsInfo;
        private System.Windows.Forms.Panel pnlGoodsInfoSearch;
        private System.Windows.Forms.Panel pnlGoodsBalance;
        private System.Windows.Forms.TabPage tabGoodsManager;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.TabPage tabGoodsUnit;
        private System.Windows.Forms.TabPage tabGoodSort;
        private System.Windows.Forms.TabPage tabWholeSalerInfo;
        private System.Windows.Forms.TabPage tabTodaySales;
        private System.Windows.Forms.TabPage tabSales;
        private System.Windows.Forms.TabPage tabUserInfoManager;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tspAddUnitInfo;
        private System.Windows.Forms.ToolStripMenuItem tspEditUnitInfo;
        private System.Windows.Forms.ToolStripMenuItem tspDeleteUnitInfo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripTextBox toolStripMenuItem6;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView dgvUnitInfo;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

