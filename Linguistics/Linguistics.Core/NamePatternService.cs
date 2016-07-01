using System;
using System.Linq;
using System.Text;

namespace Linguistics.Core
{
    public sealed class NamePatternService : INamePatternService
    {
        public string GetPattern(string name)
        {
            IDeclensionService service = new DeclensionService();
            var nameCases = service.DeclineFirstName(name);

            var i = 0;
            StringBuilder builder = new StringBuilder();

            var casesWithoutNominative = nameCases.Where(p => p.Key != Case.Nominative).Select(p => p.Value).ToList();
            var minNameCaseValueLength = nameCases.Values.Min(p => p.Length);

            foreach (var letter in nameCases[Case.Nominative].Substring(0, minNameCaseValueLength))
            {
                bool allLettersAreEqual = true;

                foreach (var nameCaseValue in casesWithoutNominative)
                {
                    if (letter != nameCaseValue[i])
                    {
                        allLettersAreEqual = false;
                        break;
                    }
                }

                if (!allLettersAreEqual)
                {
                    break;
                }

                builder.Append(letter);
                i++;
            }

            if (builder.Length < 4)
            {
                throw new TooShortPatternException();
            }

            builder.Append("*");
            return builder.ToString();
        }

        /// <summary>
        /// Check whether name pattern matches name; name may be cased.
        /// </summary>
        /// <param name="pattern">Name pattern. It should end with asterik.</param>
        /// <param name="nameCaseValue">Name value. Name may be cased.</param>
        /// <returns>true if name is matched by pattern, otherwise false.</returns>
        /// <exception cref="System.ArgumentNullException">Occurs if pattern or nameCaseValue is null</exception>
        /// <exception cref="System.ArgumentException">Occurs if pattern is empty or does not end with asterik.</exception>
        public bool IsNameMatched(string pattern, string nameCaseValue)
        {
            if (pattern == null)
            {
                throw new ArgumentNullException(@"pattern");
            }

            if (String.IsNullOrWhiteSpace(pattern))
            {
                throw new ArgumentException("Pattern can't be empty", @"pattern");
            }

            if (!pattern.EndsWith("*"))
            {
                throw new NotSupportedException("There is no asterik at the end.");
            }

            if (nameCaseValue == null)
            {
                throw new ArgumentNullException(@"nameCaseValue");
            }

            var word = pattern.Substring(0, pattern.Length - 1);
            return nameCaseValue.StartsWith(word);
        }
    }
}