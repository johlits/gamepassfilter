using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GamePassFilter.Data.QuickType;

namespace GamePassFilter.Data
{
    public class ProductService
    {
        public Task<Welcome8> GetProductsAsync(List<string> ids)
        {
            string URL = "https://displaycatalog.mp.microsoft.com/v7.0/products";
            string urlParameters = "?bigIds=" + string.Join(',', ids) + "&market=US&languages=en-us&MS-CV=DGU1mcuYo0WMMp+F.1";

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
                    return response.Content.ReadAsAsync<Welcome8>();  //Make sure to add a reference to System.Net.Http.Formatting.dll
                }
                else
                {
                    return null;
                }

            }
        }
    }
}
