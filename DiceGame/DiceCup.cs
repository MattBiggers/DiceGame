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
        public int Throw()
        {
            int value = 0;
            foreach(Die die in this.Dice)
            {
                value += die.Roll();
            }

            return value;
        }

        /// <summary>
        /// Toss the dice!
        /// </summary>
        /// <returns>Each roll individually for comparison.</returns>
        public List<int> ThrowEach()
        {
            List<int> throws = new List<int>();
            foreach(Die die in this.Dice)
            {
                throws.Add(die.Roll());
            }

            return throws;
        }

        /// <summary>
        /// Toss the dice and take the highest individual roll.
        /// </summary>
        /// <returns>The value of the highest dice roll.</returns>
        public int GetHighestRoll()
        {
            int highest = 0;
            foreach(Die die in this.Dice)
            {
                int roll = die.Roll();
                if (roll > highest) highest = roll;
            }

            return highest;
        }
    }
}
