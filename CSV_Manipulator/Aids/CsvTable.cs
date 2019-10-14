using System;
using System.Collections.Generic;
using System.Text;

namespace CSV_Manipulator.Aids
{
    public class CsvTable
    {
        public List<Row> Rows { get; set; }
        public int MaxRowLength { get
            {
                int max = 0;
                foreach (Row row in Rows)
                {
                    max = row.Cells.Count > max ? row.Cells.Count : max;
                }
                return max;
            } }
        public string Path { get; set; }
    }
}
