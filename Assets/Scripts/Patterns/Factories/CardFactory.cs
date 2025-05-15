using System;
using UnityEngine;
using CardSystem.Core.Cards;
using CardSystem.Core.Effects;
using CardSystem.Cards;
using CardSystem.Utils;

namespace CardSystem.Patterns.Factory
{
    /// <summary>
    /// Factory for creating different types of cards
    /// Follows the Factory Pattern to centralize card creation logic
    /// </summary>
    public class CardFactory : MonoBehaviour
    {
        private static CardFactory _instance;
        
        // Singleton pattern for easy access
        public static CardFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject go = new GameObject("CardFactory");
                    _instance = go.AddComponent<CardFactory>();
                    DontDestroyOnLoad(go);
                }
                return _instance;
            }
        }

        /// <summary>
        /// Creates a card of the specified type with the given properties
        /// </summary>
        public ICard CreateCard(CardType type, string name, string description, 
                             CardRarity rarity, int rpCost, int cpCost)
        {
            string id = $"card_{DateTime.Now.Ticks}_{UnityEngine.Random.Range(0, 1000)}";
            
            ICard card = null;
            
            switch(type)
            {
                case CardType.BalanceChange:
                    ICardEffect balanceEffect = EffectFactory.Instance.CreateEffect(EffectType.StatModifier);
                    card = new BalanceChangeCard(id, name, description, rarity, rpCost, cpCost, balanceEffect);
                    break;
                    
                case CardType.MetaShift:
                    ICardEffect metaEffect = EffectFactory.Instance.CreateEffect(EffectType.EnvironmentModifier);
                    card = new MetaShiftCard(id, name, description, rarity, rpCost, cpCost, metaEffect);
                    break;
                    
                case CardType.Community:
                    ICardEffect communityEffect = EffectFactory.Instance.CreateEffect(EffectType.PerceptionModifier);
                    card = new CommunityCard(id, name, description, rarity, rpCost, cpCost, communityEffect);
                    break;
                    
                case CardType.CrisisResponse:
                    ICardEffect crisisEffect = EffectFactory.Instance.CreateEffect(EffectType.EmergencyModifier);
                    card = new CrisisResponseCard(id, name, description, rarity, rpCost, cpCost, crisisEffect);
                    break;
                
                default:
                    Debug.LogError($"Unknown card type: {type}");
                    break;
            }
            
            return card;
        }
    }
}