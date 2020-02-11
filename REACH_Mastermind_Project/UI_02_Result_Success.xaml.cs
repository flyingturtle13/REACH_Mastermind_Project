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
    /// Interaction logic for Result_Success.xaml
    /// </summary>
    public partial class Result_Success : Window
    {
        public Result_Success()
        {
            InitializeComponent();
        }

        private void Close_Btn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
