using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using NumModel;
using REACH_Mastermind_Project;

namespace WebApi
{
    //Http GET - Access Online APIs
    //Makes call to web API using URL passed from MainWindow when Player initiates game)
    class WebApiRequest
    {
        HttpClient client = new HttpClient();
        

        public static async Task InitializeClient(string url)
        {
            
            WebApiRequest request = new WebApiRequest();
            await request.GetApiResponse(url);
        }


        //Make call to web API - checks first if returned API output parameters are successful
        private async Task GetApiResponse(string url)
        {
            client.DefaultRequestHeaders.Accept.Clear();

            using (HttpResponseMessage message = await client.GetAsync(url))
            {
                if (message.IsSuccessStatusCode)
                {
                    string response = await client.GetStringAsync(url);


                    //flag - uncomment to reveal for debugging 
                    MessageBox.Show("API Response: " + response.ToString());


                    UserInput.StoreApiRes(response);
                }
                else
                {
                    throw new Exception(message.ReasonPhrase);
                }
            }
            
        }
    }
}
