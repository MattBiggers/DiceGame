using System;

namespace DiceGame
{
    /// <summary>
    /// Represents an arbitrary Die for a Dice Game.
    /// </summary>
    public class Die
    {
        /// <summary>
        /// this is the universal random number generator for all dice.
        /// It is important that this is a static member because it will ensure that
        /// no two dice roll the same number consistently.
        /// 
        /// If this were a non-static member, two Dice that were created at the same time
        /// would have the same random number seed and thus would consistently roll the 
        /// same value when rolled simultaneously.
        /// </summary>
        protected static Random random = new Random();
        
        /// <summary>
        /// Number of Sides on this Die.
        /// </summary>
        public int NumSides { get; protected set; }

        /// <summary>
        /// Create a new Die.  You can provide a number of sides, or leave the default 6.
        /// </summary>
        /// <param name="sides">number of sides for the Die.  Default: 6</param>
        public Die(int sides = 6)
        {
            this.NumSides = sides;
        }

        /// <summary>
        /// Roll this die.
        /// </summary>
        /// <returns>random number between 1 and the number of sides.</returns>
        public int Roll()
        {
            return 1 + random.Next(this.NumSides);
        }
    }
}
