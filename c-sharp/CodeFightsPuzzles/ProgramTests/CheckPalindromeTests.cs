using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeFightsPuzzles;

namespace ProgramTests
{
    [TestClass]
    public class CheckPalindromeTests
    {
        
        [TestMethod]
        public void Test_Isnt_a_Palindrome()
        {
            string s = "notapalindrome";
            //Assert that this should be false; test will fail if it comes back true
            Assert.IsFalse(CheckPalindrome.checkPalindrome(s));
        }

        [TestMethod]
        public void Test_Is_a_Palindrome()
        {
            string s = "bob";
            //Assert that this should be true; test will fail if it comes back false
            Assert.IsTrue(CheckPalindrome.checkPalindrome(s));
        }

    }
}
