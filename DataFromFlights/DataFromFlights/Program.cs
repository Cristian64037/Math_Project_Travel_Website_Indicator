using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataFromFlights
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://skyscanner44.p.rapidapi.com/search?adults=1&origin=ORD&destination=JFK&departureDate=2022-09-30&currency=USD"),
				Headers =
	{
		{ "X-RapidAPI-Key", "b986f47273msh212c152bac3cbe7p14df26jsn833e94d7cbe0" },
		{ "X-RapidAPI-Host", "skyscanner44.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				Console.WriteLine(body);
			}
		}
    }
}
