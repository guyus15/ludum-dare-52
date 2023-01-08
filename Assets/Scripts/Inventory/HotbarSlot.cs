using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HotbarSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _icon;
    [SerializeField] private Image _activeImage;

    private Inventory _inventory;
    private Item _item;

    public int Index { get; set; }

    private void Start()
    {
        _inventory = Inventory.instance;

        _activeImage.enabled = false;
    }

    public void AddItem(Item item)
    {
        _item = item;

        _icon.sprite = _item.icon;
        _icon.enabled = true;
    }

    public void ClearItem()
    {
        _item = null;

        _icon.sprite = null;
        _icon.enabled = false;
    }

    public void Activate()
    {
        Debug.Log($"Activating slot {Index}");
        _activeImage.enabled = true;
    }

    public void Deactivate()
    {
        Debug.Log($"Deactivating slot {Index}");
        _activeImage.enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Handling equiping the item.
            _item.Use();

            ActivateHotbarSlotEvent activateHotbarEvt = Events.s_ActivateHotbarSlotEvent;
            activateHotbarEvt.targetSlotIndex = Index;
            EventManager.Broadcast(activateHotbarEvt);
        }
    }
}