using ConsoleExtender;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSV_Manipulator.Aids
{
    public static class Graphics
    {
        public static int ToggleCounter {get; set;}

        public static void Initialize()
        {
            ToggleCounter = 1;
            Graphics.Black();
            Console.Clear();
            Graphics.Green();

        }
        public static void Black()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }

        public static void Green()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        public static void Red()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        public static void White()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        public static void TinyFont()
        {
            ConsoleHelper.SetConsoleFont(4);
        }
        public static void SmallFont()
        {
            ConsoleHelper.SetConsoleFont(10);
        }
        public static void AlternateGreenAndBlack()
        {
            if(ToggleCounter % 2 == 0)
            {
                Green();
            }
            else
            {
                Black();
            }
            ToggleCounter++;

        }
    }
}
