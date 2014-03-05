using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuessNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int random = (new System.Random()).Next(1, 101);
            int MAX_GUESSES = 7;

            int guess = 0;
            while (guess < MAX_GUESSES)
            {
                Console.WriteLine("Guess a number between 1 and 100 (" + (MAX_GUESSES - guess) + " guesses remaining).");
                int theGuess = int.Parse(Console.ReadLine());

                // The guess is too low, or...
                if (theGuess < random)
                {
                    Console.WriteLine("Too low.");
                }
                else
                {
                    // The guess is too high, or...
                    if (theGuess > random)
                    {
                        Console.WriteLine("Too high.");
                    }

                    // The guess must be correct!
                    else
                    {
                        Console.WriteLine("Correct!");
                        break;
                    }
                }

                guess++;
            }

            // We exited the loop if we ran out of guesses, or
            // the guessed correctly. If we ran out of guesses,
            // the guess >= MAX_GUESSES. We could also check
            // if (theGuess != random)
            if (guess >= MAX_GUESSES)
            {
                Console.WriteLine("The number was " + random + ".");
            }

            // Read a key from the keyboard to prevent the
            // console window for immediately closing.
            Console.Read();
        }
    }
}
