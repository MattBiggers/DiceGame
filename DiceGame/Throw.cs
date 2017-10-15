using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiceGame
{
    /// <summary>
    /// Objects need not represent physical things.  They can also be abstractions of abstract concepts!
    /// The Throw object represents the outcome of a dice throw.  It can be initialized using a DiceCup in order
    /// to simulate a Throw of the dice.
    /// 
    /// Ideally, you should use this object in a "using" statement.
    /// E.G.
    /// 
    /// using(Throw throw = diceCup.Throw())
    /// {
    ///     ....
    /// }
    /// 
    /// This is not strictly necessary, because no resources in this class are "unmanaged".  However, it is a
    /// good example of how to use such a thing.  This is useful to limit the scope of a variable of type 
    /// Throw to the specific code where it is used so that it isn't eating up memory while it is lying dormant.
    /// </summary>
    public class Throw : IDisposable
    {
        /// <summary>
        /// Each of the rolls.
        /// </summary>
        public List<int> Rolls { get; protected set; }

        /// <summary>
        /// Initialize with a list of rolls.
        /// </summary>
        /// <param name="rolls"></param>
        public Throw(List<int> rolls)
        {
            Rolls = rolls;
        }

        /// <summary>
        /// Initialize a Throw by tossing a dice cup.
        /// </summary>
        /// <param name="cup"></param>
        public Throw(DiceCup cup)
        {
            Rolls = new List<int>();
            foreach(Die d in cup.Dice)
            {
                Rolls.Add(d.Roll());
            }
        }

        /// <summary>
        /// Total of all the dice rolls in this Throw.
        /// </summary>
        public int Total
        {
            get
            {
                int sum = 0;
                foreach (int roll in Rolls)
                    sum += roll;

                return sum;
            }
        }

        /// <summary>
        /// Get the highest roll from this toss.
        /// </summary>
        public int Highest
        {
            get
            {
                int highest = 0;
                foreach (int roll in Rolls)
                    if (roll > highest) highest = roll;

                return highest;
            }
        }

        /// <summary>
        /// Get the top rolls from this toss.
        /// </summary>
        /// <param name="count">number of rolls to return.</param>
        /// <returns></returns>
        public List<int> GetHigest(int count)
        {
            if (count > Rolls.Count) throw new ArgumentException("Count cannot exceed the number of rolls", "count");
            return Rolls.OrderByDescending(r => r).ToList().GetRange(0, count);
        }

        /// <summary>
        /// Get the lowest roll from this toss.
        /// </summary>
        public int Lowest
        {
            get
            {
                int lowest = Int32.MaxValue;
                foreach (int roll in Rolls)
                    if (roll < lowest) lowest = roll;

                return lowest;
            }
        }

        /// <summary>
        /// Get the bottom rolls from this toss.
        /// </summary>
        /// <param name="count">number of rolls to return.</param>
        /// <returns></returns>
        public List<int> GetLowest(int count)
        {
            if (count > Rolls.Count) throw new ArgumentException("Count cannot exceed the number of rolls", "count");
            return Rolls.OrderBy(r => r).ToList().GetRange(0, count);
        }

        /// <summary>
        /// The dispose method is used for clearing up excess memory usage in high-memory applications.
        /// This method is invoked automatically when you declare the Throw in a "using" statement.
        /// 
        /// E.G.
        /// 
        /// using(Throw throw = diceCup.Throw())
        /// {
        ///     ....
        /// }
        /// </summary>
        public void Dispose()
        {
            Rolls.Clear();
        }
    }
}
