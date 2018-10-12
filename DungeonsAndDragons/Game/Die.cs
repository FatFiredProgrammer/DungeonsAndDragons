using System;

namespace DungeonsAndDragons.Game
{
    /// <summary>
    ///     This represents a single die in our game.
    /// </summary>
    public sealed class Die
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

        /// <summary>
        ///     Initializes a new instance of the <see cref="Die" /> class with a specific number of sides.
        /// </summary>
        /// <param name="sides">The sides.</param>
        public Die(int sides)
        {
            // Check parameter before we use it
            if (sides < 2 || sides > 20)
                throw new ArgumentException("sides < 2 || sides > 20", nameof(sides));

            Sides = sides;
        }

        /// <summary>
        ///     A read-only property showing how many sides this dice has
        /// </summary>
        /// <value>The sides.</value>
        public int Sides { get; }

        /// <summary>
        ///     Rolls this die.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Roll()
        {
            // For thread safety, we lock before using the random number generator.
            lock (_lockObject)
            {
                // NOTE: The range for next is inclusive on the lower end but exclusive on the upper end.
                // We need to add one to the upper range so we get the correct range of values back.
                return _random.Next(1, Sides + 1);
            }
        }

        /// <inheritdoc />
        public override string ToString() => $"{Sides} sided die";
    }
}
