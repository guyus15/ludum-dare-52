using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    #region Singleton
    public static CurrencyManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one CurrencyManager instance is active.");
            return;
        }
           
        instance = this;

        EventManager.AddListener<EarnMoneyEvent>(AddMoney);
        EventManager.AddListener<SpendMoneyEvent>(RemoveMoney);
    }
    #endregion

    [SerializeField] private int _startingCurrency;

    public int CurrentAmount { get; private set; }

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
