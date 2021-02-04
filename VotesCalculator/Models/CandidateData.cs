using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VotesCalculator.Models
{
    [XmlTypeAttribute(AnonymousType = false)]
    public class CandidateData
    {
        [XmlElement("candidate")]
        public List<Candidate> Candidates { get; set; }

        public CandidateData()
        {
            Candidates = new List<Candidate>();
        }
    }
    
}
