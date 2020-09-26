using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Data.Common;
using NPOI.SS.UserModel;
using NPOI.SS.Formula.Functions;
using NPOI.XSSF.UserModel;
using System.Data.SQLite;
using System.Security.Cryptography.X509Certificates;

namespace ExcelTools.Src
{
    public delegate void SetStatusEvnet(int num);
    public class SqlProcessor
    {
        private static object fristObject = new object();


        public event SetStatusEvnet SetStatus; 
        string Sqlconn = ConfigurationManager.ConnectionStrings["SqlConnString"].ConnectionString;
        string configPath = Application.StartupPath + "\\配置文件\\Config.xml";
        bool sqlstatus = false;//sql状态
        readonly string[] tablenew = new string[] { "InventoryVIEWALL", "InventoryVIEW","InventoryClassVIEW" };
        readonly string[] tableNames = new string[] { "InventoryVIEWALL", "InventoryVIEW","InventoryClassVIEW", "METR_ERP_PU_AppVouchVIEW", "METR_ERP_PO_PodetailsVIEW", "METR_ERP_Rdrecords01VIEW", "METR_ERP_Rdrecords11VIEW", "METR_ERP_MainVIEW", "METR_ERP_ECNVIEW", "METR_ERP_BOMVIEW", "METR_ERP_BOM_ECN_PUVIEW" , "METR_ERP_WarehouseVIEW", "METR_ERP_MOM" };
        string[] TableNames { get => tableNames; }
        public string sqlUpdateTime {
            get
            {
                if (ConfigurationManager.AppSettings["SqlUpdateTime"] != null)
                {
                    return ConfigurationManager.AppSettings["SqlUpdateTime"];
                }
                else
                {
                    return null;
                }
            }
        }
        public DataSet dataSet = new DataSet();

        private SqlAccess sqlAccess = new SqlAccess();

        DataTable dt;
        DataTable dtAll;
        DataTable dt_RemoveSpecial;
        public DataTable InventoryClassTable { get; set; }
        public int tablestatus=0;
        public DataTable dataTable { get { if (dt != null) return dt; else return null; } set { dt = value; } }


        public SqlProcessor() {
        }

        public void Init() 
        {
            Sqlconn = ToolsBox.DESDecrypt(Sqlconn, "sadasdgf", "aswrfswe");
            SqlUpdate();

            if (!sqlstatus)
            {
                tablestatus = 3;
                SQLiteSelect();
                SetStatus(tablestatus);
            }
            dtAll = getInventory(dataSet.Tables["InventoryVIEWALL"]);
            dt = getInventory(dataSet.Tables["InventoryVIEW"]);
            InventoryClassTable = dataSet.Tables["InventoryClassVIEW"].Copy();
            dt_RemoveSpecial = ToolsBox.RemoveSpecialCharacters(dt, "cInvStd");
        }

        public DataTable SelectDb(string sql, string tableName) 
        {
            DataSet ds = new DataSet();

            SqlConnection conn = new SqlConnection(Sqlconn);
            try
            {
                if (DataBaseConnectHelper.QuickOpen(conn, 500))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                    SaveSQLUpdateTime();
                    sda.Fill(ds,tableName);
                    conn.Close();
                    return ds.Tables[tableName].Copy();
                }
                else
                {
                    sqlstatus = false;
                    if (conn != null)
                    {
                        conn.Close();
                    }
                    return null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                if (conn != null)
                {
                    conn.Close();
                }
                return null;
            }
        }


        #region 本地数据读取
        private void SQLiteSelect() 
        {
            if (TableNames.Length > 0) 
            {
                foreach (var tableName in tablenew) 
                {
                    GetSQLiteTable(tableName);
                }
            }

        }
        private void GetSQLiteTable(string tableName)
        {
            if (!dataSet.Tables.Contains(tableName))
            {
                string sql = string.Format("select * from {0}", tableName);
                DataTable sqldt = sqlAccess.SelectDb(sql, tableName);
                dataSet.Tables.Add(sqldt.Copy());
            }
        }
        #endregion


        #region 物料库查重

