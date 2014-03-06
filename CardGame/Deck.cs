using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame
{
    class Deck : Stack
    {
        public const int CARDS_PER_DECK = 52;
        public const int CARDS_PER_SUIT = 13;

        public Deck() : base(CARDS_PER_DECK)
        {
        }

        /// <summary>
        /// Reset the deck to contain a set of 52 perfectly ordered
        /// cards.
        /// </summary>
        public void reset()
        {
            // Reset to an empty stack that can hold a full deck.
            reset(CARDS_PER_DECK);

            // Create a perfectly ordered deck.
            for (int deckIndex = 0; deckIndex < CARDS_PER_DECK; deckIndex += 1)
            {
                Card.Suit suit = (Card.Suit)(deckIndex / CARDS_PER_SUIT);
                int rank = deckIndex % CARDS_PER_SUIT;
                add(new Card(suit, rank));
            }
        }
    }
}
