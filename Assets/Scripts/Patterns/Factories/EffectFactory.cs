using System;
using UnityEngine;
using CardSystem.Core.Effects;
using CardSystem.Effects;
using CardSystem.Utils;

namespace CardSystem.Patterns.Factory
{
    /// <summary>
    /// Factory for creating different types of card effects
    /// Follows the Factory Pattern to centralize effect creation logic
    /// </summary>
    public class EffectFactory : MonoBehaviour
    {
        private static EffectFactory _instance;
        
        // Singleton pattern for easy access
        public static EffectFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject go = new GameObject("EffectFactory");
                    _instance = go.AddComponent<EffectFactory>();
                    DontDestroyOnLoad(go);
                }
                return _instance;
            }
        }

        /// <summary>
        /// Creates an effect of the specified type
        /// </summary>
        public ICardEffect CreateEffect(EffectType type)
        {
            switch(type)
            {
                case EffectType.StatModifier:
                    string[] stats = { "Health", "Damage", "Speed", "Utility" };
                    string stat = stats[UnityEngine.Random.Range(0, stats.Length)];
                    int value = UnityEngine.Random.Range(-10, 11); // -10 to +10
                    return new StatModifierEffect(stat, value);
                    
                case EffectType.EnvironmentModifier:
                    string[] environments = { "Map Rotation", "Item Rebalance", "Game Mode Adjustment" };
                    string env = environments[UnityEngine.Random.Range(0, environments.Length)];
                    return new EnvironmentModifierEffect(env);
                    
                case EffectType.PerceptionModifier:
                    string[] perceptions = { "Community Reception", "Player Satisfaction", "Esports Appeal" };
                    string perception = perceptions[UnityEngine.Random.Range(0, perceptions.Length)];
                    int perceptionValue = UnityEngine.Random.Range(0, 31); // 0 to 30
                    return new PerceptionModifierEffect(perception, perceptionValue);
                    
                case EffectType.EmergencyModifier:
                    string[] emergencies = { "Hotfix", "Bug Fix", "Community Management" };
                    string emergency = emergencies[UnityEngine.Random.Range(0, emergencies.Length)];
                    return new EmergencyModifierEffect(emergency);
                
                default:
                    Debug.LogError($"Unknown effect type: {type}");
                    return null;
            }
        }
        
        /// <summary>
        /// Creates a specific stat modifier effect
        /// </summary>
        public ICardEffect CreateStatModifierEffect(string stat, int value)
        {
            return new StatModifierEffect(stat, value);
        }
        
        /// <summary>
        /// Creates a specific environment modifier effect
        /// </summary>
        public ICardEffect CreateEnvironmentModifierEffect(string environmentChange)
        {
            return new EnvironmentModifierEffect(environmentChange);
        }
        
        /// <summary>
        /// Creates a specific perception modifier effect
        /// </summary>
        public ICardEffect CreatePerceptionModifierEffect(string perceptionType, int value)
        {
            return new PerceptionModifierEffect(perceptionType, value);
        }
        
        /// <summary>
        /// Creates a specific emergency modifier effect
        /// </summary>
        public ICardEffect CreateEmergencyModifierEffect(string emergencyType)
        {
            return new EmergencyModifierEffect(emergencyType);
        }
    }
}