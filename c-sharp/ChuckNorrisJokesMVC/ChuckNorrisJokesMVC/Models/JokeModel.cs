using System;
namespace ChuckNorrisJokesMVC.Models
{
    /// <summary>
    /// The model class for our Chuck Norris Joke
    /// </summary>
    /// <remarks>
    /// See https://rapidapi.com/matchilling/api/chuck-norris
    /// </remarks>
    public class JokeModel
    {
        public string icon_url;
        public string id;
        public string url;
        public string value;
    }
}
