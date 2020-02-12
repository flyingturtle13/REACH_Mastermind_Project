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
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace REACH_Mastermind_Project
{
    class QuoteRequest
    {
        //Performs web API call process to retrieve random quote and author
        //Comination Check class direct here to initialize
        //Uses Newtonsoft Json to deserialize
        public static async Task GetQuote()
        {
            string urlRanQuote = "https://api.forismatic.com/api/1.0/?method=getQuote&lang=en&format=jsonp&jsonp=?";

            WebApiRequest.InitializeClient();

            using (HttpResponseMessage message = await WebApiRequest.client.GetAsync(urlRanQuote))
            {
                if (message.IsSuccessStatusCode)
                {
                    string response = await WebApiRequest.client.GetStringAsync(urlRanQuote);

                    var charRemove = new string[] { "?", "(", ")" };
                    foreach (var item in charRemove)
                    {
                        response = response.Replace(item, string.Empty);
                    }

                    QuoteModel quoteItems = JsonConvert.DeserializeObject<QuoteModel>(response);

                    Result_Success.quoteReveal = quoteItems.quoteText;
                    Result_Success.authorReveal = quoteItems.quoteAuthor;
                }
                else
                {
                    throw new Exception(message.ReasonPhrase);
                }
            }
        }
    }
}
