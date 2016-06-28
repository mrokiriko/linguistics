using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Linguistics.Core.Test
{
    [TestClass]
    public class DeclensionServiceTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            var name = "Иван";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Ивана", nameCases[Case.Genitive]);
            Assert.AreEqual("Ивану", nameCases[Case.Dative]);
            Assert.AreEqual("Ивана", nameCases[Case.Accusative]);
            Assert.AreEqual("Иваном", nameCases[Case.Instrumental]);
            Assert.AreEqual("Иване", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void Output1()
        {
            //Arrange
            var name = "Агапит";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Агапита", nameCases[Case.Genitive]);
            Assert.AreEqual("Агапиту", nameCases[Case.Dative]);
            Assert.AreEqual("Агапита", nameCases[Case.Accusative]);
            Assert.AreEqual("Агапитом", nameCases[Case.Instrumental]);
            Assert.AreEqual("Агапите", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod2()
        {
            //Arrange
            var name = "Никита";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Никиты", nameCases[Case.Genitive]);
            Assert.AreEqual("Никите", nameCases[Case.Dative]);
            Assert.AreEqual("Никиту", nameCases[Case.Accusative]);
            Assert.AreEqual("Никитой", nameCases[Case.Instrumental]);
            Assert.AreEqual("Никите", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void Output2()
        {
            //Arrange
            var name = "Акила";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Акилы", nameCases[Case.Genitive]);
            Assert.AreEqual("Акиле", nameCases[Case.Dative]);
            Assert.AreEqual("Акилу", nameCases[Case.Accusative]);
            Assert.AreEqual("Акилой", nameCases[Case.Instrumental]);
            Assert.AreEqual("Акиле", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod3()
        {
            //Arrange
            var name = "Анна";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Анны", nameCases[Case.Genitive]);
            Assert.AreEqual("Анне", nameCases[Case.Dative]);
            Assert.AreEqual("Анну", nameCases[Case.Accusative]);
            Assert.AreEqual("Анной", nameCases[Case.Instrumental]);
            Assert.AreEqual("Анне", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void Output3()
        {
            //Arrange
            var name = "Амфилохий";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Амфилохия", nameCases[Case.Genitive]);
            Assert.AreEqual("Амфилохию", nameCases[Case.Dative]);
            Assert.AreEqual("Амфилохия", nameCases[Case.Accusative]);
            Assert.AreEqual("Амфилохием", nameCases[Case.Instrumental]);
            Assert.AreEqual("Амфилохии", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod4()
        {
            //Arrange
            var name = "Анна";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Анны", nameCases[Case.Genitive]);
            Assert.AreEqual("Анне", nameCases[Case.Dative]);
            Assert.AreEqual("Анну", nameCases[Case.Accusative]);
            Assert.AreEqual("Анной", nameCases[Case.Instrumental]);
            Assert.AreEqual("Анне", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void Output4()
        {
            //Arrange
            var name = "Антиох";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Антиоха", nameCases[Case.Genitive]);
            Assert.AreEqual("Антиоху", nameCases[Case.Dative]);
            Assert.AreEqual("Антиоха", nameCases[Case.Accusative]);
            Assert.AreEqual("Антиохом", nameCases[Case.Instrumental]);
            Assert.AreEqual("Антиохе", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod5()
        {
            //Arrange
            var name = "Игорь";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Игоря", nameCases[Case.Genitive]);
            Assert.AreEqual("Игорю", nameCases[Case.Dative]);
            Assert.AreEqual("Игоря", nameCases[Case.Accusative]);
            Assert.AreEqual("Игорем", nameCases[Case.Instrumental]);
            Assert.AreEqual("Игоре", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void Output5()
        {
            //Arrange
            var name = "Бажен";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Бажена", nameCases[Case.Genitive]);
            Assert.AreEqual("Бажену", nameCases[Case.Dative]);
            Assert.AreEqual("Бажена", nameCases[Case.Accusative]);
            Assert.AreEqual("Баженом", nameCases[Case.Instrumental]);
            Assert.AreEqual("Бажене", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod6()
        {
            //Arrange
            var name = "Илья";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Ильи", nameCases[Case.Genitive]);
            Assert.AreEqual("Илье", nameCases[Case.Dative]);
            Assert.AreEqual("Илью", nameCases[Case.Accusative]);
            Assert.AreEqual("Ильей", nameCases[Case.Instrumental]);
            Assert.AreEqual("Илье", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod7()
        {
            //Arrange
            var name = "Любовь";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Любови", nameCases[Case.Genitive]);
            Assert.AreEqual("Любови", nameCases[Case.Dative]);
            Assert.AreEqual("Любовь", nameCases[Case.Accusative]);
            Assert.AreEqual("Любовью", nameCases[Case.Instrumental]);
            Assert.AreEqual("Любови", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod8()
        {
            //Arrange
            var name = "Дарья";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Дарьи", nameCases[Case.Genitive]);
            Assert.AreEqual("Дарье", nameCases[Case.Dative]);
            Assert.AreEqual("Дарью", nameCases[Case.Accusative]);
            Assert.AreEqual("Дарьей", nameCases[Case.Instrumental]);
            Assert.AreEqual("Дарье", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod9()
        {
            //Arrange
            var name = "Нинель";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Нинели", nameCases[Case.Genitive]);
            Assert.AreEqual("Нинели", nameCases[Case.Dative]);
            Assert.AreEqual("Нинель", nameCases[Case.Accusative]);
            Assert.AreEqual("Нинелью", nameCases[Case.Instrumental]);
            Assert.AreEqual("Нинели", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod10()
        {
            //Arrange
            var name = "Адолия";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Адолии", nameCases[Case.Genitive]);
            Assert.AreEqual("Адолии", nameCases[Case.Dative]);
            Assert.AreEqual("Адолию", nameCases[Case.Accusative]);
            Assert.AreEqual("Адолией", nameCases[Case.Instrumental]);
            Assert.AreEqual("Адолии", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod11()
        {
            //Arrange
            var name = "Ангела";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Ангелы", nameCases[Case.Genitive]);
            Assert.AreEqual("Ангеле", nameCases[Case.Dative]);
            Assert.AreEqual("Ангелу", nameCases[Case.Accusative]);
            Assert.AreEqual("Ангелой", nameCases[Case.Instrumental]);
            Assert.AreEqual("Ангеле", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod12()
        {
            //Arrange
            var name = "Василина";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Василины", nameCases[Case.Genitive]);
            Assert.AreEqual("Василине", nameCases[Case.Dative]);
            Assert.AreEqual("Василину", nameCases[Case.Accusative]);
            Assert.AreEqual("Василиной", nameCases[Case.Instrumental]);
            Assert.AreEqual("Василине", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod13()
        {
            //Arrange
            var name = "Фатьян";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Фатьяна", nameCases[Case.Genitive]);
            Assert.AreEqual("Фатьяну", nameCases[Case.Dative]);
            Assert.AreEqual("Фатьяна", nameCases[Case.Accusative]);
            Assert.AreEqual("Фатьяном", nameCases[Case.Instrumental]);
            Assert.AreEqual("Фатьяне", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod14()
        {
            //Arrange
            var name = "Гаврил";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Гаврила", nameCases[Case.Genitive]);
            Assert.AreEqual("Гаврилу", nameCases[Case.Dative]);
            Assert.AreEqual("Гаврила", nameCases[Case.Accusative]);
            Assert.AreEqual("Гаврилом", nameCases[Case.Instrumental]);
            Assert.AreEqual("Гавриле", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod15()
        {
            //Arrange
            var name = "Ермолай";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Ермолая", nameCases[Case.Genitive]);
            Assert.AreEqual("Ермолаю", nameCases[Case.Dative]);
            Assert.AreEqual("Ермолая", nameCases[Case.Accusative]);
            Assert.AreEqual("Ермолаем", nameCases[Case.Instrumental]);
            Assert.AreEqual("Ермолае", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod16()
        {
            //Arrange
            var name = "Исай";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Исая", nameCases[Case.Genitive]);
            Assert.AreEqual("Исаю", nameCases[Case.Dative]);
            Assert.AreEqual("Исая", nameCases[Case.Accusative]);
            Assert.AreEqual("Исаем", nameCases[Case.Instrumental]);
            Assert.AreEqual("Исае", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod17()
        {
            //Arrange
            var name = "Касьян";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Касьяна", nameCases[Case.Genitive]);
            Assert.AreEqual("Касьяну", nameCases[Case.Dative]);
            Assert.AreEqual("Касьяна", nameCases[Case.Accusative]);
            Assert.AreEqual("Касьяном", nameCases[Case.Instrumental]);
            Assert.AreEqual("Касьяне", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod18()
        {
            //Arrange
            var name = "Лев";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Льва", nameCases[Case.Genitive]);
            Assert.AreEqual("Льву", nameCases[Case.Dative]);
            Assert.AreEqual("Льва", nameCases[Case.Accusative]);
            Assert.AreEqual("Львом", nameCases[Case.Instrumental]);
            Assert.AreEqual("Льве", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod19()
        {
            //Arrange
            var name = "Май";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Мая", nameCases[Case.Genitive]);
            Assert.AreEqual("Маю", nameCases[Case.Dative]);
            Assert.AreEqual("Мая", nameCases[Case.Accusative]);
            Assert.AreEqual("Маем", nameCases[Case.Instrumental]);
            Assert.AreEqual("Мае", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod20()
        {
            //Arrange
            var name = "Минай";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Миная", nameCases[Case.Genitive]);
            Assert.AreEqual("Минаю", nameCases[Case.Dative]);
            Assert.AreEqual("Миная", nameCases[Case.Accusative]);
            Assert.AreEqual("Минаем", nameCases[Case.Instrumental]);
            Assert.AreEqual("Минае", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod21()
        {
            //Arrange
            var name = "Николай";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Николая", nameCases[Case.Genitive]);
            Assert.AreEqual("Николаю", nameCases[Case.Dative]);
            Assert.AreEqual("Николая", nameCases[Case.Accusative]);
            Assert.AreEqual("Николаем", nameCases[Case.Instrumental]);
            Assert.AreEqual("Николае", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod22()
        {
            //Arrange
            var name = "Павел";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Павла", nameCases[Case.Genitive]);
            Assert.AreEqual("Павлу", nameCases[Case.Dative]);
            Assert.AreEqual("Павла", nameCases[Case.Accusative]);
            Assert.AreEqual("Павлом", nameCases[Case.Instrumental]);
            Assert.AreEqual("Павле", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod23()
        {
            //Arrange
            var name = "Петр";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Петра", nameCases[Case.Genitive]);
            Assert.AreEqual("Петру", nameCases[Case.Dative]);
            Assert.AreEqual("Петра", nameCases[Case.Accusative]);
            Assert.AreEqual("Петром", nameCases[Case.Instrumental]);
            Assert.AreEqual("Петре", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod24()
        {
            //Arrange
            var name = "Ратибор";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Ратибора", nameCases[Case.Genitive]);
            Assert.AreEqual("Ратибору", nameCases[Case.Dative]);
            Assert.AreEqual("Ратибора", nameCases[Case.Accusative]);
            Assert.AreEqual("Ратибором", nameCases[Case.Instrumental]);
            Assert.AreEqual("Ратиборе", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod25()
        {
            //Arrange
            var name = "Савин";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Савина", nameCases[Case.Genitive]);
            Assert.AreEqual("Савину", nameCases[Case.Dative]);
            Assert.AreEqual("Савина", nameCases[Case.Accusative]);
            Assert.AreEqual("Савином", nameCases[Case.Instrumental]);
            Assert.AreEqual("Савине", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod26()
        {
            //Arrange
            var name = "Сысой";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Сысоя", nameCases[Case.Genitive]);
            Assert.AreEqual("Сысою", nameCases[Case.Dative]);
            Assert.AreEqual("Сысоя", nameCases[Case.Accusative]);
            Assert.AreEqual("Сысоем", nameCases[Case.Instrumental]);
            Assert.AreEqual("Сысое", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod27()
        {
            //Arrange
            var name = "Агапия";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Агапии", nameCases[Case.Genitive]);
            Assert.AreEqual("Агапии", nameCases[Case.Dative]);
            Assert.AreEqual("Агапию", nameCases[Case.Accusative]);
            Assert.AreEqual("Агапией", nameCases[Case.Instrumental]);
            Assert.AreEqual("Агапии", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod28()
        {
            //Arrange
            var name = "Анастасия";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Анастасии", nameCases[Case.Genitive]);
            Assert.AreEqual("Анастасии", nameCases[Case.Dative]);
            Assert.AreEqual("Анастасию", nameCases[Case.Accusative]);
            Assert.AreEqual("Анастасией", nameCases[Case.Instrumental]);
            Assert.AreEqual("Анастасии", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod29()
        {
            //Arrange
            var name = "Еванфия";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Еванфии", nameCases[Case.Genitive]);
            Assert.AreEqual("Еванфии", nameCases[Case.Dative]);
            Assert.AreEqual("Еванфию", nameCases[Case.Accusative]);
            Assert.AreEqual("Еванфией", nameCases[Case.Instrumental]);
            Assert.AreEqual("Еванфии", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod30()
        {
            //Arrange
            var name = "Анжелика";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Анжелики", nameCases[Case.Genitive]);
            Assert.AreEqual("Анжелике", nameCases[Case.Dative]);
            Assert.AreEqual("Анжелику", nameCases[Case.Accusative]);
            Assert.AreEqual("Анжеликой", nameCases[Case.Instrumental]);
            Assert.AreEqual("Анжелике", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod31()
        {
            //Arrange
            var name = "Альфия";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Альфии", nameCases[Case.Genitive]);
            Assert.AreEqual("Альфие", nameCases[Case.Dative]);
            Assert.AreEqual("Альфию", nameCases[Case.Accusative]);
            Assert.AreEqual("Альфией", nameCases[Case.Instrumental]);
            Assert.AreEqual("Альфие", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void TestMethod32()
        {
            //Arrange
            var name = "Ленина";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Ленины", nameCases[Case.Genitive]);
            Assert.AreEqual("Ленине", nameCases[Case.Dative]);
            Assert.AreEqual("Ленину", nameCases[Case.Accusative]);
            Assert.AreEqual("Лениной", nameCases[Case.Instrumental]);
            Assert.AreEqual("Ленине", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void Name1_Martin()
        {
            //Arrange
            var name = "Мартин";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Мартина", nameCases[Case.Genitive]);
            Assert.AreEqual("Мартину", nameCases[Case.Dative]);
            Assert.AreEqual("Мартина", nameCases[Case.Accusative]);
            Assert.AreEqual("Мартина", nameCases[Case.Instrumental]);
            Assert.AreEqual("Мартине", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void Name2_Kirill()
        {
            //Arrange
            var name = "Кирилл";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Кирилла", nameCases[Case.Genitive]);
            Assert.AreEqual("Кириллу", nameCases[Case.Dative]);
            Assert.AreEqual("Кирилла", nameCases[Case.Accusative]);
            Assert.AreEqual("Кириллом", nameCases[Case.Instrumental]);
            Assert.AreEqual("Кирилле", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void Name3_Zarina()
        {
            //Arrange
            var name = "Зарина";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Зарины", nameCases[Case.Genitive]);
            Assert.AreEqual("Зарине", nameCases[Case.Dative]);
            Assert.AreEqual("Зарину", nameCases[Case.Accusative]);
            Assert.AreEqual("Зариной", nameCases[Case.Instrumental]);
            Assert.AreEqual("Зарине", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void Name4_Luka()
        {
            //Arrange
            var name = "Лука";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual(name, nameCases[Case.Nominative]);
            Assert.AreEqual("Луки", nameCases[Case.Genitive]);
            Assert.AreEqual("Луке", nameCases[Case.Dative]);
            Assert.AreEqual("Луку", nameCases[Case.Accusative]);
            Assert.AreEqual("Лукой", nameCases[Case.Instrumental]);
            Assert.AreEqual("Луке", nameCases[Case.Prepositional]);
        }

        [TestMethod]
        public void Makeit()
        {
            string name = "иван";

            IDeclensionService service = new DeclensionService();
            var result = service.DeclineFirstName(name);

            Console.WriteLine("Дательный: {0}", result[Case.Dative]);
        }

        [TestMethod]
        public void MakePattern()
        {
            string name = "Илья";

            IDeclensionService service = new DeclensionService();
            IPattern pattern = new Pattern();
            var str1 = pattern.GetPattern(name);

            var result = service.DeclineFirstName(name);


            Console.WriteLine("Я {0}.", result[Case.Nominative]);
            Console.WriteLine("Нет {0}.", result[Case.Genitive]);
            Console.WriteLine("Дать {0}.", result[Case.Dative]);
            Console.WriteLine("Вижу {0}.", result[Case.Accusative]);
            Console.WriteLine("Творить {0}.", result[Case.Instrumental]);
            Console.WriteLine("Думать о {0}.", result[Case.Prepositional]);

            Console.WriteLine();

            Console.WriteLine("Паттерн: {0}", str1);
        }
    }
}