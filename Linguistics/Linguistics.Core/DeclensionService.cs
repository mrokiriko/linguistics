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
                "ка",
                new Dictionary<Case, string>
                {
                    {Case.Genitive, "и"},
                    {Case.Dative, "е"},
                    {Case.Accusative, "у"},
                    {Case.Instrumental, "ой"},
                    {Case.Prepositional, "е"}
                }
            },
            {
                "га",
                new Dictionary<Case, string>
                {
                    {Case.Genitive, "и"},
                    {Case.Dative, "е"},
                    {Case.Accusative, "у"},
                    {Case.Instrumental, "ой"},
                    {Case.Prepositional, "е"}
                }
            },
            {
                "ца",
                new Dictionary<Case, string>
                {
                    {Case.Genitive, "ы"},
                    {Case.Dative, "е"},
                    {Case.Accusative, "у"},
                    {Case.Instrumental, "ей"},
                    {Case.Prepositional, "е"}
                }
            },
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
                "ия",
                new Dictionary<Case, string>
                {
                    {Case.Genitive, "и"},
                    {Case.Dative, "и"},
                    {Case.Accusative, "ю"},
                    {Case.Instrumental, "ей"},
                    {Case.Prepositional, "и"}
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
            },
            {
                "ий",
                new Dictionary<Case, string>
                {
                    {Case.Genitive, "я"},
                    {Case.Dative, "ю"},
                    {Case.Accusative, "я"},
                    {Case.Instrumental, "ем"},
                    {Case.Prepositional, "и"}
                }
            },
            {
                "й",
                new Dictionary<Case, string>
                {
                    {Case.Genitive, "я"},
                    {Case.Dative, "ю"},
                    {Case.Accusative, "я"},
                    {Case.Instrumental, "ем"},
                    {Case.Prepositional, "е"}
                }
            },
            {
                // consonants without Й
                "0",
                new Dictionary<Case, string>
                {
                    {Case.Genitive, "а"},
                    {Case.Dative, "у"},
                    {Case.Accusative, "а"},
                    {Case.Instrumental, "ом"},
                    {Case.Prepositional, "е"}
                }
            }
        };

        private static readonly IDictionary<string, IDictionary<Case, string>> SpecialNames = new Dictionary
            <string, IDictionary<Case, string>>
        {
            {
                "Лев",
                new Dictionary<Case, string>
                {
                    {Case.Genitive, "Льва"},
                    {Case.Dative, "Льву"},
                    {Case.Accusative, "Льва"},
                    {Case.Instrumental, "Львом"},
                    {Case.Prepositional, "Льве"}
                }
            },
            {
                "Любовь",
                new Dictionary<Case, string>
                {
                    {Case.Genitive, "Любови"},
                    {Case.Dative, "Любови"},
                    {Case.Accusative, "Любовь"},
                    {Case.Instrumental, "Любовью"},
                    {Case.Prepositional, "Любови"}
                }
            },
            {
                "Павел",
                new Dictionary<Case, string>
                {
                    {Case.Genitive, "Павла"},
                    {Case.Dative, "Павлу"},
                    {Case.Accusative, "Павла"},
                    {Case.Instrumental, "Павлом"},
                    {Case.Prepositional, "Павле"}
                }
            },
            {
                "Нинель",
                new Dictionary<Case, string>
                {
                    {Case.Genitive, "Нинели"},
                    {Case.Dative, "Нинели"},
                    {Case.Accusative, "Нинель"},
                    {Case.Instrumental, "Нинелью"},
                    {Case.Prepositional, "Нинели"}
                }
            },
            {
                "Адель",
                new Dictionary<Case, string>
                {
                    {Case.Genitive, "Адель"},
                    {Case.Dative, "Адель"},
                    {Case.Accusative, "Адель"},
                    {Case.Instrumental, "Адель"},
                    {Case.Prepositional, "Адель"}
                }
            },
            {
                "Гали",
                new Dictionary<Case, string>
                {
                    {Case.Genitive, "Гали"},
                    {Case.Dative, "Гали"},
                    {Case.Accusative, "Гали"},
                    {Case.Instrumental, "Гали"},
                    {Case.Prepositional, "Гали"}
                }
            },
            {
                "Лия",
                new Dictionary<Case, string>
                {
                    {Case.Genitive, "Лии"},
                    {Case.Dative, "Лие"},
                    {Case.Accusative, "Лию"},
                    {Case.Instrumental, "Лией"},
                    {Case.Prepositional, "Лие"}
                }
            },
            {
                "Нелли",
                new Dictionary<Case, string>
                {
                    {Case.Genitive, "Нелли"},
                    {Case.Dative, "Нелли"},
                    {Case.Accusative, "Нелли"},
                    {Case.Instrumental, "Нелли"},
                    {Case.Prepositional, "Нелли"}
                }
            },
            {
                "Рахиль",
                new Dictionary<Case, string>
                {
                    {Case.Genitive, "Рахили"},
                    {Case.Dative, "Рахили"},
                    {Case.Accusative, "Рахиль"},
                    {Case.Instrumental, "Рахилью"},
                    {Case.Prepositional, "Рахили"}
                }
            },
            {
                "Руфь",
                new Dictionary<Case, string>
                {
                    {Case.Genitive, "Руфи"},
                    {Case.Dative, "Руфи"},
                    {Case.Accusative, "Руфь"},
                    {Case.Instrumental, "Руфью"},
                    {Case.Prepositional, "Руфи"}
                }
            },
            {
                "Эдит",
                new Dictionary<Case, string>
                {
                    {Case.Genitive, "Эдит"},
                    {Case.Dative, "Эдит"},
                    {Case.Accusative, "Эдит"},
                    {Case.Instrumental, "Эдит"},
                    {Case.Prepositional, "Эдит"}
                }
            },
            {
                "Эсфирь",
                new Dictionary<Case, string>
                {
                    {Case.Genitive, "Эсфири"},
                    {Case.Dative, "Эсфири"},
                    {Case.Accusative, "Эсфирь"},
                    {Case.Instrumental, "Эсфирью"},
                    {Case.Prepositional, "Эсфири"}
                }
            },
            {
                "Юдифь",
                new Dictionary<Case, string>
                {
                    {Case.Genitive, "Юдифи"},
                    {Case.Dative, "Юдифи"},
                    {Case.Accusative, "Юдифь"},
                    {Case.Instrumental, "Юдифью"},
                    {Case.Prepositional, "Юдифи"}
                }
            },
            {
                "Альфия",
                new Dictionary<Case, string>
                {
                    {Case.Genitive, "Альфии"},
                    {Case.Dative, "Альфие"},
                    {Case.Accusative, "Альфию"},
                    {Case.Instrumental, "Альфией"},
                    {Case.Prepositional, "Альфие"}
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
                "б", "в", "г", "д", "ж", "к", "л", "м", "н", "п", "р", "с", "т", "ф", "х", "ц", "ч",
                "ш", "щ"
            };


            var result = new Dictionary<Case, string> {{Case.Nominative, firstName}};

            //exceptions
            foreach (var word in SpecialNames.Keys.OrderByDescending(t => t))
            {
                if (firstName == word)
                {
                    var wordKey = SpecialNames[word];

                    foreach (var caseValue in wordKey.Keys)
                    {
                        result.Add(caseValue, wordKey[caseValue]);
                    }
                    return result;
                }
            }

            // cut last character
            foreach (var supportedEnding in EndingTable.Keys)
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

            if (letters.Any(x => firstName.EndsWith(x)))
            {
                var endings = EndingTable["0"];

                foreach (var caseValue in endings.Keys)
                {
                    result.Add(caseValue, firstName + endings[caseValue]);
                }
                return result;
            }

            throw new NotSupportedException(string.Format("End of '{0}' in not supported", firstName));
        }
    }
}