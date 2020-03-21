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
    /// Interaction logic for Hint.xaml
    /// </summary>
    public partial class Hint : Window
    {
        public Hint()
        {
            InitializeComponent();
            if (UserHint.HintCnt >= 0)
            {
                hintLeft.Content = UserHint.HintCnt;
            }
            else
            {
                hintLeft.Content = 0;
            }
            
        }

        private void GetHint_Btn(object sender, RoutedEventArgs e)
        {
            UserHint.GetHint();

            if (UserHint.HintCnt >= 0)
            {
                revNum.Content = UserHint.HintNum;
                hintLeft.Content = UserHint.HintCnt;
            }
            else
            {
                revNum.Content = "You're on your own.";
                hintLeft.Content = 0;
            }
        }

        private void HintClose_Btn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
