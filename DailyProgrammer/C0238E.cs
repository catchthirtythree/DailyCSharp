using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DailyProgrammer
{
    class C0238E
    {
        static void Main(string[] args)
        {
            char[] input = "CcVv".ToCharArray();

            for (int i = 0; i < input.Length; ++i)
            {
                switch (input[i])
                {
                    case 'C':
                        input[i] = Char.ToUpper(random(CONSONANTS));
                        break;
                    case 'c':
                        input[i] = random(CONSONANTS);
                        break;
                    case 'V':
                        input[i] = Char.ToUpper(random(VOWELS));
                        break;
                    case 'v':
                        input[i] = random(VOWELS);
                        break;
                    default:
                        throw new Exception("");
                }
            }

            Console.WriteLine(input);
        }

        static readonly string CONSONANTS = "bcdfghjklmnpqrstvwxyz";
        static readonly string VOWELS = "aeiou";
        static readonly Random rand = new Random();
        static char random(string list)
        {
            return list[rand.Next(list.Length)];
        }
    }
}