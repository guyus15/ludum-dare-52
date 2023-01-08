using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    #region Singleton
    public static Merchant instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one Merchant instance is active.");
            return;
        }

        instance = this;
    }
    #endregion

    public delegate void OnUpdateUI();
    public OnUpdateUI onUpdateUICallback;

    public List<Item> itemsToSell = new List<Item>();

    private void Start()
    {
        onUpdateUICallback += CheckItems;

        StartCoroutine(InvokeCallback());
    }

    public void Add(Item item)
    {
        itemsToSell.Add(item);
    }

    public void Sell(Item item)
    {
        int price = item.price;

        Inventory.instance.Remove(item);

        EarnMoneyEvent earnMoneyEvt = Events.s_EarnMoneyEvent;
        earnMoneyEvt.amount = price;
        EventManager.Broadcast(earnMoneyEvt);
    }

    IEnumerator InvokeCallback()
    {
        yield return new WaitForSeconds(2);

        onUpdateUICallback?.Invoke();
    }

    private void CheckItems()
    {
        itemsToSell.Clear();

        // Load sellable items
        Item[] items = Resources.LoadAll<Item>("Items/Scriptable Objects");

        items.ToList().ForEach(item =>
        {
            if (item.sellable && Inventory.instance.items.Contains(item))
            {
                Add(item);
            }
        });
    }
}
