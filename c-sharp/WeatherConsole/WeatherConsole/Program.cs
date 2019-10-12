using System;
using System.Net;
using Newtonsoft.Json.Linq;

namespace WeatherConsole
{
    ///---------------------------------------------------------------------------------
    ///   Namespace:    WeatherConsole
    ///   Class:        Program
    ///   Author:       Mark Hamner
    ///   Description:  This is a console application that demonstrates calling a public API
    ///   Notes:        I call the Open Weather Map API (https://openweathermap.org/api) to get the weather
    ///                 at the zip entered by the user
    ///---------------------------------------------------------------------------------
    class Program
    {
        private const string API_KEY = "e80758081f2bf960047caffb2c97ab3a";
        private const string CurrentWeatherUrl =
            "http://api.openweathermap.org/data/2.5/weather?" +
            "@QUERY@=@LOC@&units=imperial&APPID=" +
            API_KEY;

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your zip to get the weather: ");
            string myZip = Console.ReadLine();

            //Get the latest Forecast in JSON
            string forecastJson = GetForecastByZip(myZip);

            //As long as we didn't get an error, show our weather
            if (forecastJson.Substring(0,5) != "ERROR")
            {
                //Parse out the current conditions and current temp
                //Note:  Of course this parsing could have been done directly on the Console.WriteLine,
                //  but I've done a few this way just for readability and ease of stepping through
                JToken token = JObject.Parse(forecastJson);
                string currentWeather = (string)token.SelectToken("weather[0].description");
                string currentTemperature = (string)token.SelectToken("main.temp");

                //Write out our weather
                Console.WriteLine("Your current location: " + (string)token.SelectToken("name"));
                Console.WriteLine("Your current conditions: " + currentWeather);
                Console.WriteLine("Your current temperature: " + currentTemperature);
                Console.WriteLine("");
                Console.WriteLine("Complete Weather Data (JSON): \n" + forecastJson);
            }
            else
            {
                Console.WriteLine("Error getting weather - " + forecastJson);
            }

        }

        /// <summary>
        /// Get the forecast by passing the zip
        /// </summary>
        /// <param name="zip">zip code</param>
        /// <returns>JSON string containing forecase data</returns>
        private static string GetForecastByZip(string zip)
        {
            //Sample API Call:
            //  api.openweathermap.org/data/2.5/weather?zip=94040,us
            //  Please note if country is not specified then the search works for USA as a default

            //Format our URL to tell it we are searching by zip and pass the zip
            string url = CurrentWeatherUrl.Replace("@QUERY@", "zip");
            url = url.Replace("@LOC@", zip);

            //Wrap a using around our WebClient since it implements iDisposable and we don't want it hanging around
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    //Call the Open Weather API and save the result
                    string returnedJson = webClient.DownloadString(url);
                    return returnedJson;

                }
                catch (Exception ex)
                {
                    //If something goes wrong, return an Error string
                    return "ERROR: " + ex.ToString();
                }
            }

        }
    }
}

