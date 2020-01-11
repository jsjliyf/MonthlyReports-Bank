namespace MonthlyReports_Bank
{
    partial class Form_Main
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("非现场预警触发值");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("月度工作报告附表");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("县域基础数据报送");
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.修改密码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下载报表模板ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改密码ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.系统更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统更新ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSet_Template = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn15 = new System.Data.DataColumn();
            this.dataColumn16 = new System.Data.DataColumn();
            this.dataColumn17 = new System.Data.DataColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Template)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改密码ToolStripMenuItem,
            this.修改密码ToolStripMenuItem1,
            this.系统更新ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(794, 25);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 修改密码ToolStripMenuItem
            // 
            this.修改密码ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.下载报表模板ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.修改密码ToolStripMenuItem.Name = "修改密码ToolStripMenuItem";
            this.修改密码ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.修改密码ToolStripMenuItem.Text = "文件";
            // 
            // 下载报表模板ToolStripMenuItem
            // 
            this.下载报表模板ToolStripMenuItem.Name = "下载报表模板ToolStripMenuItem";
            this.下载报表模板ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.下载报表模板ToolStripMenuItem.Text = "下载报表模板";
            this.下载报表模板ToolStripMenuItem.Click += new System.EventHandler(this.下载报表模板ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 修改密码ToolStripMenuItem1
            // 
            this.修改密码ToolStripMenuItem1.Name = "修改密码ToolStripMenuItem1";
            this.修改密码ToolStripMenuItem1.Size = new System.Drawing.Size(68, 21);
            this.修改密码ToolStripMenuItem1.Text = "修改密码";
            this.修改密码ToolStripMenuItem1.Click += new System.EventHandler(this.修改密码ToolStripMenuItem1_Click);
            // 
            // 系统更新ToolStripMenuItem
            // 
            this.系统更新ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统更新ToolStripMenuItem1,
            this.关于ToolStripMenuItem});
            this.系统更新ToolStripMenuItem.Name = "系统更新ToolStripMenuItem";
            this.系统更新ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.系统更新ToolStripMenuItem.Text = "帮助";
            // 
            // 系统更新ToolStripMenuItem1
            // 
            this.系统更新ToolStripMenuItem1.Name = "系统更新ToolStripMenuItem1";
            this.系统更新ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.系统更新ToolStripMenuItem1.Text = "系统更新";
            this.系统更新ToolStripMenuItem1.Click += new System.EventHandler(this.系统更新ToolStripMenuItem1_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // dataSet_Template
            // 
            this.dataSet_Template.DataSetName = "DataSet_Template";
            this.dataSet_Template.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn7,
            this.dataColumn9,
            this.dataColumn15,
            this.dataColumn16,
            this.dataColumn17});
            this.dataTable1.TableName = "Template_County";
            // 
            // dataColumn1
            // 
            this.dataColumn1.Caption = "期数";
            this.dataColumn1.ColumnName = "期数";
            // 
            // dataColumn2
            // 
            this.dataColumn2.Caption = "区县名称";
            this.dataColumn2.ColumnName = "区县名称";
            // 
            // dataColumn3
            // 
            this.dataColumn3.Caption = "行名";
            this.dataColumn3.ColumnName = "行名";
            // 
            // dataColumn7
            // 
            this.dataColumn7.Caption = "各项存款";
            this.dataColumn7.ColumnName = "各项存款";
            // 
            // dataColumn9
            // 
            this.dataColumn9.Caption = "各项贷款";
            this.dataColumn9.ColumnName = "各项贷款";
            // 
            // dataColumn15
            // 
            this.dataColumn15.Caption = "次级类贷款";
            this.dataColumn15.ColumnName = "次级类贷款";
            // 
            // dataColumn16
            // 
            this.dataColumn16.Caption = "可疑类贷款";
            this.dataColumn16.ColumnName = "可疑类贷款";
            // 
            // dataColumn17
            // 
            this.dataColumn17.Caption = "损失类贷款";
            this.dataColumn17.ColumnName = "损失类贷款";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 26);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(794, 430);
            this.splitContainer1.SplitterDistance = 151;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 12;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.FullRowSelect = true;
            this.treeView1.ItemHeight = 30;
            this.treeView1.LineColor = System.Drawing.Color.SteelBlue;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点0";
            treeNode1.NodeFont = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            treeNode1.Text = "非现场预警触发值";
            treeNode2.Name = "节点1";
            treeNode2.NodeFont = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            treeNode2.Text = "月度工作报告附表";
            treeNode3.Name = "节点0";
            treeNode3.Text = "县域基础数据报送";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.treeView1.ShowLines = false;
            this.treeView1.Size = new System.Drawing.Size(151, 430);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(640, 430);
            this.tabControl1.TabIndex = 0;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 457);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(810, 358);
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Template)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 修改密码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改密码ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 系统更新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统更新ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下载报表模板ToolStripMenuItem;
        private System.Data.DataSet dataSet_Template;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn9;
        private System.Data.DataColumn dataColumn15;
        private System.Data.DataColumn dataColumn16;
        private System.Data.DataColumn dataColumn17;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabControl tabControl1;
    }
}