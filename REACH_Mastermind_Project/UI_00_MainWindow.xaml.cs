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
using WebApi;
using REACH_Mastermind_Project;


namespace REACH_Mastermind_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int AttemptCnt { get; set; }
        public static bool InPlay { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();
        }

        //Play Button - Starts Game
        private async void play_Click(object sender, RoutedEventArgs e)
        {           
            //Initiate values for global parameters
            InPlay = true;
            AttemptCnt = 10;
            UserHint.nonMatchRangeExist = false;
            UserInput.histList.Clear();

            //Open UI Main Game to retrieve user input
            UserInput uiGame = new UserInput();
            uiGame.Show();
            HelpWindow openHelp = new HelpWindow();
            openHelp.Show();
            
            //Http GET - web Random Integer API call to get random number combination
            await NumberRequest.GetRanComb();

            this.Close();
        }

        //Exit Button - Shutdown game
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        } 
    }
}
