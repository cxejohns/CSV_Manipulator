using CSV_Manipulator.Aids;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Aids
{
    public class ReadingCSVFiles
    {

        public static CsvTable GetTable()
        {

            CsvTable table = new CsvTable();
            var slnDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
            var fileName = "words.csv";
            var fullPath = Path.Combine(slnDirectory, fileName);
            table.Path = fullPath;
            var rows = new List<Row>();
            table.Rows = rows;

            try
            {
                using (StreamReader sr = new StreamReader(table.Path))
                {
                    while (!sr.EndOfStream)
                    {

                        string line = sr.ReadLine();

                        string[] words = line.Split(',');

                        Row row = new Row();
                        var cells = new List<Cell>();
                        row.Cells = cells;

                        foreach (string word in words)
                        {
                            Cell cell = new Cell();
                            cell.Text = word;
                            row.Cells.Add(cell);

                        }

                        table.Rows.Add(row);

                    }
                    sr.Close();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }
            foreach (Row row in table.Rows)
            {
                while (row.Cells.Count < table.MaxRowLength)
                {
                    var cell = new Cell();
                    cell.Text = "-";
                    row.Cells.Add(cell);
                }
            }
            return table;
        }

    public static void OutputTable(CsvTable table)
        {
            for(int i = 0; i <= table.MaxRowLength; i++)
            {
                Console.Write(PadBoth(i.ToString()));
                Console.Write(" |");
            }

            for (int i = 0; i < table.Rows.Count; i++) // Row row in table.Rows)
            {
                Console.WriteLine();
                Console.Write(PadBoth((i + 1).ToString()));
                Console.Write(" |");

                foreach (Cell cell in table.Rows[i].Cells)
                {
                    Console.Write(PadBoth(cell.Text));
                    Console.Write(" |");
                }
            }
        }
    public static string PadBoth(string source)
    {
        int length = 10;
        int spaces = length - source.Length;
        int padLeft = spaces / 2 + source.Length;
        return source.PadLeft(padLeft).PadRight(length);

    }

    public static void GetTableFixed()
        {
            CsvTable table = new CsvTable();
            table.Path = "D:\\Desktop\\CSV_Manipulator\\CSV_Manipulator\\CSV_Manipulator\\words.csv";
            var rows = new List<Row>();
            table.Rows = rows;

            StreamReader sr = new StreamReader(table.Path);

            using (var csv = new CsvReader(sr))
            {
                //csv.Read();
                //csv.ReadHeader();
                while (csv.Read())
                {
                    Console.WriteLine();
                    for (int i = 0; i < 3; i++)
                    {
                        string foo = csv.GetField(i);
                        Console.Write(foo);
                        Console.Write("|");
                    }
                }
                Console.ReadLine();
            }



        }

    }
}
