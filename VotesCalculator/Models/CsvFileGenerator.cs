using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VotesCalculator.Models
{
    class CsvFileGenerator
    {
        public static void SaveToCsvFile(string path, string header, List<int> data, bool append)
        {
            var sb = new StringBuilder();

            sb.Append(header);
            sb.AppendLine();
            foreach (int element in data)
            {
                sb.Append(element);
                sb.Append(",");
            }
            sb.AppendLine();

            System.IO.StreamWriter file = new System.IO.StreamWriter(path, append, Encoding.GetEncoding("iso-8859-2"));
            file.WriteLine(sb.ToString());
            file.Close();
        }


        public static void SaveToCsvFile(string path, string header, Dictionary<string, int> data, bool append)
        {
            var sb = new StringBuilder();

            sb.Append(header);
            sb.AppendLine();
            foreach (KeyValuePair<string, int> element in data)
            {
                sb.Append(element.Key);
                sb.Append(",");
                sb.Append(element.Value);
                sb.AppendLine();
            }

            System.IO.StreamWriter file = new System.IO.StreamWriter(path, append, Encoding.GetEncoding("iso-8859-2"));
            file.WriteLine(sb.ToString());
            file.Close();
        }

    }
}
