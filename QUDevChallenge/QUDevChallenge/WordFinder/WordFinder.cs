using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUDevChallenge.WordFinder
{
    public class WordFinder
    {
        private readonly bool[,] _visited;
        private readonly char[,] _matrix;

        public WordFinder(IEnumerable<string> matrix)
        {
            _matrix = ToCharMatrix(matrix);
            _visited = new bool[_matrix.GetLength(0), _matrix.GetLength(1)];
        }

        public IEnumerable<string> Find(IEnumerable<string> wordStream)
        {
            var wordCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            foreach (var word in wordStream.Distinct())
            {
                for (var i = 0; i < 5; i++)
                {
                    for(var j = 0; j < 5; j++) 
                    {
                        FindWord(word, word, i, j, wordCounts);
                    }                    
                }
            }

            return wordCounts.OrderByDescending(x => x.Value).Take(10).Select(x => x.Key);
        }

        private char[,] ToCharMatrix(IEnumerable<string> matrix)
        {
            var charMatrix = new char[matrix.Count(), matrix.First().Length];
            int row = 0;
            foreach (string rowString in matrix)
            {
                int column = 0;
                foreach (char item in rowString)
                {
                    charMatrix[row, column] = item;
                    column++;
                }
                row++; 
            }
            return charMatrix;
        }

        private void FindWord(string wordComplete, string word, int row, int col, Dictionary<string, int> wordCounts)
        {
            if (row < 0 || row >= _matrix.GetLength(0) || col < 0 || col >= _matrix.GetLength(1) || _visited[row, col])
            {
                return;
            }

            if (_matrix[row, col] == word[0])
            {
                if (word.Length == 1)
                {
                    if (wordCounts.ContainsKey(wordComplete))
                        wordCounts[wordComplete]++; // Found the word, increment count
                    else
                        wordCounts.Add(wordComplete, 1);
                }
                else
                {
                    _visited[row, col] = true;
                    FindWord(wordComplete, word.Substring(1), row + 1, col, wordCounts); // Search vertically
                    FindWord(wordComplete, word.Substring(1), row - 1, col, wordCounts); // Search vertically
                    FindWord(wordComplete, word.Substring(1), row, col + 1, wordCounts); // Search horizontally
                    FindWord(wordComplete, word.Substring(1), row, col - 1, wordCounts); // Search horizontally
                    _visited[row, col] = false;
                }
            }
        }
    }
}