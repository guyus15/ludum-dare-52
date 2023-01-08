using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HotbarUI : MonoBehaviour
{
    private Transform _itemsParent;
    private GameObject _hotbarUI;

    private Inventory _inventory;
    private bool _hotbarExists = false;

    private int _currentActiveSlot;

    private void Awake()
    {
        EventManager.AddListener<InitialiseUIEvent>(InitialiseHotbarUI);
        EventManager.AddListener<ActivateHotbarSlotEvent>(ActivateHotbarSlot);
    }

    private void Start()
    {
        _currentActiveSlot = 0;
    }

    private void InitialiseHotbarUI(InitialiseUIEvent evt)
    {
        _hotbarExists = true;

        _hotbarUI = UIManager.instance.HotbarUI;
        _inventory = Inventory.instance;

        _hotbarUI.SetActive(true);

        _inventory.onItemChangedCallback += UpdateUI;

        _itemsParent = GameObject.Find("StoredItems").transform;
    }

    private void UpdateUI()
    {
        if (!_hotbarExists) return;

        int numItems = _inventory.items.Count;

        if (_itemsParent.transform.childCount > 0)
        {
            foreach (Transform child in _itemsParent.transform)
            {
                Destroy(child.gameObject);
            }
        }

        for (int i = 0; i < numItems; i++)
        {
            GameObject hotbarSlot = Instantiate(Resources.Load("UI/Inventory/HotbarSlot")) as GameObject;
            hotbarSlot.transform.SetParent(_itemsParent);

            HotbarSlot slot = hotbarSlot.GetComponent<HotbarSlot>();
            hotbarSlot.GetComponent<HotbarSlot>().AddItem(_inventory.items[i]);
            hotbarSlot.GetComponent<HotbarSlot>().Index = i;

            if (slot.Index == _currentActiveSlot)
                hotbarSlot.GetComponent<HotbarSlot>().Activate();
        }
    }

    private void ActivateHotbarSlot(ActivateHotbarSlotEvent evt)
    {
        _currentActiveSlot = evt.targetSlotIndex;

        UpdateUI();
    }
}
