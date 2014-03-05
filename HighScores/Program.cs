using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HighScores
{
    class Program
    {
        static void Main(string[] args)
        {
            int MAX_SCORES = 5;

            int[] highScores = new int[MAX_SCORES];

            while (true)
            {
                Console.WriteLine("Enter a new score.");
                int newScore = int.Parse(Console.ReadLine());

                // Starting with the lowest score first, see if the
                // new score is better than any of the current high
                // scores.
                int newPlace = -1;
                for (int index = highScores.Length - 1; index >= 0; index--)
                {
                    // If we find a high score greater than the new
                    // score, we can stop searching because all
                    // remaining scores will also be greater.
                    if (highScores[index] >= newScore)
                    {
                        break;
                    }
                    else
                    {
                        // Since the new score is greater than the
                        // score we're comparing, we can drop the
                        // score we're comparing down to the next
                        // position in the array (as long as we're
                        // not comparing the last score in the array).
                        if (index < highScores.Length - 1)
                        {
                            highScores[index + 1] = highScores[index];
                        }

                        // The new score can now go into the current
                        // position in the array. If the new score is
                        // greater than the next element comparision,
                        // we will end up moving another score value
                        // into this position.
                        highScores[index] = newScore;
                        newPlace = index;
                    }
                }

                // Print out a list of the high scores. An * will
                // be placed beside the element with the new score
                // if it made it into the list.
                Console.WriteLine("High scores:");
                for (int index = 0; index < MAX_SCORES; index++)
                {
                    Console.Write(highScores[index]);
                    if (index == newPlace)
                    {
                        Console.Write("(*)");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
