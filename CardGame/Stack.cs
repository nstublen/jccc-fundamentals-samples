using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame
{
    class Stack
    {
        private Card[] mCards;
        private int mNextDraw;
        private int mNextAdd;

        public Stack(int maxCards)
        {
            reset(maxCards);
        }

        /// <summary>
        /// Add one card to the stack.
        /// </summary>
        /// <param name="newCard">The card to add to the stack</param>
        public void add(Card newCard)
        {
            if (mNextAdd >= mCards.Length)
            {
                shift();
            }
            if (mNextAdd < mCards.Length)
            {
                mCards[mNextAdd] = newCard;
                mNextAdd++;
            }
        }

        /// <summary>
        /// Add another stack of cards to the stack.
        /// </summary>
        /// <param name="newCards">The other stack of cards</param>
        public void add(Stack newCards)
        {
            while (!newCards.isEmpty())
            {
                Card newCard = newCards.draw();
                add(newCard);
            }
        }

        /// <summary>
        /// Draw one card from the top of the stack.
        /// </summary>
        /// <returns>The card from the top of the stack.</returns>
        public Card draw()
        {
            Card nextCard = mCards[mNextDraw];
            mNextDraw += 1;
            return nextCard;
        }

        /// <summary>
        /// Get the number of cards in the stack.
        /// </summary>
        /// <returns>The number of cards in the stack</returns>
        public int getSize()
        {
            return mNextAdd - mNextDraw;
        }

        /// <summary>
        /// Determine if the stack is empty.
        /// </summary>
        /// <returns>True if the stack is empty, otherwise, false</returns>
        public bool isEmpty()
        {
            return mNextDraw >= mNextAdd;
        }

        /// <summary>
        /// Reset the stack by removing all cards.
        /// </summary>
        /// <param name="maxCards">Maximum number of cards to be
        /// placed into the stack</param>
        public virtual void reset(int maxCards)
        {
            mCards = new Card[maxCards];
            mNextDraw = 0;
            mNextAdd = 0;
        }

        /// <summary>
        /// Shift cards within the internal array so more cards
        /// can be added to the stack.
        /// </summary>
        private void shift()
        {
            int shiftIndex = 0;
            while (mNextDraw < mNextAdd)
            {
                mCards[shiftIndex] = mCards[mNextDraw];
                mNextDraw += 1;
                shiftIndex += 1;
            }
            mNextDraw = 0;
            mNextAdd = shiftIndex;
        }

        /// <summary>
        /// Shuffle the cards in the stack.
        /// </summary>
        public void shuffle()
        {
            Random rng = new Random();

            // Starting with the last card in the stack and moving
            // forward, swap each card with a randomly selected card
            // before it.
            for (int deckIndex = mNextAdd - 1; deckIndex > mNextDraw; deckIndex -= 1)
            {
                int randomIndex = rng.Next(0, deckIndex);
                swapCards(deckIndex, randomIndex);
            }
        }

        /// <summary>
        /// Swap two cards in the stack.
        /// </summary>
        /// <param name="index1">The first card to swap</param>
        /// <param name="index2">The second card to swap</param>
        private void swapCards(int index1, int index2)
        {
            Card temp = mCards[index1];
            mCards[index1] = mCards[index2];
            mCards[index2] = temp;
        }
    }
}
