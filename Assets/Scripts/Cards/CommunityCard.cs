using UnityEngine;
using CardSystem.Core.Cards;
using CardSystem.Core.Effects;
using CardSystem.Management;
using CardSystem.Utils;

namespace CardSystem.Cards
{
    /// <summary>
    /// Concrete implementation of a Community card
    /// Part of the Strategy Pattern - uses different effects
    /// </summary>
    public class CommunityCard : BaseCard
    {
        private readonly ICardEffect _effect;
        
        public CommunityCard(string id, string name, string description, 
            CardRarity rarity, int rpCost, int cpCost, ICardEffect effect) 
            : base(id, name, description, CardType.Community, rarity, rpCost, cpCost)
        {
            _effect = effect;
        }
        
        public override void Play(object target = null)
        {
            Debug.Log($"Playing Community Card: {Name}");
            CardManager.Instance.NotifyObservers(this, target);
            _effect.Apply(target);
        }
        
        public override ICardEffect GetEffect()
        {
            return _effect;
        }
    }
}