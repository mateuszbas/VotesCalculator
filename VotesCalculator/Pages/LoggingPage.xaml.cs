using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Xml.Linq;
using VotesCalculator.Models;
using VotesCalculator.Views;


namespace VotesCalculator
{
    /// <summary>
    /// Logika interakcji dla klasy LoggingPage.xaml
    /// </summary>
    public partial class LoggingPage : Page
    {
        public LoggingPage()
        {
            InitializeComponent();
        }

        private void btnSummary_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            VotingDatabaseEntities db = new VotingDatabaseEntities();
            string personalIdNumber = tbPersonalId.Text;
            Voter loggedVoter = new Voter(tbFirstName.Text, tbLastName.Text, personalIdNumber);
            //Failure flags
            bool isBlacklisted = false;
            bool isUnderaged = false;
            bool hasVoted = false;
            bool isIncorrect = false;

            try
            {
                isIncorrect = PESELValidator.PESEL(personalIdNumber);
                isBlacklisted = PESELValidator.IsBlacklisted(personalIdNumber);
                isUnderaged = PESELValidator.IsUnderaged(personalIdNumber);

                
                var voters = db.Voters;
                var result = voters.Where(x => x.PersonalIdNumber == personalIdNumber).Count();
                if (result != 0)
                    hasVoted = true;
            }
            catch
            {
                isIncorrect = true;
            }

            if (isIncorrect)
                MessageBox.Show("Personal ID number is incorrect!");
            else if (isUnderaged || isBlacklisted) {
                var statisticsTable = db.Statistics;
                var disallowedTries = statisticsTable.SingleOrDefault(x => x.StatisticId == 1);
                disallowedTries.DisallowedTries++;
                db.SaveChanges();
                MessageBox.Show("You are disallowed to vote!");
           
            }
            else if (hasVoted)
                MessageBox.Show("You have already voted!");
            else
            {
                VotingPage votingPage = new VotingPage(loggedVoter);
                NavigationService.Navigate(votingPage);
            }



        }


    }
}
