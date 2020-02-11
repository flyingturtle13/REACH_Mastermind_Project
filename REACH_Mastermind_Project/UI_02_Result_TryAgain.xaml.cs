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
    /// Interaction logic for Result_TryAgain.xaml
    /// </summary>
    public partial class Result_TryAgain : Window
    {
        public Result_TryAgain(int numMatch, int locMatch, int attemptLeft)
        {
            InitializeComponent();
            NumMatchDisplay.Content = numMatch;
            NumLocDisplay.Content = locMatch;
            AttLeftDisplay.Content = attemptLeft;
        }

        private void Close_Btn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
