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
using System.Windows.Shapes;

namespace VotesCalculator.Pages
{
    /// <summary>
    /// Interaction logic for ChartsWindow.xaml
    /// </summary>
    public partial class ChartsWindow : Window
    {

        public ChartsWindow( )
        {
            InitializeComponent();
        }

        public void AddDataToCharts(Dictionary<string, int> namesCounts, Dictionary<string, int> partiesCounts, int nullVotes)
        {
            Dictionary<string, int> nullVotesDict = new Dictionary<string, int>();
            nullVotesDict.Add("Null votes", nullVotes);
            candidatesSeries.ItemsSource = namesCounts;
            partiesSeries.ItemsSource = partiesCounts;
            nullVotesSeries.ItemsSource = nullVotesDict;


        }
    }
}
