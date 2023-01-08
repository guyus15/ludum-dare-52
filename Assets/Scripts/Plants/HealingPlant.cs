using UnityEngine;

public class HealingPlant : MonoBehaviour
{
    [SerializeField] private float _timeBetweenHeals;
    [SerializeField] private int _healthPerHeal;
    [SerializeField] private RadiusVisualiser _radiusVisualiser;

    private float _currentTime;
    private CircleCollider2D _collider;

    private void Start()
    {
        _currentTime = 0.0f;
        _collider = GetComponent<CircleCollider2D>();

        _radiusVisualiser.SetRadius(_collider.radius);
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime > _timeBetweenHeals )
        {
            _radiusVisualiser.SetColour(Color.green);
        } else
        {
            _radiusVisualiser.SetColour(Color.red);
        }
    }

    public void Harvest()
    {
        var seed = Resources.Load<Item>("Items/Scriptable Objects/HealingSeed");
        var crop = Resources.Load<Item>("Items/Scriptable Objects/HealingCrop");

        Inventory.instance.Add(seed);
        Inventory.instance.Add(crop);

        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.gameObject.name.Equals("Player")) return;
        if (_currentTime < _timeBetweenHeals) return;

        _currentTime = 0.0f;

        IDamagable objectDamagable = collision.gameObject.GetComponent<IDamagable>();
        objectDamagable?.AddHealth(_healthPerHeal);
    }
}
