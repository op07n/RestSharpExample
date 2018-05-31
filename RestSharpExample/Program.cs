using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RestSharp;

using RestSharpExample.HLHttpClient;

namespace RestSharpExample
{
    internal class Program
    {
        private static async Task<T> ExecuteGet<T>(string resource)
        {
            var request = new HLHttpRequest(resource, Method.GET);
            var response = await SingletonTypicodeClient.Instance.ExecuteTaskAsync<T>(request);
            return response.Data;
        }

        private static async Task Main(string[] args)
        {
            // Llaman GET http://https://jsonplaceholder.typicode.com / resource
            var postsTask = ExecuteGet<IEnumerable<Post>>("posts");
            var commentsTask = ExecuteGet<IEnumerable<Comment>>("comments");
            var albumsTask = ExecuteGet<IEnumerable<Album>>("albums");
            Task.WaitAll(postsTask, commentsTask, albumsTask);

            Console.WriteLine($"Posts:{postsTask.Result.Count()} Comments:{commentsTask.Result.Count()} Albums:{albumsTask.Result.Count()}");
        }
    }

    /// <summary>
    ///     Instancia singleton para simular injection dependency co
    /// </summary>
    public sealed class SingletonTypicodeClient
    {
        static SingletonTypicodeClient()
        {
        }

        private SingletonTypicodeClient()
        {
        }

        public static HLHttpClient.HLHttpClient Instance { get; } = new HLHttpClient.HLHttpClient("https://jsonplaceholder.typicode.com");
    }

    // CLASES EXTRAIDAS CON http://json2csharp.com/
    public class Post
    {
        public string Body { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }

        public int UserId { get; set; }
    }

    public class Comment
    {
        public string Body { get; set; }

        public string Email { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public int PostId { get; set; }
    }

    public class Album
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int UserId { get; set; }
    }
}