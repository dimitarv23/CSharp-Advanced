using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P01.FoodFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>(4) { "pear", "flour", "pork", "olive" };

            char[] vowelsInput = Console.ReadLine()
                .Split()
                .Select(char.Parse)
                .ToArray();

            char[] consonantsInput = Console.ReadLine()
                .Split()
                .Select(char.Parse)
                .ToArray();

            Queue<char> vowels = new Queue<char>(vowelsInput);
            Stack<char> consonants = new Stack<char>(consonantsInput);

            while (consonants.Count > 0)
            {
                char currVowel = vowels.Dequeue();
                char currConsonant = consonants.Peek();

                for (int i = 0; i < 4; i++)
                {
                    string word = words[i];

                    if (word.Contains(currVowel))
                    {
                        word = word.Replace(currVowel, ' ');
                    }
                    if (word.Contains(currConsonant))
                    {
                        word = word.Replace(currConsonant, ' ');
                    }

                    words[i] = word;
                }

                consonants.Pop();
                vowels.Enqueue(currVowel);
            }

            int wordsFound = words.Where(w => w.Trim().Length == 0).Count();
            Console.WriteLine($"Words found: {wordsFound}");

            if (words[0].Trim().Length == 0)
            {
                Console.WriteLine("pear");
            }
            if (words[1].Trim().Length == 0)
            {
                Console.WriteLine("flour");
            }
            if (words[2].Trim().Length == 0)
            {
                Console.WriteLine("pork");
            }
            if (words[3].Trim().Length == 0)
            {
                Console.WriteLine("olive");
            }
        }
    }
}
