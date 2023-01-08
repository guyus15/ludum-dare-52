public static class Events
{
    public static readonly PlayerSpawnEvent s_PlayerSpawnEvent = new PlayerSpawnEvent();
    public static readonly PlayerGainHealthEvent s_PlayerGainHealthEvent = new PlayerGainHealthEvent();
    public static readonly PlayerHitEvent s_PlayerHitEvent = new PlayerHitEvent();
    public static readonly PlayerDeathEvent s_PlayerDeathEvent = new PlayerDeathEvent();
    public static readonly EnemyDeathEvent s_EnemyDeathEvent = new EnemyDeathEvent();
    public static readonly PlantGrowthEvent s_PlantGrowthEvent = new PlantGrowthEvent();
    public static readonly InitialiseUIEvent s_InitialiseUIEvent = new InitialiseUIEvent();
    public static readonly ActivateHotbarSlotEvent s_ActivateHotbarSlotEvent = new ActivateHotbarSlotEvent();
    public static readonly EarnMoneyEvent s_EarnMoneyEvent = new EarnMoneyEvent();
    public static readonly SpendMoneyEvent s_SpendMoneyEvent = new SpendMoneyEvent();
}

public class PlayerSpawnEvent : GameEvent
{
    public int maxHealth;
}

public class PlayerGainHealthEvent : GameEvent
{
    public int currentHealth;
}

public class PlayerHitEvent : GameEvent
{
    public int currentHealth;
    public int damageInflicted;
}

public class PlayerDeathEvent : GameEvent { }

public class EnemyDeathEvent : GameEvent
{
    public float xPos, yPos;
}

public class PlantGrowthEvent : GameEvent { }

public class InitialiseUIEvent : GameEvent { }

public class ActivateHotbarSlotEvent : GameEvent
{
    public int targetSlotIndex;
}

public class EarnMoneyEvent : GameEvent 
{
    public int amount;
}

public class SpendMoneyEvent : GameEvent
{
    public int amount;
}