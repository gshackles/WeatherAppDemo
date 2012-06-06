using System;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace WeatherCore
{
    public class WeatherService
    {
        public void GetWeather(string zipCode, Action<WeatherConditions> callback)
        {
            string url = "http://www.google.com/ig/api?weather=" + Uri.EscapeUriString(zipCode);
            var client = new WebClient();
            client.DownloadStringCompleted += (sender, e) =>
            {
                var conditions = parseResponse(e.Result);

                callback(conditions);
            };

            client.DownloadStringAsync(new Uri(url));
        }

        private WeatherConditions parseResponse(string response)
        {
            var conditions =
                    XElement
                        .Parse(response)
                        .Descendants("current_conditions")
                        .First();

            Func<string, string> getData =
                name => conditions.Element(name).Attribute("data").Value;

            return new WeatherConditions
            {
                Temperature = int.Parse(getData("temp_f")),
                Description = getData("condition")
            };
        }
    }
}
