using Aspose.Cells;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Telerik.WinControls.UI;

namespace ERP.Data
{
    public class ExportExcel
    {
        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(ExportExcel));
        private class SumInfo {
            public int Index { get; set; }
            public decimal Sum { get; set; }
            public String Format { get; set; }
           public GridAggregateFunction Aggregate { get; set; }
        } 

        public static void export(String filename, RadGridView grid,params int[] except)
        {
            Workbook workbook = new Workbook(); //工作簿 
            Worksheet sheet = workbook.Worksheets[0];
            Cells cells = workbook.Worksheets[0].Cells;
            int i = 0;
            List<string> hs = new List<string>();
            foreach (var col in grid.Columns)
            {

                Cell cell = cells[0, i];
                if (col.IsVisible && (except == null || ((except != null && !except.Contains(i)))) && !(col is GridViewCommandColumn))
                {
                    i++;
                    cell.PutValue(col.HeaderText);
                    hs.Add(col.Name);
                }
                else {
                    log.Debug("xx"+col.Name);
                }
            }
            i = 1;
            Hashtable sumhs = new Hashtable();
            foreach (GridViewSummaryRowItem row in grid.MasterTemplate.SummaryRowsBottom)
            {
                foreach (GridViewSummaryItem col in row.Fields)
                {
                    sumhs.Add(col.Name, new SumInfo() { Aggregate = col.Aggregate,Sum = 0 ,Format = col.FormatString});
                }
            }
            
            foreach (var row in grid.Rows)
            {
                int k = 0;
                foreach (string col in hs)
                {
                    Cell cell = cells[i, k];
                    k++;
                    if (sumhs.ContainsKey(col))
                    {
                        var item = (SumInfo)sumhs[col];
                        item.Index = k - 1;
                        item.Sum += row.Cells[col].Value == DBNull.Value?0: Convert.ToDecimal(row.Cells[col].Value);
                    }
                    if (row.Cells[col].ColumnInfo is GridViewComboBoxColumn)
                    {
                        GridViewComboBoxColumn cxbCol = (GridViewComboBoxColumn)row.Cells[col].ColumnInfo;
                        var val = cxbCol.GetLookupValue(row.Cells[col].Value);
                        if (val == null)
                        {
                            cell.PutValue(row.Cells[col].Value);
                        }
                        else
                        {

                            cell.PutValue(val);
                        }

                    }
                    else if (row.Cells[col].Value is DateTime) {
                        cell.PutValue(((DateTime)row.Cells[col].Value).ToLongDateString());
                    }
                    else
                    {
                        cell.PutValue(row.Cells[col].Value);
                    }
                }
                i++;
            }
            List<SumInfo> result = new List<SumInfo>();
            foreach (SumInfo info in sumhs.Values)
            {
                Cell cell = cells[i, info.Index];
                cell.PutValue(string.Format(info.Format,info.Sum));
            }

            //cells.ImportDataTable((DataTable)grid.DataSource, false, 0, 0);
            workbook.Save(filename);
        }
    }
}
