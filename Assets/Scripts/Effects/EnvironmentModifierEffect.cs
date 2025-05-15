using UnityEngine;
using CardSystem.Core.Effects;

namespace CardSystem.Effects
{
    /// <summary>
    /// Concrete implementation of an environment modifier effect
    /// Part of the Strategy Pattern
    /// </summary>
    public class EnvironmentModifierEffect : ICardEffect
    {
        private readonly string _environmentChange;
        
        public EnvironmentModifierEffect(string environmentChange)
        {
            _environmentChange = environmentChange;
        }
        
        public void Apply(object target = null)
        {
            Debug.Log($"Applying environment change: {_environmentChange}");
            
            // In a full implementation, this would modify the game environment
            switch (_environmentChange)
            {
                case "Map Rotation":
                    Debug.Log("Changing the active map pool");
                    // This would update the game's map rotation
                    break;
                    
                case "Item Rebalance":
                    Debug.Log("Adjusting item stats across the game");
                    // This would modify item statistics
                    break;
                    
                case "Game Mode Adjustment":
                    Debug.Log("Modifying game mode parameters");
                    // This would change how game modes function
                    break;
            }
        }
        
        public string GetDescription()
        {
            return $"Environment: {_environmentChange}";
        }
    }
}