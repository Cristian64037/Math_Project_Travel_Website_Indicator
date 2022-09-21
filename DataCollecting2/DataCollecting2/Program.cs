using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using Newtonsoft.Json.Linq;


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
                //dynamic stuff = JObject.Parse(body);

                //string name = stuff.itineraries.id;
                //Console.WriteLine(name);
                //Root myDeserializedClass = (Root)JsonConvert.DeserializeObject(body);




            }



		}

    }
    public class Agent
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool is_carrier { get; set; }
        public string update_status { get; set; }
        public bool optimised_for_mobile { get; set; }
        public bool live_update_allowed { get; set; }
        public string rating_status { get; set; }
        public double rating { get; set; }
        public int feedback_count { get; set; }
        public RatingBreakdown rating_breakdown { get; set; }
    }

    public class Carriers
    {
        public List<Marketing> marketing { get; set; }
        public string operationType { get; set; }
    }

    public class Context
    {
        public string status { get; set; }
        public string sessionId { get; set; }
    }

    public class Destination
    {
        public int id { get; set; }
        public string name { get; set; }
        public string displayCode { get; set; }
        public string flightPlaceId { get; set; }
        public Parent parent { get; set; }
        public string type { get; set; }
    }

    public class Itineraries
    {
        public List<Result> results { get; set; }
    }

    public class Leg
    {
        public string id { get; set; }
        public Origin origin { get; set; }
        public Destination destination { get; set; }
        public int durationInMinutes { get; set; }
        public int stopCount { get; set; }
        public bool isSmallestStops { get; set; }
        public DateTime departure { get; set; }
        public DateTime arrival { get; set; }
        public int timeDeltaInDays { get; set; }
        public Carriers carriers { get; set; }
        public List<Segment> segments { get; set; }
    }

    public class Marketing
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class MarketingCarrier
    {
        public int id { get; set; }
        public string name { get; set; }
        public string alternate_di { get; set; }
        public int allianceId { get; set; }
    }

    public class OperatingCarrier
    {
        public int id { get; set; }
        public string name { get; set; }
        public string alternate_di { get; set; }
        public int allianceId { get; set; }
    }

    public class Origin
    {
        public int id { get; set; }
        public string name { get; set; }
        public string displayCode { get; set; }
        public string flightPlaceId { get; set; }
        public Parent parent { get; set; }
        public string type { get; set; }
    }

    public class Parent
    {
        public string flightPlaceId { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }

    public class Price
    {
        public double amount { get; set; }
        public string update_status { get; set; }
        public DateTime last_updated { get; set; }
        public int quote_age { get; set; }
    }

    public class PricingOption
    {
        public List<Agent> agents { get; set; }
        public Price price { get; set; }
        public string url { get; set; }
    }

    public class RatingBreakdown
    {
        public double reliable_prices { get; set; }
        public double clear_extra_fees { get; set; }
        public double customer_service { get; set; }
        public double ease_of_booking { get; set; }
        public double other { get; set; }
    }

    public class Result
    {
        public string id { get; set; }
        public List<Leg> legs { get; set; }
        public List<PricingOption> pricing_options { get; set; }
        public string deeplink { get; set; }
    }

    public class Root
    {
        public Itineraries itineraries { get; set; }
        public Context context { get; set; }
    }

    public class Segment
    {
        public string id { get; set; }
        public Origin origin { get; set; }
        public Destination destination { get; set; }
        public DateTime departure { get; set; }
        public DateTime arrival { get; set; }
        public int durationInMinutes { get; set; }
        public string flightNumber { get; set; }
        public MarketingCarrier marketingCarrier { get; set; }
        public OperatingCarrier operatingCarrier { get; set; }
    }
}
