using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    [SerializeField] private int _startingCurrency;

    public int CurrentAmount { get; private set; }

    private void Awake()
    {
        EventManager.AddListener<EarnMoneyEvent>(AddMoney);
        EventManager.AddListener<SpendMoneyEvent>(RemoveMoney);
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentAmount = _startingCurrency;
    }

    void AddMoney(EarnMoneyEvent evt)
    {
        CurrentAmount += evt.amount;
    }

    void RemoveMoney(SpendMoneyEvent evt)
    {
        CurrentAmount = Mathf.Clamp(CurrentAmount - evt.amount, 0, int.MaxValue);
    }
}
