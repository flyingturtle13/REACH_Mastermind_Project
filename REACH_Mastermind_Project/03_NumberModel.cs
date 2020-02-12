using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using REACH_Mastermind_Project;


namespace NumModel
{
    //Number Model from Random Integer API (https://www.random.org/integers).  Number Request class to access
    public class NumberModel
    {
        //globalized parameter for web API output to be processed
        public static string apiRanNum { get; set; }

        //Converts API output type to a List of String type
        public static List<string> LoadNumber()
        {
            List<string> numbers = new List<string>();
            string apiResponse = apiRanNum;

            foreach (char item in apiResponse)
            {

                if (!char.IsWhiteSpace(item))
                {
                    string number = item.ToString();
                    numbers.Add(number);
                }
            }
           
            return numbers;
        }
    }
}
