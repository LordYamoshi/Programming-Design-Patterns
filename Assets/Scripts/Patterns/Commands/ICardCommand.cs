using CardSystem.Core.Cards;

namespace CardSystem.Patterns.Command
{
    /// <summary>
    /// Interface for command pattern implementation
    /// </summary>
    public interface ICardCommand
    {
        void Execute();
        void Undo();
        ICard GetCard();
        object GetTarget();
    }
}