using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Linguistics.Core.Test
{
    [TestClass]
    public class PatternTest
    {
        [TestMethod]
        public void NamePatternTest_Ivan()
        {
            // Arrange
            var name = "Иван";
            var service = new NamePatternService();

            // Act
            var pattern = service.GetPattern(name);

            // Assert
            Assert.AreEqual("Иван*", pattern);
        }

        [TestMethod]
        public void NamePatternTest_Arkady()
        {
            // Arrange
            var name = "Аркадий";
            var service = new NamePatternService();

            // Act
            var pattern = service.GetPattern(name);

            // Assert
            Assert.AreEqual("Аркади*", pattern);
        }

        [TestMethod]
        public void NamePatternTest_Vladimir()
        {
            // Arrange
            var name = "Владимир";
            var service = new NamePatternService();

            // Act
            var pattern = service.GetPattern(name);

            // Assert
            Assert.AreEqual("Владимир*", pattern);
        }


        [TestMethod]
        public void NamePatternTest_Igor()
        {
            // Arrange
            var name = "Игорь";
            var service = new NamePatternService();

            // Act
            var pattern = service.GetPattern(name);

            // Assert
            Assert.AreEqual("Игор*", pattern);
        }

        public void PatternNames(IEnumerable<string> names)
        {
            foreach (var name in names)
            {
                IDeclensionService service = new DeclensionService();
                INamePatternService pattern = new NamePatternService();
                var patternName = pattern.GetPattern(name);

                var result = service.DeclineFirstName(name);

                Console.WriteLine("{0}", patternName);

                var text = false;
                if (text)
                {
                    Console.WriteLine();

                    Console.WriteLine("Я {0}.", result[Case.Nominative]);
                    Console.WriteLine("Нет {0}.", result[Case.Genitive]);
                    Console.WriteLine("Дать {0}.", result[Case.Dative]);
                    Console.WriteLine("Вижу {0}.", result[Case.Accusative]);
                    Console.WriteLine("Творить {0}.", result[Case.Instrumental]);
                    Console.WriteLine("Думать о {0}.", result[Case.Prepositional]);


                    Console.WriteLine("-----");
                }
            }
        }

        [TestMethod]
        public void PatternBoyNames()
        {
            const string resourceName = "Resources.RussianBoyNames.txt";
            PatternNames(TestUtils.GetResourceLines(resourceName));
        }

        [TestMethod]
        public void NamePatternFunctionalTest_AllNames()
        {
            // Arrange
            const string resourceName = "Resources.RussianBoyNames.txt";
            var names = TestUtils.GetResourceLines(resourceName);

            // Act, Assert
            foreach (var name in names)
            {
                NamePatternTest(name);
            }
        }

        public static void NamePatternTest(string name)
        {
            // Arrange
            var namePatternService = new NamePatternService();
            var declensionService = new DeclensionService();

            // Act
            var pattern = namePatternService.GetPattern(name);

            // Assert
            foreach (var nameCaseValue in declensionService.DeclineFirstName(name).Values)
            {
                Assert.IsTrue(namePatternService.IsNameMatched(pattern, nameCaseValue));
            }
        }

        public bool FindName(string firstName, string line)
        {
            // Arrange
            var namePatternService = new NamePatternService();
            var declensionService = new DeclensionService();

            firstName = namePatternService.GetPattern(firstName);
            firstName = firstName.Substring(0, firstName.Length - 1);


            // Act n' Assert
            if (line.StartsWith(firstName, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [TestMethod]
        public
        void NameInLineYES_Ivan()
        {
            var firstName = "Иван";
            var line = "ИваНов";
            Assert.IsTrue
                (
                    FindName(firstName, line));
        }

        [TestMethod]
        public
        void NameInLineNO_Ivan()
        {
            var firstName = "Иван";
            var line = "АИванов";
            Assert.IsFalse
                (
                    FindName(firstName, line));
        }

        [TestMethod]
        public
        void NameInLineYES_Avram()
        {
            var firstName = "Аврам";
            var line = "Аврамовы";
            Assert.IsTrue
                (
                    FindName(firstName, line));
        }

        [TestMethod]
        public
        void NameInLineNO_Avram()
        {
            var firstName = "Аврам";
            var line = "213gasdАврамASd";
            Assert.IsFalse
                (
                    FindName(firstName, line));
        }

        [TestMethod]
        public
        void NameInLineYES_Andrey()
        {
            var firstName = "Андрей";
            var line = "Андреями";
            Assert.IsTrue
                (
                    FindName(firstName, line));
        }

        [TestMethod]
        public
        void NameInLineNO_Andrey()
        {
            var firstName = "Андрей";
            var line = "566ААндрея1020";
            Assert.IsFalse
                (
                    FindName(firstName, line));
        }

        [TestMethod]
        public
        void NameInLineYES_Nikolay()
        {
            var firstName = "Николай";
            var line = "Николая";
            Assert.IsTrue(FindName(firstName, line));
        }

        [TestMethod]
        public
        void NameInLineNO_Nikolay()
        {
            var firstName = "Николай";
            var line = "*(?!?Николай(!*?";
            Assert.IsFalse(FindName(firstName, line));
        }

        [TestMethod]
        public void MakeDictionary()
        {
            // Arrange
            string filePath = @"C:\kir\dictionary\NameValue.dic";

            if (!File.Exists(filePath))
            {
                throw new Exception("Can't open file");
            }

            var namePatternService = new NamePatternService();
            var count = 0;
            var errException = 0;

            // Act

            var names = File.ReadAllLines(filePath)
                .Select(p => p.ToLowerInvariant())
                .Where(p => p.Length > 3)
                .Distinct()
                .OrderBy(x => x);

            foreach (var name in names)
            {
                if (!name.StartsWith("#"))
                {
                    try
                    {
                        count++;
                        Console.WriteLine(namePatternService.GetPattern(name));
                    }
                    catch (Exception)
                    {
                        errException++;
                    }
                }
            }

            // Assert
            Assert.AreEqual(errException, count);
        }

        [TestMethod]
        public void CountRepeatNames()
        {
            // Arrange
            var namePatternService = new NamePatternService();
            const string filePath = @"C:\kir\dictionary\Patterns.txt";
            var patterns = File.ReadAllLines(filePath).Distinct().ToArray();

            var fileLength = patterns.Length;
            var totalAbsorptionPatternsCount = 0;

            // Act
            var uniquePatterns = new Collection<string>();

            for (var i = 0; i < fileLength; i++)
            {
                var absorbedPatterns = new Collection<string>();

                for (var k = 0; k < fileLength; k++)
                {
                    if (i == k) continue;

                    if (namePatternService.IsNameMatched(patterns[k], patterns[i]))
                    {
                        absorbedPatterns.Add(patterns[k]);
                        totalAbsorptionPatternsCount++;
                    }
                }
                Console.WriteLine("{0} - {1} {2}", patterns[i], absorbedPatterns.Count,
                    String.Join(", ", absorbedPatterns));

                if (absorbedPatterns.Count == 0)
                {
                    uniquePatterns.Add(patterns[i]);
                }
            }

            File.WriteAllLines(@"C:\kir\dictionary\UniquePatterns.txt", uniquePatterns);

            // Assert
            Assert.AreEqual(fileLength, totalAbsorptionPatternsCount);
        }

        [TestMethod]
        public void SortDicionary()
        {
            // Arrange
            const string resourceName = "Resources.PatternDictionary.txt";
            var names = TestUtils.GetResourceLines(resourceName);
            var namePatternService = new NamePatternService();
            var count = 0;

            // Act, Assert

            names = names.OrderBy(x => x);

            foreach (var name in names)
            {
                Console.WriteLine(name);
                count++;
            }
            //Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void CheckSubstring()
        {
            // Arrange
            const string resourceName = "Resources.PatternDictionary.txt";
            var names = TestUtils.GetResourceLines(resourceName);
            string subname = ")(";
            var changeName = 0;


            var loweCaseStrings = (new string[] {"sfvgxcv"})
                .Select(p => p.ToLowerInvariant())
                .Where(p => p.Length > 3)
                .Distinct();

            // Act
            foreach (var name in names)
            {
                var shortName = name.Substring(0, name.Length - 1);

                if (shortName.IndexOf(subname, StringComparison.OrdinalIgnoreCase) >= 0 &&
                    !shortName.Equals(subname, StringComparison.OrdinalIgnoreCase))
                {
                    var result = shortName.IndexOf(subname, StringComparison.OrdinalIgnoreCase);
                    Console.WriteLine("found  {0}  in  {1}({2}){3}",
                        subname,
                        shortName.Substring(0, result),
                        shortName.Substring(result, subname.Length),
                        shortName.Substring(subname.Length + result, shortName.Length - result - subname.Length));
                }
                else if (shortName.Length > 3)
                {
                    subname = shortName;
                    changeName++;
                }
            }

            // Assert
            Assert.AreEqual(0, changeName);
        }

        [TestMethod]
        public void SearchDictionary()
        {
            // Assign
            string namesPath = @"C:\kir\dictionary\ru.txt";
            var names = File.ReadAllLines(namesPath).Select(p => p.Substring(0, p.Length - 3).Trim()).ToArray();
            string patternsPath = @"C:\kir\dictionary\uniquepatterns.txt";
            var patterns = File.ReadAllLines(patternsPath).Select(p => p.Substring(0, p.Length - 1)).ToArray();
            var namePatternService = new NamePatternService();

            var good = 0;
            var bad = 0;


            // Act
            //Console.WriteLine("{0}", names[1]);
            var namesLen = names.Length;
            var patternsLen = patterns.Length;

            for (int i = 0; i < namesLen; i++)
            {
                for (int j = 0; j < patternsLen; j++)
                {
                    if (names[i].StartsWith(patterns[j]))
                    {
                        good++;
                        Console.WriteLine("found  {0}  in  {1}", patterns[j], names[i]);
                    }
                    else
                    {
                        bad++;
                    }
                }
            }

            // Assert
            Assert.AreEqual(good, bad);
        }

        public void DoubleChecking(string name, StreamWriter fileWords)
        {
            // Arrange
            var namePatternService = new NamePatternService();
            var declensionService = new DeclensionService();
            string dictionaryPath = @"C:\kir\dictionary\here\dictionary.txt";
            var matches = 0;
            var words = File.ReadAllLines(dictionaryPath);

            var nameCases = declensionService.DeclineFirstName(name);

            /*
            Console.WriteLine("    Cases:");
            foreach (var nameCase in nameCases)
            {
                Console.WriteLine(nameCase.Value);
            }
            */
            try
            {
                var pattern = namePatternService.GetPattern(name);

                // Act
                foreach (var word in words)
                {
                    if (namePatternService.IsNameMatched(pattern, word) && (word.Length - pattern.Length < 4))
                    {
                        matches = 0;
                        //Console.WriteLine("Got a first match: {0} and {1}", pattern, word);
                        foreach (var nameCase in nameCases)
                        {
                            if (word == nameCase.Value)
                            {
                                matches++;
                            }
                        }
                        if (matches == 0)
                        {
                            fileWords.WriteLine("Catch word ({0}) with pattern ({1})", word, pattern);

                            Console.WriteLine("Catch word ({0}) with pattern ({1})", word, pattern);
                        }
                    }
                }
            }
            catch (TooShortPatternException)
            {
            }
        }

        [TestMethod]
        public void DoubleCheckingDictionary()
        {
            string dictionaryPath = @"C:\kir\dictionary\here\names.txt";
            var names = File.ReadAllLines(dictionaryPath);
            string filePath = @"C:\kir\dictionary\here\result3char.txt";


            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (StreamWriter fileWords = new StreamWriter(filePath))
            {
                foreach (var name in names)
                {
                    DoubleChecking(name, fileWords);
                }
            }
        }


        [TestMethod]
        public void ClearDictionary()
        {
            string dictionaryPath = @"C:\kir\dictionary\ru.txt";
            var words =
                File.ReadAllLines(dictionaryPath)
                    .Select(p => p.Substring(0, p.Length - 4).Trim())
                    .Where(p => p.Length > 3)
                    .ToArray();
            string filePath = @"C:\kir\dictionary\here\dictionary.txt";


            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            using (StreamWriter fileWords = new StreamWriter(filePath))
            {
                foreach (var word in words)
                {
                    fileWords.WriteLine(word);
                }
            }
        }

        [TestMethod]
        public void ClearNames()
        {
            string namesPath = @"C:\kir\dictionary\NameValue.dic";
            var names = File.ReadAllLines(namesPath)
                .Where(p => !p.StartsWith("#"))
                .Select(p => p.ToLower())
                .ToArray();
            string filePath = @"C:\kir\dictionary\names.txt";


            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (StreamWriter fileWords = new StreamWriter(filePath))
            {
                foreach (var name in names)
                {
                    fileWords.WriteLine(name);
                }
            }
        }

        [TestMethod]
        public void StickDictionaries()
        {
            /*
            string filesPath = @"C:\Share\Fiction";
            var files = Directory.GetFiles(filesPath, "*.txt");


            string dictionaryPath = @"C:\kir\dictionary\here\fiction.txt";

            if (File.Exists(dictionaryPath))
            {
                File.Delete(dictionaryPath);
            }


            using (StreamWriter writer = new StreamWriter(dictionaryPath))
            {
                foreach (var file in files.Take(1))
                {
                    var dictionary = File.ReadAllText(file).Split(' ').ToArray();

                    foreach (var line in dictionary)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
            */
        }
    }
}