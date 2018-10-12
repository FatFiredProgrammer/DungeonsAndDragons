using System;

namespace DungeonsAndDragons.Game
{
    /// <summary>
    ///     This represents a single die in our game.
    /// </summary>
    public sealed class Die
    {
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
        /// <remarks>
        ///     NOTE: The range for next is inclusive on the lower end but exclusive on the upper end.
        ///     We need to add one to the upper range so we get the correct range of values back.
        /// </remarks>
        public int Roll() => Dice.Next(1, Sides + 1);

        /// <inheritdoc />
        public override string ToString() => $"{Sides} sided die";
    }
}
