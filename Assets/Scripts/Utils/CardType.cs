namespace CardSystem.Utils
{
    /// <summary>
    /// Defines the types of cards available in the game
    /// </summary>
    public enum CardType
    {
        BalanceChange,  // Orange - Directly modify character stats
        MetaShift,      // Teal - Change the game environment
        Community,      // Purple - Influence player perception
        CrisisResponse, // Red - React to emergent problems
    }

    /// <summary>
    /// Defines the rarity levels of cards
    /// </summary>
    public enum CardRarity
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Special
    }
    
    /// <summary>
    /// Defines the types of effects cards can have
    /// </summary>
    public enum EffectType
    {
        StatModifier,        // Modify character statistics
        EnvironmentModifier, // Modify game environment
        PerceptionModifier,  // Modify community perception
        EmergencyModifier,   // Handle crisis situations
    }
}