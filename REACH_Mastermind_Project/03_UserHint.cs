using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumModel;

namespace REACH_Mastermind_Project
{
    class UserHint
    {
        public static List<int> numRange { get; set; }

        public static bool nonMatchRangeExist { get; set;}

        public static void GetHint()
        {
            if (UserHint.nonMatchRangeExist == false)
            {
                UserHint.NonMatchNums();
            }
            else
            {
                UserHint.RanHint();
            }
        }

        public static void NonMatchNums()
        {
            List<string> getApiNums = NumberModel.LoadNumber();
            //List<int> numRange = new List<int>();
            List<int> apiNums = new List<int>();

            foreach (string item in getApiNums)
            {
                int num = int.Parse(item);
                apiNums.Add(num);
            }

            for (int i=0; i<8; i++)
            {
                numRange.Add(i);
            }

            for (int i=0; i<apiNums.Count; i++)
            {
                for (int j=0; j<numRange.Count; j++)
                {
                    if (apiNums[i] == numRange[j])
                    {
                        numRange.RemoveAt(j);
                    }
                }
            }

            nonMatchRangeExist = true;

            UserHint.RanHint();
        }


        public static int RanHint()
        {
            int maxNum = numRange.Count - 1;
            int minNum = numRange[0];
            Random random = new Random();

            int hint = random.Next(minNum, maxNum);

            foreach (int num in numRange)
            {
                if(hint == num)
                {
                    numRange.Remove(hint);
                }
            }

            return hint;
        }

    }
}
