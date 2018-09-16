using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace DataProvider
{
    public class CSVReader
    {
        private DataCacheProvider cacheProvider = new DataCacheProvider();
        private string fileNamePath;
        public string line;
        public static DataTable csvData; 
        public CSVReader(string fileNamePath)
        {
            this.fileNamePath = fileNamePath;
            csvData = GetCsvAsTable();
        }
        
        public DataTable GetCsvAsTable()
        {
            DataTable table = new DataTable();
            DataColumn col;
            bool isfirstRow = true;
            using (StreamReader reader = new StreamReader(this.fileNamePath))
                while ((line = reader.ReadLine()) != null)
                {
                    int i = 0;
                    string[] rows = line.Split(',');
                    DataRow datarows = table.NewRow();
                    foreach (string item in rows)
                    {
                        if (isfirstRow)
                        {
                            col = new DataColumn(item);
                            if (item == "id") col.DataType = System.Type.GetType("System.Int32");
                            table.Columns.Add(col);
                        }
                        else
                        {
                            datarows[i] = rows[i];
                            i++;
                        }
                       
                    }
                    table.Rows.Add(datarows);
                    isfirstRow = false;
                }
            table.Rows.RemoveAt(0);
            return table;
        }

        public DataTable GetCachedCsvAsTable() {
            if (cacheProvider.IsItemCached("csvData"))
            {
                return cacheProvider.GetDataCachedItem("csvData") as DataTable;
            }
            else
            {
                var item = GetCsvAsTable();
                cacheProvider.AddToDataCache("csvData", item, CachePriority.Default, new List<string> { this.fileNamePath });
                return cacheProvider.GetDataCachedItem("csvData") as DataTable;
            }
        }

        public DataTable GetOriginalCsvTable()
        {
            if (cacheProvider.IsItemCached("csvData"))
            {
                cacheProvider.RemoveDataCachedItem("csvData");
            }
            return GetCsvAsTable();
        }
    }
}
