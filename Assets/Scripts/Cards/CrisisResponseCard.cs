using UnityEngine;
using CardSystem.Core.Cards;
using CardSystem.Core.Effects;
using CardSystem.Management;
using CardSystem.Utils;

namespace CardSystem.Cards
{
    /// <summary>
    /// Concrete implementation of a Crisis Response card
    /// Part of the Strategy Pattern - uses different effects
    /// </summary>
    public class CrisisResponseCard : BaseCard
    {
        private readonly ICardEffect _effect;
        
        public CrisisResponseCard(string id, string name, string description, 
            CardRarity rarity, int rpCost, int cpCost, ICardEffect effect) 
            : base(id, name, description, CardType.CrisisResponse, rarity, rpCost, cpCost)
        {
            _effect = effect;
        }
        
        public override void Play(object target = null)
        {
            Debug.Log($"Playing Crisis Response Card: {Name}");
            CardManager.Instance.NotifyObservers(this, target);
            _effect.Apply(target);
        }
        
        public override ICardEffect GetEffect()
        {
            return _effect;
        }
    }
}