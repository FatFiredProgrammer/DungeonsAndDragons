using System;
using System.Diagnostics;

namespace DungeonsAndDragons.Game
{
    /// <summary>
    ///     This is a user interface which writes to the console.
    ///     Note how it implements the IUserInterface interface.
    /// </summary>
    public sealed class ConsoleUserInterface : IUserInterface
    {
        /// <summary>
        ///     Writes the line.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <inheritdoc />
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
            Debug.WriteLine(text);
        }
    }
}
