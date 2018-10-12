using System.Diagnostics;

namespace DungeonsAndDragons.Game
{
    /// <summary>
    ///     This is a user interface which writes to the debug trace.
    ///     Note how it implements the IUserInterface interface.
    /// </summary>
    public sealed class TraceUserInterface : IUserInterface
    {
        /// <inheritdoc />
        public void WriteLine(string text)
        {
            Debug.WriteLine(text);
        }
    }
}
