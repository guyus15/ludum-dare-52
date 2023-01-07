using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one Inventory instance is active.");
            return;
        }

        instance = this;
    }
    #endregion

    public delegate void OnItemChange();
    public OnItemChange onItemChangedCallback;

    public int defaultSpace = 12;

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        Debug.Log($"Adding {item.name} to inventory.");

        if (items.Count >= defaultSpace)
        {
            return false;
        }

        items.Add(item);

        onItemChangedCallback?.Invoke();

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        onItemChangedCallback?.Invoke();
    }
}