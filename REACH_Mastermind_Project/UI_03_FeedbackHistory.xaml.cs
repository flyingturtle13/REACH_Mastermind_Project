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

namespace REACH_Mastermind_Project
{
    /// <summary>
    /// Interaction logic for FeedbackHistory.xaml
    /// </summary>
    public partial class FeedbackHistory : Window
    {
        public FeedbackHistory()
        {
            InitializeComponent();
            guess_ListView.ItemsSource = UserInput.histList;
        }


        public void Guess_ListView(int attempts, List<int> userNums, int numMatch, int locMatch)
        {
            string userComb = "";

            for (int i = 0; i < userNums.Count; i++)
            {
                if (i == userNums.Count - 1)
                {
                    userComb += userNums[i].ToString();
                }
                else if (i == 0)
                {
                    userComb = userNums[i].ToString() + ", ";
                }
                else
                {
                    userComb += userNums[i].ToString() + ", ";
                }
            }

            
            UserInput.histList.Add(new HistoryList
            {
                AttemptNum = attempts,
                Combination = userComb,
                NumMatch = numMatch,
                NumPosMatch = locMatch
            });

            guess_ListView.ItemsSource = UserInput.histList;
        }


        private void Close_Btn(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
