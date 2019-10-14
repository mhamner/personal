using System;
namespace CodeFightsPuzzles
{
    public static class ShapeArea
    {
        /// <summary>
        /// Find the area of an n-interesting polygon with n number of sides, each having a length of 1
        /// </summary>
        /// <param name="n">The number of sides in the n-interesting polygon</param>
        /// <returns>int containing the area of the polygon</returns>
        public static int shapeArea(int n)
        {
            /*shapeArea:  Below we will define an n-interesting polygon.
             Your task is to find the area of a polygon for a given n.
            
            A 1-interesting polygon is just a square with a side of length 1.
            An n-interesting polygon is obtained by taking the n - 1-interesting polygon and
            appending 1-interesting polygons to its rim, side by side. 
            
            Mark:  There will be 2 steps here.
            1.  Call the method recursively to get the area of the (n-1) polygon
            2.  Then determine the number of squares to add.  The formula for that will be
            SquaresToAdd = (n*4) <-- number of sides - 4 <-- amount of overlap
            So (n*4) - 4
            */

            //Get the shapeArea for the previous one first, then add the current shape area

            //First, call shapeArea recursively to get the area of (n-1)
            int nMinusOneArea = 1;
            //If included for edge case so we dont drop to 0 on the n=1
            if (n > 1)
            {
                nMinusOneArea = shapeArea(n - 1);
            }
            //Now determine the number of squares to add using (n*4) - 4
            int squaresToAdd = (n * 4) - 4;

            //Now return the sum of the squares to add plus the previous area
            return nMinusOneArea + squaresToAdd;
        }

        public class InvalidNumberException : Exception
        {
            public InvalidNumberException(string message) : base(message)
            {

            }
        }

    }
}
