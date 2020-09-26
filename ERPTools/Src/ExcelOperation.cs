using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using NPOI;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;

namespace ExcelTools.Src
{
    /// <summary>
    /// 类名        ：ExcelOperation  
    /// 功能描述    ：
    /// 创 建 者    ：无奈
    /// 创建日期    ：2020-07-28 12:41:51 
    /// 最后修改者  ：无奈
    /// 最后修改日期：2020-07-28 12:41:51 
    /// </summary>
    /// 
    struct MyCell{
        public string value;
    };

    class ExcelOperation
    {

        public static bool  ReadTemplate(int startRow,int startCol,string importExcelPath,out DataTable dt)
        {
            dt = new DataTable();
            IWorkbook workbook = null;
            try
            {
                workbook = WorkbookFactory.Create(importExcelPath);
                ISheet sheet = workbook.GetSheetAt(0);//获取第一个工作薄
                IRow row = (IRow)sheet.GetRow(startRow);//获取第一行
                if (row == null) {
                    return false;
                }
                
                int rowCount = sheet.PhysicalNumberOfRows;
                int colCount = row.PhysicalNumberOfCells;
                MyCell[,] myCells = new MyCell[rowCount, colCount];
                for (int j = startRow; j < rowCount; j++)
                {
                    row = sheet.GetRow(j);
                    if (row != null)
                    {
                        for (int i = startCol; i < colCount; i++)
                        {
                            ICell cell = row.GetCell(i);
                            if (cell == null)
                            {
                                continue;
                            }
                            if (cell.CellType == CellType.Numeric && DateUtil.IsCellDateFormatted(cell)) 
                            {
                                myCells[j, i].value = cell.DateCellValue.ToString("yyyy/MM/dd");
                            }
                            else
                            {
                                cell.SetCellType(CellType.String);
                                if (cell != null && !string.IsNullOrEmpty(cell.StringCellValue))
                                {
                                    myCells[j, i].value = cell.StringCellValue;
                                }
                                else
                                {
                                    myCells[j, i].value = null;
                                }
                            }
                            
                        }
                    }
                }
                for (int i = startCol; i < colCount; i++)
                {
                    if (myCells[startRow, i].value != null)
                    {
                        dt.Columns.Add(myCells[startRow, i].value);
                    }
                }
                for (int i = startRow + 1; i < rowCount; i++)
                {
                    DataRow dataRow = dt.NewRow();
                    for (int j = startCol; j < colCount; j++)
                    {
                        if (myCells[startRow, j].value != null)
                        {
                            dataRow[myCells[startRow, j].value] = myCells[i, j].value;
                        }
                    }
                    dt.Rows.Add(dataRow);
                }
            }
            catch (Exception e)
            {
                if (workbook != null)
                {
                    workbook.Close();
                }
                MessageBox.Show(e.Message);
                return false;
            }
            if (workbook != null) {
                workbook.Close();
            }
            workbook.Close();
            return true;
        }

