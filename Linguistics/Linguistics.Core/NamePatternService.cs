using System;

namespace Linguistics.Core
{
    public sealed class NamePatternService : INamePatternService
    {
        public string GetPattern(string name)
        {
            IDeclensionService service = new DeclensionService();
            var nameCases = service.DeclineFirstName(name);

            var countLetters = 0;
            var endofline = false;

            while (endofline == false && countLetters < nameCases[Case.Nominative].Length)
            {
                var letter = nameCases[Case.Nominative][countLetters];
                foreach (var key in nameCases.Values)
                {
                    if (letter != key[countLetters])
                    {
                        endofline = true;
                        return nameCases[Case.Nominative].Substring(0, countLetters) + "*";
                    }
                }
                countLetters++;
            }

            return nameCases[Case.Nominative].Substring(0, countLetters) + "*";
        }

        public bool IsNameMatched(string pattern, string nameCaseValue)
        {
            var word = pattern.Substring(0, pattern.Length - 1);
            //Console.WriteLine(word);
            if (nameCaseValue.Contains(word))
            {
                Console.WriteLine("Found it, it's {0}", word);
                return true;
            }
            else
            {
                return false;
                //Console.WriteLine("Couldn't find it");
            }

            throw new NotImplementedException();
        }
    }
}