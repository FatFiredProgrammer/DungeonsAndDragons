namespace DungeonsAndDragons.Game
{
    /// <summary>
    ///     This is a static class.
    ///     Essentially, it is filled with global variables only.
    ///     In this case, it contains all the dice we will use for our game.
    /// </summary>
    public static class Dice
    {
        public static Die Die4 = new Die(4);

        public static Die Die6 = new Die(6);

        public static Die Die8 = new Die(8);

        public static Die Die10 = new Die(10);

        public static Die Die12 = new Die(12);

        public static Die Die20 = new Die(20);
    }
}
