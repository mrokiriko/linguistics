using System;
using System.Collections.Generic;
using System.Linq;
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
        public void CheckPatternName1_Ivan()
        {
            INamePatternService pattern = new NamePatternService();

            Assert.AreEqual(pattern.GetPattern("иван"), "иван*");
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
            const string resourceName = "Resources.NameValue.dic";
            var names = TestUtils.GetResourceLines(resourceName);
            var namePatternService = new NamePatternService();
            var count = 0;

            // Act, Assert
            foreach (var name in names)
            {
                if (!name.StartsWith("#"))
                {
                    count++;
                    Console.WriteLine(namePatternService.GetPattern(name));
                }
            }
            Assert.AreEqual(0, count);
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
    }
}