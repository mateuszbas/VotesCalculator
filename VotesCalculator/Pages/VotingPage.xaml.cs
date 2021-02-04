using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using VotesCalculator.Models;

namespace VotesCalculator.Views
{
    /// <summary>
    /// Logika interakcji dla klasy VotingPage.xaml
    /// </summary>
    public partial class VotingPage : Page
    {
        private Voter LoggedVoter { get; set; }
        private List<Candidate> candidatesList { get; set; }

        public VotingPage(Voter loggedVoter)
        {
            InitializeComponent();

            LoggedVoter = loggedVoter;

            XmlWebClientConnection xmlWebClient = new XmlWebClientConnection();
            string doc = xmlWebClient.GetXmlData(@"http://webtask.future-processing.com:8069/candidates");

            var serializer = new XmlSerializer(typeof(CandidateData), new XmlRootAttribute("candidates"));
            var stringReader = new StringReader(doc);
            var reader = XmlReader.Create(stringReader);
            var result = (CandidateData)serializer.Deserialize(reader);

            candidatesList = result.Candidates;
            lbCandidates.ItemsSource = candidatesList;
        }

        private void btnVote_Click(object sender, RoutedEventArgs e)
        {

            var mb = MessageBox.Show("Are you sure this the person you want to vote for?", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (mb == MessageBoxResult.Yes)
            {
                List<Candidate> checkedCandidatesList = candidatesList.Where(x => x.IsChecked).ToList();
                VotingDatabaseEntities db = new VotingDatabaseEntities();

                if (checkedCandidatesList.Count == 1)
                {
                    LoggedVoter.VoteName = checkedCandidatesList[0].Name;
                    LoggedVoter.VoteParty = checkedCandidatesList[0].Party;
                }
                else
                {
                    LoggedVoter.VoteName = "null";
                    LoggedVoter.VoteParty = "null";
                }

                db.Voters.Add(LoggedVoter);
                db.SaveChanges();
            }
        }

        private void btnMainPage_Click(object sender, RoutedEventArgs e)
        {
            LoggingPage loggingPage = new LoggingPage();
            NavigationService.Navigate(loggingPage);
        }
    }
}
