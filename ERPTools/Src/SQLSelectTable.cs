using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTools.Src
{

    public class  SQLSelectTable
    {

        private SqlAccess sqlAccess = new SqlAccess();

        private SqlProcessor sqlProcessor;
        public SQLSelectTable(SqlProcessor sqlProcessor) 
        {
            this.sqlProcessor = sqlProcessor;
        }

        public DataTable GetMainTable() 
        {
            DataTable dt;
            string sql ="select * from METR_ERP_MainVIEW where 1!=1";

            dt = sqlProcessor.SelectDb(sql, "METR_ERP_MainVIEW");
            if (dt == null)
            {
                dt = sqlAccess.SelectDb(sql, "METR_ERP_MainVIEW");
            }
            return dt;
        }
        /// <summary>
        /// 主表查询
        /// </summary>
        /// <param name="cInvCode"></param>
        /// <param name="cItemCode"></param>
        /// <param name="resermand"></param>
        /// <returns></returns>
        public DataTable GetMainTable(string cInvCode = null, string cItemCode = null, string resermand = null,string starttime=null,string endtime=null) 
        {
            DataTable dt;
            string str = "";
            if (cItemCode != null)
            {
                str += string.Format("  项目编码= '{0}' and ", cItemCode);
            }
            if (cInvCode != null)
            {
                str += string.Format(" 物料编码 = '{0}' and ", cInvCode);
            }
            if (resermand != null)
            {
                str += string.Format(" 请购人 = '{0}' and ", resermand);
            }
            if (starttime != null) 
            {
                str += string.Format(" 制单日期 >= '{0}' and  ", starttime);
            }
            if (endtime != null)
            {
                str += string.Format(" 制单日期 <= '{0}' and  ", endtime);
            }

            str += " 1=1 ";

            string sql = string.Format("select * from METR_ERP_MainVIEW where {0}", str);
            
            dt = sqlProcessor.SelectDb(sql, "METR_ERP_MainVIEW");
            if (dt == null) 
            {
                dt=sqlAccess.SelectDb(sql, "METR_ERP_MainVIEW");
            }
            return dt;
        }

        public DataTable GetMainTable(Dictionary<string,string> dict) 
        {
            DataTable dt;
            string str = "";
            foreach (var key in dict.Keys) 
            {
                str += string.Format(" {0} = '{1}' and ", key,dict[key]);
            }
            str += " 1=1 ";
            string sql = string.Format("select * from METR_ERP_MainVIEW where {0}", str);
            dt = sqlProcessor.SelectDb(sql, "METR_ERP_MainVIEW");
            if (dt == null)
            {
                dt = sqlAccess.SelectDb(sql, "METR_ERP_MainVIEW");
            }
            return dt;
        }
        public DataTable GetWarehouse() 
        {
            DataTable dt;
            string sql = "select * from METR_ERP_WarehouseVIEW";
            dt = sqlProcessor.SelectDb(sql, "METR_ERP_WarehouseVIEW");
            if (dt == null)
            {
                dt = sqlAccess.SelectDb(sql, "METR_ERP_WarehouseVIEW");
            }
            return dt;
        }
        public DataTable GetMom()
        {
            DataTable dt;
            string sql = "select * from METR_ERP_MOM";
            dt = sqlProcessor.SelectDb(sql, "METR_ERP_MOM");
            if (dt == null)
            {
                dt = sqlAccess.SelectDb(sql, "METR_ERP_MOM");
            }
            return dt;
        }
        public DataTable GetMom_moallocate(string MoDId) 
        {
            DataTable dt;
            string sql = string.Format("select * from METR_ERP_MOM_Moallocate where 项目编码='{0}' ", MoDId);
            dt = sqlProcessor.SelectDb(sql, "METR_ERP_MOM_Moallocate");
            if (dt == null)
            {
                dt = sqlAccess.SelectDb(sql, "METR_ERP_MOM_Moallocate");
            }
            return dt;
        }


        public DataTable GetWarehouse(Dictionary<string, string> dict)
        {
            DataTable dt;
            string str = "";
            foreach (var key in dict.Keys)
            {
                str += string.Format(" {0} = '{1}' and ", key, dict[key]);
            }
            str += " 1=1 ";
            string sql = string.Format("select * from METR_ERP_WarehouseVIEW where {0}", str);
            dt = sqlProcessor.SelectDb(sql, "METR_ERP_WarehouseVIEW");
            if (dt == null)
            {
                dt = sqlAccess.SelectDb(sql, "METR_ERP_WarehouseVIEW");
            }
            return dt;
        }

        public DataTable GetMainTable(Dictionary<string, string> dict, string cInvCode = null, string cItemCode = null, string resermand = null, string starttime = null, string endtime = null)
        {
            DataTable dt;
            string str = "";
            if (cItemCode != null)
            {
                str += string.Format("  项目编码= '{0}' and ", cItemCode);
            }
            if (cInvCode != null)
            {
                str += string.Format(" 物料编码 = '{0}' and ", cInvCode);
            }
            if (resermand != null)
            {
                str += string.Format(" 请购人 = '{0}' and ", resermand);
            }
            if (starttime != null)
            {
                str += string.Format(" 制单日期 >= '{0}' and  ", starttime);
            }
            if (endtime != null)
            {
                str += string.Format(" 制单日期 <= '{0}' and  ", endtime);
            }
            foreach (var key in dict.Keys)
            {
                str += string.Format(" {0} = '{1}' and ", key, dict[key]);
            }
            str += " 1=1 ";
            string sql = string.Format("select * from METR_ERP_MainVIEW where {0}", str);
            dt = sqlProcessor.SelectDb(sql, "METR_ERP_MainVIEW");
            if (dt == null)
            {
                dt = sqlAccess.SelectDb(sql, "METR_ERP_MainVIEW");
            }
            return dt;
        }
        /// <summary>
        /// 请购单
        /// </summary>
        /// <returns></returns>
        public DataTable GetPU_AppVouchs(string cCode=null,string cInvCode=null, string cItemCode=null,string resermand=null,string start=null,string end=null) 
        {
            
            string str = "";
            if (cCode != null) 
            {
                str += string.Format(" 请购单号 = '{0}' and ", cCode);
            }
            if (cItemCode != null) 
            {
                str += string.Format(" 项目编码 = '{0}' and ", cItemCode);
            }
            if (cInvCode != null) 
            {
                str += string.Format(" 物料编码 = '{0}' and ",cInvCode);
            }
            if (resermand != null) 
            {
                str += string.Format(" 请购人 = '{0}' and ", resermand);
            }

            if (start != null) 
            {
                str += string.Format(" 制单日期 >= '{0}' and ", start);
            }
            if (end != null) 
            {
                str += string.Format(" 制单日期 <= '{0}' and ",end);
            }

            str += " 1=1 ";

            DataTable dt;
            string sql =string.Format("select * from METR_ERP_PU_AppVouchVIEW where {0} ", str);
            dt =sqlProcessor.SelectDb(sql, "METR_ERP_PU_AppVouchVIEW");
            if (dt == null)
            {
                dt = sqlAccess.SelectDb(sql, "METR_ERP_PU_AppVouchVIEW");
            }
            return dt;
        }


        /// <summary>
        /// 采购订单 
        /// </summary>
        /// <param name="cPOID"></param>
        /// <param name="cappcode"></param>
        /// <param name="cInvCode"></param>
        /// <param name="cItemCode"></param>
        /// <param name="resermand"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataTable GetPO_Podetails(string cPOID = null, string cappcode=null, string cInvCode=null,string cItemCode = null, string resermand = null, string start = null, string end = null) 
        {
            string str = "";
            if (cPOID != null) 
            {
                str += string.Format(" 采购订单号 = '{0}' and ",cPOID);
            }
            if (cappcode != null) 
            {
                str += string.Format(" 请购单号 = '{0}' and ",cappcode);
            }
            if (cItemCode != null)
            {
                str += string.Format(" 项目编码 = '{0}' and ", cItemCode);
            }
            if (cInvCode != null)
            {
                str += string.Format(" 物料编码 = '{0}' and ", cInvCode);
            }
            if (resermand != null)
            {
                str += string.Format(" 请购人 = '{0}' and ", resermand);
            }

            if (start != null)
            {
                str += string.Format(" 制单时间 >= '{0}' and ", start);
            }
            if (end != null)
            {
                str += string.Format(" 制单时间 <= '{0}' and ", end);
            }

            str += " 1=1 ";

            DataTable dt;
            string sql = string.Format("select * from METR_ERP_PO_PodetailsVIEW where {0} ", str);

            dt = sqlProcessor.SelectDb(sql, "METR_ERP_PO_PodetailsVIEW");
            if (dt == null)
            {
                dt = sqlAccess.SelectDb(sql, "METR_ERP_PO_PodetailsVIEW");
            }
            return dt;
        }
        
        /// <summary>
        /// 材料入库单
        /// </summary>
        /// <param name="cItemCode"></param>
        /// <param name="cInvCode"></param>
        /// <param name="resermand"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataTable GetRdrecords01(string id=null,string cItemCode = null,string cInvCode=null, string resermand = null, string start = null, string end = null)
        {
            string str = "";
            if (id != null)
            {
                str += string.Format(" 采购入库单号 = '{0}' and ", id);
            }
            if (cItemCode != null)
            {
                str += string.Format(" 项目编码 = '{0}' and ", cItemCode);
            }
            if (resermand != null)
            {
                str += string.Format(" 请购人 = '{0}' and ", resermand);
            }
            if (cInvCode != null)
            {
                str += string.Format(" 物料编码 = '{0}' and ", cInvCode);
            }

            if (start != null)
            {
                str += string.Format(" 制单时间 >= '{0}' and ", start);
            }
            if (end != null)
            {
                str += string.Format(" 制单时间 <= '{0}' and ", end);
            }

            str += " 1=1 ";

            DataTable dt;
            string sql = string.Format("select * from METR_ERP_Rdrecords01VIEW where {0}", str);
            dt = sqlProcessor.SelectDb(sql, "METR_ERP_Rdrecords01VIEW");
            if (dt == null)
            {
                dt = sqlAccess.SelectDb(sql, "METR_ERP_Rdrecords01VIEW");
            }
            return dt;
            }



        /// <summary>
        /// 材料出库单
        /// </summary>
        /// <param name="cItemCode"></param>
        /// <param name="resermand"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataTable GetRdrecords11(string id=null,string cItemCode = null,string cInvCode=null, string resermand = null, string start = null, string end = null)
        {
            string str = "";
            if (id != null)
            {
                str += string.Format(" 材料出库单号 = '{0}' and ", id);
            }
            if (cItemCode != null)
            {
                str += string.Format(" 项目编码 = '{0}' and  ", cItemCode);
            }
            if (cInvCode != null) 
            {
                str += string.Format(" 物料编码 = '{0}' and ",cInvCode);
            }
            if (resermand != null)
            {
                str += string.Format(" 请购人 = '{0}' and ", resermand);
            }

            if (start != null)
            {
                str += string.Format(" 出库时间 >= '{0}' and ", start);
            }
            if (end != null)
            {
                str += string.Format(" 出库时间 <= '{0}' and ", end);
            }

            str += " 1=1 ";

            DataTable dt;
            string sql = string.Format(" select * from METR_ERP_Rdrecords11VIEW where {0}", str);
            dt = sqlProcessor.SelectDb(sql, "METR_ERP_Rdrecords11VIEW");
            if (dt == null)
            {
                dt = sqlAccess.SelectDb(sql, "METR_ERP_Rdrecords11VIEW");
            }
            return dt;
        }




        /// <summary>
        /// ECN变更单
        /// </summary>
        /// <param name="cItemCode"></param>
        /// <param name="resermand"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataTable GetECN(string ecnid=null,string cItemCode = null,string cInvCode=null, string resermand = null, string start = null, string end = null)
        {
            string str = "";
            if (start != null)
            {
                str += string.Format(" CreateTime >= '{0}' and ", start);
            }
            if (end != null)
            {
                str += string.Format(" CreateTime <= '{0}' and ", end);
            }
            str += " 1=1 ";

            DataTable dt;
            string sql=string.Format("select * from METR_ERP_ECNVIEW where {0} ", str);
            dt = sqlProcessor.SelectDb(sql, "METR_ERP_ECNVIEW");
            if (dt == null)
            {
                dt = sqlAccess.SelectDb(sql, "METR_ERP_ECNVIEW");
            }
            return dt;
        }



        /// <summary>
        /// BOM单
        /// </summary>
        /// <param name="cItemCode"></param>
        /// <param name="cInvCode"></param>
        /// <param name="resermand"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataTable GetBOM(string bomID=null,string cItemCode = null, string cInvCode=null,string resermand = null, string start = null, string end = null)
        {
            string str = "";
            if (bomID != null)
            {
                str += string.Format(" BomID  = '{0}' and ", bomID);
            }
            if (cItemCode != null)
            {
                str += string.Format(" BOM包编码  like '%{0}%' and ", cItemCode);
            }
            if (cInvCode != null)
            {
                str += string.Format(" 物料编码 = '{0}' and ", cInvCode);
            }
            if (resermand != null)
            {
                str += string.Format(" 请购人 = '{0}' and ", resermand);
            }

            if (start != null)
            {
                str += string.Format(" 制单时间 >= '{0}' and ", start);
            }
            if (end != null)
            {
                str += string.Format(" 制单时间 <= '{0}' and ", end);
            }
            str += " 1=1 ";
            DataTable dt;
            string sql = string.Format("select * from METR_ERP_BOMVIEW where {0}", str);
            dt = sqlProcessor.SelectDb(sql, "METR_ERP_BOMVIEW");
            if (dt == null)
            {
                dt = sqlAccess.SelectDb(sql, "METR_ERP_BOMVIEW");
            }
            return dt;
        }

        public DataTable SelectLike(Dictionary<string, string> dict, string tableName) 
        {
            DataTable dt;
            string str = "";
            foreach (var key in dict.Keys)
            {
                string keystr = key.Replace("/", "");
                str += string.Format(" {0} like '%{1}%' and ", keystr, dict[key]);
            }
            str += " 1=1 ";
            string sql = string.Format("select * from {0} where {1}",tableName, str);
            dt = sqlProcessor.SelectDb(sql, tableName);
            if (dt == null)
            {
                dt = sqlAccess.SelectDb(sql, tableName);
            }
            return dt;
        }



    }
}
