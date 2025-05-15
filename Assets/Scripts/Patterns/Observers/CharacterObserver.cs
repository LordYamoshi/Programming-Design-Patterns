using UnityEngine;
using CardSystem.Core.Cards;
using CardSystem.Entities;
using CardSystem.Utils;

namespace CardSystem.Patterns.Observer
{
    /// <summary>
    /// Observer that reacts to card plays by updating character state
    /// Part of the Observer Pattern
    /// </summary>
    public class CharacterObserver : ICardObserver
    {
        public void Update(ICard card, object target = null)
        {
            // Changed this line to not define a character variable in the string interpolation
            string targetName = target is Character ? ((Character)target).Name : "game";
            Debug.Log($"Character Observer: Reacting to {card.Name} played on {targetName}");
            
            // In a full implementation, this would update character state in response to cards
            if (target is Character character)
            {
                // Character-specific reactions based on card type
                switch (card.Type)
                {
                    case CardType.BalanceChange:
                        // Notify character of balance change, potentially affecting relationships
                        Debug.Log($"Character {character.Name} is affected by balance change {card.Name}");
                        break;
                        
                    case CardType.MetaShift:
                        // Update character's position in the meta
                        Debug.Log($"Character {character.Name}'s meta position shifting due to {card.Name}");
                        character.ModifyPopularity(Random.Range(-5f, 10f));
                        break;
                        
                    // Additional cases for other card types
                }
            }
            else
            {
                // Global character updates when no specific target
                Debug.Log("Updating all characters in response to played card");
                
            }
        }
    }
}