        /// <summary>
        /// 按规格查重，不区分大小写
        /// </summary>
        /// <returns></returns>
        public DataTable SQLSelfTestTable() 
        {
            string sql = @"select * from SQLSELFTESTVIEW";
            DataTable dt=SelectDb(sql, "SQLSELFTESTVIEW");
            return dt;
        }
        /// <summary>
        /// 规格名称
        /// </summary>
        /// <returns></returns>
        public DataTable SqlSelfTestNameAndSTD() 
        {
            string sql = @"select * from SqlSelfTestNameAndSTDView";
            DataTable dt = SelectDb(sql, "SqlSelfTestNameAndSTDView");
            return dt;

        }

        /// <summary>
        /// 规格去除特殊字符及汉字
        /// </summary>
        /// <returns></returns>
        public DataTable SQLSelfTestTable_A_Z0_9()
        {
            string sql = @"select * from SQLSelfTestTable_A_Z0_9VIEW;
                ";
            DataTable dt = SelectDb(sql, "SQLSelfTestTable_A_Z0_9VIEW");
            return dt;
        }
        public DataTable SQLSelfTestTable_A_Z0_9NameAndStd() 
        {
            string sql = @"select * from SQLSelfTestTable_A_Z0_9NameAndStdVIEW;
                ";
            DataTable dt = SelectDb(sql, "SQLSelfTestTable_A_Z0_9NameAndStdVIEW");
            return dt;
        }
        /// <summary>
        /// 包含关系查重
        /// </summary>
        /// <returns></returns>
        public DataTable SQLSelfTestTable_Contains()
        {
            string sql = @"select * from SQLSelfTestTable_ContainsVIEW order by 长度差";
            DataTable dt = SelectDb(sql, "SQLSelfTestTable_ContainsVIEW");
            return dt;
        }
        public DataTable SQLSelfTestTable__()
        {
            string sql = @"select * from SQLSelfTest__VIEW";
            DataTable dt = SelectDb(sql, "SQLSelfTest__VIEW");
            return dt;
        }


        #endregion


        public DataTable AccurateQuery_Like_List(string[] Names, string colName,bool df=false) 
        {
            DataTable data;
            if (df)
            {
                string sql = "select * from InventoryVIEW where ";
                foreach (string value in Names)
                {
                    string Name = value;
                    sql += string.Format("{0} like '{1}' ", colName, @Name) + " OR ";
                }
                sql = sql.Trim();
                sql = sql.TrimEnd('R');
                sql = sql.TrimEnd('O');
                sql = sql.Trim();
                data = SelectDb(sql, "InventoryVIEW");
                if (data == null)
                {
                    data = sqlAccess.SelectDb(sql, "InventoryVIEW");
                }
                data = getInventory(data);
            }
            else 
            {

                data = dt.Copy();
                data.Clear();
                string sql="";
                foreach (string value in Names)
                {
                    string Name = value;
                    Name = Name.Replace("\r", "");
                    Name = Name.Replace("\n", "");
                    Name = Name.Replace("[", "[[]");
                    Name = Name.Replace("*", "[*]");
                    Name = Name.Replace(".", "[.]");
                    Name = Name.Replace("%", "[%]");
                    sql += string.Format("{0} like '{1}' ", colName, @Name) + " OR ";
                }
                sql = sql.Trim();
                sql = sql.TrimEnd('R');
                sql = sql.TrimEnd('O');
                sql = sql.Trim();
                DataRow[] rows=dt.Select(sql);
                foreach (DataRow row in rows) 
                {
                    data.Rows.Add(row.ItemArray);
                }

            }
            return data;
        }
        public DataTable AccurateQuery_Like(string Name, string colName,bool df=false)
        {

            DataTable data;
            if (df)
            {
                string sql = string.Format("select * from InventoryVIEW where {0} like '{1}' ", colName, Name);
                data = SelectDb(sql, "InventoryVIEW");
                if (data == null)
                {
                    data = sqlAccess.SelectDb(sql, "InventoryVIEW");
                }
                data = getInventory(data);
            }
            else 
            {
                Name = Name.Replace("\r", "");
                Name = Name.Replace("\n", "");
                Name = Name.Replace("[", "[[]");
                Name = Name.Replace("*", "[*]");
                Name = Name.Replace(".", "[.]");
                Name = Name.Replace("%", "[%]");
                data = dt.Copy();
                data.Clear();
                string sql = "";
                sql = string.Format(" {0} like '{1}' ",colName,Name);
                DataRow[] rows = dt.Select(sql);
                foreach (DataRow row in rows)
                {
                    data.Rows.Add(row.ItemArray);
                }
            }
            return data;
        }
            /// <summary>
            ///  精确查询
            /// </summary>
        public DataTable AccurateQuery(string Name,string colName, bool df=false)
        {
            DataTable data;
            if (df)
            {
                string sql = string.Format("select * from InventoryVIEW where {0} like '%{1}%' ", colName, Name);
                data = SelectDb(sql, "InventoryVIEW");
                if (data == null)
                {
                    data = sqlAccess.SelectDb(sql, "InventoryVIEW");
                }
                Console.WriteLine(data.Rows.Count + " " + colName + " " + Name);
                data = getInventory(data);
            }
            else 
            {
                Name = Name.Replace("\r", "");
                Name = Name.Replace("\n", "");
                Name = Name.Replace("[", "[[]");
                Name = Name.Replace("*", "[*]");
                Name = Name.Replace(".", "[.]");
                Name = Name.Replace("%", "[%]");
                data = dt.Copy();
                data.Clear();
                string sql = "";
                sql = string.Format(" {0} like '%{1}%' ", colName, Name);
                DataRow[] rows = dt.Select(sql);
                foreach (DataRow row in rows)
                {
                    data.Rows.Add(row.ItemArray);
                }
            }
            return data;
        }

