using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace QuWordFinderTest.Tests
{
    [TestFixture()]
    public class WordFinderTests
    {
        [Test()]
        public void FindTest()
        {
            IEnumerable<string> matrix = new List<string>() {
                "FNLIVOMOTUAM",
                "AKQYRPNOIVAO",
                "QTRENHPAKNTT",
                "NZIYCANTOIEO",
                "EYZKUVKELTLC",
                "ROOHXILLUACI",
                "TRENXOFCCPIC",
                "MEZADNLIIOCL",
                "MOTOLCFCHTOE",
                "MMOCRABIEUTT",
                "FTFAVVJBVAOA",
                "CARROORRACMN"
            };
            IEnumerable<string> wordStream = new List<string>()
            {
                "AVION",
                "CARRO",
                "VEHICULO",
                "MOTO",
                "MOTOCICLETA",
                "AUTOMOVIL",
                "TREN",
                "BARCO",
                "BICICLETA",
                "AUTO",
                "PATIN"
            };
            IWordFinder wordFinder = new WordFinder(matrix);
            Stopwatch sw = Stopwatch.StartNew();
            var result = wordFinder.Find(wordStream);
            sw.Stop();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<string>>(result);
            Assert.IsTrue(((List<string>)result).Count == 10);
            Assert.IsTrue(sw.ElapsedMilliseconds <= 100);
        }

        [Test()]
        public void FindTestWithSomeDataInputIsNullOrEmptyOrWhiteSpace()
        {
            IEnumerable<string> matrix = new List<string>() {
                "FNLIVOMOTUAM",
                "AKQYRPNOIVAO",
                "QTRENHPAKNTT",
                "NZIYCANTOIEO",
                "EYZKUVKELTLC",
                "ROOHXILLUACI",
                "TRENXOFCCPIC",
                "MEZADNLIIOCL",
                "MOTOLCFCHTOE",
                "MMOCRABIEUTT",
                "FTFAVVJBVAOA",
                "CARROORRACMN"
            };
            IEnumerable<string> wordStream = new List<string>()
            {
                null,
                string.Empty,
                " ",
                "VEHICULO",
                "MOTO",
                "MOTOCICLETA",
                "AUTOMOVIL",
                "TREN",
                "BARCO",
                "BICICLETA",
                "AUTO",
                "PATIN"
            };
            IWordFinder wordFinder = new WordFinder(matrix);
            Stopwatch sw = Stopwatch.StartNew();
            var result = wordFinder.Find(wordStream);
            sw.Stop();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<string>>(result);
            Assert.IsTrue(((List<string>)result).Count == 9);
            Assert.IsTrue(sw.ElapsedMilliseconds <= 100);
        }

        
        [Test()]
        public void FindTestAllDataInputIsNull()
        {
            IEnumerable<string> matrix = new List<string>() {
                "FNLIVOMOTUAM",
                "AKQYRPNOIVAO",
                "QTRENHPAKNTT",
                "NZIYCANTOIEO",
                "EYZKUVKELTLC",
                "ROOHXILLUACI",
                "TRENXOFCCPIC",
                "MEZADNLIIOCL",
                "MOTOLCFCHTOE",
                "MMOCRABIEUTT",
                "FTFAVVJBVAOA",
                "CARROORRACMN"
            };
            IEnumerable<string> wordStream = new List<string>();
            IWordFinder wordFinder = new WordFinder(matrix);
            Stopwatch sw = Stopwatch.StartNew();
            var result = wordFinder.Find(wordStream);
            sw.Stop();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<string>>(result);
            Assert.IsTrue(((List<string>)result).Count == 0);
            Assert.IsTrue(sw.ElapsedMilliseconds <= 100);
        }
    }
}