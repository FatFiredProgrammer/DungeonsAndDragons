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
            lock (_lockObject)
            {
                // Which weapon to generate?
                var which = _random.Next(0, _weaponGenerator.Count);

                // Call the lambda to generate it.
                return _weaponGenerator[which]();
            }
        }
    }
}
