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
    /// Window allows player to view previous attempt history information to help strategize
    /// Includes previous inputted combinations, attempt #, numbers matched, number positions matched
    /// </summary>
    public partial class FeedbackHistory : Window
    {
        public FeedbackHistory()
        {
            InitializeComponent();
            guess_ListView.ItemsSource = UserInput.histList;
        }


        //Receiving method for parameters passed from combination check class if player is to attempt again
        public void Guess_ListView(int attempt, List<int> userNums, int numMatch, int locMatch)
        {
            string userComb = "";

            //converting player inputted previous attempt combination in readible string type
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

            
            //Adding properties to existing 
            UserInput.histList.Add(new HistoryList
            {
                AttemptNum = attempt,
                Combination = userComb,
                NumMatch = numMatch,
                NumPosMatch = locMatch
            });

            //Add new properties to list view
            guess_ListView.ItemsSource = UserInput.histList;
        }


        //Close Button - returns player to User Input window-------
        private void Close_Btn(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
