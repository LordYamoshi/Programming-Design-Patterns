namespace CardSystem.Core.Effects
{
    /// <summary>
    /// Interface for all card effects in the system
    /// Implements the Strategy pattern for different effect behaviors
    /// </summary>
    public interface ICardEffect
    {
        void Apply(object target = null);
        string GetDescription();
    }
}