using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

		private static void CheckNames(string resourceName)
		{
			// Arrange
			var service = new DeclensionService();

			// Act
			var errorCount = 0;
			var okCount = 0;
			var errorNames = new Collection<string>();

			foreach (var name in GetResourceLines(resourceName))
			{
				try
				{
					var nameCases = service.DeclineFirstName(name);
					okCount++;
				}
				catch (Exception)
				{
					errorNames.Add(name);
					errorCount++;
				}
			}

			// Assert
			Assert.AreEqual(0, errorCount,
				string.Format("OK: {0}\r\nErrors: {1}\r\nError Names:\r\n{2}", okCount, errorCount, string.Join("\r\n", errorNames)));
		}
	}
}