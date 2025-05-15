using UnityEngine;
using CardSystem.Core.Cards;
using CardSystem.Core.Effects;
using CardSystem.Management;
using CardSystem.Utils;

namespace CardSystem.Cards
{
    /// <summary>
    /// Concrete implementation of a Meta Shift card
    /// Part of the Strategy Pattern - uses different effects
    /// </summary>
    public class MetaShiftCard : BaseCard
    {
        private readonly ICardEffect _effect;

        public MetaShiftCard(string id, string name, string description,
            CardRarity rarity, int rpCost, int cpCost, ICardEffect effect)
            : base(id, name, description, CardType.MetaShift, rarity, rpCost, cpCost)
        {
            _effect = effect;
        }

        public override void Play(object target = null)
        {
            Debug.Log($"Playing Meta Shift Card: {Name}");
            CardManager.Instance.NotifyObservers(this, target);
            _effect.Apply(target);
        }
        
        public override ICardEffect GetEffect()
        {
            return _effect;
        }
    }
}