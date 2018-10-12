using System;
using DungeonsAndDragons.Game.Weapons;

namespace DungeonsAndDragons.Game
{
    /// <summary>
    ///     The master class which represents our DnD adventure.
    /// </summary>
    public sealed class Adventure
    {
        /// <summary>
        ///     A constant for the experience points per enemy defeated.
        /// </summary>
        public const int ExperiencePointsPerEnemy = 25;

        /// <summary>
        ///     A constant for the amount of health recovered between rounds.
        /// </summary>
        public const int HealthRecoveredPerRound = 20;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Adventure" /> class.
        ///     Note that the user interface is passed in a parameter.
        ///     This is called inversion of control.
        ///     The adventure does not really know anything about the user interface
        ///     except that we have one.
        /// </summary>
        /// <param name="userInterface">The user interface.</param>
        public Adventure(IUserInterface userInterface)
            => _userInterface = userInterface;

        private readonly IUserInterface _userInterface;

        private static bool GameOver(Character player) => player.Level >= 20 || !player.IsAlive;

        /// <summary>
        ///     Generates an enemy commensurate with player's current level.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <returns>Character.</returns>
        private static Character GenerateEnemy(Character player)
        {
            // Create a random level here from 1 to 20 but < than player's level (if possible).
            var level = player.Level == 1 ? 1: Dice.Next2(1, player.Level - 1);
            var enemy = new Character
            {
                Level = level,
                HitPoints = 20,
                MagicPoints = 80,
                Strength = 12 + level,
                Dexterity = 10,
                Concentration = 10 + level,
                Intelligence = 10,
                Wisdom = 10,
                Charisma = 10,
                Weapon = WeaponFactory.Generate(),
            };

            // Name
            enemy.Name = $"Level {enemy.Level} {enemy.Weapon.Name} Wielder";

            // Start with maximum hit points.
            enemy.ResetHitPoints();
            return enemy;
        }

        private static int GetExperiencePoints(Character enemy) => ExperiencePointsPerEnemy + enemy.Level;

        public void Play(Character player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            WriteLine("Starting adventure...");
            player.ResetHitPoints();
            WriteLine(player.ToString());

            // While game is not over, keep trying.
            while (!GameOver(player))
            {
                // Spawn an enemy
                var enemy = GenerateEnemy(player);
                WriteLine();
                WriteLine("Enemy spawned");
                WriteLine($"{enemy}");

                // Battle it out
                var battle = new Battle(player, enemy);
                battle.Fight(_userInterface);

                // What happened to the enemy?
                WriteLine(enemy.IsAlive ? $"{enemy.Name} was victorious." : $"{enemy.Name} was killed.");
                WriteLine($"{enemy}");

                // If player is alive, award experience
                if (player.IsAlive)
                {
                    player.ExperiencePoints += GetExperiencePoints(enemy);
                    WriteLine($"{player.Name} now has {player.ExperiencePoints} XP");

                    // Recover a little health
                    // Cannot exceed maximum.
                    player.HitPoints = Math.Min(player.HitPoints + HealthRecoveredPerRound, player.MaxHitPoints);
                }

                // Check if we should level up.
                if (player.ShouldLevelUp)
                {
                    player.LevelUp();
                    WriteLine($"Congratulations! {player.Name} is now level {player.Level}!");
                }

                // Write player's stats
                WriteLine($"{player}");
            }

            WriteLine(player.IsAlive ? "You win." : "You died.");
            WriteLine("Game over...");
            WriteLine(player.ToString());
        }

        private void WriteLine(string text = null)
        {
            _userInterface?.WriteLine(text ?? string.Empty);
        }
    }
}
