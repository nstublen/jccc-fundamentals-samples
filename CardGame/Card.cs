using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame
{
    class Card
    {
        /// <summary>
        /// An enumeration of all possible card suits
        /// </summary>
        public enum Suit
        {
            Clubs,
            Diamonds,
            Hearts,
            Spades
        }

        private Suit mSuit;
        private int mRank;

        private static string[] CARD_RANKS = new string[] { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
        private static string[] CARD_SUITS = new string[] { "Clubs", "Diamonds", "Hearts", "Spades" };

        /// <summary>
        /// Construct a new Card instance to represent one of the
        /// 52 possible cards in a standard deck.
        /// </summary>
        /// <param name="inSuit">The card suit</param>
        /// <param name="inSuit">The card rank (1-13)</param>
        public Card(Suit inSuit, int inRank)
        {
            mSuit = inSuit;
            mRank = inRank;
        }

        /// <summary>
        /// Get a description of the card.  For example, "Ace of Spades".
        /// </summary>
        /// <returns>The card description</returns>
        public string getDescription()
        {
            return CARD_RANKS[getRank() - 1] + " of " + CARD_SUITS[(int)getSuit()];
        }

        /// <summary>
        /// Get the card's rank (1-13).
        /// </summary>
        /// <returns>The card's rank (1-13)</returns>
        public int getRank()
        {
            return mRank;
        }

        /// <summary>
        /// Get the card's suit.
        /// </summary>
        /// <returns>The card's suit.</returns>
        public Suit getSuit()
        {
            return mSuit;
        }

        /// <summary>
        /// Is the card a face card?
        /// </summary>
        /// <returns>True if the card is a face card, otherwise,
        /// false.</returns>
        public bool isFace()
        {
            return getRank() > 10;
        }
    }
}
