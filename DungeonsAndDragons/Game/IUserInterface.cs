namespace DungeonsAndDragons.Game
{
    /// <summary>
    /// This is an interface which defines our user interface.
    /// It doesn't specify HOW it works, it only specifies WHAT is can do.
    /// It might use a GUI or a web or a phone interface.
    /// This interface provides an abstraction.
    /// Other classes will implement our user interface.
    /// We have a very simple user interface. All we can do is write text.
    /// </summary>
    public interface IUserInterface
    {
        /// <summary>
        /// Writes the line.
        /// </summary>
        /// <param name="text">The text.</param>
        void WriteLine(string text);
    }
}
