using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamagable, IMoveable
{
    [field: SerializeField, Header("Movement")]
    public float MoveSpeed { get; set; }


    [field: SerializeField, Header("Health")]
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; private set; }

    [Header("Damage")]
    [SerializeField] private int _damagePerHit = 20;

    [SerializeField] private GameObject _target;

    private EnemyManager _enemyManager;
    private NavMeshAgent _agent;

    private void Start()
    {
        CurrentHealth = MaxHealth;

        _target = GameObject.Find("Player");
        _enemyManager = FindObjectOfType<EnemyManager>();
        _agent = GetComponent<NavMeshAgent>();

        _enemyManager.RegisterEnemy(this);

        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _agent.speed = MoveSpeed;
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        _agent.SetDestination(_target.transform.position);

        Vector3 targetDir = _target.transform.position - transform.position;
        targetDir.z = 0;
        float angle = Mathf.Atan2(targetDir.x, targetDir.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, -transform.forward);
    }

    public void AddHealth(int amount)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0, MaxHealth);
    }

    public void RemoveHealth(int amount)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - amount, 0, MaxHealth);

        if (CurrentHealth <= 0) Die();
    }
    public void Die()
    {
        _enemyManager.DeregisterEnemy(this);

        EnemyDeathEvent deathEvt = Events.s_EnemyDeathEvent;
        deathEvt.xPos = transform.position.x;
        deathEvt.yPos = transform.position.y;
        EventManager.Broadcast(deathEvt);

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;

        if (collision.gameObject.CompareTag("Player")) return;

        if (collision.gameObject.transform.TryGetComponent<IDamagable>(out var objectDamagable))
        {
            objectDamagable.RemoveHealth(_damagePerHit);
        }
        else
        {
            // Check parent
            try
            {
                objectDamagable = collision.gameObject.transform.parent.GetComponent<IDamagable>();
                objectDamagable.RemoveHealth(_damagePerHit);
            }
            catch
            {
                return;
            }
        }
    }
}

