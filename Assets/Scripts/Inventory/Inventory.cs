using System.Collections.Generic;
using UnityEngine;
using System.Collections;

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

    public int defaultSpace = 5;

    public List<Item> items = new List<Item>();

    void Start()
    {
        var seed = Resources.Load<Item>("Items/Scriptable Objects/BeanSeed");
        Add(seed);
        StartCoroutine(InvokeCallback());
    }

    public bool Add(Item item)
    {
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

    IEnumerator InvokeCallback()
    {
        yield return new WaitForSeconds(2.1f);
        onItemChangedCallback.Invoke();
    }
}