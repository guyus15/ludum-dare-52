using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMPro.TextMeshProUGUI _price;

    private Item _item;

    public void AddItem(Item item)
    {
        _item = item;

        _icon.sprite = _item.icon;
        _icon.enabled = true;
        _price.text = $"${_item.price}";
    }

    public void ClearItem()
    {
        _item = null;

        _icon.sprite = null;
        _icon.enabled = false;
        _price.text = "";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Handle buying the item here.
            _item.Buy();
        }
    }
}
