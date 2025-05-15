using System;
using UnityEngine;
using CardSystem.Core.Effects;
using CardSystem.Utils;

namespace CardSystem.Core.Cards
{
    /// <summary>
    /// Abstract base class for all cards, implementing ICard
    /// </summary>
    public abstract class BaseCard : ICard
    {
        public string Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public CardType Type { get; protected set; }
        public CardRarity Rarity { get; protected set; }
        public int ResearchPointCost { get; protected set; }
        public int CommunityPointCost { get; protected set; }
        
        protected BaseCard(string id, string name, string description, CardType type, 
            CardRarity rarity, int rpCost, int cpCost)
        {
            Id = id;
            Name = name;
            Description = description;
            Type = type;
            Rarity = rarity;
            ResearchPointCost = rpCost;
            CommunityPointCost = cpCost;
        }
        
        public abstract void Play(object target = null);
        public abstract ICardEffect GetEffect();
        
        public override string ToString()
        {
            return $"{Name} ({Type}) - {Description}";
        }
    }
}