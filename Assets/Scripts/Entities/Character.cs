using UnityEngine;

namespace CardSystem.Entities
{
    /// <summary>
    /// Represents a character in the game that can be affected by cards
    /// </summary>
    public class Character : MonoBehaviour
    {
        public string Name { get; set; }
        public float Health { get; private set; } = 100f;
        public float Damage { get; private set; } = 20f;
        public float Speed { get; private set; } = 10f;
        public float Utility { get; private set; } = 50f;
        
  
        public float Popularity { get; private set; } = 50f;
        public float WinRate { get; private set; } = 50f;
        public float PickRate { get; private set; } = 10f;
        
        private void Start()
        {
            if (string.IsNullOrEmpty(Name))
            {
                Name = gameObject.name;
            }
            
            Debug.Log($"Character initialized: {Name}");
        }
        
        public void ModifyHealth(float percentage) 
        {
            float oldValue = Health;
            Health *= (1 + percentage / 100f);
            Debug.Log($"{Name}'s Health changed from {oldValue} to {Health} ({(percentage >= 0 ? "+" : "")}{percentage}%)");
        }
        
        public void ModifyDamage(float percentage) 
        {
            float oldValue = Damage;
            Damage *= (1 + percentage / 100f);
            Debug.Log($"{Name}'s Damage changed from {oldValue} to {Damage} ({(percentage >= 0 ? "+" : "")}{percentage}%)");
        }
        
        public void ModifySpeed(float percentage) 
        {
            float oldValue = Speed;
            Speed *= (1 + percentage / 100f);
            Debug.Log($"{Name}'s Speed changed from {oldValue} to {Speed} ({(percentage >= 0 ? "+" : "")}{percentage}%)");
        }
        
        public void ModifyUtility(float percentage) 
        {
            float oldValue = Utility;
            Utility *= (1 + percentage / 100f);
            Debug.Log($"{Name}'s Utility changed from {oldValue} to {Utility} ({(percentage >= 0 ? "+" : "")}{percentage}%)");
        }
        
        public void ModifyPopularity(float change)
        {
            Popularity = Mathf.Clamp(Popularity + change, 0f, 100f);
            Debug.Log($"{Name}'s Popularity is now {Popularity}");
        }
        
        public void UpdateWinRate(float newWinRate)
        {
            WinRate = Mathf.Clamp(newWinRate, 0f, 100f);
            Debug.Log($"{Name}'s Win Rate is now {WinRate}%");
        }
        
        public void UpdatePickRate(float newPickRate)
        {
            PickRate = Mathf.Clamp(newPickRate, 0f, 100f);
            Debug.Log($"{Name}'s Pick Rate is now {PickRate}%");
        }
        
        // Apply a direct or one-time stat change
        public void ApplyStatChange(string statName, float value)
        {
            switch (statName.ToLower())
            {
                case "health":
                    ModifyHealth(value);
                    break;
                    
                case "damage":
                    ModifyDamage(value);
                    break;
                    
                case "speed":
                    ModifySpeed(value);
                    break;
                    
                case "utility":
                    ModifyUtility(value);
                    break;
                    
                case "popularity":
                    ModifyPopularity(value);
                    break;
                    
                default:
                    Debug.LogWarning($"Unknown stat: {statName}");
                    break;
            }
        }
    }
}