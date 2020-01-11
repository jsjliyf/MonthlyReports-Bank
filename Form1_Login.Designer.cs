namespace MonthlyReports_Bank
{
    partial class Form_Login
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
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelCounty = new System.Windows.Forms.Label();
            this.labelPass = new System.Windows.Forms.Label();
            this.textBox_Pass = new System.Windows.Forms.TextBox();
            this.comboBox_County = new System.Windows.Forms.ComboBox();
            this.labelBank = new System.Windows.Forms.Label();
            this.comboBox_Bank = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_BankType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox_ServerIP = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonLogin.Location = new System.Drawing.Point(195, 163);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin.TabIndex = 0;
            this.buttonLogin.Text = "登录";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonClose.Location = new System.Drawing.Point(338, 163);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "关闭";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // labelCounty
            // 
            this.labelCounty.AutoSize = true;
            this.labelCounty.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCounty.Location = new System.Drawing.Point(40, 51);
            this.labelCounty.Name = "labelCounty";
            this.labelCounty.Size = new System.Drawing.Size(49, 14);
            this.labelCounty.TabIndex = 3;
            this.labelCounty.Text = "区县：";
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPass.Location = new System.Drawing.Point(192, 101);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(63, 14);
            this.labelPass.TabIndex = 4;
            this.labelPass.Text = "密  码：";
            // 
            // textBox_Pass
            // 
            this.textBox_Pass.Location = new System.Drawing.Point(275, 100);
            this.textBox_Pass.Name = "textBox_Pass";
            this.textBox_Pass.PasswordChar = '*';
            this.textBox_Pass.Size = new System.Drawing.Size(125, 21);
            this.textBox_Pass.TabIndex = 6;
            // 
            // comboBox_County
            // 
            this.comboBox_County.FormattingEnabled = true;
            this.comboBox_County.Items.AddRange(new object[] {
            "枣强",
            "武邑",
            "深州",
            "武强",
            "饶阳",
            "安平",
            "故城",
            "景县",
            "阜城",
            "冀州",
            "衡水"});
            this.comboBox_County.Location = new System.Drawing.Point(95, 50);
            this.comboBox_County.Name = "comboBox_County";
            this.comboBox_County.Size = new System.Drawing.Size(73, 20);
            this.comboBox_County.TabIndex = 7;
            // 
            // labelBank
            // 
            this.labelBank.AutoSize = true;
            this.labelBank.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelBank.Location = new System.Drawing.Point(192, 55);
            this.labelBank.Name = "labelBank";
            this.labelBank.Size = new System.Drawing.Size(77, 14);
            this.labelBank.TabIndex = 8;
            this.labelBank.Text = "机构名称：";
            // 
            // comboBox_Bank
            // 
            this.comboBox_Bank.FormattingEnabled = true;
            this.comboBox_Bank.Items.AddRange(new object[] {
            "农业发展银行",
            "工商银行",
            "农业银行",
            "中国银行",
            "建设银行",
            "交通银行",
            "邮储银行",
            "民生银行",
            "浦发银行",
            "衡水银行",
            "河北银行",
            "邢台银行",
            "沧州银行",
            "张家口银行",
            "安平惠民村镇银行",
            "深州丰源村镇银行",
            "阜城家银村镇银行",
            "故城家银村镇银行",
            "武强家银村镇银行",
            "饶阳民商村镇银行",
            "武邑邢农商村镇银行",
            "枣强丰源村镇银行",
            "冀州丰源村镇银行",
            "景州丰源村镇银行",
            "衡水农商行",
            "阜城农商行",
            "武强农商行",
            "景州农商行",
            "冀州农商行",
            "枣强农商行",
            "安平农商行",
            "深州农商行",
            "饶阳联社",
            "故城联社",
            "武邑联社"});
            this.comboBox_Bank.Location = new System.Drawing.Point(275, 50);
            this.comboBox_Bank.Name = "comboBox_Bank";
            this.comboBox_Bank.Size = new System.Drawing.Size(224, 20);
            this.comboBox_Bank.TabIndex = 9;
            this.comboBox_Bank.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Bank_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(40, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "机构类型：";
            // 
            // comboBox_BankType
            // 
            this.comboBox_BankType.FormattingEnabled = true;
            this.comboBox_BankType.Items.AddRange(new object[] {
            "政策性银行",
            "大型银行(含邮储）",
            "股份制银行(全国性股份制+城商行）",
            "县域农合机构(农商行+县联社)",
            "村镇银行"});
            this.comboBox_BankType.Location = new System.Drawing.Point(123, 8);
            this.comboBox_BankType.Name = "comboBox_BankType";
            this.comboBox_BankType.Size = new System.Drawing.Size(224, 20);
            this.comboBox_BankType.TabIndex = 11;
            this.comboBox_BankType.Text = "(非必填项)";
            this.comboBox_BankType.SelectedIndexChanged += new System.EventHandler(this.ComboBox_BankType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "服务器：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(195, 212);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(333, 50);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // comboBox_ServerIP
            // 
            this.comboBox_ServerIP.FormattingEnabled = true;
            this.comboBox_ServerIP.Items.AddRange(new object[] {
            "192.168.101.235",
            "10.20.66.6"});
            this.comboBox_ServerIP.Location = new System.Drawing.Point(65, 228);
            this.comboBox_ServerIP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_ServerIP.Name = "comboBox_ServerIP";
            this.comboBox_ServerIP.Size = new System.Drawing.Size(103, 20);
            this.comboBox_ServerIP.TabIndex = 15;
            this.comboBox_ServerIP.Text = "10.20.66.6";
            this.comboBox_ServerIP.SelectedIndexChanged += new System.EventHandler(this.ComboBox_ServerIP_SelectedIndexChanged);
            // 
            // Form_Login
            // 
            this.AcceptButton = this.buttonLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(530, 265);
            this.Controls.Add(this.comboBox_ServerIP);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_BankType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Bank);
            this.Controls.Add(this.labelBank);
            this.Controls.Add(this.comboBox_County);
            this.Controls.Add(this.textBox_Pass);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.labelCounty);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form_Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelCounty;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.TextBox textBox_Pass;
        private System.Windows.Forms.ComboBox comboBox_County;
        private System.Windows.Forms.Label labelBank;
        private System.Windows.Forms.ComboBox comboBox_Bank;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_BankType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBox_ServerIP;
    }
}