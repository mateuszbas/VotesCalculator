using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VotesCalculator.Models
{
    /*
     * Class handles connection with web server for downloading xml information
     */

    class XmlWebClientConnection
    {
        private WebClient Client;

        //Sets up connection
        public XmlWebClientConnection()
        {
            Client = new WebClient();
            Client.Headers.Add("Accept", "application/xml");
            Client.Encoding = Encoding.UTF8;
        }

        //Downloads xml data as a string
        public string GetXmlData(string url)
        {
            string xmlResult = Client.DownloadString(url);
            return xmlResult;
        }


    }
}
