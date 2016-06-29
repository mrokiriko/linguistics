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

            // Act n' Assert
            return namePatternService.IsNameMatched(namePatternService.GetPattern(firstName), line);
        }

        [TestMethod]
        public void NameInLine1_Ivan()
        {
            var firstName = "Иван";
            var line = "NetИвана99";
            Assert.AreEqual(true, FindName(firstName, line));
        }

        [TestMethod]
        public void NameInLine2_Avram()
        {
            var firstName = "Аврам";
            var line = "И на весь мир стали известные Аврамовы дети";
            Assert.AreEqual(true, FindName(firstName, line));
        }

        [TestMethod]
        public void NameInLine3_Andrey()
        {
            var firstName = "Андрей";
            var line = "566ААндрея1020";
            Assert.AreEqual(true, FindName(firstName, line));
        }

        [TestMethod]
        public void NameInLine4_Dmitriy()
        {
            var firstName = "Дмитрий";
            var line =
                "Слушай меня, слушай внимательно: и дворник, и Кох, и Пестряков, и другой дворник, и жена первого дворника, и мещанка, что о ту пору у ней в дворницкой сидела, и надворный советник Крюков, который в эту самую минуту с извозчика встал и в подворотню входил об руку с дамою, -- все, то есть восемь или десять свидетелей, единогласно показывают, что Николай придавил Дмитрия к земле, лежал на нем и его тузил, а тот ему в волосы вцепился и тоже тузил. Лежат они поперек дороги и проход загораживают; их ругают со всех сторон, а они, как малые ребята (буквальное выражение свидетелей), лежат друг на друге, визжат, дерутся и хохочут, оба хохочут взапуски, с самыми смешными рожами, и один другого догонять, точно дети, на улицу выбежали. Слышал? Теперь строго заметь себе: тела наверху еще теплые, слышишь, теплые, так нашли их! Если убили они, или только один Николай, и при этом ограбили сундуки со взломом, или только участвовали чем-нибудь в грабеже, то позволь тебе задать всего только один вопрос: сходится ли подобное душевное настроение, то есть взвизги, хохот, ребяческая драка под воротами, -- с топорами, с кровью, с злодейскою хитростью, осторожностью, грабежом? Тотчас же убили, всего каких-нибудь пять или десять минут назад, -- потому так выходит, тела еще теплые, -- и вдруг, бросив и тела, и квартиру отпертую, и зная, что сейчас туда люди прошли, и добычу бросив, они, как малые ребята, валяются на дороге, хохочут, всеобщее внимание на себя привлекают, и этому десять единогласных свидетелей есть!";
            Assert.AreEqual(true, FindName(firstName, line));
        }
    }
}