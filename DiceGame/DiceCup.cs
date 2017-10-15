using System;
using System.Collections.Generic;

namespace DiceGame
{
    /// <summary>
    /// Object for containing a set of dice.
    /// </summary>
    public class DiceCup
    {
        /// <summary>
        /// All the dice in this cup.
        /// </summary>
        public List<Die> Dice
        {
            get; protected set;
        }

        /// <summary>
        /// Initializes and empty Dice Cup.
        /// </summary>
        public DiceCup()
        {
            this.Dice = new List<Die>();
        }

        /// <summary>
        /// Add the given Die to the cup.
        /// </summary>
        /// <param name="die"></param>
        public void AddDie(Die die)
        {
            this.Dice.Add(die);
        }

        /// <summary>
        /// Add a number of the same dice to this cup.
        /// </summary>
        /// <param name="count">number of dice to add.</param>
        /// <param name="numSides">number of sides on each dice.</param>
        public void AddDice(int count, int numSides)
        {
            for (int i = 0; i < count; i++)
                Dice.Add(new Die(numSides));
        }

        /// <summary>
        /// Toss the dice!
        /// </summary>
        /// <returns>The sum of all the dice thrown.</returns>
        public Throw Throw()
        {
            return new DiceGame.Throw(this);
        }
    }
}
