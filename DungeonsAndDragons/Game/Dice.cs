using System;

namespace DungeonsAndDragons.Game
{
    /// <summary>
    ///     This is a static class.
    ///     Essentially, it is filled with global variables only.
    ///     In this case, it contains all the dice we will use for our game.
    /// </summary>
    public static class Dice
    {
        /// <summary>
        ///     The random number generator.
        ///     This is static. We only have one of these.
        ///     On most Windows systems, Random objects created within 15 milliseconds of one another are likely to have identical
        ///     seed values.
        ///     So, we won't really get random numbers if we create a lot of these quickly.
        ///     Instead we use one of them.
        /// </summary>
        private static readonly Random _random = new Random();

        /// <summary>
        ///     The lock object.
        ///     The random number generator is not thread safe.
        ///     Even though we don't use threads, we are going to be thorough and be thread safe.
        /// </summary>
        private static readonly object _lockObject = new object();

        public static Die Die4 = new Die(4);

        public static Die Die6 = new Die(6);

        public static Die Die8 = new Die(8);

        public static Die Die10 = new Die(10);

        public static Die Die12 = new Die(12);

        public static Die Die20 = new Die(20);

        /// <summary>
        ///     Generate a random number using our built in random object.
        /// </summary>
        /// <param name="minimum">The minimum inclusive.</param>
        /// <param name="maximum">The maximum exclusive.</param>
        /// <returns>System.Int32.</returns>
        public static int Next(int minimum, int maximum)
        {
            lock (_lockObject)
            {
                // NOTE: The range for next is inclusive on the lower end but exclusive on the upper end.
                // We need to add one to the upper range so we get the correct range of values back.
                return _random.Next(minimum, maximum);
            }
        }

        /// <summary>
        ///     Generate a random number using our built in random object.
        ///     This generator essentially rolls two dice in order to create a more guassian like distribution.
        /// </summary>
        /// <param name="minimum">The minimum inclusive.</param>
        /// <param name="maximum">The maximum exclusive.</param>
        /// <returns>System.Int32.</returns>
        public static int Next2(int minimum, int maximum)
        {
            lock (_lockObject)
            {
                var range = (maximum - minimum) / 2;
                return Math.Min(minimum + _random.Next(0, range + 1) + _random.Next(0, range + 1), maximum - 1);
            }
        }
    }
}
