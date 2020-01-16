using MonthlyReports_Bank;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace OperatingData
{
    public class OperatingData
    {
        //DB login information
        private static string DB_UserName = "lyf";
        private static string DB_PassWord = "HiAmigo168F";

        /// <summary>
        /// NPOI方式读取Excel
        /// </summary>
        /// <param name="strFileName">Excel文件路径</param>
        /// <param name="reportType">表格类型</param>
        /// <param name="isStandard">若是标准格式，则按照首行来创建列;若否，则按照表中最大的列来创建列</param>
        /// <param name="needFirstRow">是否需要取出首行数据，若不需要，则将首行作为DT的列标题</param>
        /// <returns>对应的DataSet</returns>
        public static DataSet DSFromExcel(string strFileName, string reportType, bool isStandard, bool needFirstRow)
        {
            DataSet ds = new DataSet();

            try
            {
                using (FileStream fs = File.OpenRead(strFileName))   //打开excel文件
                {
                    IWorkbook wk = null;

                    string fileName = Path.GetFileNameWithoutExtension(fs.Name);
                    string extension = Path.GetExtension(fs.Name);

                    //判断excel文件类型
                    if (extension == ".xlsx" || extension == ".xls")
                    {
                        //判断excel的版本
                        if (extension == ".xlsx")
                        {
                            wk = new XSSFWorkbook(fs);
                        }
                        else
                        {
                            wk = new HSSFWorkbook(fs);
                        }
                    }

                    ISheet sheet = wk.GetSheetAt(0);   //只读取第1个sheet的数据
                    DataTable dt = new DataTable();

                    IRow headrow = sheet.GetRow(0);  //读取sheet表的第一行数据，即列标题
                    //创建列
                    for (int c = 0; c < headrow.LastCellNum; c++)  //按照首行创建列
                    {
                        ICell cell = headrow.GetCell(c);
                        string columnName = GetCellValue(cell);

                        dt.Columns.Add(columnName, Type.GetType("System.String"));

                    }
                    #region 校验表格
                    if (reportType == "县域基础数据")
                    {
                        if (headrow.LastCellNum != 8)
                        {
                            MessageBox.Show("导入的表列数不对，只能有8列，请删除空列");
                            return null;
                        }
                    }
                    else if (reportType == "预警")
                    {
                        if (headrow.LastCellNum != 3 ||
                            !GetCellValue(headrow.GetCell(0)).Contains("监管指标"))
                        {
                            MessageBox.Show("导入的表不是标准格式，请从“文件”里面下载报送模板进行填报。");
                            return null;
                        }
                    }
                    #endregion
                    //取出sheet中的全部数据
                    int firstRow = 0;
                    if (!needFirstRow)
                    {
                        firstRow = 1;
                    }
                    for (int r = firstRow; r <= sheet.LastRowNum; r++)
                    {
                        IRow row = sheet.GetRow(r);  //读取当前行数据
                        DataRow dr = dt.NewRow();

                        if (row != null)
                        {
                            for (int k = 0; k < row.LastCellNum; k++)
                            {
                                ICell cell = row.GetCell(k);  //当前表格
                                if (cell != null)
                                {
                                    dr[k] = GetCellValue(cell);
                                }
                                else if (cell == null)
                                {
                                    dr[k] = string.Empty;
                                }
                            }
                        }
                        else if (row == null)
                        {
                            dr[0] = string.Empty;
                        }
                        dt.Rows.Add(dr);
                    }
                    ds.Tables.Add(dt);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + "请关闭已打开的Excel文件后再试。");
                return null;
            }
            return ds;
        }

        private static string GetCellValue(ICell cell)
        {
            if (cell == null)
                return string.Empty;
            switch (cell.CellType)
            {
                case CellType.Blank: //空数据类型 这里类型注意一下，不同版本NPOI大小写可能不一样,有的版本是Blank（首字母大写)
                    return string.Empty;
                case CellType.Boolean: //bool类型
                    return cell.BooleanCellValue.ToString();
                case CellType.Error:
                    return cell.ErrorCellValue.ToString();
                case CellType.Numeric: //数字类型
                    if (HSSFDateUtil.IsCellDateFormatted(cell))//日期类型
                    {
                        return cell.DateCellValue.ToString();
                    }
                    else //其它数字
                    {
                        return cell.NumericCellValue.ToString();
                    }
                case CellType.Unknown: //无法识别类型
                default: //默认类型
                    return cell.ToString();//
                case CellType.String: //string 类型
                    return cell.StringCellValue;
                case CellType.Formula: //带公式类型
                    try
                    {
                        HSSFFormulaEvaluator e = new HSSFFormulaEvaluator(cell.Sheet.Workbook);
                        e.EvaluateInCell(cell);
                        return cell.ToString();
                    }
                    catch
                    {
                        return cell.NumericCellValue.ToString();
                    }
            }
        }

        /// <summary>
        /// 从数据库取出数据到DataTable
        /// </summary>
        /// <param name="strSql">查询语句</param>
        /// <param name="dbName">数据库名称</param>
        /// <returns>取出的DataTable</returns>
        public static DataTable DTfromDB(string strSql, string dbName)
        {
            using (SqlConnection conn = new SqlConnection("server=" + Form_Login.serverIP + ";database=" + dbName + ";uid=" + DB_UserName + ";pwd=" + DB_PassWord))
            {
                try
                {
                    SqlDataAdapter sda = new SqlDataAdapter(strSql, conn);

                    DataTable dtSelected = new DataTable();

                    sda.Fill(dtSelected);
                    return dtSelected;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n" + "未找到对应的表，请先生成表或将表导入数据库中");
                    return null;
                }
            }
        }

        /// <summary>
        /// 更新数据表
        /// </summary>
        /// <param name="dtName">待更新的数据表名称</param>
        /// <param name="dbName">数据库名称</param>
        /// <returns>是否更新成功</returns>
        public static bool UpdateDB(string dtName, string dbName)
        {
            if(string.IsNullOrEmpty(Form_Login.serverIP))
            {
                MessageBox.Show("服务器地址为空");
                return false;
            }

            using (SqlConnection conn = new SqlConnection("server=" + Form_Login.serverIP + ";database=" + dbName + ";uid="+DB_UserName+";pwd="+DB_PassWord))
            {
                string strUpdate = string.Format(@"update {0} set passMD5='{1}' where county='{2}' and bank='{3}'", dtName, Form_Login.loginPassMD5, Form_Login.loginCounty, Form_Login.loginBank);
                SqlCommand comm = new SqlCommand(strUpdate, conn);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    int i =
                        comm.ExecuteNonQuery();
                    return true;;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n");
                    return false;;
                }
            }
        }

        /// <summary>
        /// 利用SqlBulkCopy将DataTable数据导入数据库
        /// </summary>
        /// <param name="dt_ToDB">待导入的DataTable</param>
        /// <param name="dbName">数据库名称</param>
        /// <returns>是否导入成功</returns>
        public static bool DTtoDB(DataTable dt_ToDB, string dbName)
        {
            if (dt_ToDB == null || dt_ToDB.Rows.Count == 0) { MessageBox.Show("要导入的表不存在数据，请重新导入。"); return false; }

            //判断要导入的表在数据库中是否存在
            string strSql_GetTableName = "SELECT NAME FROM sysobjects WHERE XTYPE = 'U' AND NAME='" + dt_ToDB.TableName + "' ORDER BY NAME";
            DataTable dt_TableName = DTfromDB(strSql_GetTableName, dbName);

            //不存在此表则创建新表
            if (dt_TableName == null || dt_TableName.Rows.Count == 0)
                CreateTableInDB(dt_ToDB, dbName);

            //存在此表则清空原表（选择是否导入）
            else if (dt_TableName.Rows.Count > 0)
            {
                //如果是登录用户信息表，则直接清空用户登录信息
                if (dt_ToDB.TableName == "tb_BankUser")
                {
                    using (SqlConnection sqlConn = new SqlConnection("server="+ Form_Login.serverIP+";database=" + dbName + ";uid="+DB_UserName+";pwd="+DB_PassWord))
                    {
                        if (sqlConn.State == ConnectionState.Closed)
                            sqlConn.Open();
                        //清空数据库中对应的表数据
                        try
                        {
                            SqlCommand sqlComm = new SqlCommand("truncate table " + dt_ToDB.TableName, sqlConn);
                            int i =
                                sqlComm.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            if (sqlConn.State == ConnectionState.Open)
                                sqlConn.Close();

                            MessageBox.Show(ex.ToString());
                            return false;
                        }
                        if (sqlConn.State == ConnectionState.Open)
                            sqlConn.Close();
                    }
                }
                else
                {
                    DialogResult dr = MessageBox.Show("数据库中已经存在此表，继续导入吗？将会覆盖原表", "是否清空表", MessageBoxButtons.OKCancel);
                    //仍然导入，则先清空原数据
                    if (dr == DialogResult.OK)
                    {
                        using (SqlConnection sqlConn = new SqlConnection("server="+ Form_Login.serverIP+";database=" + dbName + ";uid="+DB_UserName+";pwd="+DB_PassWord))
                        {
                            if (sqlConn.State == ConnectionState.Closed)
                                sqlConn.Open();
                            //清空数据库中对应的表数据
                            try
                            {
                                SqlCommand sqlComm = new SqlCommand("truncate table " + dt_ToDB.TableName, sqlConn);
                                int i =
                                    sqlComm.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                if (sqlConn.State == ConnectionState.Open)
                                    sqlConn.Close();

                                MessageBox.Show(ex.ToString());
                                return false;
                            }
                            if (sqlConn.State == ConnectionState.Open)
                                sqlConn.Close();
                        }
                    }
                    //不导入数据
                    else if (dr == DialogResult.Cancel)
                    {
                        return false;

                    }
                }
            }

            //SqlBulkCopy批量导入数据
            using (SqlConnection sqlConn = new SqlConnection("server="+ Form_Login.serverIP+";database=" + dbName + ";uid="+DB_UserName+";pwd="+DB_PassWord))
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                using (SqlBulkCopy sbc = new SqlBulkCopy(sqlConn))
                {
                    try
                    {
                        sbc.BatchSize = dt_ToDB.Rows.Count;
                        sbc.DestinationTableName = dt_ToDB.TableName;

                        for (int c = 0; c < dt_ToDB.Columns.Count; c++)
                        {
                            sbc.ColumnMappings.Add(dt_ToDB.Columns[c].ColumnName, dt_ToDB.Columns[c].ColumnName);
                        }

                        sbc.WriteToServer(dt_ToDB);
                    }
                    catch (Exception ex)
                    {
                        if (sqlConn.State == ConnectionState.Open)
                            sqlConn.Close();

                        MessageBox.Show(ex.ToString());
                        return false;
                    }
                }

                if (sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
            }

            MessageBox.Show("\"" + dt_ToDB.TableName + "\"" + "成功导入数据库");
            return true;
        }

        /// <summary>
        /// 在数据库dbName中创建表，表结构与(DataTable)dt一样
        /// </summary>
        /// <param name="dt">表(结构)</param>
        /// <param name="dbName">数据库的名字</param>
        /// <returns></returns>
        private static bool CreateTableInDB(DataTable dt, string dbName)
        {
            //创建表（只有结构，没有数据）
            try
            {
                //注意这里不要用Integrated Security=SSPI，这样连接其他机器如服务器的数据库时会报错，直接用登录名和密码登录即可
                string connString = "Initial Catalog=" + dbName + ";" + "Data Source=" + Form_Login.serverIP + ";uid="+DB_UserName+";pwd="+DB_PassWord;
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connString;
                conn.Open();

                string strSql = "CREATE TABLE " + dt.TableName + "(";

                //！！注意列名中如果含有特殊字符，要加中括号[]引起来，防止sql无法识别
                //另注意，表的名字是有限制的，最好不要以数字开头，不能包括特殊字符，如“-”等（但：下划线_是可以的）
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    if (c != dt.Columns.Count - 1)
                        strSql += "[" + dt.Columns[c].ColumnName + "] nvarchar(50) NOT NULL,";  //！！注意，不要随便设主键，否则SqlBulkCopy导入数据库后，会按照主键来进行排序！
                    else if (c == dt.Columns.Count - 1)
                        strSql += "[" + dt.Columns[c].ColumnName + "] nvarchar(50) NOT NULL)";
                }

                SqlCommand cmd = new SqlCommand(strSql, conn);
                int i =
                    cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }

            return true;
        }

        #region NPOI保存数据到excel
        /// <summary>
                /// 导出数据到excel中
                /// </summary>
                /// <param name="dataSet"></param>
                /// <param name="filename"></param>
                /// <returns></returns>
        public static bool DSToExcel(DataSet dataSet, string filename)
        {
            MemoryStream ms = new MemoryStream();
            using (dataSet)
            {
                IWorkbook workBook;
                //IWorkbook workBook=WorkbookFactory.Create(filename);

                string suffix = Path.GetExtension(filename);

                //string suffix = filename.Substring(filename.LastIndexOf(".") + 1, filename.Length - filename.LastIndexOf(".") - 1);
                if (suffix == ".xls")
                {
                    workBook = new HSSFWorkbook();
                }
                else
                    workBook = new XSSFWorkbook();

                for (int i = 0; i < dataSet.Tables.Count; i++)
                {
                    string sheetName = "";
                    //如果是生成表（NPL和SML），则sheet的名字改成“各支行汇总”
                    //if (dataSet.Tables[i].TableName.Contains("各支行汇总"))
                    //{

                        //if (dataSet.Tables[i].TableName.Contains("不良贷款"))
                        //    sheetName = "各支行汇总" + "不良贷款";
                        //else if (dataSet.Tables[i].TableName.Contains("关注类贷款"))
                        //    sheetName = "各支行汇总" + "关注类贷款";
                    //}
                    sheetName = dataSet.Tables[i].TableName;

                    ISheet sheet = workBook.CreateSheet(sheetName);
                    SheetFromDT(sheet, dataSet.Tables[i]);
                }
                workBook.Write(ms);

                try
                {
                    SaveToFile(ms, filename);
                    ms.Flush();
                    return true;
                }
                catch
                {
                    ms.Flush();
                    throw;
                }
            }
        }

        private static void SheetFromDT(ISheet sheet, DataTable dataTable)
        {
            IRow headerRow = sheet.CreateRow(0);
            //表头
            foreach (DataColumn column in dataTable.Columns)
                headerRow.CreateCell(column.Ordinal).SetCellValue(column.Caption);//If Caption not set, returns the ColumnName value

            int rowIndex = 1;
            foreach (DataRow row in dataTable.Rows)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);
                foreach (DataColumn column in dataTable.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                }
                rowIndex++;
            }
        }

        private static void SaveToFile(MemoryStream ms, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                byte[] data = ms.ToArray();         //转为字节数组 
                fs.Write(data, 0, data.Length);     //保存为Excel文件
                fs.Flush();
                data = null;
            }
        }
        #endregion

        #region DataTable与DataGridView相互传递数据
        /// <summary>
        /// 将DataTable数据赋值到DataGridView中
        /// DT是从Excel取出来的，带有标题行，即行数比Dgv多一行
        /// 因Dgv的类型不同，第一列既可以在Dgv的Header里，也有可能不在，所以需要根据Dgv的类型来判断列数
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dgv"></param>
        /// <param name="ReportType">传递的表类型</param>
        /// <param name="startRow_DT">从第几行开始传值</param>
        /// <param name="startColumn_DT">从第几列开始传值</param>
        /// <param name="startRow_Dgv">从第几行开始传入Dgv</param>
        /// <param name="startColumn_Dgv">从第几列开始传入Dgv</param>
        public static void Copy_DT_To_DataGridView(DataTable dt, DataGridView dgv, string ReportType,
            int startRow_DT, int startColumn_DT,int startRow_Dgv,int startColumn_Dgv)
        {
            #region 判断格式是否正确
            if (ReportType == "预警")
            {
                if (dgv.ColumnCount + 1 != dt.Columns.Count || dgv.Rows.Count != dt.Rows.Count
                || !dt.Rows[0][0].ToString().Contains("资本充足率"))
                {
                    MessageBox.Show("导入的Excel不是正确的格式，请重新导入"); return;
                }
            }
            else if (ReportType == "县域基础数据")
            {
                //首列“期数”赋值，先对日期进行判断
                string pattern = @"^20(0|1|2|3)\d(0|1)\d$";
                if (Regex.IsMatch(dt.Rows[0][0].ToString(), pattern) == false)
                {
                    MessageBox.Show("输入的日期格式不正确，格式为\"201901\"");
                    return;
                }
            }
            #endregion

            for (int r = startRow_DT; r < dt.Rows.Count; r++)
            {
                int nextRow_Column_Dgv = startColumn_Dgv;
                for (int c = startColumn_DT; c < dt.Columns.Count; c++)
                {
                    //空值处理
                    if (dt.Rows[r][c].ToString() == "")
                    {
                        dgv.Rows[startRow_Dgv].Cells[nextRow_Column_Dgv].Value = "-";
                        nextRow_Column_Dgv++;
                    }
                    else  //传值
                    {
                        dgv.Rows[startRow_Dgv].Cells[nextRow_Column_Dgv].Value = dt.Rows[r][2].ToString();
                        nextRow_Column_Dgv++;
                    }
                }
                startRow_Dgv++;
            }
        }

        /// <summary>
        /// 将Dgv的数据复制到DataTable中，注意：统一将Dgv的列标题作为DT的列名
        /// </summary>
        /// <param name="dgv">待拷贝的Dgv</param>
        /// <param name="needRowHeader">是否需要将Dgv的行头复制到DT中</param>
        /// <returns></returns>
        public static DataTable Copy_Dgv_To_DataTable(DataGridView dgv,string ReportType, bool needRowHeader)
        {
            string headerName = null;
            if(ReportType == "预警")
            {
                headerName = "监测指标";
            }
            DataTable dt = new DataTable();
            //添加列
            //如果需要行头，则先添加一列
            if (needRowHeader)
            {
                DataColumn dc_Header = new DataColumn(headerName);
                dt.Columns.Add(dc_Header);
            }
            //添加正常列
            for (int columnCount = 0; columnCount < dgv.Columns.Count; columnCount++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[columnCount].Name.ToString());
                dt.Columns.Add(dc);
            }

            //添加行
            //若needRowHeader，先添加除了列头的行
            if (needRowHeader)
            {
                //先从DT的第二列开始添加Dgv的各行数据
                for (int r = 0; r < dgv.RowCount; r++)
                {
                    DataRow dr = dt.NewRow();
                    for (int c = 0; c < dgv.ColumnCount; c++)
                    {
                        dr[c + 1] = Convert.ToString(dgv.Rows[r].Cells[c].Value);
                    }
                    dt.Rows.Add(dr);
                }
                //再在每行的第一列添加行头
                for (int j = 0; j < dgv.RowCount; j++)
                {
                    dt.Rows[j][0] = dgv.Rows[j].HeaderCell.Value.ToString();
                }
            }

            else  //Don't needRowHeader
            {
                for (int r = 0; r < dgv.RowCount; r++)
                {
                    DataRow dr = dt.NewRow();
                    for (int c = 0; c < dgv.ColumnCount; c++)
                    {
                        dr[c] = Convert.ToString(dgv.Rows[r].Cells[c].Value);
                    }
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }
        #endregion

        //MD5加密
        public static string ComputeMD5Hash(string userPassword)
        {
            string strMD5Hash = "";

            MD5 md5 = new MD5CryptoServiceProvider();

            byte[] byteSource = System.Text.Encoding.UTF8.GetBytes(userPassword);

            byte[] byteMD5Hash = md5.ComputeHash(byteSource);

            for (int i = 0; i < byteMD5Hash.Length; i++)
            {
                strMD5Hash += byteMD5Hash[i].ToString("X2");
            }

            return strMD5Hash;
        }

        public static bool ReadUserInfoFromXML(string xmlFileName, string[] elementString)
        {
            if(!File.Exists(xmlFileName))
            {
                return true;//不存在文件，也返回true，因为本地没有，可以随后生成
            }
            try
            {
                //创建一个XmlTextReader对象，读取XML数据
                XmlTextReader xmlReader = new XmlTextReader(xmlFileName);

                while (xmlReader.Read())
                {
                    if (xmlReader.Name.Equals("county") == true)
                    {
                        elementString[0] = xmlReader.ReadString().Trim();
                    }

                    else if (xmlReader.Name.Equals("bank") == true)
                    {
                        elementString[1] = xmlReader.ReadString().Trim();
                    }
                    else if (xmlReader.Name.Equals("passMD5") == true)
                    {
                        elementString[2] = xmlReader.ReadString().Trim();
                    }
                }
                xmlReader.Close();
            }
            catch (Exception ex)
            {
                return false;

            }
            return true;
        }

        //XmlTextWriter默认是覆盖以前的文件,如果此文件名不存在,它将创建此文件
        //进行md5加密后存储
        public static bool WriteUserInfoToXML(string xmlFileName,string[] elementString)
        {
            //string pass_MD5Hash = ComputeMD5Hash(loginPass);
            if(elementString.Length!=3)
            {
                return false;
            }
            try
            {
                XmlTextWriter xmlWriter = new XmlTextWriter(xmlFileName, Encoding.UTF8);
                xmlWriter.Formatting = Formatting.Indented;
                //写入根元素
                xmlWriter.WriteStartElement("userData");
                //加入子元素
                xmlWriter.WriteElementString("county", elementString[0]);
                xmlWriter.WriteElementString("bank", elementString[1]);
                xmlWriter.WriteElementString("passMD5", elementString[2]);

                //关闭根元素，并书写结束标签
                xmlWriter.WriteEndElement();
                //将XML写入文件并且关闭XmlTextWriter
                xmlWriter.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
