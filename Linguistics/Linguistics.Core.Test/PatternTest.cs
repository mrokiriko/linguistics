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
				var str1 = pattern.GetPattern(name);

				var result = service.DeclineFirstName(name);

				Console.WriteLine("{0}", str1);

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

		public static bool IsNameMatched(string pattern, string nameCaseValue)
		{
			throw new NotImplementedException();
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
				Assert.IsTrue(IsNameMatched(pattern, nameCaseValue));
			}
		}

		[TestMethod]
		public void FindName()
		{
			var line =
				"Оробей Еремей - обидит и воробей. Наговорил Егор с гору, да все не в пору. На всякого Егорку есть поговорка. Каждый Еремей про себя разумей. Ефрем любит хрен, а Федька - редьку.";

			var check = 0;
			var err = 0;
			var resourceLink = "Resources.NamePattern.txt";
			foreach (var name in TestUtils.GetResourceLines(resourceLink))
			{
				var word = name.Substring(0, name.Length - 1);
				//Console.WriteLine(word);
				if (line.Contains(word))
				{
					Console.WriteLine("Found it, it's {0}", word);
					check++;
				}
				else
				{
					err++;
					//Console.WriteLine("Couldn't find it");
				}
			}
			Console.WriteLine("{0}: Mistakes", err);
			Assert.AreNotEqual(0, check);
		}
	}
}