using CardSystem.Core.Cards;

namespace CardSystem.Patterns.Observer
{
    /// <summary>
    /// Interface for observers that react to card plays
    /// Part of the Observer Pattern
    /// </summary>
    public interface ICardObserver
    {
        void Update(ICard card, object target = null);
    }
}