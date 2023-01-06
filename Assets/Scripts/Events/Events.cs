public static class Events
{

}

public class PlayerSpawnEvent : GameEvent
{
    public int maxHealth;
}

public class PlayerHitEvent : GameEvent
{
    public int currentHealth;
    public int damageInflicted;
}

public class PlayerDeathEvent : GameEvent { }