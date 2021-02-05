using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VotesCalculator.Models
{
    class XmlWebClientConnection
    {
        private WebClient Client;

        public XmlWebClientConnection()
        {
            Client = new WebClient();
            Client.Headers.Add("Accept", "application/xml");
            Client.Encoding = Encoding.UTF8;
        }

        public string GetXmlData(string url)
        {
            string xmlResult = Client.DownloadString(url);
            return xmlResult;
        }


    }
}
