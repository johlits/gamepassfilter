using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GamePassFilter.Data
{
    public class GameService
    {
        public Task<IEnumerable<Game>> GetGamesAsync()
        {
            string URL = "https://catalog.gamepass.com/sigls/v2";
            string urlParameters = "?id=fdd9e2a7-0fee-49f6-ad69-4354098401ff&language=en-us&market=US";

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
                    return response.Content.ReadAsAsync<IEnumerable<Game>>();  //Make sure to add a reference to System.Net.Http.Formatting.dll
                }
                else
                {
                    return null;
                }

            }
        }
    }
}
