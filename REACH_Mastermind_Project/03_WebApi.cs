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
    //Initializes Http client to make an API call from API model processor
    class WebApiRequest
    {
        public static HttpClient client { get; set; }
        

        public static void InitializeClient()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
