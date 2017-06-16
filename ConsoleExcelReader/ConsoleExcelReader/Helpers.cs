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

        public static void SelectMonth()
        {


        }





        public static List<DateTime> DataFromTwoStrings(List<string> column1, List<string> column2, List<string> dataAndTimeString)
        {
            DateTime dt;
            List<DateTime> dT = new List<DateTime>();

            for (int i = 0; i < column2.Count; i++)
            {
                StringBuilder builder = new StringBuilder(column1[i], 25);
                builder.Append(" ");
                builder.Append(column2[i]);
                dataAndTimeString.Add(builder.ToString());
                DateTime.TryParse(dataAndTimeString[i], out dt);
                dT.Add(dt);
            }

            return dT;
        }
    }
}
