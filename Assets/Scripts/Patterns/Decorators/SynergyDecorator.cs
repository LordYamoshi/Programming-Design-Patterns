using UnityEngine;
using CardSystem.Core.Cards;
using CardSystem.Core.Effects;
using CardSystem.Management;

namespace CardSystem.Patterns.Decorator
{
    /// <summary>
    /// Decorator that adds synergy effects to a card
    /// Part of the Decorator Pattern
    /// </summary>
    public class SynergyDecorator : CardDecorator
    {
        private readonly ICardEffect _synergisticEffect;
        
        public SynergyDecorator(ICard card, ICardEffect effect) : base(card)
        {
            Name = $"Synergistic {card.Name}";
            Description = $"{card.Description} (Synergy Active)";
            _synergisticEffect = effect;
        }
        
        public override void Play(object target = null)
        {
            Debug.Log($"Playing card with synergy: {Name}");
            
            // First play the original card's effect
            WrappedCard.Play(target);
            
            // Then apply the synergistic effect
            _synergisticEffect.Apply(target);
            
            // Notify observers about the synergy
            CardManager.Instance.NotifyObservers(this, target);
        }
        
        public override ICardEffect GetEffect()
        {
            return _synergisticEffect;
        }
    }
}