using System;

using RestSharp;

using RestSharpExample.HLHttpClient.Serializers;

namespace RestSharpExample.HLHttpClient
{
    public class HLHttpRequest : RestRequest
    {
        public HLHttpRequest()
            : base()
        {
            JsonSerializer = new NewtonsoftSerializer();
        }

        public HLHttpRequest(Method method)
            : this()
        {
            Method = method;
        }

        public HLHttpRequest(string resource)
            : this(resource, Method.GET)
        {
        }

        public HLHttpRequest(string resource, Method method)
            : this()
        {
            Resource = resource;
            Method = method;
        }

        public HLHttpRequest(Uri resource)
            : this(resource, Method.GET)
        {
        }

        public HLHttpRequest(Uri resource, Method method)
            : this(
                resource.IsAbsoluteUri
                    ? resource.AbsolutePath + resource.Query
                    : resource.OriginalString,
                method)
        {
        }
    }
}