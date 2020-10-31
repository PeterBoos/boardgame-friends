using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BGF.App.Services
{
    public class BggWebRequests
    {
        static async Task FetchUserCollection(string bggUsername)
        {
            var httpClient = HttpClientFactory.Create();

            var url = "https://www.boardgamegeek.com/xmlapi2/collection?username=" + bggUsername + "&own=1";
            var data = await httpClient.GetStringAsync(url);
            HttpResponseMessage responseMsg = await httpClient.GetAsync(url);

            if (responseMsg.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                do
                {
                    Console.WriteLine("Web request ACCEPTED. Pausing for 3 seconds to fetch queued web request later.");
                    System.Threading.Thread.Sleep(3000);

                    responseMsg = await httpClient.GetAsync(url);
                } while (responseMsg.StatusCode == System.Net.HttpStatusCode.Accepted);
            }

            if (responseMsg.IsSuccessStatusCode)
            {
                string msg = await responseMsg.Content.ReadAsStringAsync();
                Console.WriteLine(msg);
            }

            //Console.WriteLine("Hello World!");
        }
    }
}
