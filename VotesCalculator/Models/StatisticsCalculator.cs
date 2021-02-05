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
        public int ValidVotes { get; }
        public Dictionary<string, int> namesCounts { get; }
        public Dictionary<string, int> partiesCounts { get; }
        public int DisallowedTries { get; }

        public StatisticsCalculator()
        {
            VotingDatabaseEntities db = new VotingDatabaseEntities();
            DisallowedTries = db.Statistics.Select(x => x.DisallowedTries).ToArray()[0];

            NullVotes = db.Voters.Count(x => string.IsNullOrEmpty(x.CandidateId.ToString()));
            ValidVotes = db.Voters.Count(x => !string.IsNullOrEmpty(x.CandidateId.ToString()));

            var leftOuterJoin = from v in db.Voters
                                join c in db.Candidates 
                                on v.CandidateId equals c.CandidateId into joined
                                from c in joined.DefaultIfEmpty()
                                select new
                                {
                                    v,
                                    c
                                };

            var rightOuterJoin = from c in db.Candidates
                                 join v in db.Voters 
                                 on c.CandidateId equals v.CandidateId into joined
                                 from v in joined.DefaultIfEmpty()
                                 select new
                                 {
                                     v,
                                     c
                                 };

            var fullOuterJoin = leftOuterJoin.Union(rightOuterJoin);


            namesCounts = fullOuterJoin.GroupBy(x => x.c.Name)
                            .Select(y => new
                            {
                                Name = y.Key,
                                Count = y.Where(z => z.v.CandidateId != null).Count()
                            }).ToDictionary(t => t.Name, t => t.Count);

            partiesCounts = fullOuterJoin.GroupBy(x => x.c.Party)
                            .Select(y => new
                            {
                                Name = y.Key,
                                Count = y.Where(z => z.v.CandidateId != null).Count()
                            }).ToDictionary(t => t.Name, t => t.Count);

        }
    }
}
