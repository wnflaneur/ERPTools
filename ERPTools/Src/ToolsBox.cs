using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelTools.Src
{
    public class ToolsBox
    {
        struct RowSimilarity{
            public DataRow row;
            public double similarity;
        }


        public static Dictionary<string,string> ListTODict(Map[] maps) {
            Dictionary<string, string> dict=new Dictionary<string, string>();
            foreach (Map map in maps) {
                dict.Add(map.Name, map.Value);
            }
            return dict;

        }

        /// <summary>
        /// 去除特殊字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveSpecialCharacters(string str) 
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if (Char.IsLetterOrDigit(c))
                { sb.Append(c); }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 去除特殊字符
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="colName"></param>
        /// <returns></returns>
        public static DataTable RemoveSpecialCharacters(DataTable dt, string colName) 
        {
            DataTable dataTable = dt.Copy();
            if (dt.Columns.Contains(colName)) {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row != null) 
                    {
                        row[colName] = RemoveSpecialCharacters(row[colName].ToString());
                    }
                }
            }
            return dataTable;
        }
        /// <summary>
        /// DataGridView美化，单元格不可编辑
        /// </summary>
        /// <param name="dataGridView"></param>
        public static void DataGridViewPrettify(DataGridView dataGridView)
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.BackgroundColor = System.Drawing.Color.White;
            dataGridView.BorderStyle = BorderStyle.Fixed3D;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;//211, 223, 240
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(223)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            //dataGridView.ReadOnly = true;
            //dataGridView.RowHeadersVisible = false;
            dataGridView.RowTemplate.Height = 23;
            //dataGridView.RowTemplate.ReadOnly = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        /// <summary>
        /// DataGridView美化,单元格可编辑
        /// </summary>
        /// <param name="dataGridView"></param>
        public static void DataGridViewPrettify_Set(DataGridView dataGridView)
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridView.AllowUserToAddRows = true;
            dataGridView.AllowUserToDeleteRows = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.BackgroundColor = System.Drawing.Color.White;
            dataGridView.BorderStyle = BorderStyle.Fixed3D;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;//211, 223, 240
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(223)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridView.ReadOnly = false;
            //dataGridView.RowHeadersVisible = false;
            dataGridView.RowTemplate.Height = 23;
            dataGridView.RowTemplate.ReadOnly = false;
            //dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public static DataTable GetDataTableisNull(DataTable dt, Dictionary<string, string> dict)
        {
            DataTable data = dt.Copy();
            data.Clear();
            string sql = "";
            foreach (var key in dict.Keys)
            {
                string value = dict[key];
                value = value.Replace("\n", "");
                value = value.Replace("\r", "");
                value = value.Replace("[", "[[]");
                value = value.Replace("*", "[*]");
                value = value.Replace(".", "[.]");
                value = value.Replace("%", "[%]");
                sql += string.Format(" {0} is Null and ", key);
            }
            sql += " 1=1 ";
            DataRow[] rows = dt.Select(sql);
            if (rows != null && rows.Length > 0)
            {
                foreach (var row in rows)
                {
                    data.Rows.Add(row.ItemArray);
                }
            }

            return data;

        }
        public static DataTable GetDataTableisNotNull(DataTable dt, Dictionary<string, string> dict)
        {
            DataTable data = dt.Copy();
            data.Clear();
            string sql = "";
            foreach (var key in dict.Keys)
            {
                string value = dict[key];
                value = value.Replace("\n", "");
                value = value.Replace("\r", "");
                value = value.Replace("[", "[[]");
                value = value.Replace("*", "[*]");
                value = value.Replace(".", "[.]");
                value = value.Replace("%", "[%]");
                sql += string.Format(" {0} is Not Null and ", key);
            }
            sql += " 1=1 ";
            DataRow[] rows = dt.Select(sql);
            if (rows != null && rows.Length > 0)
            {
                foreach (var row in rows)
                {
                    data.Rows.Add(row.ItemArray);
                }
            }

            return data;

        }
        #region DataTable相似度查询
        /// <summary>
        /// 根据相似度查询DataTable
        /// </summary>
        /// <param name="dt">数据源</param>
        /// <param name="colName">查询列名</param>
        /// <param name="queryStr">查询条件</param>
        /// <param name="Similarity">相似度</param>
        /// <returns></returns>
        public static DataTable SimilarityQuery(DataTable dt,string colName,string queryStr, double Similarity) {
            List<RowSimilarity> rowSimilarities = new List<RowSimilarity>();
            DataTable data = dt.Copy();
            data.Clear();
            foreach (DataRow row in dt.Rows)
            {
                double db = 0;
                if ((db = SimilarityCos(row[colName].ToString(), queryStr)) > Similarity)
                {
                    RowSimilarity rowSimilarity;
                    rowSimilarity.similarity = db;
                    rowSimilarity.row = row;
                    rowSimilarities.Add(rowSimilarity);
                }
            }
            rowSimilarities.Sort(delegate (RowSimilarity row1, RowSimilarity row2) { return -row1.similarity.CompareTo(row2.similarity); });
            foreach (var Item in rowSimilarities)
            {
                data.Rows.Add(Item.row.ItemArray);
            }
            return data;
        }

        /// <summary>
        /// 根据相似度排序
        /// </summary>
        /// <param name="drs"></param>
        /// <param name="colName"></param>
        /// <param name="queryStr"></param>
        /// <param name="Similarity"></param>
        /// <returns></returns>
        public static DataRow[] SimilarityQuery(DataRow[] drs, string colName, string queryStr, double Similarity)
        {
            List<RowSimilarity> rowSimilarities = new List<RowSimilarity>();
            foreach (DataRow row in drs)
            {
                double db = 0;
                if ((db = SimilarityCos(row[colName].ToString(), queryStr)) > Similarity)
                {
                    RowSimilarity rowSimilarity;
                    rowSimilarity.similarity = db;
                    rowSimilarity.row = row;
                    rowSimilarities.Add(rowSimilarity);
                }
            }
            rowSimilarities.Sort(delegate (RowSimilarity row1, RowSimilarity row2) { return -row1.similarity.CompareTo(row2.similarity); });
            List<DataRow> lists = new List<DataRow>();
            foreach (var Item in rowSimilarities)
            {
                lists.Add(Item.row);
            }
            return lists.ToArray();
        }







        /// <summary>
        /// 比较2个字符串的相似度（使用余弦相似度）
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns>0-1之间的数</returns>
        public static double SimilarityCos(string str1, string str2)
        {
            str1 = str1.Trim();
            str2 = str2.Trim();
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
                return 0;

            List<string> lstr1 = SimpParticiple(str1);
            List<string> lstr2 = SimpParticiple(str2);
            //求并集
            var strUnion = lstr1.Union(lstr2);
            //求向量
            List<int> int1 = new List<int>();
            List<int> int2 = new List<int>();
            foreach (var item in strUnion)
            {
                int1.Add(lstr1.Count(o => o == item));
                int2.Add(lstr2.Count(o => o == item));
            }

            double s = 0;
            double den1 = 0;
            double den2 = 0;
            for (int i = 0; i < int1.Count(); i++)
            {
                //求分子
                s += int1[i] * int2[i];
                //求分母（1）
                den1 += Math.Pow(int1[i], 2);
                //求分母（2）
                den2 += Math.Pow(int2[i], 2);
            }

            return s / (Math.Sqrt(den1) * Math.Sqrt(den2));
        }

        /// <summary>
        /// 简单分词（需要更好的效果，需要这里优化，比如把：【今天天气很好】，分成【今天，天气，很好】，同时可以做同义词优化，【今天】=【今日】效果更好）
        /// </summary>
        public static List<string> SimpParticiple(string str)
        {
            List<string> vs = new List<string>();
            foreach (var item in str)
            {
                vs.Add(item.ToString());
            }
            return vs;
        }
        #endregion


        #region DES加密解密
        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="data">加密数据</param>
        /// <param name="key">8位字符的密钥字符串</param>
        /// <param name="iv">8位字符的初始化向量字符串</param>
        /// <returns></returns>
        public static string DESEncrypt(string data, string key, string iv)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(iv);

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="data">解密数据</param>
        /// <param name="key">8位字符的密钥字符串(需要和加密时相同)</param>
        /// <param name="iv">8位字符的初始化向量字符串(需要和加密时相同)</param>
        /// <returns></returns>
        public static string DESDecrypt(string data, string key, string iv)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(iv);

            byte[] byEnc;
            try
            {
                byEnc = Convert.FromBase64String(data);
            }
            catch
            {
                return null;
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            return sr.ReadToEnd();
        }


        #endregion
    }




}
