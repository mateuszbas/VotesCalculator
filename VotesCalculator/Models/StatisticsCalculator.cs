using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotesCalculator.Models
{
    class StatisticsCalculator
    {
        public int NullVotes { get; }
        public Dictionary<string, int> VotesPerCandidate { get; }
        public Dictionary<string, int> VotesPerParty { get; }

        public StatisticsCalculator()
        {
            //XmlWebClientConnection xmlWebClient = new XmlWebClientConnection();
            //string doc = xmlWebClient.GetXmlData(@"http://webtask.future-processing.com:8069/candidates");

            //var serializer = new XmlSerializer(typeof(CandidateData), new XmlRootAttribute("candidates"));
            //var stringReader = new StringReader(doc);
            //var reader = XmlReader.Create(stringReader);
            //var result = (CandidateData)serializer.Deserialize(reader);

            //candidatesList = result.Candidates;
        }
    }
}
