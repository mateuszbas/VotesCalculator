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

namespace VotesCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //CandidateData candidateData = new CandidateData();
            //candidateData.CandidateListFromURL(@"http://webtask.future-processing.com:8069/candidates");
            //candidateData.CandidateListToDatabase();

            NavigationFrame.Navigate(new LoggingPage(), NavigationFrame);
            
        }

       
    }
}
