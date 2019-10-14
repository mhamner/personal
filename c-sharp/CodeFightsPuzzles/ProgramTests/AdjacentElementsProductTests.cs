using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeFightsPuzzles;

namespace ProgramTests
{
    [TestClass]
    public class AdjacentAreaTests
    {
        [TestMethod]
        public void Pass_Letters_in_Array()
        {
            //Verify that we fail if we try and pass letters in the array
            string n = "A,B,C,D,E";
            string[] elements = n.Split(',');
                    
            //Test passes if we fail for Format Exception as expected
            Assert.ThrowsException<System.FormatException>(()
                => AdjacentElementsProduct.adjacentElementsProduct(elements));
            

        }
    }
}
