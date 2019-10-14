using System;

namespace CodeFightsPuzzles
{
    ///---------------------------------------------------------------------------------
    ///   Namespace:    CodeFightsPuzzles
    ///   Class:        Program
    ///   Author:       Mark Hamner
    ///   Description:  This is a console application that demonstrates several examples of
    ///                 Code Fights (now called Code Signal) puzzles I completed
    ///   Notes:        The puzzles are:
    ///                 1.  Check Palindrome
    ///                 2.  Adjacent Elements Product
    ///                 3.  Shape Area (of n-interesting polygon)
    ///---------------------------------------------------------------------------------
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please choose an app from the menu below " +
                "or enter anything else to exit.  \n");
            Console.WriteLine("1 - Check Palindrome");
            Console.WriteLine("2 - Adjacent Elements Product");
            Console.WriteLine("3 - Shape Area");
            Console.WriteLine("");
            string menuChoice = Console.ReadLine();

            switch(menuChoice)
            {
                //Case 1:  Run Check Palindrome
                case "1":
                    Console.WriteLine("Check Palindrome:  Please enter a string: ");
                    string s = Console.ReadLine();
                    bool palindrome = CheckPalindrome.checkPalindrome(s);
                    if(palindrome)
                    {
                        Console.WriteLine(s + " is a palindrome!");
                    }
                    else
                    {
                        Console.WriteLine(s + " is not a palindrome.");
                    }
                    break;

                //Case 2:  Run Adjacent Elements Product
                case "2":
                    Console.WriteLine("Adjacent Elements Product:  Please enter a list of numbers " +
                        "separate by commas.");
                    string n = Console.ReadLine();

                    //Split the values entered by commmas and load them into an array
                    string[] elements = n.Split(',');
                    int i = AdjacentElementsProduct.adjacentElementsProduct(elements);
                    Console.WriteLine("The highest product of 2 adjacent elements is " + i.ToString());
                    break;

                //Case 3:  Run Shape Area
                case "3":
                    Console.WriteLine("Shape Area:  Please enter the number of sides for our polygon: ");
                    int sides = Convert.ToInt32(Console.ReadLine());
                    int area = ShapeArea.shapeArea(sides);
                    Console.WriteLine("The area of your polygon is " + area.ToString());
                    break;

                //Default:  Exit
                default:
                    Console.WriteLine("\n Exiting, thanks for playing!");
                    break;


            }
        }
    }
}
