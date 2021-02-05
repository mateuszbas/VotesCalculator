using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace VotesCalculator.Models
{
    [XmlTypeAttribute(AnonymousType = false)]
    public class CandidateData
    {
        [XmlElement("candidate")]

        public List<Candidate> Candidates { get; }

        public CandidateData()
        {
            Candidates = new List<Candidate>();
        }

        public CandidateData(string url): base()
        {
            XmlWebClientConnection xmlWebClient = new XmlWebClientConnection();
            string doc = xmlWebClient.GetXmlData(@"http://webtask.future-processing.com:8069/candidates");

            var serializer = new XmlSerializer(typeof(CandidateData), new XmlRootAttribute("candidates"));
            var stringReader = new StringReader(doc);
            var reader = XmlReader.Create(stringReader);
            Candidates = ((CandidateData)serializer.Deserialize(reader)).Candidates;
        }

    }

    
    
}
