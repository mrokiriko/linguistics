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
        public void Makeit()
        {
            //Arrange
            var name = "Иван";
            IDeclensionService service = new DeclensionService();

            //Act
            var nameCases = service.DeclineFirstName(name);

            //Assert
            Assert.AreEqual(6, nameCases.Keys.Count);
            Assert.AreEqual("1", nameCases[Case.Nominative]);
        }
    }
}