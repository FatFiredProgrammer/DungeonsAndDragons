using System;
using System.Threading;

namespace DungeonsAndDragons.Game
{
    /// <summary>
    ///     A class used to simulate a battle between a player and an enemy.
    /// </summary>
    public sealed class Battle
    {
        public Battle(Character player, Character enemy)
        {
            Player = player ?? throw new ArgumentNullException(nameof(player));
            Enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
        }

        public Character Player { get; }

        public Character Enemy { get; }

        public int Turn { get; set; }

        public void Fight(IUserInterface userInterface)
        {
            if (userInterface == null)
                throw new ArgumentNullException(nameof(userInterface));

            ++Turn;
#if !DEBUG
            // Only sleep running in release mode.
            if (Turn > 1)
                Thread.Sleep(TimeSpan.FromSeconds(2));
#endif

            userInterface.WriteLine("Sir:");
            userInterface.WriteLine($"Turn {Turn}");

            // Calculate the damage and the consequences.
            var playerDamage = Player.CalculateDamage();
            var enemyDamage = Enemy.CalculateDamage();

            Player.HitPoints -= enemyDamage;
            Player.TotalDamageTaken += enemyDamage;
            Player.TotalDamageDealt += playerDamage;

            Enemy.HitPoints -= playerDamage;
            Enemy.TotalDamageTaken += playerDamage;
            Enemy.TotalDamageDealt += enemyDamage;

            userInterface.WriteLine($"{Player.Name} did {playerDamage} damage and has {Player.HitPoints} HP.");
            userInterface.WriteLine($"{Enemy.Name} did {enemyDamage} damage and has {Enemy.HitPoints} HP.");
            userInterface.WriteLine(string.Empty);
        }
    }
}
