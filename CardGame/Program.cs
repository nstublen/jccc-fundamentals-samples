using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame
{
    class Program
    {
        /// <summary>
        /// This program will simulate a slightly modified version of the
        /// card game War.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Create a deck of cards and shuffle it.
            Deck deck = new Deck();
            deck.reset();
            deck.shuffle();

            // Create a stack of cards for each player and allow them
            // to hold a full deck.
            Stack playerStack1 = new Stack(deck.getSize());
            Stack playerStack2 = new Stack(deck.getSize());

            // Divide the deck between the two players.
            while (!deck.isEmpty())
            {
                Card nextCard = deck.draw();
                playerStack1.add(nextCard);
                
                nextCard = deck.draw();
                playerStack2.add(nextCard);
            }

            // Each player will also have a second stack of cards
            // to hold all the cards won during the round.
            Stack playerWinnings1;
            Stack playerWinnings2;

            // Create a stack of "draw cards" to hold matching cards
            // until a winner is determined.
            Stack drawCards = new Stack(playerStack1.getSize() + playerStack2.getSize());

            int roundsCompleted = 0;
            while (!playerStack1.isEmpty() && !playerStack2.isEmpty())
            {
                // Create a stack for each player's winnings.
                playerWinnings1 = new Stack(playerStack1.getSize() + playerStack2.getSize());
                playerWinnings2 = new Stack(playerStack1.getSize() + playerStack2.getSize());

                // Keep playing the round until someone is out of cards.
                while (!playerStack1.isEmpty() && !playerStack2.isEmpty())
                {
                    // Draw one card from each player's stack.
                    Card playerCard1 = playerStack1.draw();
                    Card playerCard2 = playerStack2.draw();

                    //Console.WriteLine(playerCard1.getDescription() + " vs. " + playerCard2.getDescription());

                    // Compare the ranks of the two cards.
                    int rank1 = playerCard1.getRank();
                    int rank2 = playerCard2.getRank();

                    if (rank1 > rank2)
                    {
                        // Give player 1 both cards and any draw cards.
                        playerWinnings1.add(drawCards);
                        playerWinnings1.add(playerCard1);
                        playerWinnings1.add(playerCard2);
                        //Console.WriteLine("- Player 1 wins!");
                    }
                    else
                    {
                        if (rank2 > rank1)
                        {
                            // Give player 2 both cards and any draw cards.
                            playerWinnings2.add(drawCards);
                            playerWinnings2.add(playerCard2);
                            playerWinnings2.add(playerCard1);
                            //Console.WriteLine("- Player 2 wins!");
                        }
                        else
                        {
                            // Place both players' cards in the draw stack.
                            drawCards.add(playerCard1);
                            drawCards.add(playerCard2);
                            //Console.WriteLine("- It's a draw!");
                        }
                    }

                    //Console.ReadKey();
                }

                // Add any winnings to the end of each player's stack
                // for the next round.
                playerStack1.add(playerWinnings1);
                playerStack2.add(playerWinnings2);

                Console.WriteLine("Player 1 wins " + playerStack1.getSize() + " cards.");
                Console.WriteLine("Player 2 wins " + playerStack2.getSize() + " cards.");
                //Console.ReadKey();

                roundsCompleted += 1;
            }

            Console.WriteLine(roundsCompleted);
            Console.ReadKey();
        }
    }
}
