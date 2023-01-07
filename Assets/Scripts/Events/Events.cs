public static class Events
{
    public static readonly PlayerSpawnEvent s_PlayerSpawnEvent = new PlayerSpawnEvent();
    public static readonly PlayerGainHealthEvent s_PlayerGainHealthEvent = new PlayerGainHealthEvent();
    public static readonly PlayerHitEvent s_PlayerHitEvent = new PlayerHitEvent();
    public static readonly PlayerDeathEvent s_PlayerDeathEvent = new PlayerDeathEvent();
    public static readonly EnemyDeathEvent s_EnemyDeathEvent = new EnemyDeathEvent();
    public static readonly InitialiseUIEvent s_InitialiseUIEvent = new InitialiseUIEvent();
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

public class InitialiseUIEvent : GameEvent { }