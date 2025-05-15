using UnityEngine;
using CardSystem.Core.Cards;
using CardSystem.Effects;

namespace CardSystem.Patterns.Command
{
    /// <summary>
    /// Command for playing a card
    /// Part of the Command Pattern
    /// </summary>
    public class PlayCardCommand : ICardCommand
    {
        private readonly ICard _card;
        private readonly object _target;
        
        public PlayCardCommand(ICard card, object target = null)
        {
            _card = card;
            _target = target;
        }
        
        public void Execute()
        {
            Debug.Log($"Executing card command: {_card.Name}");
            _card.Play(_target);
        }
        
        public void Undo()
        {
            Debug.Log($"Undoing card command: {_card.Name}");
            // In a full implementation, this would reverse the card's effects
            if (_card.GetEffect() is StatModifierEffect statEffect)
            {
                // Apply the opposite effect
                // For example, if it was +10% Health, apply -10% Health
                // This would require effects to have an inverseApply method in a real implementation
                Debug.Log($"Reversing stat effect: {statEffect.GetDescription()}");
            }
        }
        
        public ICard GetCard()
        {
            return _card;
        }
        
        public object GetTarget()
        {
            return _target;
        }
    }
}