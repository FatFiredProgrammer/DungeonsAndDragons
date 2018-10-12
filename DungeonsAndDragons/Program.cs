using DungeonsAndDragons.Game;
using DungeonsAndDragons.Game.Weapons;

namespace DungeonsAndDragons
{
    public static class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// Note that there is no real logic here.
        /// We create some dependencies like the ConsoleUserInterface.
        /// This is called "Inversion of Control"
        /// And we create a player and then run the game.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            // Start a new adventure using the console as our user interface.
            var adventure = new Adventure(new ConsoleUserInterface());

            // Create a default player
            var player = new Character
            {
                Name = "Aaron's player",
                Weapon = new Maul(),
            };

            // Play an adventure with our player
            adventure.Play(player);
        }
    }
}
