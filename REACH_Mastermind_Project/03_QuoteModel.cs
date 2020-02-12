using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using WebApi;

namespace REACH_Mastermind_Project
{
    //Location for random quote to store properties
    //to be displayed in Result_Success window
    class QuoteModel
    {
        public string quoteAuthor { get; set; }
        public string quoteText { get; set; }
    }
}
