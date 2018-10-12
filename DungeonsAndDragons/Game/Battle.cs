using System;

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

            while (Player.IsAlive && Enemy.IsAlive)
            {
                FightOneRound(userInterface);
            }
        }

        private void FightOneRound(IUserInterface userInterface)
        {
            ++Turn;

#if !DEBUG

// Only sleep running in release mode.
            if (Turn > 1)
                Thread.Sleep(TimeSpan.FromSeconds(2));
#endif

            userInterface.WriteLine($"Turn {Turn}");

            // Calculate the damage and the consequences.
            var playerDamage = Player.CalculateDamage();

            Player.TotalDamageDealt += playerDamage;
            Enemy.HitPoints -= playerDamage;
            Enemy.TotalDamageTaken += playerDamage;
            userInterface.WriteLine($"{Player.Name} did {playerDamage} damage and {Enemy.Name} has {Enemy.HitPoints} HP.");

            // Enemy only gets to strike if not already dead!
            if (Enemy.IsAlive)
            {
                var enemyDamage = Enemy.CalculateDamage();
                Enemy.TotalDamageDealt += enemyDamage;
                Player.HitPoints -= enemyDamage;
                Player.TotalDamageTaken += enemyDamage;
                userInterface.WriteLine($"{Enemy.Name} did {enemyDamage} damage and {Player.Name} has {Player.HitPoints} HP.");
            }

            userInterface.WriteLine(string.Empty);
        }
    }
}
