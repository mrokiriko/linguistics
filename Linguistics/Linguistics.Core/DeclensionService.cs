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
            },

            {
                "я",
                new Dictionary<Case, string>
                {
                    {Case.Genitive, "и"},
                    {Case.Dative, "е"},
                    {Case.Accusative, "ю"},
                    {Case.Instrumental, "ей"},
                    {Case.Prepositional, "е"}
                }
            }
        };

        private static readonly IDictionary<string, IDictionary<Case, string>> LetterTable = new Dictionary
            <string, IDictionary<Case, string>>
        {
            {
                "0",
                new Dictionary<Case, string>
                {
                    {Case.Genitive, "а"},
                    {Case.Dative, "у"},
                    {Case.Accusative, "а"},
                    {Case.Instrumental, "ом"},
                    {Case.Prepositional, "е"}
                }
            },
            {
                "ь",
                new Dictionary<Case, string>
                {
                    {Case.Genitive, "я"},
                    {Case.Dative, "ю"},
                    {Case.Accusative, "я"},
                    {Case.Instrumental, "ем"},
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

            string[] letters =
            {
                "б", "в", "г", "д", "ж", "й", "к", "л", "м", "н", "п", "р", "с", "т", "ф", "х", "ц", "ч",
                "ш", "щ"
            };


            var result = new Dictionary<Case, string> {{Case.Nominative, firstName}};

            // костыли
            if (letters.Any(x => firstName.EndsWith(x)))
            {
                var endings = LetterTable["0"];

                foreach (var caseValue in endings.Keys)
                {
                    result.Add(caseValue, firstName + endings[caseValue]);
                }
                return result;
            }
            if (firstName.EndsWith("ь"))
            {
                var endings = LetterTable["ь"];
                var firstNameStam = firstName.Substring(0, firstName.Length - 1);

                foreach (var caseValue in endings.Keys)
                {
                    result.Add(caseValue, firstNameStam + endings[caseValue]);
                }
                return result;
            }

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