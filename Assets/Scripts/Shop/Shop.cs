using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shop : MonoBehaviour
{
    #region Singleton
    public static Shop instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one Shop instance is active.");
            return;
        }

        instance = this;
    }
    #endregion

    public delegate void OnUpdateUI();
    public OnUpdateUI onUpdateUICallback;

    public List<Item> itemsForSale = new List<Item>();

    private void Start()
    {
        onUpdateUICallback += CheckItems;

        StartCoroutine(InvokeCallback());
    }

    public void Add(Item item)
    {
        itemsForSale.Add(item);
    }

    public void Purchase(Item item)
    {
        int price = item.price;

        // Check we can purchase this.
        if (CurrencyManager.instance.CurrentAmount - price >= 0)
        {
            Inventory.instance.Add(item);

            SpendMoneyEvent spendMoneyEvt = Events.s_SpendMoneyEvent;
            spendMoneyEvt.amount = price;
            EventManager.Broadcast(spendMoneyEvt);
        }
    }

    IEnumerator InvokeCallback()
    {
        yield return new WaitForSeconds(2);

        onUpdateUICallback?.Invoke();
    }

    private void CheckItems()
    {
        itemsForSale.Clear();

        // Load purchasable items.
        Item[] items = Resources.LoadAll<Item>("Items/Scriptable Objects");

        items.ToList().ForEach(item =>
        {
            if (item.purchasable)
            {
                Add(item);
            }
        });
    }
}