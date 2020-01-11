using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MonthlyReports_Bank
{
    public partial class Form_Main : Form
    {
        private string loginBank;
        private string loginCounty;
        private string loginPassMD5;

        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            loginCounty = Form_Login.loginCounty;
            loginBank = Form_Login.loginBank;
            loginPassMD5 = Form_Login.loginPassMD5;

            if (loginCounty == loginBank.Substring(0, 2))
                this.Text = "机构数据报送客户端 - " + loginBank;
            else
                this.Text = "机构数据报送客户端 - " + loginCounty + loginBank;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void 修改密码ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form3 form_ModifyPass = new Form3();
            form_ModifyPass.ShowDialog();

        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form_CopyRight = new Form4();
            form_CopyRight.ShowDialog();
        }

        private void 下载报表模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel文件(*.xls,*xlsx)|*.xls;*.xlsx",  //设置文件类型
                Title = "保存至Excel",
                FileName = "报表模板",
                DefaultExt = "xls",   //设置默认格式（可以不设）
                AddExtension = true  //设置自动在文件名中添加扩展名
            };
            
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                DataTable dt_Temp = dataSet_Template.Tables[0];
                DataRow dr = dt_Temp.NewRow();
                dr[0] = DateTime.Now.AddMonths(-((DateTime.Now.Month - 1) % 3 + 1)).ToString("yyyyMM");
                dr[1] = loginCounty;
                dr[2] = loginBank;
                dt_Temp.Rows.Add(dr);

                OperatingData.OperatingData.DSToExcel(dataSet_Template, sfd.FileName);
                MessageBox.Show("导出Excel表成功!"); return;
            }
        }

        private void 系统更新ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("您使用的是最新版本！");
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text.Contains("预警触发值"))
            {
                UC_Warning uc_warning= new UC_Warning();

                tabControl1.TabPages.Clear();
                TabPage tp = new TabPage("预警触发值");
                tp.Controls.Add(uc_warning);
                uc_warning.Dock = DockStyle.Fill;
                tabControl1.TabPages.Add(tp);
            }

            else if (e.Node.Text.Contains("县域基础数据报送"))
            {
                UC_CountyReport uc_countyReport = new UC_CountyReport();

                tabControl1.TabPages.Clear();
                TabPage tp = new TabPage("县域基础数据报送");
                tp.Controls.Add(uc_countyReport);
                uc_countyReport.Dock = DockStyle.Fill;
                tabControl1.TabPages.Add(tp);
            }
        }
    }
}
