namespace MonthlyReports_Bank
{
    partial class UC_Warning
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonFromExcel = new System.Windows.Forms.Button();
            this.buttonQuery = new System.Windows.Forms.Button();
            this.buttonUpload = new System.Windows.Forms.Button();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyyMM";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(3, 6);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(77, 21);
            this.dateTimePicker1.TabIndex = 3;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Location = new System.Drawing.Point(3, 42);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(672, 278);
            this.tabControl1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "(支持文件直接拖放到下表)";
            // 
            // buttonFromExcel
            // 
            this.buttonFromExcel.Location = new System.Drawing.Point(171, 3);
            this.buttonFromExcel.Name = "buttonFromExcel";
            this.buttonFromExcel.Size = new System.Drawing.Size(116, 29);
            this.buttonFromExcel.TabIndex = 19;
            this.buttonFromExcel.Text = "从Excel导入";
            this.buttonFromExcel.UseVisualStyleBackColor = true;
            this.buttonFromExcel.Click += new System.EventHandler(this.buttonFromExcel_Click);
            // 
            // buttonQuery
            // 
            this.buttonQuery.Location = new System.Drawing.Point(86, 3);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size(75, 29);
            this.buttonQuery.TabIndex = 21;
            this.buttonQuery.Text = "查询";
            this.buttonQuery.UseVisualStyleBackColor = true;
            this.buttonQuery.Click += new System.EventHandler(this.buttonQuery_Click);
            // 
            // buttonUpload
            // 
            this.buttonUpload.Location = new System.Drawing.Point(556, 3);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(75, 28);
            this.buttonUpload.TabIndex = 22;
            this.buttonUpload.Text = "上报";
            this.buttonUpload.UseVisualStyleBackColor = true;
            this.buttonUpload.Click += new System.EventHandler(this.buttonUpload_Click);
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(475, 3);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(75, 28);
            this.buttonCheck.TabIndex = 23;
            this.buttonCheck.Text = "校验";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // UC_Warning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.buttonUpload);
            this.Controls.Add(this.buttonQuery);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonFromExcel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "UC_Warning";
            this.Size = new System.Drawing.Size(677, 322);
            this.Load += new System.EventHandler(this.UC_Warning_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonFromExcel;
        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.Button buttonUpload;
        private System.Windows.Forms.Button buttonCheck;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
