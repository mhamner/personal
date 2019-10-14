using Microsoft.AspNetCore.Mvc;
using ChuckNorrisJokesMVC.Models;
using Newtonsoft.Json;


namespace ChuckNorrisJokesMVC.Controllers
{
    public class JokeController : Controller
    {
        private static Jokes _jokes = new Jokes();
        private JokeModel jm = new JokeModel();
                
        // GET: /<controller>/
        //Note that the Action method name below will correspond to the actual page in the Views folder
        public IActionResult JokePage()
        {
            //Call our GetJoke method in our Jokes class and save the result in our Joke Model
            jm = _jokes.GetJoke();
            return View(jm);    //return the joke model
        }
    }
}
