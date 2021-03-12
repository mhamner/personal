using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Simon
{
    class Program
    {
        //const int randomNumberUpperBounds = 11;

        static void Main(string[] args)
        {
           //Set up the config to pull from the appsettings.json file
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);
            IConfiguration config = builder.Build();
          
            //Get the various settings from appsettings.json
            int randomNumberUpperBounds = Convert.ToInt32(config["RandomNumberUpperBounds"]);
            int timeNumberRemainsOnScreenInMilliseconds = Convert.ToInt32(config["TimeNumberRemainsOnScreenInMilliseconds"]);

            List<int> numberList = new List<int>();
            var rand = new Random();
            bool stillPlaying = true;         
            int score = 0;
            
            Console.WriteLine("Welcome to Simon!  Press any key to begin.");
            Console.ReadKey();
           
            while(stillPlaying)
            {
                Console.Clear();

                //Get the next random number and add it to the list            
                numberList.Add(rand.Next(randomNumberUpperBounds));
          
                //Show the user the whole list for a brief moment each
                ShowTheList(ref numberList, ref timeNumberRemainsOnScreenInMilliseconds);

                //Now let's see how they did!  Loop through the whole list and ask them to tell you all the numbers
                CheckTheirMemory(ref numberList, ref score, ref stillPlaying);
            }

            GameOver(ref numberList, ref score);
        }

        /// <summary>
        /// Shows the current list to the user, with a delay between each number
        /// </summary>
        /// <param name="numberList">Current list of numbers to memorize</param>
        private static void ShowTheList(ref List<int> numberList, ref int timeNumberRemainsOnScreenInMilliseconds)
        {
            foreach(int n in numberList)
            {
                Console.Clear();
                Console.WriteLine($"**** {n} ****");
                Task.Delay(timeNumberRemainsOnScreenInMilliseconds).Wait();
            }
        }

        /// <summary>
        /// Prompts the user to enter the list of numbers and checks their entries against the current list
        /// </summary>
        /// <param name="numberList">Current list of numbers to memorize</param>
        /// <param name="score">Current score</param>
        /// <param name="stillPlaying">Indicates whether the player is still playing</param>
        private static void CheckTheirMemory(ref List<int> numberList, ref int score, ref bool stillPlaying)
        {
            int count = 0;
            foreach (int n in numberList)
            {
                count++;
                Console.Clear();
                Console.WriteLine($"Enter number {count}: ");
                string answer = Console.ReadLine();
                if (answer.TrimEnd() == n.ToString())
                {
                    score++;
                }
                else
                {               
                    stillPlaying = false;
                    break;
                }
            }
        }

        /// <summary>
        /// Sends the final sequence to the user, along with their final score, and ends the game
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="finalScore"></param>
        private static void GameOver(ref List<int> numberList, ref int score)
        {
            Console.WriteLine("Incorrect answer.  The correct sequence is: ");
            foreach(int s in numberList)
            {
                Console.Write($"{s}   ");
            }
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Game over.  Thanks for playing!  Your final score is {score}.  Press any key to end.");
            Console.ReadKey();             
        }
    }
}
