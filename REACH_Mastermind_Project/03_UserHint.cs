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
        public static bool nonMatchRangeExist { get; set;}

        public static List<int> numRange = new List<int>();

        public static int HintNum { get; set; }

        public static int HintCnt { get; set; }

        public static void GetHint()
        {
            if (nonMatchRangeExist == false)
            {
                NonMatchNums();
            }
            else if (nonMatchRangeExist == true && HintCnt >= 0)
            {
                RanHint();
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

            RanHint();
        }


        public static int RanHint()
        {
            List<int> numRangeMod = numRange.ToList<int>();
            int maxNum = numRange.Max()+1;
            int minNum = numRange.Min();
            Random random = new Random();

            HintNum = random.Next(minNum, maxNum);

            foreach (int num in numRangeMod)
            {
                if(HintNum == num)
                {
                    numRange.Remove(HintNum);
                }
            }

            HintCnt -= 1;

            return HintNum;
        }

    }
}
