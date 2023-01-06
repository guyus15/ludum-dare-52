using UnityEngine;

public class Player : MonoBehaviour, IMoveable, IDamagable
{
    [field: SerializeField, Header("Movement")]
    public float MoveSpeed { get; set; }
    public Vector2 Velocity { get; set; }

    [field: SerializeField, Header("Health")]
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; private set; }

    private bool _canBeDamaged;
    private Rigidbody2D _rb2d;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;

        CurrentHealth = MaxHealth;

        PlayerSpawnEvent spawnEvt = Events.s_PlayerSpawnEvent;
        spawnEvt.maxHealth = MaxHealth;
        EventManager.Broadcast(spawnEvt);
    }

    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        _rb2d.velocity = new Vector2(Input.GetAxis("Horizontal") * MoveSpeed, Input.GetAxis("Vertical") * MoveSpeed);

        Vector3 mousePosition = Input.mousePosition;
        Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);

        mousePosition.x -= playerScreenPosition.x;
        mousePosition.y -= playerScreenPosition.y;

        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void AddHealth(int amount)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0, MaxHealth);

        PlayerGainHealthEvent gainHealthEvt = Events.s_PlayerGainHealthEvent;
        gainHealthEvt.currentHealth = CurrentHealth;
        EventManager.Broadcast(gainHealthEvt);
    }

    public void RemoveHealth(int amount)
    {
        if (!_canBeDamaged) return;

        CurrentHealth = Mathf.Clamp(CurrentHealth - amount, 0, MaxHealth);

        PlayerHitEvent hitEvt = Events.s_PlayerHitEvent;
        hitEvt.currentHealth = CurrentHealth;
        hitEvt.damageInflicted= amount;
        EventManager.Broadcast(hitEvt);

        if (CurrentHealth <= 0) Die();

        _canBeDamaged = false;
    }

    public void Die()
    {
        PlayerDeathEvent deathEvt = Events.s_PlayerDeathEvent;
        EventManager.Broadcast(deathEvt);
    }
}
