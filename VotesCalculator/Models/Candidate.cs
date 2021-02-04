using System;
using System.Collections.Generic;
using System.Text;

namespace VotesCalculator
{
    class Candidate : Person
    {
        private int PartyId { get; set; }
        public Candidate(string name, string surname, int partyid) : base(name, surname)
        {
            PartyId = partyid;
        }
    }
}
