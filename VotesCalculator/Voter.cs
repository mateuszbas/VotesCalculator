namespace VotesCalculator
{
    using System;
    using System.Collections.Generic;

    public partial class Voter
    {
        public int VoteId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalIdNumber { get; set; }
        public int? CandidateId { get; set; }

        public virtual Candidate Candidate { get; set; }

        public Voter() { }
        public Voter(string firstName, string lastName, string personalIdNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PersonalIdNumber = personalIdNumber;
        }

    }
}