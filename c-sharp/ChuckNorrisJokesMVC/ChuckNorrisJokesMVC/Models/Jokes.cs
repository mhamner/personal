using System;
using System.Net;
using Newtonsoft.Json;

namespace ChuckNorrisJokesMVC.Models
{
    public class Jokes
    {
        private const string ChuckNorrisURL =
            "https://api.chucknorris.io/jokes/random";


        public JokeModel GetJoke()
        {
            //Sample API Call:
            //  https://api.chucknorris.io/jokes/random

            //Wrap a using around our WebClient since it implements iDisposable and we don't want it hanging around

            JokeModel cnJoke = new JokeModel();
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    //Call the Chuck Norris Joke API and save the result
                    string returnedJson = webClient.DownloadString(ChuckNorrisURL);
                    cnJoke = JsonConvert.DeserializeObject<JokeModel>(returnedJson);

                }
                catch (Exception ex)
                {
                    //If something goes wrong, return an Error string
                    cnJoke.value = "ERROR: " + ex.ToString();
                }
                return cnJoke;
            }

        }

    }
}
