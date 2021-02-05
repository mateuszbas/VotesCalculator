using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Xml.Linq;
using VotesCalculator.Models;
using VotesCalculator.Pages;
using VotesCalculator.Views;


namespace VotesCalculator
{
    /// <summary>
    /// Interaction logic for LoggingPage.xaml
    /// </summary>
    public partial class LoggingPage : Page
    {
        public LoggingPage()
        {
            InitializeComponent();
        }

        //Sends user to voting summary page
        private void btnSummary_Click(object sender, RoutedEventArgs e)
        {
            SummaryPage summaryPage = new SummaryPage();
            NavigationService.Navigate(summaryPage);
        }

        //Logs user with provided first name, last name and personal id number
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //Connect to database and create Voter object
            VotingDatabaseEntities db = new VotingDatabaseEntities();
            string personalIdNumber = tbPersonalId.Text;
            Voter loggedVoter = new Voter(tbFirstName.Text, tbLastName.Text, personalIdNumber);

            //Failure flags
            bool isBlacklisted = false;
            bool isUnderaged = false;
            bool hasVoted = false;
            bool isIncorrect = false;

            
                //Check validity of personal id number
                isIncorrect = PESELValidator.PESEL(personalIdNumber);
                isBlacklisted = PESELValidator.IsBlacklisted(personalIdNumber);
                isUnderaged = PESELValidator.IsUnderaged(personalIdNumber);

                var voters = db.Voters;
                var result = voters.Select(x => x.PersonalIdNumber).ToList();

                //Decrypt personal id number from database and compare it with given one
                if(result.Count != 0)
                foreach (string voterId in result)
                    if (Encrypter.DecryptString(voterId) == personalIdNumber)
                    {
                        hasVoted = true;
                        break;
                    }
            
          

            //Handling of invalid personal id number 
            if (isIncorrect)
                MessageBox.Show("Personal ID number is incorrect!");
            else if (isUnderaged || isBlacklisted)
            {
                //Update information about disallowed logging tries  
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
                //If personal id number is valid, sendu user to voting page
                VotingPage votingPage = new VotingPage(loggedVoter);
                NavigationService.Navigate(votingPage);
            }

        }

    }
}
