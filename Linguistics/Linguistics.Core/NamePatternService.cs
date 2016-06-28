namespace Linguistics.Core
{
	public sealed class NamePatternService : INamePatternService
	{
		public string GetPattern(string name)
		{
			IDeclensionService service = new DeclensionService();
			var nameCases = service.DeclineFirstName(name);

			var equal = false;

			//var specialNameCases =
			//	nameCases
			//		.Where(nc => nc.Key != Case.Nominative)
			//		.ToDictionary(p => p.Key, p => p.Value)
			//	;

			var str1 = nameCases[Case.Nominative];
			var str2 = nameCases[Case.Genitive].Substring(0, str1.Length);

			while (equal == false)
			{
				if (str1 == str2)
				{
					equal = true;
				}
				else
				{
					str1 = str1.Substring(0, str1.Length - 1);
					str2 = str2.Substring(0, str2.Length - 1);
				}
			}

			return str1 + '*';
		}
	}
}