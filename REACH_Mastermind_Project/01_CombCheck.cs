using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumModel;
using WebApi;
using REACH_Mastermind_Project;
using System.Windows.Forms;

namespace REACH_Mastermind_Project
{

    //Class that evaluates player combination input. Checks if combination matches computer generated combination
    //and returns the result to the player
    class CombCheck
    {
        //Method to compile user and computer number combinations. Unlock Button directs to this class.
        public async Task SetCombNums(List<int> inputNums)
        {
            //sets user combination input
            List<string> apiNums = new List<string>();
            List<int> userNums = inputNums;

            //Initiates Number Model to call API for random combination
            //NumberModel nm = new NumberModel();
            apiNums = NumberModel.LoadNumber();

            await CombCheck.RunCheck(apiNums, userNums);
        }


        //Evaluates if user input combination matches API generated combination 
        public static async Task RunCheck(List<string> apiNums, List<int> userNums)
        {
            //MessageBox.Show("User: " + userNums[0] + "," + userNums[1] + "," + userNums[2] + "," + userNums[3]);
            //MessageBox.Show("API: " + apiNums[0] + "," + apiNums[1] + "," + apiNums[2] + "," + apiNums[3]);
            FeedbackHistory fHis = new FeedbackHistory();
            UserInput ui = new UserInput();
            MainWindow mw = new MainWindow();

            //Conditions being checked to determined numbers matched and number positions matched
            if (MainWindow.InPlay == true)
            {
                int numMatch = 0;
                int locMatch = 0;
                List<int> apiNumsTest = new List<int>();
                List<int> userNumsTest = userNums.ToList<int>();

                //convert generated API random numbers to integer type
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
                            userNumsTest.RemoveAt(i);
                            userNumsTest.Insert(i, 9);
                            break;
                        }
                    }
                }

                //Determine results of user combination guess
                if (numMatch == apiNums.Count && locMatch == apiNums.Count)
                {
                    //for successful combination
                    //initiates API call for random quote to return to user
                    await QuoteRequest.GetQuote();
                    //
                    MainWindow.InPlay = false;

                    Result_Success matched = new Result_Success();

                    //passess parameters for player guess history
                    //fHis.Guess_ListView(10 - MainWindow.AttemptCnt, userNums, numMatch, locMatch);

                    ui.Close();
                    mw.Show();
                    matched.Show();
                }
                else if (MainWindow.AttemptCnt == 1)
                {
                    //for if player fails - 0 attempts left
                    Result_Fail fail = new Result_Fail(apiNums);

                    MainWindow.InPlay = false;
                    UserInput.histList.Clear();
                    ui.Close();                    
                    mw.Show();
                    fail.Show(); 
                }
                else
                {
                    //for when player is perform next attempt
                    MainWindow.AttemptCnt -= 1;

                    Result_TryAgain tryAgain = new Result_TryAgain(numMatch, locMatch, MainWindow.AttemptCnt);

                    fHis.Guess_ListView(10-MainWindow.AttemptCnt, userNums, numMatch, locMatch);
                    
                    tryAgain.Show();
                }
            }
            else
            {
                //case for when game no longer to continue
                mw.Show();
                ui.Close();
            }
        }
    }
}
