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
using VotesCalculator.Pages;

namespace VotesCalculator.Views
{
    /// <summary>
    /// Logika interakcji dla klasy VotingPage.xaml
    /// </summary>
    public partial class VotingPage : Page
    {
        public Voter LoggedVoter { get; }

        private CandidateData candidateData;

        public VotingPage(Voter loggedVoter)
        {
            InitializeComponent();

            LoggedVoter = loggedVoter;
            candidateData = new CandidateData(@"http://webtask.future-processing.com:8069/candidates");
            lbCandidates.ItemsSource = candidateData.Candidates;
        }

        private void btnVote_Click(object sender, RoutedEventArgs e)
        {

            var mb = MessageBox.Show("Are you sure this the person you want to vote for?", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (mb == MessageBoxResult.Yes)
            {
                List<Candidate> checkedCandidatesList = candidateData.Candidates.Where(x => x.IsChecked).ToList();
                VotingDatabaseEntities db = new VotingDatabaseEntities();

                if (checkedCandidatesList.Count == 1)
                {
                    LoggedVoter.CandidateId = checkedCandidatesList[0].CandidateId;
                  
                }
                else
                {
                    LoggedVoter.CandidateId = -1;
                   
                }

                db.Voters.Add(LoggedVoter);
                db.SaveChanges();

                SummaryPage summaryPage = new SummaryPage();
                NavigationService.Navigate(summaryPage);
            }
        }

        private void btnMainPage_Click(object sender, RoutedEventArgs e)
        {
            LoggingPage loggingPage = new LoggingPage();
            NavigationService.Navigate(loggingPage);
        }
    }
}
