using System;
using System.Collections.Generic;

namespace QuWordFinderTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Word Finder!");
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
            IEnumerable<string> wordStream1 = new List<string>()
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
            IEnumerable<string> wordStream2 = new List<string>()
            {
                null,
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
            var result = wordFinder.Find(wordStream1);
        }
    }
}
