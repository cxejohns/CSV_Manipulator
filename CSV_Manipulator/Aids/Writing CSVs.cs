using CSV_Manipulator.Aids;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Aids
{
    public class WritingCSVFiles
    {

        public static void WipeFile(CsvTable table)
        {

            FileStream fcreate = File.Open(table.Path, FileMode.Create); // will create the file or overwrite it if it already exists
            try
            {

                using (StreamWriter sw = new StreamWriter(fcreate))
                {
                    sw.WriteLine("{0}", "");
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (IOException e) //catch a specific type of Exception
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }
        }
        public static void AddRow(CsvTable table, string usrInput)
        {
            string[] words = usrInput.Split(',');

            FileStream fappend = File.Open(table.Path, FileMode.Append); // will create the file or overwrite it if it already exists
            try
            {

                using (StreamWriter sw = new StreamWriter(fappend))
                {
                    sw.WriteLine(string.Join(',', words));
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (IOException e) //catch a specific type of Exception
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }

        }

        public static void AddColumn(CsvTable table, string usrInput)
        {
            string[] words = usrInput.Split(',');

            for(int i = 0; i < words.Length; i++)
            {
                if (i + 1 > table.Rows.Count)
                {
                   //skip
                }
                else {
                    var cell = new Cell();
                    cell.Text = words[i];
                    table.Rows[i].Cells.Add(cell);
                }
                
            }
            UpdateTable(table);
        }
        public static void DeleteRow(CsvTable table, int rowNumber)
        {

            table.Rows.RemoveAt(rowNumber - 1);
            UpdateTable(table);

        }

        public static void DeleteColumn(CsvTable table, int colNumber)
        {
            foreach(Row row in table.Rows)
            {
                row.Cells.RemoveAt(colNumber - 1);
            }
            UpdateTable(table);

        }

        public static void UpdateTable(CsvTable table)
        {
            FileStream fcreate = File.Open(table.Path, FileMode.Create);
            try
            {

                using (StreamWriter sw = new StreamWriter(fcreate))
                {
                    foreach (Row row in table.Rows)
                    {
                        string newLine = "";
                        foreach (Cell cell in row.Cells)
                        {
                            newLine += cell.Text + ",";
                        }
                        newLine = newLine.TrimEnd(',');
                        sw.WriteLine(newLine);

                    }
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (IOException e) //catch a specific type of Exception
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }
        }
        public static void WriteCell(CsvTable table, string newWord)
        {
            
            FileStream fcreate = File.Open(table.Path, FileMode.Append);
            try
            {
                using (StreamWriter sw = new StreamWriter(fcreate))
                {
                    sw.WriteLine("{0},{0}", newWord);
                }
            }
            catch (IOException e) //catch a specific type of Exception
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }

        }
    }
}
