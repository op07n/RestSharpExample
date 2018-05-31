using System;

using RestSharp;

namespace RestSharpExample.HLHttpClient
{
    public class HLHttpClient : RestClient
    {
        public HLHttpClient()
        {
        }

        public HLHttpClient(Uri baseUrl)
            : this()
        {
            BaseUrl = baseUrl;
        }

        public HLHttpClient(string baseUrl)
            : this()
        {
            if (string.IsNullOrEmpty(baseUrl))
                throw new ArgumentNullException(nameof(baseUrl));
            BaseUrl = new Uri(baseUrl);
        }
    }
}