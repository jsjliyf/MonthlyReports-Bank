using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MonthlyReports_Bank
{
    public partial class UC_CountyReport : UserControl
    {
        public UC_CountyReport()
        {
            InitializeComponent();
        }

        private string loginBank;
        private string loginCounty;
        private string loginPassMD5;

        DataSet dsFromExcel;

        private void UC_CountyReport_Load(object sender, EventArgs e)
        {
            loginCounty = Form_Login.loginCounty;
            loginBank = Form_Login.loginBank;
            loginPassMD5 = Form_Login.loginPassMD5;

            //初始化DateTimePicker，显示上个季度末的数值
            dateTimePicker1.Value = DateTime.Now.AddMonths(-((DateTime.Now.Month - 1) % 3 + 1));
            //初始化DataGridView

            //单击可以编辑（已在属性中设置）
            //dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;

            //增加一行
            dataGridView1.Rows.Add();

            /*登录进去之后就不让选择区县和银行机构名称了，自动按照登录信息填入即可
            DataGridViewComboBoxCell dgvCb_County = new DataGridViewComboBoxCell();
            dgvCb_County.Items.AddRange(Form_Login.county);
            dgvCb_County.Value = loginCounty;
            dataGridView1.Rows[0].Cells["区县名称"] = dgvCb_County;
            */
            dataGridView1.Rows[0].Cells["期数"].Value = dateTimePicker1.Text;
            dataGridView1.Rows[0].Cells["区县名称"].Value = loginCounty;
            dataGridView1.Rows[0].Cells["区县名称"].ReadOnly = true;
            dataGridView1.Rows[0].Cells["区县名称"].Style.BackColor = Color.LightGray;
            dataGridView1.Rows[0].Cells["行名"].Value = loginBank;
            dataGridView1.Rows[0].Cells["行名"].ReadOnly = true;
            dataGridView1.Rows[0].Cells["行名"].Style.BackColor = Color.LightGray;

            //设置“期数”的提示信息
            dataGridView1.Rows[0].Cells[0].ToolTipText = "期数格式为\"201901\"";

            this.Text = "县域报表填报端 - " + loginCounty + " - " + loginBank;
        }
        
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            //Close();
        }

        //上报
        private void ButtonUpload_Click(object sender, EventArgs e)
        {
            //先校验
            if (CheckData() == false)
            {
                MessageBox.Show("校验未通过，请先检查表");
                return;
            }
            //将datagridview1的数据传入至DataTable
            DataTable dtFromDgv = new DataTable();
            //列名
            for (int columnCount = 0; columnCount < dataGridView1.Columns.Count; columnCount++)
            {
                DataColumn dc = new DataColumn(dataGridView1.Columns[columnCount].Name.ToString());
                dtFromDgv.Columns.Add(dc);
            }

            DataRow dr = dtFromDgv.NewRow();
            for (int c = 0; c < dataGridView1.Columns.Count; c++)
            {
                dr[c] = Convert.ToString(dataGridView1.Rows[0].Cells[c].Value);
            }
            dtFromDgv.Rows.Add(dr);

            //设置表名
            dtFromDgv.TableName = dtFromDgv.Rows[0][1].ToString() + dtFromDgv.Rows[0][2].ToString() + dtFromDgv.Rows[0][0].ToString();

            OperatingData.OperatingData.DTtoDB(dtFromDgv, "db_CountyCollection");
        }

        //从Excel中导入表
        private void ButtonFromExcel_Click(object sender, EventArgs e)
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
                dsFromExcel = OperatingData.OperatingData.DSFromExcel(excelPath, "县域基础数据");
                if (dsFromExcel == null) return;
                if (dsFromExcel != null && dsFromExcel.Tables.Count == 0) return;

                //将DataSet数据填充到DataGridView
                DataTable dtFromExcel = dsFromExcel.Tables[0];
                CopyToDataGridView(dtFromExcel);
            }
        }

        //将Excle数据赋值到DataGridView中
        private void CopyToDataGridView(DataTable dt)
        {
            if (dataGridView1.ColumnCount != dt.Columns.Count)
            {
                MessageBox.Show("导入的Excel不是正确的格式，请重新导入"); return;
            }

            //首列“期数”赋值，先对日期进行判断
            string pattern = @"^20(0|1|2|3)\d(0|1)\d$";
            if (Regex.IsMatch(dt.Rows[0][0].ToString(), pattern) == false)
            {
                MessageBox.Show("输入的日期格式不正确，格式为\"201901\"");
                return;
            }
            dataGridView1.Rows[0].Cells[0].Value = dt.Rows[0][0].ToString();

            //从Excel的第三列开始，将数据传入-修改表结构时需注意！！
            for (int c = 3; c < dt.Columns.Count; c++)
            {
                //将空值改为0
                if (dt.Rows[0][c].ToString() == "")
                    dataGridView1.Rows[0].Cells[c].Value = 0;

                else  //赋值到dataGridView1
                    dataGridView1.Rows[0].Cells[c].Value = dt.Rows[0][c].ToString();
            }
        }

        //校验
        private void ButtonCheck_Click(object sender, EventArgs e)
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

        //校验数据
        private bool CheckData()
        {
            bool checkedData = false;
            //先判断Datagridview1里面是否有数据，如果没有，则要求其导入或直接填上数据
            if (dataGridView1.Rows.Count != 1)
            {
                MessageBox.Show("表的行数有错误，只能有1个数据行");
                return false;
            }
            if (dataGridView1.Columns.Count != 8)
            {
                MessageBox.Show("表的列数有错误，只能有8个数据列");
                return false;
            }

            if (dataGridView1.Rows[0].Cells[0].Value == null)
                return false;

            string pattern = @"^20(0|1|2|3)\d(0|1)\d$";
            if (Regex.IsMatch(dataGridView1.Rows[0].Cells[0].Value.ToString(), pattern) == false)
            {
                MessageBox.Show("输入的日期格式不正确，格式为\"201901\"");
                return false;
            }

            for (int c = 0; c < dataGridView1.Columns.Count; c++)
            {
                //不允许为空
                if (dataGridView1.Rows[0].Cells[c].Value == null || dataGridView1.Rows[0].Cells[c].Value.ToString() == "")
                {
                    MessageBox.Show("表中不允许存在空单元格，若当期数为0，请填写0");
                    return false;
                }
            }

            //判断县域、机构名称是否与登录信息一致
            if (loginCounty != dataGridView1.Rows[0].Cells[1].Value.ToString())
            {
                MessageBox.Show("\"区县名称\"与登录信息不一致，请改成与登录信息一致的区县名称");
                return false;
            }
            if (loginBank != dataGridView1.Rows[0].Cells[2].Value.ToString())
            {
                MessageBox.Show("\"行名\"与登录信息不一致，请改成与登录信息一致的行名\r\n（见本界面左上角登录信息）");
                return false;
            }

            checkedData = true;

            return checkedData;
        }

        //当对“期数”进行编辑时，显示提示，但是没有成功，暂时放弃。
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            if (e.RowIndex == 0 && e.ColumnIndex == 0)
            {
                dataGridView1.CurrentCell.ToolTipText = "期数格式为\"201901\"";
                dataGridView1.Rows[0].Cells[0].ToolTipText = "期数格式为\"201901\"";
            }
            */
        }

        //拖放
        private void DataGridView1_DragEnter(object sender, DragEventArgs e)
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

        private void DataGridView1_DragDrop(object sender, DragEventArgs e)
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
                    dsFromExcel = OperatingData.OperatingData.DSFromExcel(paths[0], "县域基础数据");
                    if (dsFromExcel == null) return;
                    if (dsFromExcel != null && dsFromExcel.Tables.Count == 0) return;
                    DataTable dt = dsFromExcel.Tables[0];
                    if (dt.Rows.Count == 0) return;
                    CopyToDataGridView(dt);
                }
            }
        }

        private void ButtonQuery_Click(object sender, EventArgs e)
        {
            //先查询数据库
            //判断要导入的表在数据库中是否存在
            string strSql_GetTableName = "SELECT NAME FROM sysobjects WHERE XTYPE = 'U' AND NAME='" + loginCounty + loginBank + dateTimePicker1.Text + "' ORDER BY NAME";
            DataTable dt_TableName = OperatingData.OperatingData.DTfromDB(strSql_GetTableName, "db_CountyCollection");

            //不存在
            if (dt_TableName == null || dt_TableName.Rows.Count == 0)
            { MessageBox.Show("未查找到相应的表"); return; }
            //有相应表
            else if (dt_TableName.Rows.Count > 0)
            {
                //从数据库中取出相应的表
                string strSql_GetTable = "SELECT * FROM " + loginCounty + loginBank + dateTimePicker1.Text;
                DataTable dt_Query = OperatingData.OperatingData.DTfromDB(strSql_GetTable, "db_CountyCollection");

                CopyToDataGridView(dt_Query);
            }
        }

        
    }
}
