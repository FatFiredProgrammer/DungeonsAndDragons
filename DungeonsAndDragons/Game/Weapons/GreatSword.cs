using System;

namespace DungeonsAndDragons.Game.Weapons
{
    /// <summary>
    ///     This is a specific type of weapon.
    ///     Note how it derives from Weapon (which, itself, implements IWeapon interface).
    /// </summary>
    public sealed class GreatSword : Weapon
    {
        /// <inheritdoc />
        public override string Name { get; } = nameof(GreatSword);

        /// <inheritdoc />
        /// <remarks>Note that we use Math.Max to make sure our damage is not negative.</remarks>
        public override int CalculateDamage(Character character) => Math.Max(1, GetBaseDamage(character) + Dice.Die6.Roll() + Dice.Die6.Roll());
    }
}
