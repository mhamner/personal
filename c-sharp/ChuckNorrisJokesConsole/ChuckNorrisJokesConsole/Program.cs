using System;
using System.Net;
using Newtonsoft.Json.Linq;

namespace ChuckNorrisJokesConsole
{
    ///---------------------------------------------------------------------------------
    ///   Namespace:    ChuckNorrisJokesConsole
    ///   Class:        Program
    ///   Author:       Mark Hamner
    ///   Description:  This is a console application that demonstrates calling a public API to get
    ///                 Chuck Norris jokes :) 
    ///---------------------------------------------------------------------------------
    class Program
    {        
        private const string ChuckNorrisURL =
            "https://api.chucknorris.io/jokes/random";

        static void Main(string[] args)
        {
            string wantToHearMore = "Y";

            while (wantToHearMore.ToUpper() == "Y")
            {
                Console.WriteLine("Would you like to hear about Chuck Norris?  [Y/N]: ");
                wantToHearMore = Console.ReadLine();

                //If the user made the (rather unwise) decision to stop, get out of the loop immediately
                if(wantToHearMore.ToUpper() == "N")
                {
                    break;
                }

                //Call our method to get a Chuck Norris joke
                string chuckNorrisJokeJSON = GetChuckNorrisJoke();
                //Parse out the Joke as long as we didn't get an error
                if (chuckNorrisJokeJSON.Substring(0, 5) != "ERROR")
                {

                    JToken token = JObject.Parse(chuckNorrisJokeJSON);

                    //Write out the joke
                    Console.WriteLine("Did you hear about Chuck Norris?? " + (string)token.SelectToken("value"));
                    Console.WriteLine("");
                    Console.WriteLine("Complete Chuck Norris Joke Data (JSON): \n" + chuckNorrisJokeJSON);
                }
                else
                {
                    Console.WriteLine("Chuck Norris doesn't like Errors! " + chuckNorrisJokeJSON);
                }
            }

            Console.WriteLine("Chuck Norris doesn't like you stopping!");

        }

        /// <summary>
        /// Get a Chuck Norris Joke
        /// </summary>
        /// <returns>JSON string containing a Chuck Norris joke</returns>
        private static string GetChuckNorrisJoke()
        {
            //Sample API Call:
            //  https://api.chucknorris.io/jokes/random
            
            //Wrap a using around our WebClient since it implements iDisposable and we don't want it hanging around
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    //Call the Chuck Norris Joke API and save the result
                    string returnedJson = webClient.DownloadString(ChuckNorrisURL);
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
