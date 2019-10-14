using CSV_Manipulator.Aids;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Manipulator.Aids
{
    public class WritingCSVFiles
    {

        public static string GetPath()
        {
            var slnDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
            var fileName = "words.csv";
            var fullPath = Path.Combine(slnDirectory, fileName);
            return fullPath;
        }
        public static string GetPath(string FileName)
        {
            var slnDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
            var fullPath = Path.Combine(slnDirectory, FileName + ".csv");
            return fullPath;
        }
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

        public static void WriteCSVHelper()
        {
            var records = new List<Foo>
            {
                new Foo { Id = 3, Name = "three" },
                new Foo { Id = 4, Name = "four" },
            };
            using (var writer = new StreamWriter(GetPath("csvhelper")))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(records);
            }
        }



        public static void CsvHelperToUpper()
        {
            string filename = "csvhelper";
            var records = new List<Foo>();
            using (var reader = new StreamReader(GetPath(filename)))
            {
                using (var csv = new CsvReader(reader))
                {
                    var recordsRaw = csv.GetRecords<Foo>();
                    foreach(Foo record in recordsRaw)
                    {
                        Console.WriteLine("test");
                        record.Name = record.Name.ToUpper();
                        records.Add(record);

                    }
                }
            }
            using (var writer = new StreamWriter(GetPath(filename)))
            using (var csvWriter = new CsvWriter(writer))
            {
                csvWriter.WriteRecords(records);
            }
        }
    }
}
