using System;
using System.Collections.Generic;
using System.Linq;

namespace Linguistics.Core
{
    public sealed class DeclensionService : IDeclensionService
    {
        private static readonly IDictionary<string, IDictionary<Case, string>> EndingTable = new Dictionary
            <string, IDictionary<Case, string>>
        {
            {
                "а",
                new Dictionary<Case, string>
                {
                    {Case.Genitive, "ы"},
                    {Case.Dative, "е"},
                    {Case.Accusative, "у"},
                    {Case.Instrumental, "ой"},
                    {Case.Prepositional, "е"}
                }
            }
        };

        public IDictionary<Case, string> DeclineFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First name is not specified.", @"firstName");
            }

            var result = new Dictionary<Case, string> {{Case.Nominative, firstName}};

            foreach (var supportedEnding in EndingTable.Keys.OrderByDescending(t => t))
            {
                if (firstName.EndsWith(supportedEnding))
                {
                    var endings = EndingTable[supportedEnding];
                    var firstNameStam = firstName.Substring(0, firstName.Length - 1);

                    foreach (var caseValue in endings.Keys)
                    {
                        result.Add(caseValue, firstNameStam + endings[caseValue]);
                    }
                    return result;
                }
            }

            throw new NotSupportedException(string.Format("End of '{0}' in not supported", firstName));
        }
    }
}