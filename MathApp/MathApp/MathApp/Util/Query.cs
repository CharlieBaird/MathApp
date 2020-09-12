using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace MathApp.Util
{
    public class Query
    {
        private static readonly HttpClient Client = new HttpClient();
        
        private static async Task<string> QueryApiLessonsAsync()
        {

            string response;
            
            try
            {
                // var url = new Uri("https://mathquestioneditor.herokuapp.com/");
                var url = new Uri("http://172.16.42.18:80");
                response = await Client.GetStringAsync(url);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            
            return response;
        }

        public static async Task<string> QueryLessonsAsync()
        {
            var response = await QueryApiLessonsAsync();

            return response;
        }
    }
}