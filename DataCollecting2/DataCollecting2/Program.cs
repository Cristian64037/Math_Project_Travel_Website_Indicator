using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataCollecting2
{
    class Program
    {
        static async Task Main(string[] args)
        {
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://skyscanner44.p.rapidapi.com/search-extended?adults=1&origin=ORD&destination=PHX&departureDate=2022-10-11&currency=USD&duration=50&startFrom=00%3A00&arriveTo=23%3A59&returnStartFrom=00%3A00&returnArriveTo=23%3A59"),
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
