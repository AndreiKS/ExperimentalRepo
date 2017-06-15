using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//repo

namespace ConsoleExcelReader
{

    class Program
    {

        static void Main(string[] args)
        {
            List<string> column1 = new List<string>();
            List<string> column2 = new List<string>();
            List<string> column3 = new List<string>();
            List<string> column4 = new List<string>();


            using (var fs = File.OpenRead(@"E:\118.csv"))
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


            List<string> dataAndTimeString = new List<string>();
            List<DateTime> dT = new List<DateTime>();
            DateTime dt;
            for (int i = 0; i < column2.Count; i++)
            {
                StringBuilder builder = new StringBuilder(column1[i], 25);
                builder.Append(" ");
                builder.Append(column2[i]);
                dataAndTimeString.Add(builder.ToString());
                DateTime.TryParse(dataAndTimeString[i], out dt);
                dT.Add(dt);
            }


            // вынести в отдельный класс

            //var smth = column1.Where(x=>x.)
            for (int i = 0; i < 250; i++)
            {
                //можно сильно упростить
                if (dT[i].Hour >= 8 && dT[i].Hour <= 10) Console.ForegroundColor = ConsoleColor.Red;
                else if ((dT[i].Hour >= 0 && dT[i].Hour <= 5) | (dT[i].Hour >= 23 && dT[i].Hour <= 24)) Console.ForegroundColor = ConsoleColor.Cyan;
                else Console.ForegroundColor = ConsoleColor.White;
                Console.Write(dT[i]);
                Console.WriteLine("         " +column3[i]+"    "+column4[i]);

            }


            Console.ReadKey();

        }
    }
}
