using UnityEngine;
using CardSystem.Core.Cards;
using CardSystem.Core.Effects;
using CardSystem.Management;
using CardSystem.Utils;

namespace CardSystem.Cards
{
    /// <summary>
    /// Concrete implementation of a Balance Change card
    /// Part of the Strategy Pattern - uses different effects
    /// </summary>
    public class BalanceChangeCard : BaseCard
    {
        private readonly ICardEffect _effect;
        
        public BalanceChangeCard(string id, string name, string description, 
            CardRarity rarity, int rpCost, int cpCost, ICardEffect effect) 
            : base(id, name, description, CardType.BalanceChange, rarity, rpCost, cpCost)
        {
            _effect = effect;
        }
        
        public override void Play(object target = null)
        {
            Debug.Log($"Playing Balance Change Card: {Name}");
            CardManager.Instance.NotifyObservers(this, target);
            _effect.Apply(target);
        }
        
        public override ICardEffect GetEffect()
        {
            return _effect;
        }
    }
}