using System;

namespace DungeonsAndDragons.Game.Weapons
{
    /// <summary>
    ///     This is a "base" class to make implementing weapons easier.
    ///     It accumulates some shared logic.
    ///     Note how we derive from IWeapon.
    ///     Also note that this class is abstract.
    ///     You can't simply have a generic weapon.
    /// </summary>
    public abstract class Weapon : IWeapon
    {
        /// <inheritdoc />
        public abstract string Name { get; }

        /// <inheritdoc />
        public abstract int CalculateDamage(Character character);

        /// <summary>
        ///     Gets the base damage for a character based on his strength.
        ///     This logic is shared by all weapons.
        ///     Notice how this is a protected method.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <returns>System.Int32.</returns>
        protected int GetBaseDamage(Character character)
        {
            if (character == null)
                throw new ArgumentNullException(nameof(character));

            return (character.Strength - 10) / 2;
        }

        /// <inheritdoc />
        public override string ToString() => Name;
    }
}
