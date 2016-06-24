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
    }
}