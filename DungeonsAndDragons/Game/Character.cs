using System.Text;
using DungeonsAndDragons.Game.Weapons;

namespace DungeonsAndDragons.Game
{
    /// <summary>
    ///     This defines a character.
    ///     It could be our character or our enemy.
    /// </summary>
    public sealed class Character
    {
        public string Name { get; set; } = nameof(Character);

        public int Level { get; set; } = 1;

        public int ExperiencePoints { get; set; } = 0;

        public int HitPoints { get; set; } = 50;

        public int MagicPoints { get; set; } = 80;

        public int Strength { get; set; } = 16;

        public int Dexterity { get; set; } = 10;

        public int Concentration { get; set; } = 18;

        public int Intelligence { get; set; } = 10;

        public int Wisdom { get; set; } = 10;

        public int Charisma { get; set; } = 10;

        public IWeapon Weapon { get; set; } = new Club();

        public int TotalDamageTaken { get; set; }

        public int TotalDamageDealt { get; set; }

        public bool IsAlive => HitPoints > 0;

        public int MaxHitPoints => ((Concentration - 10) / 2) * Level + 50;

        public bool ShouldLevelUp
        {
            get
            {
                if (!IsAlive)
                    return false;

                // You need to defeat about level# enemies.
                // Sigma N for 1..N is equivalent to (N * (N+1)) / 2
                // In other words, at each level, you need another Level * Adventure.ExperiencePointsPerEnemy XP.
                return ExperiencePoints >= ((Level * (Level + 1)) / 2) * Adventure.ExperiencePointsPerEnemy;
            }
        }

        /// <summary>
        ///     Calculates the damage a character wielding this weapon will cause.
        /// </summary>
        /// <returns>Damage caused.</returns>
        public int CalculateDamage() => Weapon.CalculateDamage(this);

        /// <summary>
        /// Levels up a character
        /// </summary>
        public void LevelUp()
        {
            Level++;
            Strength++;
            ResetHitPoints();
        }

        /// <summary>
        /// Resets the hit points to the maximum value.
        /// </summary>
        public void ResetHitPoints()
        {
            HitPoints = MaxHitPoints;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            var text = new StringBuilder();
            text.AppendLine($"{Name} - Level {Level}, {ExperiencePoints} XP");
            text.AppendLine($"\tWielding a {Weapon.Name}");
            text.AppendLine($"\t{nameof(HitPoints)}={HitPoints}");
            text.AppendLine($"\t{nameof(MagicPoints)}={MagicPoints}");
            text.AppendLine($"\t{nameof(Strength)}={Strength}");
            text.AppendLine($"\t{nameof(Dexterity)}={Dexterity}");
            text.AppendLine($"\t{nameof(Concentration)}={Concentration}");
            text.AppendLine($"\t{nameof(Intelligence)}={Intelligence}");
            text.AppendLine($"\t{nameof(Wisdom)}={Wisdom}");
            text.AppendLine($"\t{nameof(Charisma)}={Charisma}");
            if (TotalDamageTaken > 0)
                text.AppendLine($"\t{nameof(TotalDamageTaken)}={TotalDamageTaken}");
            if (TotalDamageDealt > 0)
                text.AppendLine($"\t{nameof(TotalDamageDealt)}={TotalDamageDealt}");
            return text.ToString();
        }
    }
}
