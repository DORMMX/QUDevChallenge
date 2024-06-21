using Microsoft.VisualStudio.TestTools.UnitTesting;
using QUDevChallenge.WordFinder;
using System.Collections.Generic;
using System.Linq;

namespace UTWordFinder
{
    [TestClass]
    public class Matrix
    {
        //Mock
        private readonly WordFinder _wordFinder;
        public Matrix()
        {
            List<string> matrix =
            [
                "abcdc",
                "fgwio",
                "chill",
                "pqnsd",
                "uvdxy"
            ];
            _wordFinder = new(matrix);
        }

        [TestMethod]
        public void FindAWord()
        {
            List<string> words = [
                "cold"               
            ];

            var result = _wordFinder.Find(words);

            Assert.IsTrue(result.Count() == 1);
        }

        [TestMethod]
        public void FindTwoWords()
        {
            List<string> words = [
                "cold",
                "chill"
            ];

            var result = _wordFinder.Find(words);

            Assert.IsTrue(result.Count() == 2);
        }

        [TestMethod]
        public void EmptySearch()
        {
            List<string> words = [
                "cole",
                "chilt"
            ];

            var result = _wordFinder.Find(words);

            Assert.IsTrue(condition: !result.Any());
        }
    }
}