        public DataTable AccurateQuery_A_Z_0_9(string Name, string colName,bool df=false)
        {
            string str = ToolsBox.RemoveSpecialCharacters(Name);
            DataTable data;
            if (df)
            {
                string sql = string.Format("select * from InventoryVIEW where dbo.fun_RemoveSpecialString({0}) like '%'+dbo.fun_RemoveSpecialString('{1}')+'%' ", colName, Name);
                data = SelectDb(sql, "InventoryVIEW");
                if (data == null)
                {
                    //sqlite中去除特殊字符

                    return null;
                }
                data = getInventory(data);
            }
            else 
            {
                Name = Name.Replace("\r", "");
                Name = Name.Replace("\n", "");
                Name = Name.Replace("[", "[[]");
                Name = Name.Replace("*", "[*]");
                Name = Name.Replace(".", "[.]");
                Name = Name.Replace("%", "[%]");
                data = dt.Copy();
                data.Clear();
                string sql = "";
                sql = string.Format(" {0} like '{1}' ", colName, Name);
                DataRow[] rows = dt_RemoveSpecial.Select(sql);
                foreach (DataRow row in rows)
                {
                    int index = row.Table.Rows.IndexOf(row);
                    data.Rows.Add(dt.Rows[index].ItemArray);
                }
            }
            return data;
        }

