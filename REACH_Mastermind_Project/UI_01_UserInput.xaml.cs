using System;
using System.IO;
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
using WebApi;
using NumModel;

namespace REACH_Mastermind_Project
{
    /// <summary>
    /// Interaction logic for UserInput.xaml
    /// </summary>
    
    partial class UserInput : Window
    {
        public UserInput()
        {
            InitializeComponent();
            AttLeftDisplay.Content = MainWindow.AttemptCnt;
        }

        //-------------------------------------------------------

        //global access to player guess history to be retrieved when next attempt initiated
        public static List<HistoryList> histList = new List<HistoryList>();


        //Unlock Button - Player to submit combination guess---------------
        private async void Unlock_Btn(object sender, RoutedEventArgs e)
        {            
            List<int> inputNums = new List<int>();
            List<string> inputText = new List<string>();
            int error = 0;

            //Creates a list of user combination input
            inputText.Add(num1Input1.Text);
            inputText.Add(num2Input2.Text);
            inputText.Add(num3Input3.Text);
            inputText.Add(num4Input4.Text);

            foreach (string item in inputText)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    inputNums.Add(int.Parse(item));  
                }
                else
                {
                    //If player leaves an input blank or does not comply with rules,
                    //will flag to notify player try re-entering values
                    error++;
                }
            }   

            if (error == 0)
            {
                //Pass inputs to combination check class
                CombCheck eval = new CombCheck();
                await eval.SetCombNums(inputNums);
                this.Hide();
            }
            else
            {
                MessageBox.Show("There are " + error + " input errors.  Make sure to input a number from 0 to 7 in all placeholders.");
            }
        }


        //Player reference redirect options-----------------------
        //Help Button - List Game Rules for Player
        private void Help_Btn(object sender, RoutedEventArgs e)
        {
            HelpWindow openHelp = new HelpWindow();
            openHelp.Show();
        }


        //Guess History Button
        private void His_Btn(object sender, RoutedEventArgs e)
        {
            FeedbackHistory openHistory = new FeedbackHistory();
            openHistory.Show();
        }
        //---------------------------------------------------------
        

        //Hint Button----------------------------------------------
        private void Hint_Btn(object sender, RoutedEventArgs e)
        {
            Hint openHint= new Hint();
            openHint.Show();
        }
        //---------------------------------------------------------


        //Quit Game-------------------------------------------------
        private void Quit_Btn(object sender, RoutedEventArgs e)
        {
            MainWindow returnMain = new MainWindow();
            returnMain.Show();
            UserInput.histList.Clear();
            this.Close();
        }
        //---------------------------------------------------------     
    }


    //Globalize player guess history list to pass properties
    public class HistoryList
    {
        public int AttemptNum { get; set; }
        public string Combination { get; set; }
        public int NumMatch { get; set; }
        public int NumPosMatch { get; set; }
    }
}
