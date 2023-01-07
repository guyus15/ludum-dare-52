using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour, IMoveable, IDamagable
{
    [field: SerializeField, Header("Movement")]
    public float MoveSpeed { get; set; }
    public Vector2 Velocity { get; set; }

    [field: SerializeField, Header("Health")]
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; private set; }

    private bool _canBeDamaged;
    private NavMeshAgent _agent;
    private float _moveSmoothingFactor = 0.3f;

    void Start()
    {
        _agent= GetComponent<NavMeshAgent>();
        _agent.speed = MoveSpeed;
        _agent.updatePosition = false;
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;

        CurrentHealth = MaxHealth;

        PlayerSpawnEvent spawnEvt = Events.s_PlayerSpawnEvent;
        spawnEvt.maxHealth = MaxHealth;
        EventManager.Broadcast(spawnEvt);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var seed = Resources.Load<Item>("Items/Scriptable Objects/CropSeed");
            Inventory.instance.Add(seed);
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        var agentDrift = 0.0001f; // minimal
        var driftPos = movement + (Vector3)(agentDrift * Random.insideUnitCircle);
        _agent.Move(driftPos * Time.deltaTime * _agent.speed);

        transform.position = Vector3.Lerp(transform.position, _agent.nextPosition, _moveSmoothingFactor);
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
