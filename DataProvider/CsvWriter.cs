using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataProvider
{
    public class CsvWriter
    {
        public string DataTableToCSV(DataTable dt, char seperator = ',')
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sb.Append(dt.Columns[i]);
                if (i < dt.Columns.Count - 1)
                    sb.Append(seperator);
            }
            sb.AppendLine();
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sb.Append(dr[i].ToString());

                    if (i < dt.Columns.Count - 1)
                        sb.Append(seperator);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public void SaveCsvToFile(string csv, string path)
        {
            File.WriteAllText(path, csv);
        }
    }
}
