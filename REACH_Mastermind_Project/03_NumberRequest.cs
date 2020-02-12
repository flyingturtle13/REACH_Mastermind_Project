using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using WebApi;
using System.Windows.Forms;

namespace REACH_Mastermind_Project
{
    
    class NumberRequest
    {
        //Performs web API call to retrieve random number combination
        public static async Task GetRanComb()
        {
            string urlRanNum = "https://www.random.org/integers/?num=4&min=0&max=7&col=1&base=10&format=plain&rnd=new";

            WebApiRequest.InitializeClient();

            using (HttpResponseMessage message = await WebApiRequest.client.GetAsync(urlRanNum))
            {
                if (message.IsSuccessStatusCode)
                {
                    string response = await message.Content.ReadAsStringAsync();
                    
                    //-------flag - uncomment to reveal for debugging-------// 
                    //MessageBox.Show(response);

                    NumModel.NumberModel.apiRanNum = response;
                }
                else
                {
                    throw new Exception(message.ReasonPhrase);
                }
            }
        }
    }
}
