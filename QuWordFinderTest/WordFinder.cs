using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace QuWordFinderTest
{
    public class WordFinder : IWordFinder
    {
        private readonly IEnumerable<string> _matrix;
        private IEnumerable<string> _matrixColumns;
        public WordFinder(IEnumerable<string> matrix)
        {
            try
            {
                ValidateMatrixSize(matrix);
                ValidateMatrixWhiteSpaces(matrix);
                _matrix = matrix;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            GetColumns(_matrix);
            List<(string, int)> searchResult = new List<(string, int)>();

            foreach (string word in wordstream)
            {
                searchResult.Add(GetWordOcurrences(word));   
            }
            return searchResult.Where(x => x.Item2 > 0).OrderByDescending(x => x.Item2).Take(10).Select(x => x.Item1).ToList();
        }

        public void ValidateMatrixSize(IEnumerable<string> matrix)
        {     
            if ((matrix.Min(x => x.Length) != matrix.Max(x => x.Length)) && matrix.Max(x => x.Length) > 64)
                throw new ArgumentException("Incorrect object size", "matrix");
        }

        public void ValidateMatrixWhiteSpaces(IEnumerable<string> matrix)
        {
            if (matrix.Where(x => x.Contains(" ")).Count() > 0)
                throw new ArgumentException("There are white spaces into the object", "matrix");
        }

        private void GetColumns(IEnumerable<string> matrix)
        {
            _matrixColumns = new List<string>();
            for (var j = 0; j < _matrix.Count(); j++)
            {
                string columnValue = null;
                for (var i = 0; i < _matrix.Count(); i++)
                {
                    columnValue += _matrix.ElementAt(i)[j];
                }
                ((List<string>) _matrixColumns).Add(columnValue);
            }
        }

        private int CountMatches(string matrixStream, string wordToFind)
        {
           return Regex.Matches(matrixStream, wordToFind).Count + Regex.Matches(string.Join("", matrixStream.Reverse()), wordToFind).Count;
        }

        private (string word, int wordOcurrences) GetWordOcurrences(string word)
        {
            int ocurrences = 0;
            if (!string.IsNullOrWhiteSpace(word) && !word.Contains(" "))
            {
                for (int i = 0; i < _matrix.Count(); i++)
                {
                    ocurrences += (CountMatches(_matrix.ElementAt(i), word) + CountMatches(_matrixColumns.ElementAt(i), word));
                }
            }
            return (word, ocurrences);
        }
    }
}
