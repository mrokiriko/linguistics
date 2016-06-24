using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Linguistics.Core.Test
{
	[TestClass]
	public sealed class FunctionalTests
	{
		public static Stream GetResourceStream(string resourceName)
		{
			var resourceFullFileName = string.Format("{0}.{1}", typeof(FunctionalTests).Namespace, resourceName);
			return Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceFullFileName);
		}

		public static IEnumerable<string> GetResourceLines(string resourceName)
		{
			using (var stream = GetResourceStream(resourceName))
			{
				using (var reader = new StreamReader(stream))
				{
					while (!reader.EndOfStream)
					{
						yield return reader.ReadLine();
					}
				}
			}
//			var names = new HashSet<string> {"", "", "", ""};
		}

		[TestMethod]
		public void CheckAllBoyNamesTest()
		{
			const string resourceName = "Resources.RussianBoyNames.txt";
			CheckNames(resourceName);
		}

		[TestMethod]
		public void CheckAllGirlNamesTest()
		{
			const string resourceName = "Resources.RussianGirlNames.txt";
			CheckNames(resourceName);
		}

		private static IDictionary<Case, string> CompareNameCases(IDictionary<Case, string> expected,
			IDictionary<Case, string> actual)
		{
			var result = new Dictionary<Case, string>();

			foreach (var actualNameCase in actual)
			{
				var expectedNameCase = expected[actualNameCase.Key];

				if (actualNameCase.Value != expectedNameCase)
				{
					result.Add
						(
							actualNameCase.Key,
							string.Format("{0} != {1}", expectedNameCase, actualNameCase.Value)
						);
				}
			}
			return result;
		}

		private static void CheckNames(string resourceName)
		{
			// Arrange
			var service = new DeclensionService();
			var morpher = new MorpherService();

			// Act
			var errorCount = 0;
			var okCount = 0;
			var errorNames = new Collection<string>();
			var errorNameCases = new Dictionary<string, IDictionary<Case, string>>();

			foreach (var name in GetResourceLines(resourceName).Take(20))
			{
				try
				{
					var parsedName = morpher.DeclineFirstName(name);
					var nameCases = service.DeclineFirstName(name);

					var comparison = CompareNameCases(parsedName, nameCases);
					if (comparison.Count > 0)
					{
						errorNameCases.Add(name, comparison);
						errorCount++;
					}
					else
					{
						okCount++;
					}
				}
				catch (Exception)
				{
					errorNames.Add(name);
					errorCount++;
				}
			}

			// Assert
			if (errorNameCases.Count > 0)
			{
				foreach (var nameCases in errorNameCases)
				{
					Console.WriteLine(nameCases.Key);
					foreach (var nameCase in nameCases.Value)
					{
						Console.WriteLine("\t{0} - {1}", nameCase.Key, nameCase.Value);
					}
				}
			}

			Assert.AreEqual(0, errorCount,
				string.Format("OK: {0}\r\nErrors: {1}\r\nError Names:\r\n{2}", okCount, errorCount, string.Join("\r\n", errorNames)));
		}

		[TestMethod]
		public void MorpherServiceTest()
		{
			var nameCases = new MorpherService().DeclineFirstName("Иван");
			foreach (var nameCase in nameCases)
			{
				Console.WriteLine("\t{0} - {1}", nameCase.Key, nameCase.Value);
			}
		}
	}
}