        public DataTable AccurateQuery_AND(string Name1, string colName1,string Name2,string colName2,bool df=false) {
            DataTable data;
            if (df)
            {
                string sql = string.Format("select * from InventoryVIEW where {0} like '%{1}%' and {2} like '%{3}%' ", colName1, @Name1, colName2, @Name2);
                data = SelectDb(sql, "InventoryVIEW");
                if (data == null)
                {
                    data = sqlAccess.SelectDb(sql, "InventoryVIEW");
                }
                data = getInventory(data);
            }
            else 
            {
                Name1 = Name1.Replace("\r", "");
                Name1 = Name1.Replace("\n", "");
                Name1 = Name1.Replace("[", "[[]");
                Name1 = Name1.Replace("*", "[*]");
                Name1 = Name1.Replace(".", "[.]");
                Name1 = Name1.Replace("%", "[%]");
                Name2 = Name2.Replace("\r", "");
                Name2 = Name2.Replace("\n", "");
                Name2 = Name2.Replace("[", "[[]");
                Name2 = Name2.Replace("*", "[*]");
                Name2 = Name2.Replace(".", "[.]");
                Name2 = Name2.Replace("%", "[%]");
                data = dt.Copy();
                data.Clear();
                string sql = "";
                sql = string.Format(" {0} like '%{1}%' and {2} like '%{3}%' ", colName1, Name1, colName2, Name2);
                DataRow[] rows = dt.Select(sql);
                foreach (DataRow row in rows)
                {
                    data.Rows.Add(row.ItemArray);
                }
            }
            return data;
        }
        public DataTable AccurateQuery_AND_Like(string Name1, string colName1, string Name2, string colName2,bool df=false)
        {
            DataTable data;
            if (df)
            {
                string sql = string.Format("select * from InventoryVIEW where {0} like '{1}' and {2} like '{3}' ", colName1, @Name1, colName2, @Name2);
                data = SelectDb(sql, "InventoryVIEW");
                if (data == null)
                {
                    data = sqlAccess.SelectDb(sql, "InventoryVIEW");
                }
                data = getInventory(data);
            }
            else 
            {
                Name1 = Name1.Replace("\r", "");
                Name1 = Name1.Replace("\n", "");
                Name1 = Name1.Replace("[", "[[]");
                Name1 = Name1.Replace("*", "[*]");
                Name1 = Name1.Replace(".", "[.]");
                Name1 = Name1.Replace("%", "[%]");
                Name2 = Name2.Replace("\r", "");
                Name2 = Name2.Replace("\n", "");
                Name2 = Name2.Replace("[", "[[]");
                Name2 = Name2.Replace("*", "[*]");
                Name2 = Name2.Replace(".", "[.]");
                Name2 = Name2.Replace("%", "[%]");
                data = dt.Copy();
                data.Clear();
                string sql = "";
                sql = string.Format(" {0} like '{1}' and {2} like '{3}' ", colName1, Name1, colName2, Name2);
                DataRow[] rows = dt.Select(sql);
                foreach (DataRow row in rows)
                {
                    data.Rows.Add(row.ItemArray);
                }
            }
            return data;
        }
        public DataTable AccurateQuery_OR(string Name1, string colName1, string Name2, string colName2,bool df=false)
        {
            DataTable data;
            if (df)
            {
                string sql = string.Format("select * from InventoryVIEW where {0} like '%{1}%' OR {2} like '%{3}%' ", colName1, @Name1, colName2, @Name2);
                data = SelectDb(sql, "InventoryVIEW");
                if (data == null)
                {
                    data = sqlAccess.SelectDb(sql, "InventoryVIEW");
                }
                data = getInventory(data);
            }
            else {
                Name1 = Name1.Replace("\r", "");
                Name1 = Name1.Replace("\n", "");
                Name1 = Name1.Replace("[", "[[]");
                Name1 = Name1.Replace("*", "[*]");
                Name1 = Name1.Replace(".", "[.]");
                Name1 = Name1.Replace("%", "[%]");
                Name2 = Name2.Replace("\r", "");
                Name2 = Name2.Replace("\n", "");
                Name2 = Name2.Replace("[", "[[]");
                Name2 = Name2.Replace("*", "[*]");
                Name2 = Name2.Replace(".", "[.]");
                Name2 = Name2.Replace("%", "[%]");
                data = dt.Copy();
                data.Clear();
                string sql = "";
                sql = string.Format(" {0} like '%{1}%' OR {2} like '%{3}%' ", colName1, Name1, colName2, Name2);
                DataRow[] rows = dt.Select(sql);
                foreach (DataRow row in rows)
                {
                    data.Rows.Add(row.ItemArray);
                }
            }
            return data;
        }

        /// <summary>
        /// 包含关系
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="colName"></param>
        /// <returns></returns>
        public DataTable ContainsQuery(string Name, string colName,bool df=false) {
            DataTable data;
            if (df)
            {
                string sql = string.Format("select * from InventoryVIEW where {0} like '%{1}%' ", colName, Name);
                data = SelectDb(sql, "InventoryVIEW");
                if (data == null)
                {
                    data = sqlAccess.SelectDb(sql, "InventoryVIEW");
                }
                data = getInventory(data);
            }
            else 
            {
                Name = Name.Replace("\r", "");
                Name = Name.Replace("\n", "");
                Name = Name.Replace("[", "[[]");
                Name = Name.Replace("*", "[*]");
                Name = Name.Replace(".", "[.]");
                Name = Name.Replace("%", "[%]");
                data = dt.Copy();
                data.Clear();
                string sql = "";
                sql = string.Format(" {0} like '%{1}%' ", colName, Name);
                DataRow[] rows = dt.Select(sql);
                foreach (DataRow row in rows)
                {
                    data.Rows.Add(row.ItemArray);
                }
            }
            return data;
        }


