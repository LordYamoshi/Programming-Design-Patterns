using UnityEngine;
using CardSystem.Core.Cards;
using CardSystem.Effects;
using CardSystem.Utils;

namespace CardSystem.Patterns.Observer
{
    /// <summary>
    /// Observer that tracks changes to the community sentiment
    /// Part of the Observer Pattern
    /// </summary>
    public class CommunityObserver : ICardObserver
    {
        private float _satisfaction = 70f; // Default starting value (0-100)
        private float _engagement = 50f;   // Default starting value (0-100)
        private float _trust = 60f;        // Default starting value (0-100)
        
        public void Update(ICard card, object target = null)
        {
            Debug.Log($"Community Observer: Updating community sentiment after {card.Name}");
            
            // In a full implementation, this would update community sentiment
            // For example:
            switch (card.Type)
            {
                case CardType.BalanceChange:
                    HandleBalanceChangeFeedback(card);
                    break;
                    
                case CardType.MetaShift:
                    HandleMetaShiftReaction(card);
                    break;
                    
                case CardType.Community:
                    HandleCommunityEngagement(card);
                    break;
                    
                case CardType.CrisisResponse:
                    HandleCrisisReaction(card);
                    break;
            }
            
            // Report current sentiment metrics
            Debug.Log($"Community Sentiment - Satisfaction: {_satisfaction}, Engagement: {_engagement}, Trust: {_trust}");
        }
        
        private void HandleBalanceChangeFeedback(ICard card)
        {
            // Community often has mixed reactions to balance changes
            float satisfactionChange = Random.Range(-5f, 10f);
            
            // Balance changes that add power often more popular than nerfs
            if (card.GetEffect() is StatModifierEffect statEffect)
            {
                string description = statEffect.GetDescription();
                if (description.Contains("+"))
                {
                    satisfactionChange += 2f; // Buffs are slightly more popular
                }
                else if (description.Contains("-"))
                {
                    satisfactionChange -= 3f; // Nerfs are often unpopular
                }
            }
            
            _satisfaction = Mathf.Clamp(_satisfaction + satisfactionChange, 0f, 100f);
            Debug.Log($"Community reaction to balance change: {(satisfactionChange >= 0 ? "Positive" : "Negative")}");
        }
        
        private void HandleMetaShiftReaction(ICard card)
        {
            // Meta shifts create excitement and freshness
            float engagementChange = Random.Range(5f, 15f);
            _engagement = Mathf.Clamp(_engagement + engagementChange, 0f, 100f);
            
            // But can be disruptive to established players
            float satisfactionChange = Random.Range(-10f, 15f);
            _satisfaction = Mathf.Clamp(_satisfaction + satisfactionChange, 0f, 100f);
            
            Debug.Log($"Community excited about meta changes, engagement up by {engagementChange}");
        }
        
        private void HandleCommunityEngagement(ICard card)
        {
            // Community cards directly boost engagement and trust
            float engagementChange = Random.Range(5f, 20f);
            _engagement = Mathf.Clamp(_engagement + engagementChange, 0f, 100f);
            
            float trustChange = Random.Range(3f, 12f);
            _trust = Mathf.Clamp(_trust + trustChange, 0f, 100f);
            
            Debug.Log($"Community appreciates direct engagement, trust improved by {trustChange}");
        }
        
        private void HandleCrisisReaction(ICard card)
        {
            // Crisis responses can restore trust if handled well
            float trustChange = Random.Range(5f, 15f);
            _trust = Mathf.Clamp(_trust + trustChange, 0f, 100f);
            
            // May not fully satisfy but shows responsiveness
            float satisfactionChange = Random.Range(0f, 10f);
            _satisfaction = Mathf.Clamp(_satisfaction + satisfactionChange, 0f, 100f);
            
            Debug.Log($"Community relieved by crisis response, trust restored by {trustChange}");
        }
        
        private void HandleMysteryCardCuriosity(ICard card)
        {
            // Mystery creates curiosity and engagement
            float engagementChange = Random.Range(10f, 25f);
            _engagement = Mathf.Clamp(_engagement + engagementChange, 0f, 100f);
            
            // But can be confusing or frustrating
            float satisfactionChange = Random.Range(-10f, 10f);
            _satisfaction = Mathf.Clamp(_satisfaction + satisfactionChange, 0f, 100f);
            
            Debug.Log($"Community intrigued by mystery changes, engagement up by {engagementChange}");
        }
    }
}