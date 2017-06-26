using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExcelReader
{
    public static class Helpers
    {
        public static void FileReader(string filename, ref List<string> column1, ref List<string> column2,
            ref List<string> column3, ref List<string> column4)
        {

            try
            {

                // выяснить корректность и варианты подобного использования using для нескольких 
                // объектов
                using (var fs = File.OpenRead(filename))
                using (var reader = new StreamReader(fs))
                {
                    char[] split = new char[] { ';' };
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(split);

                        column1.Add(values[0]);
                        column2.Add(values[1]);
                        if (values.Length <= 2)
                        {
                            column3.Add("no value");
                            column4.Add("no value");
                        }

                        else
                        {
                            column3.Add(values[2]);
                            column4.Add(values[3]);
                        }
                    }
                }

            }


            catch (FileNotFoundException)
            {
                Console.WriteLine($"File {filename} not found. Press any key");
                Console.ReadKey();
            }
        }

        public static void SelectMonth()
        {


        }

        public static void SelectDayZone()
        {


        }

        public static double ConvertToRealValue(double value, int ratio)
        {
            return value * ratio / 2;
        }


        public static List<DateTime> DataFromTwoStrings(List<string> column1, List<string> column2, List<string> dataAndTimeString)
        {
            DateTime dt;
            List<DateTime> dT = new List<DateTime>();

            for (int i = 0; i < column2.Count; i++)
            {
                StringBuilder builder = new StringBuilder(column1[i], 20);
                builder.Append(" ");
                builder.Append(column2[i]);
                dataAndTimeString.Add(builder.ToString());
                DateTime.TryParse(dataAndTimeString[i], out dt);
                dT.Add(dt);
            }

            return dT;
        }
    }





class WriteTextFile
{
    static void Method()
    {

        // These examples assume a "C:\Users\Public\TestFolder" folder on your machine.

        // Example #1: Write an array of strings to a file.
        // Create a string array that consists of three lines.
        string[] lines = { "First line", "Second line", "Third line" };
        // WriteAllLines creates a file, writes a collection of strings to the file,
        // and then closes the file.  You do NOT need to call Flush() or Close().
        System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\WriteLines.txt", lines);


        // Example #2: Write one string to a text file.
        string text = "A class is the most powerful data type in C#. Like a structure, " +
                       "a class defines the data and behavior of the data type. ";
        // WriteAllText creates a file, writes the specified string to the file,
        // and then closes the file.    You do NOT need to call Flush() or Close().
        System.IO.File.WriteAllText(@"C:\Users\Public\TestFolder\WriteText.txt", text);

        // Example #3: Write only some strings in an array to a file.
        // The using statement automatically flushes AND CLOSES the stream and calls 
        // IDisposable.Dispose on the stream object.
        // NOTE: do not use FileStream for text files because it writes bytes, but StreamWriter
        // encodes the output as text.
        using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\WriteLines2.txt"))
        {
            foreach (string line in lines)
            {
                if (!line.Contains("Second"))
                {
                    file.WriteLine(line);
                }
            }
        }

        // Example #4: Append new text to an existing file.
        // The using statement automatically flushes AND CLOSES the stream and calls 
        // IDisposable.Dispose on the stream object.
        using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\WriteLines2.txt", true))
        {
            file.WriteLine("Fourth line");
        }
    }
}



}