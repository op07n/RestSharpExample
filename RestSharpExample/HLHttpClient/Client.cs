using System;

using RestSharp;

namespace RestSharpExample.HLHttpClient
{
    public class Client : RestClient
    {
        public Client()
        {
        }

        public Client(Uri baseUrl)
            : this()
        {
            BaseUrl = baseUrl;
        }

        public Client(string baseUrl)
            : this()
        {
            if (string.IsNullOrEmpty(baseUrl))
                throw new ArgumentNullException(nameof(baseUrl));
            BaseUrl = new Uri(baseUrl);
        }
    }
}