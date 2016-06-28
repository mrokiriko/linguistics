using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Linguistics.Core.Test
{
    [TestClass]
    public class PatternTest
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

        public void PatternNames(string resourceLink)
        {
            foreach (var name in GetResourceLines(resourceLink))
            {
                IDeclensionService service = new DeclensionService();
                IPattern pattern = new Pattern();
                var str1 = pattern.GetPattern(name);

                var result = service.DeclineFirstName(name);

                Console.WriteLine("{0}", str1);

                var text = false;
                if (text)
                {
                    Console.WriteLine();

                    Console.WriteLine("Я {0}.", result[Case.Nominative]);
                    Console.WriteLine("Нет {0}.", result[Case.Genitive]);
                    Console.WriteLine("Дать {0}.", result[Case.Dative]);
                    Console.WriteLine("Вижу {0}.", result[Case.Accusative]);
                    Console.WriteLine("Творить {0}.", result[Case.Instrumental]);
                    Console.WriteLine("Думать о {0}.", result[Case.Prepositional]);


                    Console.WriteLine("-----");
                }
            }
        }

        [TestMethod]
        public void PatternBoyNames()
        {
            string s = "Resources.RussianBoyNames.txt";
            PatternNames(s);
        }

        [TestMethod]
        public void FindName()
        {
            var line =
                "Оробей Еремей - обидит и воробей. Наговорил Егор с гору, да все не в пору. На всякого Егорку есть поговорка. Каждый Еремей про себя разумей. Ефрем любит хрен, а Федька - редьку.";

            var check = 0;
            var err = 0;
            var resourceLink = "Resources.NamePattern.txt";
            foreach (var name in GetResourceLines(resourceLink))
            {
                var word = name.Substring(0, name.Length - 1);
                //Console.WriteLine(word);
                if (line.Contains(word))
                {
                    Console.WriteLine("Found it, it's {0}", word);
                    check++;
                }
                else
                {
                    err++;
                    //Console.WriteLine("Couldn't find it");
                }
            }
            Console.WriteLine("{0}: Mistakes", err);
            Assert.AreNotEqual(0, check);
        }
    }
}