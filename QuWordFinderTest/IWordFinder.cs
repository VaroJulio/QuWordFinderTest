using System.Collections.Generic;

namespace QuWordFinderTest
{
    public interface IWordFinder
    {
        public IEnumerable<string> Find(IEnumerable<string> wordstream);
        public void ValidateMatrixSize(IEnumerable<string> matrix);
        public void ValidateMatrixWhiteSpaces(IEnumerable<string> matrix);
    }
}
