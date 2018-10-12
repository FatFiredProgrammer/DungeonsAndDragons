namespace DungeonsAndDragons.Game
{
    /// <summary>
    ///     This interface defines a weapon.
    /// </summary>
    public interface IWeapon
    {
        /// <summary>
        ///     Gets the name.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     Calculates the damage a character wielding this weapon will cause.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <returns>Damage caused.</returns>
        int CalculateDamage(Character character);
    }
}
