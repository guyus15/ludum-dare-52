using UnityEngine;

public class ShopUI : MonoBehaviour
{
    private Transform _itemsParent;
    private GameObject _shopUI;

    private Shop _shop;
    private bool _shopExists = false;

    private void Awake()
    {
        EventManager.AddListener<InitialiseUIEvent>(InitialiseShopUI);
        EventManager.AddListener<OpenShopEvent>(Open);
    }

    private void InitialiseShopUI(InitialiseUIEvent evt)
    {
        _shopExists = true;

        _shopUI = UIManager.instance.ShopUI;

        _shopUI.SetActive(true);

        _shop = Shop.instance;

        _shop.onUpdateUICallback += UpdateUI;

        _itemsParent = GameObject.Find("ShopItems").transform;

        _shopUI.SetActive(false);
    }

    private void UpdateUI()
    {
        if (!_shopExists) return;

        if (_itemsParent.transform.childCount > 0)
        {
            foreach (Transform child in _itemsParent.transform) 
            {
                Destroy(child.gameObject);
            }
        }

        int numItems = _shop.itemsForSale.Count;
        for (int i = 0; i < numItems; i++)
        {
            GameObject shopItem = Instantiate(Resources.Load<GameObject>("UI/Shop/ShopItem"));
            shopItem.transform.SetParent(_itemsParent);

            ShopItem item = shopItem.GetComponent<ShopItem>();
            item.GetComponent<ShopItem>().AddItem(_shop.itemsForSale[i]);
        }
    }

    private void Open(OpenShopEvent evt)
    {
        if (_shopExists)
        {
            _shopUI.SetActive(true);
        }
    }

    public void Close()
    {
        if (_shopExists)
        {
            _shopUI.SetActive(false);
        }
    }
}