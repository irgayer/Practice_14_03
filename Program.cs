using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Practice_14_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordsWithCount = new Dictionary<string, int>();
            string text = "Вот дом, Который построил Джек. А это пшеница, Кото­рая в темном  чулане хранится В доме, Который построил Джек. А это веселая птица­синица, Которая часто вору­ет пшеницу, Которая в темном чулане хранится В доме, Который построил Джек.";
            int counter = 0;
            string withOutSpecialCharacters = new string(text.Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '-').ToArray());
            string[] words = withOutSpecialCharacters.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in words)
            {
                for (int i = 0; i < words.Length; i++)
                {
                    if (s == words[i])
                    {
                        counter++;
                    }
                }
                if (wordsWithCount.ContainsKey(s))
                {
                    continue;
                }
                else
                {
                    wordsWithCount.Add(s, counter);
                    counter = 0;
                }

            }
            string result = string.Format("{0,-20} {1, -15} {2, -10}\n", "Номер" ,"Слово: ", "Кол-во");
            int counterForDictionary = 1;
            
            int uniqueCounter = 0;
            int amountWords = 0;
            foreach (var s in wordsWithCount)
            {
                result += string.Format("{0,-20} {1, -15} {2, -10} \n", counterForDictionary, s.Key , s.Value);
                Console.WriteLine(result);

                counterForDictionary++;
                if (s.Value != 0)
                {
                    uniqueCounter++;
                }
                if (s.Key != null)
                {
                    amountWords++;
                }
            }
            Console.WriteLine("Всего слов: " + (amountWords + uniqueCounter) + " из них уникальные: " + uniqueCounter);

            Console.ReadKey();
        }
    }
}
