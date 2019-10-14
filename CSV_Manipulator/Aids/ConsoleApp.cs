using CSV_Manipulator.Aids;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Manipulator.Aids
{
    public class ConsoleApp
    {
        public void Start()
        {

            string initialInput = null;
            do
            {
                Graphics.Initialize();
                Console.WriteLine("Enter the file name:");
                initialInput = Console.ReadLine();
                CsvTable wordsCSV = ReadingCSVFiles.GetTable(initialInput);
                Console.WriteLine(wordsCSV.Path);
                ReadingCSVFiles.OutputTable(wordsCSV);
                string usrAction = null;

                Console.ReadLine();
                do
                {
                    Graphics.Red();
                    Console.WriteLine("(1) add row, (2) delete a row, (3) add a column, (4) delete a column, (5) read csvhelper (6) write csvhelper (7)convert to uppercase (0) exit");
                    Graphics.Black();
                    usrAction = Console.ReadLine();
                    if (usrAction == "1")
                    {
                        Console.WriteLine("Type input separated by commas:");
                        string usrInput = Console.ReadLine();
                        WritingCSVFiles.AddRow(wordsCSV, usrInput);
                    }
                    else if (usrAction == "2")
                    {
                        Console.WriteLine("Enter the number of the row to delete");
                        WritingCSVFiles.DeleteRow(wordsCSV, Int32.Parse(Console.ReadLine()));
                    }
                    else if (usrAction == "3")
                    {
                        Console.WriteLine("Type input separated by commas:");
                        string usrInput = Console.ReadLine();
                        WritingCSVFiles.AddColumn(wordsCSV, usrInput);
                    }
                    else if (usrAction == "4")
                    {
                        Console.WriteLine("Enter the number of the column to delete");
                        WritingCSVFiles.DeleteColumn(wordsCSV, Int32.Parse(Console.ReadLine()));
                    }
                    else if (usrAction == "5")
                    {
                        ReadingCSVFiles.CSVHelperTest();

                    }
                    else if (usrAction == "6")
                    {
                        WritingCSVFiles.WriteCSVHelper();
                    }
                    else if (usrAction == "7")
                    {
                        WritingCSVFiles.CsvHelperToUpper();
                    }
                    Console.ReadLine();
                    wordsCSV = ReadingCSVFiles.GetTable(initialInput);
                    ReadingCSVFiles.OutputTable(wordsCSV);
                    Console.ReadLine();


                } while (usrAction != "0");
            } while (initialInput != "0");
           
        }

        
    }
}
