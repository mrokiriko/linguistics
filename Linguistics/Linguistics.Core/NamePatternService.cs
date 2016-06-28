using System;

namespace Linguistics.Core
{
    public sealed class NamePatternService : INamePatternService
    {
        public string GetPattern(string name)
        {
            IDeclensionService service = new DeclensionService();
            var nameCases = service.DeclineFirstName(name);

            //var specialNameCases =
            //	nameCases
            //		.Where(nc => nc.Key != Case.Nominative)
            //		.ToDictionary(p => p.Key, p => p.Value)
            //	;

            var countLetters = 0;
            var endofline = false;

            while (endofline == false && countLetters < nameCases[Case.Nominative].Length)
            {
                var letter = nameCases[Case.Nominative][countLetters];
                foreach (var key in nameCases.Values)
                {
                    if (letter != key[countLetters])
                    {
                        //Console.WriteLine("{0} != {1}", letter, key[countLetters]);
                        endofline = true;
                        return nameCases[Case.Nominative].Substring(0, countLetters) + "*";
                    }
                }
                countLetters++;
            }

            return nameCases[Case.Nominative].Substring(0, countLetters) + "*";
        }
    }
}