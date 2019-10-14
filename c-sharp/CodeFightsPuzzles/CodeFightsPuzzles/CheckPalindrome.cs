using System;
namespace CodeFightsPuzzles
{
    public static class CheckPalindrome
    {
        /// <summary>
        /// This checks to see if the string is a panlindrome
        /// </summary>
        /// <param name="inputString">String to check to see if its a palindrome</param>
        /// <returns>boolean indicating true / false</returns>
        public static bool checkPalindrome(string inputString)
        {
            //Check to see if the inputString is a paindrome (the same forwards and backwards)
            string reversedString = "";

            //Set up a reverse loop to reverse the string
            for (int i = (inputString.Length); i > 0; i--)
            {
                //Substring at i - 1 because length is not zero based but position is
                reversedString += inputString.Substring((i - 1), 1);
            }
            //Compare the reverse string to the input string and return the result

            return (reversedString == inputString) ? true : false;
        }

    }
}
