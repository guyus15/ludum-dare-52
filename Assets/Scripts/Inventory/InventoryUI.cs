using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Transform _itemsParent;
    [SerializeField] private GameObject _inventoryUI;

    private Inventory _inventory;
    private bool _inventoryExists = false;

    private void Awake()
    {
        EventManager.AddListener<InitialiseUIEvent>(InitialiseInventoryUI);
    }

    private void InitialiseInventoryUI(InitialiseUIEvent evt)
    {
        _inventoryExists = true;

        _inventoryUI = UIManager.instance.InventoryUI;
        _inventory = Inventory.instance;

        _inventoryUI.SetActive(true);

        _inventory.onItemChangedCallback += UpdateUI;

        _itemsParent = GameObject.Find("StoredItems").transform;

        _inventoryUI.SetActive(false);
    }

    private void Update()
    {
        if (_inventoryExists)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _inventoryUI.SetActive(!_inventoryUI.activeSelf);
            }
        }
    }

    private void UpdateUI()
    {
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
            GameObject inventorySlot = Instantiate(Resources.Load("UI/Inventory/InventorySlot")) as GameObject;
            inventorySlot.transform.SetParent(_itemsParent);

            inventorySlot.GetComponent<InventorySlot>().AddItem(_inventory.items[i]);
        }
    }
}