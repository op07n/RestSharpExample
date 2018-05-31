using System;

using RestSharp;

using RestSharpExample.HLHttpClient.Serializers;

namespace RestSharpExample.HLHttpClient
{
    public class Request : RestRequest
    {
        public Request()
            : base()
        {
            JsonSerializer = new NewtonsoftSerializer();
        }

        public Request(Method method)
            : this()
        {
            Method = method;
        }

        public Request(string resource)
            : this(resource, Method.GET)
        {
        }

        public Request(string resource, Method method)
            : this()
        {
            Resource = resource;
            Method = method;
        }

        public Request(Uri resource)
            : this(resource, Method.GET)
        {
        }

        public Request(Uri resource, Method method)
            : this(
                resource.IsAbsoluteUri
                    ? resource.AbsolutePath + resource.Query
                    : resource.OriginalString,
                method)
        {
        }
    }
}