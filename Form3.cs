using System;
using System.Data;
using System.Windows.Forms;

namespace MonthlyReports_Bank
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        //重置
        private void Button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        //确认
        private void Button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 6 || textBox2.Text.Length < 6)
            {
                MessageBox.Show("密码位数不能少于6位，请重新输入");
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else if (!string.Equals(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("两次输入的密码不一致，请重新输入");
                textBox1.Text = "";
                textBox2.Text = "";
            }

            else
            {
                string passwordMD5 = OperatingData.OperatingData.ComputeMD5Hash(textBox1.Text).ToLower();
                Form_Login.loginPassMD5 = passwordMD5;
                //修改数据库
                DataTable dt = new DataTable();
                dt.TableName = "tb_BankUser";
                dt.Columns.Add("county", Type.GetType("System.String"));
                dt.Columns.Add("bank", Type.GetType("System.String"));
                dt.Columns.Add("passMD5", Type.GetType("System.String"));

                DataRow dr = dt.NewRow();
                dr["county"] = Form_Login.loginCounty;
                dr["bank"] = Form_Login.loginBank;
                dr["passMD5"] = Form_Login.loginPassMD5;
                dt.Rows.Add(dr);

                bool writeToDB = OperatingData.OperatingData.UpdateDB("tb_BankUser", "db_CountyCollection");

                if (writeToDB == false)
                {
                    MessageBox.Show("密码更新失败");
                    return;
                }
                else if (writeToDB == true)
                {
                    //继续修改userData
                    string[] userData = { Form_Login.loginCounty, Form_Login.loginBank, Form_Login.loginPassMD5 };
                    bool writen = OperatingData.OperatingData.WriteUserInfoToXML("userData.xml", userData);
                    if (writen == false)
                    {
                        MessageBox.Show("写入本地配置文件失败");
                        return;
                    }

                    MessageBox.Show("密码更新成功，请牢记新密码");
                }
            }
        }
    }
}
