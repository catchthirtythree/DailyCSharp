using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DailyProgrammer
{
    class C0238I
    {
        const int GUESSES = 4;
        static Random random = new Random();

        static void Main(string[] args)
        {
            string[] lines = Properties.Resources.enable1.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            Console.Write("Choose a difficulty (0 - 4): ");
            int difficulty = Int32.Parse(Console.ReadLine());

            List<String> words = lines
                .Where(line => line.Length == GetWordLength(difficulty))
                .OrderBy<String, int>(line => random.Next())
                .Take(10).ToList<String>();

            Console.WriteLine(String.Join("\n", words.ToArray()));
            string password = words[random.Next(words.Count - 1)];

            int correct;
            int length = password.Length;
            for (int tries = 0; tries < GUESSES; ++tries)
            {
                Console.Write("Guess ({0} left): ", GUESSES - tries);
                correct = Guess(password, Console.ReadLine().ToLower());

                if (correct == password.Length)
                {
                    Console.WriteLine("You win!");
                    return;
                }

                Console.WriteLine("{0}/{1} correct.", correct, password.Length);
            }

            Console.WriteLine("You lose! The word was {0}.", password);
        }

        static int GetWordLength(int difficulty)
        {
            switch (difficulty)
            {
                case 0: return random.Next(4, 5);
                case 1: return random.Next(6, 8);
                case 2: return random.Next(9, 10);
                case 3: return random.Next(11, 12);
                case 4: return random.Next(13, 15);
                default: return -1;
            }
        }

        static int Guess(string password, string guess)
        {
            return password.Zip(guess, (a, b) => a == b).Count(b => b == true);
        }
    }
}