using System;
namespace CodeFightsPuzzles
{
    public static class AdjacentElementsProduct
    {
        /// <summary>
        /// Given an array of integers, find the pair of adjacent elements that has
        /// the largest product and return that product.
        /// </summary>
        /// <param name="inputArray">An arry of strings</param>
        /// <returns>The highest product of any adjacent integers in the input array</returns>
        public static int adjacentElementsProduct(string[] inputArray)
        {
            int product = 0;
            int highestProduct = -1000;  //start with -1000 as per Code Fights constraint

            //Loop through the input array (using (length - 1 so we don't run past the end))
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                //Get the product of the 2 adjacenet elements
                product = Convert.ToInt32(inputArray[i]) * Convert.ToInt32(inputArray[i + 1]);

                //If the product is the highest so far, its the new king of the hill
                if (product > highestProduct)
                {
                    highestProduct = product;
                }
            }
            return highestProduct;
        }
    }
}
