using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExcelReader
{

    class Program
    {
        private static char[] arr ;

        static void Main(string[] args)
        {
            List<string> column1 = new List<string>();
            List<string> column2 = new List<string>();
            List<string> column3 = new List<string>();
            List<string> column4 = new List<string>();


            using (var fs = File.OpenRead(@"E:\118.csv"))
            using (var reader = new StreamReader(fs))
            {
                char[] arr = new char[] { ';' };
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split( arr, 5);

                    column1.Add(values[0]);
                    column2.Add(values[1]);
                    if (values.Length > 2)
                    { 
                    column3.Add(values[2]);
                    column4.Add(values[3]);
                    }
                }
            }
            
            /*Console.WriteLine(column1[3]);
            Console.WriteLine(column2[3]);
            Console.WriteLine(column3[3]);
            Console.WriteLine(column4[3]);
            */
            //StringBuilder s = new StringBuilder();

            List<string> dataAndTime = new List<string>();

            for (int i = 0; i < column2.Count; i++)
            {
                dataAndTime[i] = column1[i] + " " + column2[i];
            }



            string a = column1[3]+" " + column2[3];
            DateTime dt1 = DateTime.Parse(a);
            DateTime dt2 = DateTime.Parse(dataAndTime[2]);

            //var smth = column1.Where(x=>x.)

            Console.WriteLine(dt1);
            Console.WriteLine(dt2);

            Console.ReadKey();

        }
    }
}
