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
        private const int ExperiencePointsPerEnemy = 35;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Adventure" /> class.
        ///     Note that the user interface is passed in a parameter.
        ///     This is called inversion of control.
        ///     The adventure does not really know anything about the user interface
        ///     except that we have one.
        /// </summary>
        /// <param name="userInterface">The user interface.</param>
        public Adventure(IUserInterface userInterface)
            => _userInterface = userInterface ?? throw new ArgumentNullException(nameof(userInterface));

        private readonly IUserInterface _userInterface;

        private static bool GameOver(Character player) => player.Level >= 20 || !player.IsAlive;

        /// <summary>
        ///     Generates an enemy commensurate with player's current level.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <returns>Character.</returns>
        private static Character GenerateEnemy(Character player)
        {
            var enemy = new Character
            {
                HitPoints = 20,
                MagicPoints = 80,
                Strength = 12 + player.Level,
                Dexterity = 10,
                Concentration = 10 + player.Level,
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

        public void Play(Character player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            _userInterface.WriteLine("Starting adventure...");
            player.ResetHitPoints();
            _userInterface.WriteLine(player.ToString());

            // While game is not over, keep trying.
            while (!GameOver(player))
            {
                // Spawn an enemy
                var enemy = GenerateEnemy(player);
                _userInterface.WriteLine("Enemy spawned");
                _userInterface.WriteLine($"{enemy}");

                // Battle it out
                var battle = new Battle(player, enemy);
                while (player.IsAlive && enemy.IsAlive)
                {
                    battle.Fight(_userInterface);
                }

                if (!enemy.IsAlive)
                    _userInterface.WriteLine($"{enemy.Name} was killed.");

                // If player is alive, award experience
                if (player.IsAlive)
                {
                    player.ExperiencePoints += ExperiencePointsPerEnemy;
                    _userInterface.WriteLine($"{player.Name} has {player.ExperiencePoints} XP");
                }

                // Check if we should level up.
                if (player.ShouldLevelUp)
                {
                    player.LevelUp();
                    _userInterface.WriteLine($"Congratulations! {player.Name} is now level {player.Level}!");
                    _userInterface.WriteLine($"{player}");
                }
            }

            _userInterface.WriteLine(player.IsAlive ? "You win." : "You died.");
            _userInterface.WriteLine("Game over...");
            _userInterface.WriteLine(player.ToString());
        }
    }
}
