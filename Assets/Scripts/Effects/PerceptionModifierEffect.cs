using UnityEngine;
using CardSystem.Core.Effects;

namespace CardSystem.Effects
{
    /// <summary>
    /// Concrete implementation of a perception modifier effect
    /// Part of the Strategy Pattern
    /// </summary>
    public class PerceptionModifierEffect : ICardEffect
    {
        private readonly string _perceptionType;
        private readonly int _value;
        
        public PerceptionModifierEffect(string perceptionType, int value)
        {
            _perceptionType = perceptionType;
            _value = value;
        }
        
        public void Apply(object target = null)
        {
            Debug.Log($"Applying perception modifier: {_perceptionType} +{_value}%");
            
            // In a full implementation, this would modify community perception
            switch (_perceptionType)
            {
                case "Community Reception":
                    Debug.Log($"Improving community reception by {_value}%");
                    // This would update community satisfaction metrics
                    break;
                    
                case "Player Satisfaction":
                    Debug.Log($"Increasing player satisfaction by {_value}%");
                    // This would modify player happiness values
                    break;
                    
                case "Esports Appeal":
                    Debug.Log($"Enhancing esports appeal by {_value}%");
                    // This would improve competitive aspects
                    break;
            }
        }
        
        public string GetDescription()
        {
            return $"{_perceptionType} +{_value}%";
        }
    }
}