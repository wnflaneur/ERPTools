using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Migrations.Model;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelTools.Src
{
    class SqlAccess
    {
        string connectionString;

        private string fileName = Application.StartupPath + "\\配置文件\\ERPData.db";
        public SqlAccess()
        {
            if (!File.Exists(fileName)) 
            {
                SQLiteConnection.CreateFile(fileName);
            }
            connectionString = "data source = " + fileName;
            //SQLiteConnection dbConnection = new SQLiteConnection(connectionString);
            //dbConnection.Open();
        }
        private SQLiteConnection GetConn()
        {
            try
            {
                SQLiteConnection Connection = new SQLiteConnection(connectionString);
                Connection.Open();
                return Connection;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "数据库连接失败");
                throw;
            }
        }

        //根据输入的SQL语句检索数据库数据
        public DataTable SelectDb(string strSql, string strTableName)
        {
            try
            {
                SQLiteConnection connection = this.GetConn();
                SQLiteDataAdapter dta = new SQLiteDataAdapter(strSql, connection);
                DataSet DS = new DataSet();
                dta.FillSchema(DS, SchemaType.Source, strTableName);    //加载表架构 注意
                dta.Fill(DS, strTableName);    //加载表数据
                return DS.Tables[strTableName];//返回填充了数据的DataSet，其中数据表以strTableName给出的字符串命名
            }
            catch (Exception ex)
            {
                Console.WriteLine(strSql);
                MessageBox.Show(ex.Message, "数据库操作失败");
                throw;
            }
        }
        public void CreateTable(DataTable dt) 
        {
            string sql = GetCreateTableSql(dt,dt.TableName);
            SQLiteConnection sqliteConn = this.GetConn();
            try
            {
                if (sqliteConn.State == ConnectionState.Open)
                {
                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.Connection = sqliteConn;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch 
            {
                MessageBox.Show(dt.TableName);
            }
            sqliteConn.Close();
        }

        internal void FastInsertMany(DataTable dt)
        {
            if (Exists(dt.TableName))
            {
                DROP(dt.TableName);
            }
            CreateTable(dt);
            SQLiteConnection conn = this.GetConn();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = conn;
            SQLiteTransaction tx = conn.BeginTransaction();
            cmd.Transaction = tx;
            List<string> sqlList = new List<string>();
            foreach (DataRow row in dt.Rows) 
            {
                string str = "";
                foreach (DataColumn col in dt.Columns) 
                {
                    if (row[col.ColumnName] != DBNull.Value)
                    {
                        str += "'"+row[col.ColumnName] + "',";
                    }
                    else 
                    {
                        str += "null,";
                    }
                }
                str=str.TrimEnd(',');
                string sql = string.Format("INSERT INTO {0} VALUES({1})", dt.TableName, str);
                sqlList.Add(sql);
            }
            try
            {
                foreach (string sql in sqlList)
                {
                    if (sql.Trim().Length > 0)
                    {
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                    }
                }
                tx.Commit();
            } 
            catch (Exception e)
            {
                tx.Rollback();
                throw new Exception(e.Message);
            }           
           
        }

        private bool Exists(string name) 
        {
            SQLiteConnection sqliteConn = this.GetConn();
            if (sqliteConn.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = sqliteConn;
                string sql = string.Format("SELECT count(*) FROM sqlite_master WHERE type='table' AND name = '{0}'",name);
                cmd.CommandText = sql;
                if(0 == Convert.ToInt32(cmd.ExecuteScalar()))
                {
                    sqliteConn.Close();
                    return false;
                    //table - Student does not exist.
                }
            }
            sqliteConn.Close();
            return true;
        }
        private void DROP(string tableName) 
        {
            SQLiteConnection sqliteConn = this.GetConn();
            if (sqliteConn.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = sqliteConn;
                cmd.CommandText = "DROP TABLE " + tableName;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 根据DataTable,生成建表语句
        /// </summary>
        /// <param name="table"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private string GetCreateTableSql(DataTable table, string tableName)
        {
            var colList = new List<string>();

            //遍历列，获取字段属性
            foreach (DataColumn col in table.Columns)
            {
                var ty = TypeHelper.ConvertTypeToSqlDbType(col.DataType) + "";
                var isautoIn = col.AutoIncrement ? $"IDENTITY({col.AutoIncrementSeed},{col.AutoIncrementStep})" : "";
                var isnull = col.AllowDBNull ? "NULL" : "NOT NULL";
                var colStr = $"[{col.ColumnName}] [{ty}] {isautoIn} {isnull} ";
                colList.Add(colStr);
            }
            //拼接建表sql
            var sql = string.Format(@"CREATE TABLE {0}(
                     {1}
                    );
                    ", tableName, string.Join(",", colList));
            return sql;
        }
    }

    public class TypeHelper
    {

        public static SqlDbType ConvertTypeToSqlDbType(Type t)
        {

            //判断convertsionType类型是否为泛型，因为nullable是泛型类, 
            //判断convertsionType是否为nullable泛型类
            if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                //如果convertsionType为nullable类，声明一个NullableConverter类，该类提供从Nullable类到基础基元类型的转换
                NullableConverter nullableConverter = new NullableConverter(t);
                //将convertsionType转换为nullable对的基础基元类型
                t = nullableConverter.UnderlyingType;
            }
            var code = Type.GetTypeCode(t);


            switch (code)
            {
                case TypeCode.Boolean:
                    return SqlDbType.Bit;
                case TypeCode.Byte:
                    return SqlDbType.TinyInt;
                case TypeCode.DateTime:
                    return SqlDbType.NVarChar;
                //case TypeCode.DateTime:
                //    return SqlDbType.DateTime2;
                case TypeCode.Decimal:
                    return SqlDbType.Decimal;
                case TypeCode.Double:
                    return SqlDbType.Float;
                case TypeCode.Int16:
                    return SqlDbType.SmallInt;
                case TypeCode.Int32:
                    return SqlDbType.Int;
                case TypeCode.Int64:
                    return SqlDbType.BigInt;
                case TypeCode.SByte:
                    return SqlDbType.TinyInt;
                case TypeCode.Single:
                    return SqlDbType.Real;
                case TypeCode.String:
                    return SqlDbType.NVarChar;
                case TypeCode.UInt16:
                    return SqlDbType.SmallInt;
                case TypeCode.UInt32:
                    return SqlDbType.Int;
                case TypeCode.UInt64:
                    return SqlDbType.BigInt;
                case TypeCode.Object:
                    return SqlDbType.Variant;
                default:
                    if (t == typeof(byte[]))
                    {
                        return SqlDbType.Binary;
                    }
                    return SqlDbType.Variant;

            }
        }


    }
}
