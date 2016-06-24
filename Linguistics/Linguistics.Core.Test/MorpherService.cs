using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml;

namespace Linguistics.Core.Test
{
	public sealed class MorpherService : IDeclensionService
	{
		public IDictionary<Case, string> DeclineFirstName(string firstName)
		{
			string responseText;
			using (var webClient = new WebClient {Encoding = Encoding.UTF8})
			{
				webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0");
				webClient.Headers.Add(HttpRequestHeader.AcceptCharset, "UTF-8");
				webClient.Proxy.Credentials = CredentialCache.DefaultCredentials;

				var url = "http://api.morpher.ru/WebService.asmx/GetXml?s=" + firstName;
				responseText = webClient.DownloadString(url);
			}

			//Console.WriteLine(responseText);

			return ParseReponse(responseText);
		}

		private IDictionary<Case, string> ParseReponse(string responseText)
		{
			var document = new XmlDocument();
			document.LoadXml(responseText);

			IDictionary<Case, string> result = new Dictionary<Case, string>();

			foreach (XmlNode xmlNode in document.DocumentElement.ChildNodes)
			{
				switch (xmlNode.Name)
				{
					case @"Р":
						result.Add(Case.Genitive, xmlNode.InnerText);
						break;

					case @"Д":
						result.Add(Case.Dative, xmlNode.InnerText);
						break;

					case @"В":
						result.Add(Case.Accusative, xmlNode.InnerText);
						break;

					case @"Т":
						result.Add(Case.Instrumental, xmlNode.InnerText);
						break;

					case @"П":
						result.Add(Case.Prepositional, xmlNode.InnerText);
						break;

					case @"ФИО":
						result.Add(Case.Nominative, xmlNode.ChildNodes[1].InnerText);
						break;
				}
			}

			return result;

			//	{Case.Genitive, document.DocumentElement.SelectSingleNode(@"//s:xml").Value} /*,
			//{
			//return new Dictionary<Case, string>
			//	{Case.Dative, document.SelectSingleNode(@"s://Д").Value},
			//	{Case.Accusative, document.SelectSingleNode(@"s://В").Value},
			//	{Case.Instrumental, document.SelectSingleNode(@"s://Т").Value},
			//	{Case.Prepositional, document.SelectSingleNode(@"s://П").Value},
			//	{Case.Nominative, document.SelectSingleNode(@"s://ФИО/И").Value}*/
			//};
		}
	}
}