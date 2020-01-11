using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace MonthlyReports_Bank
{
    public partial class UC_Warning : UserControl
    {
        string[] str_Threshold = { "≥10.5%", "＞5%", "≥150%", "≤10%", "≤15%", "≥25%", "≥1%", "≥11%", "≤150%", "≤5%", "≤35%", "≥2.5%", "≥70%", "≤100", "≤30%", "≥70%", "＞50%", "≤50%", "＜1/3", "＜40%", "＜20%", "0", "0", "0" };
        string[] str_HeaderName = {"资本充足率(季度)","不良贷款率","拨备覆盖率","单一客户贷款集中度(季度)","单一集团授信集中度(季度)",
            "流动性比例","调整资产利润率(季度)","资本利润率(季度)","逾期90天贷款与不良贷款的比例","关注类贷款率","成本收入比例(季度)",
            "拨贷比","农户和小微企业贷款合计占比","户均贷款余额(万元)","净上存主发起行资金比例","单户500万元(含)以下贷款余额占比",
            "存贷款比例","最大单家同业融出比例","全部同业融入占总负债比重","开出承兑汇票余额占各项贷款余额的比例","票据贴现（转贴现）余额占各项贷款余额的比例",
            "投资非标资产余额","发放房地产开发贷款(保障房项目除外)余额","委托贷款投向限控行业余额" };
        string BankName_Simplified = Form_Login.loginBank.Substring(0, Form_Login.loginBank.IndexOf("村"));
       
        DataSet dsFromExcel;
        DataGridView dgv_Warning;

        public UC_Warning()
        {
            InitializeComponent();
        }

        private void UC_Warning_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.AddMonths(-1);

            //Initialize the DataGridView
            dgv_Warning = new DataGridView();
            dgv_Warning.Name = "村镇银行预警";

            InitDgv(dgv_Warning);
            DisplaySheet(dgv_Warning);

            dgv_Warning.DragEnter += dgv_Warning_DragEnter;
            dgv_Warning.DragDrop += dgv_Warning_DragDrop;
        }

        private void InitDgv(DataGridView dgv)
        {
            dgv.AllowUserToAddRows = false;
            //HeaderCell's width style
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

            string[] dgv_columnName = new string[] { "监测值要求", BankName_Simplified};

           //添加列
            for (int c = 0; c < 2; c++)
            {
                DataGridViewTextBoxColumn dgv_Column = new DataGridViewTextBoxColumn
                {
                    Name = dgv_columnName[c],
                    HeaderText = dgv_columnName[c],
                    //dgv1Column.DefaultCellStyle.BackColor = Color.AliceBlue;

                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    SortMode = DataGridViewColumnSortMode.NotSortable
                };

                dgv.Columns.Add(dgv_Column);
            }
            //添加行
            dgv.Rows.Add(24);

            for (int i = 0; i < 24; i++)
            {
                dgv.Rows[i].Cells[0].Value = str_Threshold[i];
                //添加HeaderCell
                dgv.Rows[i].HeaderCell.Value = str_HeaderName[i];
            }
        }

        private void DisplaySheet(DataGridView dgv)
        {
            TabPage tp = new TabPage(dgv.Name);
            tp.Controls.Add(dgv);
            dgv.Dock = DockStyle.Fill;

            tabControl1.TabPages.Add(tp);

            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            //最后一行颜色
            //dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.BackColor = Color.AliceBlue;
        }

        private void buttonFromExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openExcelFile = new OpenFileDialog
            {
                Title = "请选择要导入的Excel表",
                Filter = "Excel文件(*.xls,*.xlsx) | *.xls;*.xlsx"
            };

            //读取Excel到DataSet
            if (openExcelFile.ShowDialog() == DialogResult.OK)
            {
                string excelPath = openExcelFile.FileName;
                //清空ds
                dsFromExcel = new DataSet();

                //NPoI方式读取Excel
                dsFromExcel = OperatingData.OperatingData.DSFromExcel(excelPath, "预警");
                if (dsFromExcel == null) return;
                if (dsFromExcel != null && dsFromExcel.Tables.Count == 0) return;

                //将DataSet数据填充到DataGridView
                DataTable dtFromExcel = dsFromExcel.Tables[0];
                OperatingData.OperatingData.Copy_DT_To_DataGridView(dtFromExcel, dgv_Warning, "预警", 1, 2, 0, 1);
            }
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            //先校验
            if (CheckData() == false)
            {
                MessageBox.Show("校验未通过，请先检查表");
                return;
            }
            //将dgv_Warning的数据传入至DataTable
            DataTable dtFromDgv = OperatingData.OperatingData.Copy_Dgv_To_DataTable(dgv_Warning);

            //设置表名
            //dtFromDgv.TableName = dtFromDgv.Rows[0][1].ToString() + dtFromDgv.Rows[0][2].ToString() + dtFromDgv.Rows[0][0].ToString();

            OperatingData.OperatingData.DTtoDB(dtFromDgv, "db_CountyCollection");
        }

        //校验数据
        private bool CheckData()
        {
            bool checkedData = false;
            //先判断dgv_Warning里面是否有数据，如果没有，则要求其导入或直接填上数据
            if (dgv_Warning.Rows.Count != 1)
            {
                MessageBox.Show("表的行数有错误，只能有1个数据行");
                return false;
            }
            if (dgv_Warning.Columns.Count != 8)
            {
                MessageBox.Show("表的列数有错误，只能有8个数据列");
                return false;
            }

            if (dgv_Warning.Rows[0].Cells[0].Value == null)
                return false;

            string pattern = @"^20(0|1|2|3)\d(0|1)\d$";
            if (Regex.IsMatch(dgv_Warning.Rows[0].Cells[0].Value.ToString(), pattern) == false)
            {
                MessageBox.Show("输入的日期格式不正确，格式为\"201901\"");
                return false;
            }

            for (int c = 0; c < dgv_Warning.Columns.Count; c++)
            {
                //不允许为空
                if (dgv_Warning.Rows[0].Cells[c].Value == null || dgv_Warning.Rows[0].Cells[c].Value.ToString() == "")
                {
                    MessageBox.Show("表中不允许存在空单元格，若当期数为0，请填写0");
                    return false;
                }
            }

            //判断县域、机构名称是否与登录信息一致
            if (Form_Login.loginCounty != dgv_Warning.Rows[0].Cells[1].Value.ToString())
            {
                MessageBox.Show("\"区县名称\"与登录信息不一致，请改成与登录信息一致的区县名称");
                return false;
            }
            if (Form_Login.loginBank != dgv_Warning.Rows[0].Cells[2].Value.ToString())
            {
                MessageBox.Show("\"行名\"与登录信息不一致，请改成与登录信息一致的行名\r\n（见本界面左上角登录信息）");
                return false;
            }

            checkedData = true;

            return checkedData;
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            if (CheckData() == true)
            {
                MessageBox.Show("校验通过");
                return;
            }
            else
            {
                MessageBox.Show("校验未通过");
                return;
            }
        }

        //拖放
        private void dgv_Warning_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void dgv_Warning_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] paths = e.Data.GetData(DataFormats.FileDrop) as string[];
                if (paths.Length != 1)
                {
                    MessageBox.Show("只能拖入一个文件");
                    return;
                }
                else if (!File.Exists(paths[0]))
                {
                    MessageBox.Show("请拖入单个文件而不是文件夹");
                    return;
                }
                else if (Array.IndexOf(new string[] { ".xls", ".xlsx" }, Path.GetExtension(paths[0])) == -1)
                {
                    MessageBox.Show("拖入的文件不是Excel文件");
                    return;
                }
                else
                {
                    dsFromExcel = new DataSet();

                    //NPoI方式读取Excel
                    dsFromExcel = OperatingData.OperatingData.DSFromExcel(paths[0], "预警");
                    if (dsFromExcel == null) return;
                    if (dsFromExcel != null && dsFromExcel.Tables.Count == 0) return;
                    DataTable dt = dsFromExcel.Tables[0];
                    if (dt.Rows.Count == 0) return;
                    OperatingData.OperatingData.Copy_DT_To_DataGridView(dt, dgv_Warning, "预警", 1, 2, 0, 1);
                }
            }
        }
    }
}
