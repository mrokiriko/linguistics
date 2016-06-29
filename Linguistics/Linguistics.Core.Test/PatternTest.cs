using System;
using System.Collections.Generic;
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
            if (line.StartsWith(firstName))
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
            var line = "Иванов";
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
    }
}