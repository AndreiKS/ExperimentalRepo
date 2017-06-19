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
        public Program()
        {

        }

        static void Main(string[] args)
        {
            List<string> column1 = new List<string>();
            List<string> column2 = new List<string>();
            List<string> column3 = new List<string>();
            List<string> column4 = new List<string>();
            List<string> dataAndTimeString = new List<string>();
            int CTRatio = 40;
            string filename = @"E:\118.csv";
            Helpers.FileReader(filename, ref column1, ref column2, ref column3, ref column4);
            
            List<DateTime>  dT = Helpers.DataFromTwoStrings(column1, column2, dataAndTimeString);

            double powerSum=0;
            double powerPeak = 0;
            double powerNight = 0;
            double powerDay = 0;
            double maxPeakPower = 0;
            DateTime maxpeakPowerData = DateTime.MinValue;
            DateTime requiredDate = new DateTime { };

            //var smth = column1.Where(x=>x.)
            for (int i = 0; i < column1.Count; i++)
            {

                if (dT[i].Month == 3)
                {
                double res = 0;
                double.TryParse(column4[i].ToString(), out res);
                powerSum += res;
                
                //можно сильно упростить или использовать LINQ
                if (dT[i].Hour >= 8 && dT[i].Hour <= 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Zones z = Zones.Peak;
                    powerPeak += res;
                        if (res>=maxPeakPower)
                        {
                            maxPeakPower = res;
                            maxpeakPowerData = dT[i];
                        }
                }
                else if ((dT[i].Hour >= 0 && dT[i].Hour <= 5)
                    | (dT[i].Hour >= 23 && dT[i].Hour <= 24))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Zones z = Zones.Night;
                    powerNight += res;    
                }
                else
                {
                        Console.ForegroundColor = ConsoleColor.White;
                        Zones z = Zones.Night;
                        powerDay += res;
                }

                Console.Write(dT[i]);
                Console.WriteLine("         " +column3[i]+"    "+column4[i]);

                }
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            Console.WriteLine($"powerSum = {powerSum}");
            double consumption = powerSum * CTRatio/2;
            Console.WriteLine($"consumption= { consumption}");
            Console.WriteLine($"consumptionPeak= { powerPeak * CTRatio / 2} or {powerPeak/ powerSum * 100}%");
            Console.WriteLine($"consumptionDay= { powerDay * CTRatio / 2} or {powerDay / powerSum * 100, 2}%");
            Console.WriteLine($"consumptionNight= { powerNight * CTRatio/2} or {powerNight / powerSum * 100, 2}%");
            Console.WriteLine();

            Console.WriteLine($"maxPeakPower = {maxPeakPower*CTRatio} ");
            Console.WriteLine($"maxPeakPowerData = {maxpeakPowerData} ");

            Console.ReadKey();

        }
    }
}
