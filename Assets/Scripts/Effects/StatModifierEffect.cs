using UnityEngine;
using CardSystem.Core.Effects;
using CardSystem.Entities;

namespace CardSystem.Effects
{
    /// <summary>
    /// Concrete implementation of a stat modifier effect
    /// Part of the Strategy Pattern
    /// </summary>
    public class StatModifierEffect : ICardEffect
    {
        private readonly string _stat;
        private readonly int _value;
        
        public StatModifierEffect(string stat, int value)
        {
            _stat = stat;
            _value = value;
        }
        
        public void Apply(object target = null)
        {
            Debug.Log($"Applying stat modifier: {_stat} {(_value > 0 ? "+" : "")}{_value}% to target");
            
            // In a full implementation, we would modify the target's stats
            // For example:
            if (target is Character character)
            {
                switch (_stat.ToLower())
                {
                    case "health":
                        character.ModifyHealth(_value);
                        break;
                    case "damage":
                        character.ModifyDamage(_value);
                        break;
                    case "speed":
                        character.ModifySpeed(_value);
                        break;
                    case "utility":
                        character.ModifyUtility(_value);
                        break;
                }
            }
        }
        
        public string GetDescription()
        {
            return $"{_stat} {(_value > 0 ? "+" : "")}{_value}%";
        }
    }
}