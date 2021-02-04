using System;
using System.Collections.Generic;
using System.Text;

namespace VotesCalculator
{
    interface IVote
    {
        // Voting operation
        public int Vote(int partyid);

        // Checking if voter has already voted
        public bool HasVoted();
        public bool IsOverEighteen(int pesel);
    }
}
