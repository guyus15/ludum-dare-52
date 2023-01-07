using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _icon;

    private Inventory _inventory;
    private Item _item;

    private void Start()
    {
        _inventory = Inventory.instance;
    }

    public void AddItem(Item newItem)
    {
        _item = newItem;

        _icon.sprite = _item.icon;
        _icon.enabled = true;
    }

    public void ClearItem()
    {
        _item = null;

        _icon.sprite = null;
        _icon.enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            MoveItem();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            // Equip the item through the equipment manager.
            if (_inventory.items.Contains(_item))
            {
                _item.Use();
            }
        }
    }

    public void MoveItem()
    {
        Debug.LogWarning("MoveItem not implemented.");
    }

    public void UseItem()
    {
        _item?.Use();
    }
}