using System.Collections.Generic;
using UnityEngine;
using CardSystem.Core.Cards;
using CardSystem.Core.Effects;
using CardSystem.Effects;
using CardSystem.Patterns.Command;
using CardSystem.Patterns.Decorator;
using CardSystem.Patterns.Observer;
using CardSystem.Utils;

namespace CardSystem.Management
{
    /// <summary>
    /// Main manager for the card system
    /// Implements the Observer pattern and integrates other patterns
    /// </summary>
    public class CardManager : MonoBehaviour
    {
        private static CardManager _instance;
        public static CardManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject go = new GameObject("CardManager");
                    _instance = go.AddComponent<CardManager>();
                    DontDestroyOnLoad(go);
                }
                return _instance;
            }
        }
        
        private readonly List<ICardObserver> _observers = new List<ICardObserver>();
        private readonly List<ICardCommand> _playedCards = new List<ICardCommand>();
        
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }
            
            _instance = this;
            DontDestroyOnLoad(gameObject);
            
            // Initialize with default observers
            AddObserver(new CharacterObserver());
            AddObserver(new MetaObserver());
            AddObserver(new CommunityObserver());
        }
        
        #region Observer Pattern Methods
        
        public void AddObserver(ICardObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }
        
        public void RemoveObserver(ICardObserver observer)
        {
            _observers.Remove(observer);
        }
        
        public void NotifyObservers(ICard card, object target = null)
        {
            foreach (var observer in _observers)
            {
                observer.Update(card, target);
            }
        }
        
        #endregion
        
        #region Command Pattern Methods
        
        public void PlayCard(ICard card, object target = null)
        {
            // Create and execute the command
            ICardCommand command = new PlayCardCommand(card, target);
            command.Execute();
            
            // Store for undo and synergy detection
            _playedCards.Add(command);
            
            // Check for synergies
            CheckForSynergies(card, target);
        }
        
        public void UndoLastCard()
        {
            if (_playedCards.Count > 0)
            {
                int lastIndex = _playedCards.Count - 1;
                ICardCommand command = _playedCards[lastIndex];
                command.Undo();
                _playedCards.RemoveAt(lastIndex);
                
                Debug.Log("Last card action undone");
            }
            else
            {
                Debug.Log("No cards to undo");
            }
        }
        
        #endregion
        
        #region Decorator Pattern Methods
        
        private void CheckForSynergies(ICard card, object target)
        {
            if (_playedCards.Count < 2) return;
            
            // Get the previous card
            ICard previousCard = _playedCards[_playedCards.Count - 2].GetCard();
            
            // Check for synergies between card types
            if (IsSynergistic(previousCard, card))
            {
                Debug.Log($"Synergy detected between {previousCard.Name} and {card.Name}");
                
                // In a real implementation, this would create appropriate effects
                // and potentially notify the player about the synergy
            }
        }
        
        private bool IsSynergistic(ICard card1, ICard card2)
        {
            // Community card followed by Balance Change
            if (card1.Type == CardType.Community && card2.Type == CardType.BalanceChange)
            {
                return true;
            }
            // Pro Player Consultation followed by Skill Ceiling Increase
            if (card1.Name.Contains("Pro Player") && card2.Name.Contains("Skill Ceiling"))
            {
                return true;
            }
            
            // Developer Update followed by Emergency Hotfix
            if (card1.Name.Contains("Developer Update") && card2.Type == CardType.CrisisResponse)
            {
                return true;
            }
            
            return false;
        }
        
        public ICard CreateSynergyCard(ICard card, ICardEffect synergyEffect)
        {
            return new SynergyDecorator(card, synergyEffect);
        }
        
        #endregion
        
        #region Factory Integration Methods
        
        public ICard CreateRandomCard(CardRarity minRarity = CardRarity.Common)
        {
            CardType randomType = (CardType)Random.Range(0, System.Enum.GetValues(typeof(CardType)).Length);
            CardRarity randomRarity = GetRandomRarityAtOrAbove(minRarity);
            
            string name = $"Random {randomType} Card";
            string description = $"A randomly generated {randomType} card";
            
            int rpCost = Random.Range(5, 20);
            int cpCost = Random.Range(0, 15);
            
            return Patterns.Factory.CardFactory.Instance.CreateCard(randomType, name, description, randomRarity, rpCost, cpCost);
        }
        
        private CardRarity GetRandomRarityAtOrAbove(CardRarity minRarity)
        {
            // Higher rarities are less likely
            float roll = Random.value;
            
            if (roll < 0.6f)
                return (int)minRarity < (int)CardRarity.Common ? CardRarity.Common : minRarity;
            else if (roll < 0.85f)
                return (int)minRarity < (int)CardRarity.Uncommon ? CardRarity.Uncommon : minRarity;
            else if (roll < 0.95f)
                return (int)minRarity < (int)CardRarity.Rare ? CardRarity.Rare : minRarity;
            else if (roll < 0.99f)
                return (int)minRarity < (int)CardRarity.Epic ? CardRarity.Epic : minRarity;
            else
                return (int)minRarity < (int)CardRarity.Special ? CardRarity.Special : minRarity;
        }
        
        #endregion
    }
}