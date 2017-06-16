using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//repo
// read .csv

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
            List<string> dataAndTimeString = new List<string>();

            string filename = @"E:\118.csv";
            Helpers.FileReader(filename, ref column1, ref column2, ref column3, ref column4);


            List<DateTime>  dT = Helpers.DataFromTwoStrings(column1, column2, dataAndTimeString);

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