        public static DataSet ReadExcel(string path) {
            DataSet ds = new DataSet();
            IWorkbook workbook = null ;
            try
            {
                workbook = WorkbookFactory.Create(path);
                for (int i = 0; i < workbook.NumberOfSheets; i++)
                {
                    ISheet sheet = workbook.GetSheetAt(i);//获取第一个工作薄
                    IRow row = (IRow)sheet.GetRow(0);//获取第一行
                    if (row != null)
                    {
                        int colCount = row.PhysicalNumberOfCells;
                        DataTable dt = new DataTable();
                        for (int j = 0; j < colCount; j++)
                        {
                            ICell cell = row.GetCell(j);
                            cell.SetCellType(CellType.String);
                            if (cell != null && !string.IsNullOrEmpty(cell.StringCellValue))
                            {
                                dt.Columns.Add(cell.StringCellValue);
                            }
                        }
                        ds.Tables.Add(dt);
                    }
                    
                }
            }
            catch(Exception e){
                if (workbook != null)
                {
                    workbook.Close();
                }
                MessageBox.Show(e.Message);
                return null;
            }
            if (workbook != null)
            {
                workbook.Close();
            }
            return ds;
        }
        public static bool  WriteExcel(string path, string templatePath ,DataTable dt,int startRow,int startCol)
        {
            string pLocalFilePath =templatePath;//要复制的文件路径
            string pSaveFilePath = path;//指定存储的路径
            if (File.Exists(pLocalFilePath)&&!path.Equals(templatePath))//必须判断要复制的文件是否存在
            {
                File.Copy(pLocalFilePath, pSaveFilePath, true);//三个参数分别是源文件路径，存储路径，若存储路径有相同文件是否替换
            }
            IWorkbook workbook = null;
            try
            {
                RemoveEmpty(ref dt);
                workbook = WorkbookFactory.Create(pSaveFilePath);
                ISheet sheet = workbook.GetSheetAt(0);
                IRow row = sheet.GetRow(startRow);
                ICellStyle style = workbook.CreateCellStyle();
                style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                style.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                style.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                style.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                int end = 0;
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    row.Cells[j + 1].SetCellValue(dt.Columns[j].ColumnName);
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (sheet.GetRow(i + startRow + 1) == null)
                    {
                        sheet.CopyRow(startRow, i + startRow + 1);
                    }
                    row = sheet.GetRow(i + startRow + 1);
                    DataRow dr = dt.Rows[i];
                    ICell cell = row.GetCell(0);
                    //cell.CellStyle = style;
                    end = i + startRow + 1;
                    if (cell == null)
                    {
                        cell = row.CreateCell(0);
                    }
                    cell.SetCellValue((i + 1).ToString());
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (row.GetCell(j + startCol) == null)
                        {
                            cell = row.CreateCell(j + startCol);
                            cell.CellStyle = style;
                        }
                        else
                        {
                            cell = row.GetCell(j + startCol);
                        }
                        cell.SetCellValue(dr[dt.Columns[j]].ToString());
                    }
                }
                //导出excel
                FileStream fs = new FileStream(pSaveFilePath, FileMode.Create, FileAccess.ReadWrite);
                workbook.Write(fs);
                fs.Close();
            }
            catch(Exception e) {
                if (workbook != null)
                {
                    workbook.Close();
                }
                MessageBox.Show(e.Message);
                return false;
            }
            if (workbook != null)
            {
                workbook.Close();
            }
            return true;

        }

        public static bool WriteExcel2(string path, string templatePath, DataSet ds)
        {
            string pLocalFilePath = templatePath;//要复制的文件路径
            string pSaveFilePath = path;//指定存储的路径
            if (File.Exists(pLocalFilePath))//必须判断要复制的文件是否存在
            {
                File.Copy(pLocalFilePath, pSaveFilePath, true);//三个参数分别是源文件路径，存储路径，若存储路径有相同文件是否替换
            }
            IWorkbook workbook = null;
            try
            {
                workbook= WorkbookFactory.Create(pSaveFilePath);
                for (int k = 0; k < ds.Tables.Count; k++)
                {
                    DataTable dt = ds.Tables[k];
                    RemoveEmpty(ref dt);
                    ISheet sheet = workbook.GetSheetAt(k);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        IRow row = sheet.CreateRow(i+1);
                        DataRow dr = dt.Rows[i];
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            ICell cell = row.CreateCell(j);
                            cell.SetCellValue(dr[dt.Columns[j]].ToString());
                            
                        }
                    }
                }
                //导出excel
                FileStream fs = new FileStream(pSaveFilePath, FileMode.Create, FileAccess.ReadWrite);
                workbook.Write(fs);
                fs.Close();
            }
            catch (Exception e)
            {
                if (workbook != null)
                {
                    workbook.Close();
                }
                MessageBox.Show(e.Message);
                return false;
            }
            if (workbook != null)
            {
                workbook.Close();
            }
            return true;

        }

        public static void ClearExcel(ref ISheet sheet, int rowindex) 
        {
           
            for (int i = sheet.LastRowNum; i > rowindex; i--)
            {
                if (sheet.GetRow(i) != null)
                {
                    sheet.RemoveRow(sheet.GetRow(i));
                }
                else
                {
                    //sheet.ShiftRows(i,i+1,-1);
                    continue;
                }
            }


        }
        public static bool ExportDataTable(DataTable dt,string path)
        {
            try
            {
                string exportedExcelFullName = path;
                if (dt != null && dt.Rows.Count > 0)
                {
                    XSSFWorkbook workBook = new XSSFWorkbook();
                    ISheet firstSheet = workBook.CreateSheet("First Sheet");
                    IRow headerRow = firstSheet.CreateRow(0);

                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        ICell headerCell = headerRow.CreateCell(i);
                        headerCell.SetCellValue(dt.Columns[i].ColumnName?.ToString());
                    }

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        IRow dataRow = firstSheet.CreateRow(i + 1);
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            ICell dataCell = dataRow.CreateCell(j);
                            dataCell.SetCellValue(dt.Rows[i][j]?.ToString());
                        }
                    }
                    //for (int i = 0; i < dt.Columns.Count; i++)
                    //{
                    //    firstSheet.AutoSizeColumn(i);
                    //}

                    using (FileStream excelStream = File.Create(exportedExcelFullName))
                    {
                        workBook.Write(excelStream);
                    }
                }
            }
            catch (Exception e) 
            {
                MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 清除空白行
        /// </summary>
        /// <param name="dt"></param>
        public static void RemoveEmpty(ref DataTable dt)
        {
            List<DataRow> removelist = new List<DataRow>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool IsNull = true;
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[i][j].ToString().Trim()))
                    {
                        IsNull = false;
                    }
                }
                if (IsNull)
                {
                    removelist.Add(dt.Rows[i]);
                }
            }
            for (int i = 0; i < removelist.Count; i++)
            {
                dt.Rows.Remove(removelist[i]);
            }
        }
    }
}
