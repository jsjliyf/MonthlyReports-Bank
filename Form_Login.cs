using CountyCollection;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CountyCollection_Bank
{
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }

        public static string[] bankType = { "政策性银行", "大型银行(含邮储）", "股份制银行(全国性股份制+城商行）", "县域农合机构(农商行+县联社)", "村镇银行" };
        public static string[] county = { "枣强", "武邑", "深州", "武强", "饶阳", "安平", "故城", "景县", "阜城", "衡水" };
        public static string[] bank =  { "农业发展银行",//0
            "工商银行","农业银行","中国银行","建设银行","交通银行","邮储银行",//1-6
            "民生银行","浦发银行","衡水银行","河北银行","邢台银行","沧州银行","张家口银行",//7-13
        "安平惠民村镇银行","深州丰源村镇银行","阜城家银村镇银行","故城家银村镇银行","武强家银村镇银行",//14-18
            "饶阳民商村镇银行","武邑邢农商村镇银行","枣强丰源村镇银行","冀州丰源村镇银行","景州丰源村镇银行",//19-23
            "衡水农商行","阜城农商行","武强农商行","景州农商行",//24-27
            "冀州农商行","枣强农商行","安平农商行","深州农商行",//28-31
            "饶阳联社","故城联社","武邑联社" };//32-34

        public static string loginBank=null;
        public static string loginCounty=null;
        private static string loginPass = null;
        public static string loginPassMD5 = null;

        public static string serverIP = null;

        private void Form_Login_Load(object sender, EventArgs e)
        {
            serverIP = comboBox_ServerIP.Text;

            string[] userInfo = { loginBank, loginCounty, loginPassMD5 };
            bool readen = OperatingData.OperatingData.ReadUserInfoFromXML("userData.xml", userInfo);

            if (readen == false)
            {
                MessageBox.Show("本地配置文件有错误");
            }
            else if (readen == true)
            {
                loginCounty = userInfo[0];
                loginBank = userInfo[1];
                loginPassMD5 = userInfo[2];
            }
            if (!string.IsNullOrEmpty(loginBank) && !string.IsNullOrEmpty(loginCounty) && !string.IsNullOrEmpty(loginPassMD5))
            {
                comboBox_County.Text = loginCounty;
                comboBox_Bank.Text = loginBank;
                textBox_Pass.Text = loginPassMD5;
            }
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox_County.Text.Trim()) && !string.IsNullOrEmpty(comboBox_Bank.Text.Trim()) && !string.IsNullOrEmpty(textBox_Pass.Text))
            {
                loginCounty = comboBox_County.Text.Trim();
                loginBank = comboBox_Bank.Text.Trim();
                loginPass = textBox_Pass.Text;
                if (!string.Equals(loginPassMD5, loginPass, StringComparison.CurrentCultureIgnoreCase))
                    loginPassMD5 = OperatingData.OperatingData.ComputeMD5Hash(loginPass).ToLower();

                DataTable dt_Login = OperatingData.OperatingData.DTfromDB("select * from tb_登录账号 where county='" + loginCounty + "' and bank='" + loginBank + "' and passMD5='" + loginPassMD5.ToLower() + "'", "db_CountyCollection");
                if (dt_Login == null)
                {
                    MessageBox.Show("账号或密码错误，请重新登录");
                    return;
                }
                else if (dt_Login.Rows.Count == 0)
                {
                    MessageBox.Show("账号或密码错误，请重新登录");
                    return;
                }
               
                else //登录成功
                {
                    string[] userInfo = { loginCounty, loginBank , loginPassMD5 };
                    //将登录信息保存到当地XML文件中
                 bool writen=  OperatingData.OperatingData.WriteUserInfoToXML("userData.xml", userInfo);
                    if(writen == false)
                    {
                        MessageBox.Show("用户信息有错误，没有写入当地配置文件");
                    }

                    Form form_Upload = new Form2();
                    Hide();
                    form_Upload.ShowDialog();
                    Close();
                }
            }

            else
            {
                MessageBox.Show("登录信息不完整，请重新填写！");
                return;
            }
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ComboBox_BankType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBox_BankType.SelectedItem.ToString() == "政策性银行")
            {
                comboBox_Bank.Items.Clear();
                comboBox_Bank.Items.Add(bank[0]);
                comboBox_Bank.Text = comboBox_Bank.Items[0].ToString();
            }
            else if(comboBox_BankType.SelectedItem.ToString() == "大型银行(含邮储）")
            {
                comboBox_Bank.Items.Clear();
                string[] bank_select = new string[6];
                Array.ConstrainedCopy(bank, 1, bank_select, 0, 6);
                comboBox_Bank.Items.AddRange(bank_select);
                comboBox_Bank.Text = comboBox_Bank.Items[0].ToString();
            }
           else if (comboBox_BankType.SelectedItem.ToString() == "股份制银行(全国性股份制+城商行）")
            {
                comboBox_Bank.Items.Clear();
                string[] bank_select = new string[7];
                Array.ConstrainedCopy(bank, 7, bank_select, 0, 7);
                comboBox_Bank.Items.AddRange(bank_select);
                comboBox_Bank.Text = comboBox_Bank.Items[0].ToString();
            }
            else if (comboBox_BankType.SelectedItem.ToString() == "县域农合机构(农商行+县联社)")
            {
                comboBox_Bank.Items.Clear();
                string[] bank_select = new string[11];
                Array.ConstrainedCopy(bank, 24, bank_select, 0, 11);
                comboBox_Bank.Items.AddRange(bank_select);
                comboBox_Bank.Text = comboBox_Bank.Items[0].ToString();
            }
            else if (comboBox_BankType.SelectedItem.ToString() == "村镇银行")
            {
                comboBox_Bank.Items.Clear();
                string[] bank_select = new string[10];
                Array.ConstrainedCopy(bank, 14, bank_select, 0, 10);
                comboBox_Bank.Items.AddRange(bank_select);
                comboBox_Bank.Text = comboBox_Bank.Items[0].ToString();
            }
        }

        private void ComboBox_Bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Array.IndexOf(bank, comboBox_Bank.Text) >= Array.IndexOf(bank, "安平惠民村镇银行") && Array.IndexOf(bank, comboBox_Bank.Text) <= Array.IndexOf(bank, "武邑联社"))
            {
                if (comboBox_Bank.Text.Substring(0, 2) != comboBox_County.Text)
                {
                    comboBox_County.Text = comboBox_Bank.Text.Substring(0, 2);
                }
            }
        }

        private void ComboBox_ServerIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            serverIP = comboBox_ServerIP.Text;
        }
    }
}
