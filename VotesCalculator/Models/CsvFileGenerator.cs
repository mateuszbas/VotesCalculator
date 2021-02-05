using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VotesCalculator.Models
{
    /*
     * Class handles generation of CSV file 
     */
    class CsvFileGenerator
    {
        //Saves data from list to a csv file on a given path
        public static void SaveToCsvFile(string path, string header, List<int> data, bool append)
        {
            var sb = new StringBuilder();

            //Add header to the file
            sb.Append(header);
            sb.AppendLine();

            //Iterate through elements in the list
            foreach (int element in data)
            {
                sb.Append(element);
                sb.Append(",");
            }
            sb.AppendLine();

            //Write file
            System.IO.StreamWriter file = new System.IO.StreamWriter(path, append, Encoding.GetEncoding("iso-8859-2"));
            file.WriteLine(sb.ToString());
            file.Close();
        }

        //Saves data from Dictionary to a csv file on a given path
        public static void SaveToCsvFile(string path, string header, Dictionary<string, int> data, bool append)
        {
            var sb = new StringBuilder();

            //Add header to the file
            sb.Append(header);
            sb.AppendLine();

            //Iterate through elements in the dictionary
            foreach (KeyValuePair<string, int> element in data)
            {
                sb.Append(element.Key);
                sb.Append(",");
                sb.Append(element.Value);
                sb.AppendLine();
            }

            //Write file
            System.IO.StreamWriter file = new System.IO.StreamWriter(path, append, Encoding.GetEncoding("iso-8859-2"));
            file.WriteLine(sb.ToString());
            file.Close();
        }

    }
}
