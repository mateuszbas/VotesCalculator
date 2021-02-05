using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VotesCalculator.Models
{
    /*
     * Class handles calculation of voting results: null votes, valid votes, votes per candidates, votes per party and disallowed votes
     */
    class StatisticsCalculator
    {
        public int NullVotes { get; }
        public int ValidVotes { get; }
        public Dictionary<string, int> namesCounts { get; }
        public Dictionary<string, int> partiesCounts { get; }
        public int DisallowedTries { get; }

        public StatisticsCalculator()
        {
            try
            {
                VotingDatabaseEntities db = new VotingDatabaseEntities();
                DisallowedTries = db.Statistics.Select(x => x.DisallowedTries).ToArray()[0];

                NullVotes = db.Voters.Count(x => string.IsNullOrEmpty(x.CandidateId.ToString()));
                ValidVotes = db.Voters.Count(x => !string.IsNullOrEmpty(x.CandidateId.ToString()));



                //Create left join of tables Voters and Candidates
                var leftOuterJoin = (from v in db.Voters
                                     join c in db.Candidates
                                     on v.CandidateId equals c.CandidateId into joined
                                     from c in joined.DefaultIfEmpty()
                                     select new
                                     {
                                         v,
                                         c
                                     });

                //Create right join of tables Voters and Candidates
                var rightOuterJoin = (from c in db.Candidates
                                      join v in db.Voters
                                      on c.CandidateId equals v.CandidateId into joined
                                      from v in joined.DefaultIfEmpty()
                                      select new
                                      {
                                          v,
                                          c
                                      });

                //Combine both joins to get full join
                var fullOuterJoin = leftOuterJoin.Union(rightOuterJoin);

                //From full join group by names to count occurences of each Candidate
                namesCounts = fullOuterJoin.Where(x => x.c.Name != null).GroupBy(x => x.c.Name)
                                .Select(y => new
                                {
                                    Name = y.Key,
                                    Count = y.Where(z => z.v.CandidateId != null).Count()
                                }).ToDictionary(t => t.Name, t => t.Count);

                //From full join group by parties to count occurences of each Party
                partiesCounts = fullOuterJoin.Where(x => x.c.Party != null).GroupBy(x => x.c.Party)
                                .Select(y => new
                                {
                                    Name = y.Key,
                                    Count = y.Where(z => z.v.CandidateId != null).Count()
                                }).ToDictionary(t => t.Name, t => t.Count);
            }
            catch
            {
                MessageBox.Show("Could not provide voting results! Try again.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}
