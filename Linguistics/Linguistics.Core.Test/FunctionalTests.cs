﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Linguistics.Core.Test
{
	[TestClass]
	public sealed class FunctionalTests
	{
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
				if (!expected.ContainsKey(actualNameCase.Key))
				{
					result.Add
						(
							actualNameCase.Key,
							string.Format("<not found> != {0}", actualNameCase.Value)
						);
					continue;
				}

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

			foreach (var name in TestUtils.GetResourceLines(resourceName))
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
				catch (Exception t)
				{
					errorNames.Add(name);
					Console.WriteLine("{0} : {1}", name, t.Message);
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
				string.Format("OK: {0}\r\nErrors: {1}\r\nError Names:\r\n{2}", okCount, errorCount,
					string.Join("\r\n", errorNames)));
		}

		[TestMethod]
		public void MorpherServiceTest()
		{
			var nameCases = new MorpherService().DeclineFirstName("Веньямин");
			foreach (var nameCase in nameCases)
			{
				Console.WriteLine("\t{0} - {1}", nameCase.Key, nameCase.Value);
			}
		}
	}
}