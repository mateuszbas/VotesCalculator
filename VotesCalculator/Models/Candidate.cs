using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace VotesCalculator
{
    public class Candidate
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "party")]
        public string Party { get; set; }

        public bool IsChecked { get; set; }
        
    }
}
