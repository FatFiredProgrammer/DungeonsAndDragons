﻿using System;

namespace DungeonsAndDragons.Game.Weapons
{
    /// <summary>
    ///     This is a specific type of weapon.
    ///     Note how it derives from Weapon (which, itself, implements IWeapon interface).
    /// </summary>
    public sealed class Dagger : Weapon
    {
        /// <inheritdoc />
        public override string Name { get; } = nameof(Dagger);

        /// <inheritdoc />
        /// <remarks>Note that we use Math.Max to make sure our damage is not negative.</remarks>
        public override int CalculateDamage(Character character) => Math.Max(0, GetBaseDamage(character) + Dice.Die4.Roll());
    }
}
