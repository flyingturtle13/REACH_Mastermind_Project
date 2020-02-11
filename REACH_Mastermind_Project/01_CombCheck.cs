﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumModel;
using REACH_Mastermind_Project;
using System.Windows.Forms;

namespace REACH_Mastermind_Project
{
    class CombCheck
    {
        public static void SetCombNums(List<int> inputNums)
        {
            List<string> apiNums = new List<string>();
            List<int> userNums = inputNums;

            NumberModel nm = new NumberModel();
            apiNums = NumberModel.LoadNumber();

            CombCheck.RunCheck(apiNums, userNums);
        }


        //Evaluates if user input combination matches API generated combination 
        public static void RunCheck(List<string> apiNums, List<int> userNums)
        {
            //MessageBox.Show("User: " + userNums[0] + "," + userNums[1] + "," + userNums[2] + "," + userNums[3]);
            //MessageBox.Show("API: " + apiNums[0] + "," + apiNums[1] + "," + apiNums[2] + "," + apiNums[3]);
            FeedbackHistory fHis = new FeedbackHistory();
            UserInput ui = new UserInput();
            MainWindow mw = new MainWindow();

            if (MainWindow.InPlay == true)
            {
                int numMatch = 0;
                int locMatch = 0;
                List<int> apiNumsTest = new List<int>();
                List<int> userNumsTest = userNums.ToList<int>();

                //convert generated API random numbers to type integer
                foreach (string item in apiNums)
                {
                    int num = int.Parse(item);
                    apiNumsTest.Add(num);
                }

                //1.  Check for condition when integers match AND position match
                //    records count for number match, position match, and replaces matched values (eliminates double counting)
                for (int i = 0; i < userNumsTest.Count; i++)
                {
                    for (int j = 0; j < apiNumsTest.Count; j++)
                    {
                        if (userNumsTest[i] == apiNumsTest[j] && i == j)
                        {
                            numMatch++;
                            locMatch++;
                            apiNumsTest.RemoveAt(j);
                            apiNumsTest.Insert(j, 8);
                            userNumsTest.RemoveAt(i);
                            userNumsTest.Insert(i, 9);
                            break;
                        }
                    }
                }

                //2.  Check condition for when ONLY numbers match
                //    records count to number match and replaces matched values (eliminates double counting)
                for (int i = 0; i < userNumsTest.Count; i++)
                {
                    for (int j = 0; j < apiNumsTest.Count; j++)
                    {
                        if (userNumsTest[i] == apiNumsTest[j])
                        {
                            numMatch++;
                            apiNumsTest.RemoveAt(j);
                            apiNumsTest.Insert(j, 8);
                            break;
                        }
                    }
                }

                //Determine results of user combination guess
                if (numMatch == apiNums.Count && locMatch == apiNums.Count)
                {
                    MainWindow.InPlay = false;
                    Result_Success matched = new Result_Success();

                    fHis.Guess_ListView(10 - MainWindow.AttemptCnt, userNums, numMatch, locMatch);
                    ui.Show();
                    matched.Show();
                    
                }
                else if (MainWindow.AttemptCnt == 1)
                {
                    Result_Fail fail = new Result_Fail();

                    MainWindow.InPlay = false;
                    UserInput.histList.Clear();
                    ui.Close();                    
                    mw.Show();
                    fail.Show(); 
                }
                else
                {
                    MainWindow.AttemptCnt -= 1;
                    Result_TryAgain tryAgain = new Result_TryAgain(numMatch, locMatch, MainWindow.AttemptCnt);

                    //MessageBox.Show("UN:" + userNums[0].ToString() + userNums[1].ToString() + userNums[2].ToString() + userNums[3].ToString());
                    //MessageBox.Show("API: " + apiNums[0] + "," + apiNums[1] + "," + apiNums[2] + "," + apiNums[3]);
                    fHis.Guess_ListView(10-MainWindow.AttemptCnt, userNums, numMatch, locMatch);
                    
                    ui.Show();
                    tryAgain.Show();
                }
            }
            else
            {
                mw.Show();
                ui.Close();
            }
        }
    }
}
