using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Linguistics.Core.Test
{
    [TestClass]
    public sealed class NamePatternServiceTests
    {
        [TestMethod]
        [TestCategory("NamePatternTests")]
        public void NamePatternServiceMatchesNameCorrectlyTest()
        {
            // Arrange
            var service = new NamePatternService();

            // Act
            var isMatched = service.IsNameMatched("Иван*", "Ивану");

            // Assert
            Assert.IsTrue(isMatched);
        }

        [TestMethod]
        [TestCategory("NamePatternTests")]
        public void NamePatternServiceDoesNotMatchDifferentNameTest()
        {
            // Arrange
            var service = new NamePatternService();

            // Act
            var isMatched = service.IsNameMatched("Иван*", "Петру");

            // Assert
            Assert.IsFalse(isMatched);
        }

        [TestMethod]
        [TestCategory("NamePatternTests")]
        public void NamePatternServiceDoesNotMatchIncorrectNameTest()
        {
            // Arrange
            var service = new NamePatternService();

            // Act
            var isMatched = service.IsNameMatched("Иван*", "99Ивану");

            // Assert
            Assert.IsFalse(isMatched);
        }

        [TestMethod]
        [TestCategory("NamePatternTests")]
        [ExpectedException(typeof(NotSupportedException))]
        public void NamePatternServiceFailsOnIncorrectPatternTest()
        {
            // Arrange
            var service = new NamePatternService();

            // Act
            service.IsNameMatched("Иван", "99Ивану");

            // Assert
        }

        [TestMethod]
        [TestCategory("NamePatternTests")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NamePatternServiceFailsOnNullPatternTest()
        {
            // Arrange
            var service = new NamePatternService();

            // Act
            service.IsNameMatched(null, "99Ивану");

            // Assert
        }

        [TestMethod]
        [TestCategory("NamePatternTests")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NamePatternServiceFailsOnNullNameTest()
        {
            // Arrange
            var service = new NamePatternService();

            // Act
            service.IsNameMatched("Иван*", null);

            // Assert
        }

        [TestMethod]
        [TestCategory("NamePatternTests")]
        [ExpectedException(typeof(ArgumentException))]
        public void NamePatternServiceFailsOnEmptyPatternTest()
        {
            // Arrange
            var service = new NamePatternService();

            // Act
            service.IsNameMatched("", "99Ивану");

            // Assert
        }

        [TestMethod]
        public void CheckPatternName1_Ivan()
        {
            // Arrange
            INamePatternService service = new NamePatternService();

            // Act
            var pattern = service.GetPattern("иван");

            // Assert
            Assert.AreEqual(pattern, "иван*");
        }

        [TestMethod]
        [ExpectedException(typeof(TooShortPatternException))]
        public void CheckPatternName1_Lev()
        {
            // Arrange
            INamePatternService service = new NamePatternService();

            // Act
            service.GetPattern("Лев");

            // Assert
        }
    }
}