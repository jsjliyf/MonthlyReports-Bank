namespace MonthlyReports_Bank
{
    partial class UC_CountyReport
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonFromExcel = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.buttonQuery = new System.Windows.Forms.Button();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.buttonUpload = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.期数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.区县名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.行名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.各项存款 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.各项贷款 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.次级类贷款 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.可疑类贷款 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.损失类贷款 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "(支持文件直接拖放到下表)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(556, 61);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "单位：万元";
            // 
            // buttonFromExcel
            // 
            this.buttonFromExcel.Location = new System.Drawing.Point(3, 50);
            this.buttonFromExcel.Name = "buttonFromExcel";
            this.buttonFromExcel.Size = new System.Drawing.Size(116, 23);
            this.buttonFromExcel.TabIndex = 15;
            this.buttonFromExcel.Text = "从Excel导入";
            this.buttonFromExcel.UseVisualStyleBackColor = true;
            this.buttonFromExcel.Click += new System.EventHandler(this.ButtonFromExcel_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker1.CustomFormat = "yyyyMM";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(3, 13);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(117, 21);
            this.dateTimePicker1.TabIndex = 13;
            // 
            // buttonQuery
            // 
            this.buttonQuery.Location = new System.Drawing.Point(144, 12);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size(75, 23);
            this.buttonQuery.TabIndex = 17;
            this.buttonQuery.Text = "查询";
            this.buttonQuery.UseVisualStyleBackColor = true;
            this.buttonQuery.Click += new System.EventHandler(this.ButtonQuery_Click);
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(304, 13);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(75, 25);
            this.buttonCheck.TabIndex = 11;
            this.buttonCheck.Text = "校验";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.ButtonCheck_Click);
            // 
            // buttonUpload
            // 
            this.buttonUpload.Location = new System.Drawing.Point(411, 13);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(75, 25);
            this.buttonUpload.TabIndex = 14;
            this.buttonUpload.Text = "上报";
            this.buttonUpload.UseVisualStyleBackColor = true;
            this.buttonUpload.Click += new System.EventHandler(this.ButtonUpload_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.期数,
            this.区县名称,
            this.行名,
            this.各项存款,
            this.各项贷款,
            this.次级类贷款,
            this.可疑类贷款,
            this.损失类贷款});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(3, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(622, 210);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.DataGridView1_DragDrop);
            this.dataGridView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.DataGridView1_DragEnter);
            // 
            // 期数
            // 
            this.期数.HeaderText = "期数";
            this.期数.MinimumWidth = 6;
            this.期数.Name = "期数";
            this.期数.Width = 125;
            // 
            // 区县名称
            // 
            this.区县名称.HeaderText = "区县名称";
            this.区县名称.MinimumWidth = 6;
            this.区县名称.Name = "区县名称";
            this.区县名称.Width = 125;
            // 
            // 行名
            // 
            this.行名.HeaderText = "行名";
            this.行名.MinimumWidth = 6;
            this.行名.Name = "行名";
            this.行名.Width = 125;
            // 
            // 各项存款
            // 
            this.各项存款.HeaderText = "各项存款";
            this.各项存款.MinimumWidth = 6;
            this.各项存款.Name = "各项存款";
            this.各项存款.Width = 125;
            // 
            // 各项贷款
            // 
            this.各项贷款.HeaderText = "各项贷款";
            this.各项贷款.MinimumWidth = 6;
            this.各项贷款.Name = "各项贷款";
            this.各项贷款.Width = 125;
            // 
            // 次级类贷款
            // 
            this.次级类贷款.HeaderText = "次级类贷款";
            this.次级类贷款.MinimumWidth = 6;
            this.次级类贷款.Name = "次级类贷款";
            this.次级类贷款.Width = 125;
            // 
            // 可疑类贷款
            // 
            this.可疑类贷款.HeaderText = "可疑类贷款";
            this.可疑类贷款.MinimumWidth = 6;
            this.可疑类贷款.Name = "可疑类贷款";
            this.可疑类贷款.Width = 125;
            // 
            // 损失类贷款
            // 
            this.损失类贷款.HeaderText = "损失类贷款";
            this.损失类贷款.MinimumWidth = 6;
            this.损失类贷款.Name = "损失类贷款";
            this.损失类贷款.Width = 125;
            // 
            // UC_CountyReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonFromExcel);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.buttonQuery);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.buttonUpload);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UC_CountyReport";
            this.Size = new System.Drawing.Size(628, 293);
            this.Load += new System.EventHandler(this.UC_CountyReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonFromExcel;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.Button buttonUpload;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 期数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 区县名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 行名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 各项存款;
        private System.Windows.Forms.DataGridViewTextBoxColumn 各项贷款;
        private System.Windows.Forms.DataGridViewTextBoxColumn 次级类贷款;
        private System.Windows.Forms.DataGridViewTextBoxColumn 可疑类贷款;
        private System.Windows.Forms.DataGridViewTextBoxColumn 损失类贷款;
    }
}
