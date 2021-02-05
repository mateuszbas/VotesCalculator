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
    /*
     * Class handles downloading information about candidates from url and 
     * exporting of candidate data to the database
     */
    [XmlTypeAttribute(AnonymousType = false)]
    public class CandidateData
    {
        [XmlElement("candidate")]
        public List<Candidate> Candidates { get; set; }

        public CandidateData()
        {
            Candidates = new List<Candidate>();
        }

        //Downloads data about candidates from specified URL
        public void CandidateListFromURL(string url)
        {

            XmlWebClientConnection xmlWebClient = new XmlWebClientConnection();
            string doc = xmlWebClient.GetXmlData(url);

            var serializer = new XmlSerializer(typeof(CandidateData), new XmlRootAttribute("candidates"));
            var stringReader = new StringReader(doc);
            var reader = XmlReader.Create(stringReader);
            Candidates = ((CandidateData)serializer.Deserialize(reader)).Candidates;
        }

        //Downloads data about candidates from the database
        public void CandidateListFromDatabase()
        {
            VotingDatabaseEntities db = new VotingDatabaseEntities();
            Candidates = db.Candidates.Select(x => x).ToList();
        }

        //Sends data about candidated to the database
        public void CandidateListToDatabase()
        {
            VotingDatabaseEntities db = new VotingDatabaseEntities();
            foreach (Candidate candidate in Candidates)
                db.Candidates.Add(candidate);
            db.SaveChanges();
        }
    }

    
    
}
