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
    /// Interaction logic for VotingPage.xaml
    /// </summary>
    public partial class VotingPage : Page
    {
        public Voter LoggedVoter { get; }

        private CandidateData candidateData;

        public VotingPage(Voter loggedVoter)
        {
            InitializeComponent();

            LoggedVoter = loggedVoter;

            //Show list of candidates to vote for
            candidateData = new CandidateData();
            candidateData.CandidateListFromDatabase();
            lbCandidates.ItemsSource = candidateData.Candidates;
        }

        private void btnVote_Click(object sender, RoutedEventArgs e)
        {
            //Present the user with a messagebox to ensure his decision
            var mb = MessageBox.Show("Are you sure this the person you want to vote for?", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (mb == MessageBoxResult.Yes)
            {
                try
                {
                    //If affirmative, find checked candidate 
                    List<Candidate> checkedCandidatesList = candidateData.Candidates.Where(x => x.IsChecked).ToList();
                    VotingDatabaseEntities db = new VotingDatabaseEntities();
                    //Encrypt the users personal id number 
                    LoggedVoter.PersonalIdNumber = Encrypter.EncryptString(LoggedVoter.PersonalIdNumber);

                    //If single candidate was selected
                    if (checkedCandidatesList.Count == 1)
                        //Add which candidate was selected
                        LoggedVoter.CandidateId = checkedCandidatesList[0].CandidateId;
                    else
                        LoggedVoter.CandidateId = null;

                    //Update database
                    db.Voters.Add(LoggedVoter);


                    db.SaveChanges();
                    //Navigate user to the summary page
                    SummaryPage summaryPage = new SummaryPage();
                    NavigationService.Navigate(summaryPage);
                }
                catch
                {
                    MessageBox.Show("Could not save your vote! Try again.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }



            }
        }

        //Navigate user to the main page
        private void btnMainPage_Click(object sender, RoutedEventArgs e)
        {
            LoggingPage loggingPage = new LoggingPage();
            NavigationService.Navigate(loggingPage);
        }
    }
}
