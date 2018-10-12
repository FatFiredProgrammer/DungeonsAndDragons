using System;
using System.Collections.Generic;

namespace DungeonsAndDragons.Game.Weapons
{
    /// <summary>
    ///     A class which supports weapon generation.
    /// </summary>
    public static class WeaponFactory
    {
        /// <summary>
        ///     A list which has lambdas which create weapons.
        ///     This is a very advanced concept.
        /// </summary>
        private static readonly List<Func<IWeapon>> _weaponGenerator = new List<Func<IWeapon>>
        {
            () => new Club(),
            () => new Dagger(),
            () => new GreatAxe(),
            () => new GreatSword(),
            () => new HandAxe(),
            () => new LongSword(),
            () => new Mace(),
            () => new Maul(),
            () => new ShortSword(),
            () => new Staff(),
            () => new WarAxe(),
        };

        /// <summary>
        ///     Generates a random weapon.
        /// </summary>
        /// <returns>DungeonsAndDragons.Game.IWeapon.</returns>
        public static IWeapon Generate()
        {
            // Which weapon to generate?
            var which = Dice.Next(0, _weaponGenerator.Count);

            // Call the lambda to generate it.
            return _weaponGenerator[which]();
        }
    }
}
