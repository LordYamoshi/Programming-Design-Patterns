using CardSystem.Core.Effects;
using CardSystem.Utils;

namespace CardSystem.Core.Cards
{
    /// <summary>
    /// Base interface for all cards in the system
    /// </summary>
    public interface ICard
    {
        string Id { get; }
        string Name { get; }
        string Description { get; }
        CardType Type { get; }
        CardRarity Rarity { get; }
        int ResearchPointCost { get; }
        int CommunityPointCost { get; }
        
        void Play(object target = null);
        ICardEffect GetEffect();
    }
}