using CardSystem.Core.Cards;
using CardSystem.Core.Effects;
using CardSystem.Utils;

namespace CardSystem.Patterns.Decorator
{
    /// <summary>
    /// Base decorator class for adding functionality to cards
    /// Part of the Decorator Pattern
    /// </summary>
    public abstract class CardDecorator : BaseCard
    {
        protected readonly ICard WrappedCard;
        
        protected CardDecorator(ICard card) 
            : base(
                card.Id + "_decorated", 
                card.Name, 
                card.Description, 
                card.Type, 
                card.Rarity, 
                card.ResearchPointCost, 
                card.CommunityPointCost)
        {
            WrappedCard = card;
        }
    }
}