using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MerchantItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TMPro.TextMeshProUGUI _name;
    [SerializeField] private Image _icon;
    [SerializeField] private TMPro.TextMeshProUGUI _price;

    private Item _item;

    public void AddItem(Item item)
    {
        _item = item;

        _name.text = _item.itemName;
        _icon.sprite = _item.icon;
        _icon.enabled = true;
        _price.text = $"${_item.price}";
    }

    public void ClearItem()
    {
        _item = null;

        _name.text = "";
        _icon.sprite = null;
        _icon.enabled = false;
        _price.text = "";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Handle selling the item here.
            _item.Sell();
        }
    }
}
