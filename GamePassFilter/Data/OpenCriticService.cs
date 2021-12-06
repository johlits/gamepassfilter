using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using GamePassFilter.Data.CodeBeautify;
using GamePassFilter.Data.QuickType;

namespace GamePassFilter.Data
{
    public class OCGame
    {
        public int id { get; set; }

        public string name { get; set; }

        public double dist { get; set; }
    }
    public class OpenCriticService
    {
        public Task<Welcome9[]> GetGameReviewsAsync(string gameId)
        {
            string URL = "https://api.opencritic.com/api/review/game/" + gameId;
            string urlParameters = "";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                // List data response.
                HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    return response.Content.ReadAsAsync<Welcome9[]>();  //Make sure to add a reference to System.Net.Http.Formatting.dll
                }
                else
                {
                    return null;
                }

            }
        }

        public Task<OCGame[]> GetGameIdAsync(string gameName)
        {
            string URL = "https://api.opencritic.com/api/game/search";
            string urlParameters = "?criteria=" + HttpUtility.UrlEncode(gameName);

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                // List data response.
                HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    return response.Content.ReadAsAsync<OCGame[]>();  //Make sure to add a reference to System.Net.Http.Formatting.dll
                }
                else
                {
                    return null;
                }

            }
        }
    }
}
