using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuessPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            int DIGITS = 4;

            // We need one array to hold the random solution and
            // one array to hold the guess.
            int[] answer = new int[DIGITS];
            int[] guess = new int[DIGITS];

            createRandomPattern(answer);

            // Keep asking for inputs and displaying the number of
            // matches until all four digits are correct.
            int matches = 0;
            while (matches < answer.Length)
            {
                gatherGuess(guess);

                matches = compareArrays(answer, guess);
                Console.WriteLine("You matched " + matches + " digit(s).");
            }

            Console.WriteLine("Congratulations!");

            // Read a key from the keyboard to prevent the
            // console window for immediately closing.
            Console.Read();
        }

        // Compare two arrays, assuming they are of equal length
        // and return the number of elements have equal values at
        // the same position in the array.
        static int compareArrays(int[] array1, int[] array2)
        {
            int matches = 0;
            for (int index = 0; index < array1.Length; index += 1)
            {
                if (array1[index] == array2[index])
                {
                    matches += 1;
                }
            }
            return matches;
        }

        static void createRandomPattern(int[] answer)
        {
            // Reset each array element to 0 to indicate it
            // has not yet been filled with a random value.
            for (int index = 0; index < answer.Length; index += 1)
            {
                answer[index] = 0;
            }

            Random prng = new Random();

            // We will fill the array with numbers between 1 and
            // the number of elements in the array.
            for (int value = 1; value <= answer.Length; value++)
            {
                // Each value will be placed in a random index
                // position in the array.
                int index = prng.Next(0, answer.Length);

                // If the index position has already been filled,
                // keep looking at the next index until we find
                // an unused element (still initialized to 0).
                while (answer[index] != 0)
                {
                    // Use % to loop back to the beginning of the
                    // array.
                    index = (index + 1) % answer.Length;
                }

                // Put the value into the unused array element.
                answer[index] = value;
            }
        }

        static void gatherGuess(int[] guess)
        {
            Console.WriteLine("Enter your " + guess.Length + " guesses.");
            for (int index = 0; index < guess.Length; index += 1)
            {
                guess[index] = int.Parse(Console.ReadLine());
            }
        }
    }
}
