using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VotesCalculator.Models;

namespace VotesCalculator.Pages
{
    /// <summary>
    /// Interaction logic for SummaryPage.xaml
    /// </summary>
    public partial class SummaryPage : Page
    {
        public SummaryPage()
        {
            InitializeComponent();

            StatisticsCalculator statisticsCalculator = new StatisticsCalculator();
            lbCandidatesResults.ItemsSource = statisticsCalculator.namesCounts;
        
            lbPartiesResults.ItemsSource = statisticsCalculator.partiesCounts;
        }

        private void btnMainPage_Click(object sender, RoutedEventArgs e)
        {
            LoggingPage loggingPage = new LoggingPage();
            NavigationService.Navigate(loggingPage);
        }
    }
}
