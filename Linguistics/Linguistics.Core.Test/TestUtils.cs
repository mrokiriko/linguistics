using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Linguistics.Core.Test
{
	public sealed class TestUtils
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
		}
	}
}