        public DataTable getInventory(DataTable table) 
        {
            DataTable data = new DataTable();
            Param param = new Param();
            DataTable dataTable = table;
            DataKeep.Serialize(configPath, false, ref param);
            foreach (var map in param.Maps)
            {
                data.Columns.Add(map.Name);
            }
            foreach (DataRow row in dataTable.Rows)
            {
                DataRow dr = data.NewRow();
                foreach (DataColumn col in data.Columns)
                {
                    dr[col.ColumnName] = row[col.ColumnName];
                }
                data.Rows.Add(dr);
            }
            return data;
        }



        #region 数据索引获取
        public string[] GetName(string name) 
        {
            HashSet<string> setName = new HashSet<string>();
            DataTable data = AccurateQuery(name, "cInvName");
            if(data.Rows.Count>0) 
            {
                foreach (DataRow dr in data.Rows) 
                {
                    try
                    {
                        if (dr["cInvName"] != DBNull.Value)
                        {
                            setName.Add(dr["cInvName"].ToString());
                        }
                    }
                    catch(Exception ex) { Console.WriteLine(ex); }
                }
            }
            if (setName.Count() > 0)
            {
                return setName.ToArray();
            }
            else {
                return null;
            }
        }
        public void GetNameAndModel(string name,string model, out string[] names, out string[] models) 
        {
            DataTable data = AccurateQuery_AND(name, "cInvName", model, "cInvStd");
            HashSet<string> setName = new HashSet<string>();
            HashSet<string> setModel = new HashSet<string>();
            if (data.Rows.Count>0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    try
                    {
                        if (dr["cInvName"] != DBNull.Value)
                        {
                            setName.Add(dr["cInvName"].ToString());
                        }
                        if (dr["cInvStd"] != DBNull.Value)
                        {
                            setModel.Add(dr["cInvStd"].ToString());
                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex); }
                }
            }
            if (setName.Count() > 0)
            {
                names = setName.ToArray();
            }
            else
            {
                names = null;  
            }
            if (setModel.Count() > 0)
            {
                models=setModel.ToArray();
            }
            else
            {
                models=null;
            }
        }
        public string[] GetModel(string model) 
        {
            DataTable data = AccurateQuery(model, "cInvStd");
            HashSet<string> setModel = new HashSet<string>();
            if (data.Rows.Count>0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    try
                    {
                        if (dr["cInvStd"] != DBNull.Value)
                        {
                            setModel.Add(dr["cInvStd"].ToString());
                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex); }
                }
            }
            if (setModel.Count() > 0)
            {
                return setModel.ToArray();
            }
            else
            {
                return null;
            }
        }
        #endregion


        /// <summary>
        /// 机加件编码
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, int> GetNumber_M() 
        {
            var dict = new Dictionary<string, int>();
            foreach (DataRow row in dtAll.Rows)
            {
                if (row["cInvCCode"].Equals("M"))
                {
                    string strnum = row["cInvCode"].ToString().Split('.').Last();
                    string strname = row["cInvCode"].ToString().Split('.').First();
                    try
                    {
                        int num = int.Parse(strnum);
                        if (dict.ContainsKey(strname))
                        {
                            int temp = dict[strname];
                            if (num > temp)
                            {
                                dict[strname] = num;
                            }
                        }
                        else 
                        {
                            dict.Add(strname, int.Parse(strnum));
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            return dict;
        }

        /// <summary>
        /// 标准件编码
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, int> GetNumber() {
            var dict = new Dictionary<string, int>();
            foreach (DataRow row in InventoryClassTable.Rows) {
                if (Convert.ToBoolean(row["bInvCEnd"].ToString())) {
                    if (!dict.ContainsKey(row["cInvCCode"].ToString())) {
                        dict.Add(row["cInvCCode"].ToString(), 0);
                    }
                }
            }
            foreach (DataRow row in dtAll.Rows) {
                if (!row["cInvCCode"].Equals("M"))
                {
                    string strnum = row["cInvCode"].ToString().Split('.').Last();
                    try
                    {
                        int num = int.Parse(strnum);
                        string str = row["cInvCCode"].ToString();
                        if (dict.ContainsKey(str))
                        {
                            int temp = dict[str];
                            if (num > temp)
                            {
                                dict[str] = num;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            return dict;
        }


        /// <summary>
        /// 数据库更新时间编写
        /// </summary>
        private void SaveSQLUpdateTime() {
            Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings["SqlUpdateTime"] == null)
            {
                config.AppSettings.Settings.Add("SqlUpdateTime", DateTime.Now.ToString());
            }
            else {
                config.AppSettings.Settings["SqlUpdateTime"].Value=DateTime.Now.ToString();
            }
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        #region 数据库更新

        public void GetTalbe()
        {
            dtAll = getInventory(dataSet.Tables["InventoryVIEWALL"]);
            dt = getInventory(dataSet.Tables["InventoryVIEW"]);
            InventoryClassTable = dataSet.Tables["InventoryClassVIEW"].Copy();
            dt_RemoveSpecial = ToolsBox.RemoveSpecialCharacters(dt, "cInvStd");
        }

        public bool SqlUpdate()
        {
            dataSet = new DataSet();
            DataSet ds = new DataSet();
           
            SqlConnection conn = new SqlConnection(Sqlconn);
            try
            {
                if (DataBaseConnectHelper.QuickOpen(conn, 500))
                {
                    sqlstatus = true;
                    foreach (string tableName in tablenew) 
                    {
                        SqlUpdateTable(tableName);
                    }
                    Thread thread = new Thread(()=> 
                    {
                        foreach (string tableName in TableNames)
                        {
                            if (!dataSet.Tables.Contains(tableName))
                            {
                                SqlUpdateTable(tableName);
                            }
                        }
                        foreach (DataTable dataT in dataSet.Tables)
                        {
                            sqlAccess.FastInsertMany(dataT);
                        }

                    });
                    thread.Start();
                    tablestatus = 1;
                    SetStatus(tablestatus);
                }
                else
                {
                    sqlstatus = false;
                    if (conn != null)
                    {
                        conn.Close();
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                if (conn != null)
                {
                    conn.Close();
                }
                return false;
            }
            if (conn != null)
            {
                conn.Close();
            }
            return true;
        }
        

        public bool SqlUpdateTable(string tableName)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(Sqlconn);
            try
            {
                string sql = string.Format("select * from {0} ",tableName);
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                SaveSQLUpdateTime();
                sda.Fill(ds);
                DataTable dt = ds.Tables[0].Copy();
                dt.TableName = tableName;
                dataSet.Tables.Add(dt);
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                if (conn != null)
                {
                    conn.Close();
                }
                return false;
            }
            if (conn != null)
            {
                conn.Close();
            }
            return true;

        }

        #endregion

        #region  判断地址数据库是否连接成功
        /// <summary>
        /// 通过监听来查看目标地址是否存在
        /// </summary>
        public static class DataBaseConnectHelper
        {
            public static bool QuickOpen(DbConnection conn, int timeout)
            {
                // We'll use a Stopwatch here for simplicity. A comparison to a stored DateTime.Now value could also be used
                Stopwatch sw = new Stopwatch();
                bool connectSuccess = false;

                // Try to open the connection, if anything goes wrong, make sure we set connectSuccess = false
                Thread t = new Thread(delegate ()
                {
                    try
                    {
                        sw.Start();
                        conn.Open();
                        connectSuccess = true;
                    }
                    catch
                    {
                    }
                });

                // Make sure it's marked as a background thread so it'll get cleaned up automatically
                t.IsBackground = true;
                t.Start();

                // Keep trying to join the thread until we either succeed or the timeout value has been exceeded
                while (timeout > sw.ElapsedMilliseconds)
                    if (t.Join(1))
                        break;
                // If we didn't connect successfully, throw an exception
                /* if (!connectSuccess)
                     throw new Exception("Timed out while trying to connect.");*/
                return connectSuccess;
            }
        }
        #endregion

    }
}
