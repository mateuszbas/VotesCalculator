using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VotesCalculator.Models;
using MessageBox = System.Windows.MessageBox;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;

namespace VotesCalculator.Pages
{
    /// <summary>
    /// Interaction logic for SummaryPage.xaml
    /// </summary>
    public partial class SummaryPage : Page
    {
        StatisticsCalculator statisticsCalculator;

        public SummaryPage()
        {
            InitializeComponent();

            //Show statistics in Datagrids and TextBlock
            statisticsCalculator = new StatisticsCalculator();
            dgCandidatesResults.ItemsSource = statisticsCalculator.namesCounts;
            dgPartiesResults.ItemsSource = statisticsCalculator.partiesCounts;
            tbNullResults.Text = "Null votes count: " + statisticsCalculator.NullVotes;
        }

        //Send user to the main page
        private void btnMainPage_Click(object sender, RoutedEventArgs e)
        {
            LoggingPage loggingPage = new LoggingPage();
            NavigationService.Navigate(loggingPage);
        }

        //Shows bar charts 
        private void btnShowCharts_Click(object sender, RoutedEventArgs e)
        {
            ChartsWindow chartsWindow = new ChartsWindow();
            chartsWindow.Show();
            chartsWindow.AddDataToCharts(statisticsCalculator.namesCounts, statisticsCalculator.partiesCounts, statisticsCalculator.NullVotes);
        }

        //Exports data to CSV (..... and PDF......) file
        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog exportDialog = new SaveFileDialog();
            exportDialog.DefaultExt = ".csv";
            exportDialog.ShowDialog();
            try
            {
                
                string filename = exportDialog.FileName;
                CsvFileGenerator.SaveToCsvFile(filename, "Name, Votes", statisticsCalculator.namesCounts, false);
                CsvFileGenerator.SaveToCsvFile(filename, "Party, Votes", statisticsCalculator.partiesCounts, true);
                CsvFileGenerator.SaveToCsvFile(filename, "Valid Votes, Null Votes", new List<int> { statisticsCalculator.ValidVotes, statisticsCalculator.NullVotes }, true);
                CsvFileGenerator.SaveToCsvFile(filename, "Dissallowed tries", new List<int> { statisticsCalculator.DisallowedTries }, true);
            }
            catch
            {
                MessageBox.Show("Could not export data!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
               
           
        }
    }
}
