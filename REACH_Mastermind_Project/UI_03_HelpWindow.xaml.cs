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
    /// Interaction logic for HelpWindow.xaml
    /// Help prompt reminding player of game rules/information
    /// </summary>
    public partial class HelpWindow : Window
    {
        public HelpWindow()
        {
            InitializeComponent();
        }

        //Close Button - returns player to User Input window-----
        private void Close_Btn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
