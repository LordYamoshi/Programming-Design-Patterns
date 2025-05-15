using UnityEngine;
using CardSystem.Core.Effects;

namespace CardSystem.Effects
{
    /// <summary>
    /// Concrete implementation of an emergency modifier effect
    /// Part of the Strategy Pattern
    /// </summary>
    public class EmergencyModifierEffect : ICardEffect
    {
        private readonly string _emergencyType;
        
        public EmergencyModifierEffect(string emergencyType)
        {
            _emergencyType = emergencyType;
        }
        
        public void Apply(object target = null)
        {
            Debug.Log($"Applying emergency action: {_emergencyType}");
            
            // In a full implementation, this would handle crisis situations
            switch (_emergencyType)
            {
                case "Hotfix":
                    Debug.Log("Implementing emergency hotfix");
                    // This would apply immediate balance fixes
                    break;
                    
                case "Bug Fix":
                    Debug.Log("Fixing critical bug");
                    // This would resolve gameplay issues
                    break;
                    
                case "Community Management":
                    Debug.Log("Addressing community concerns");
                    // This would mitigate negative sentiment
                    break;
            }
        }
        
        public string GetDescription()
        {
            return $"Emergency: {_emergencyType}";
        }
    }
}