using UnityEngine;

public class MerchantUI : MonoBehaviour
{
    [SerializeField] private GameObject _merchantMessage;
    
    private Transform _itemsParent;
    private GameObject _merchantUI;

    private Merchant _merchant;
    private bool _merchantExists = false;

    private void Awake()
    {
        EventManager.AddListener<InitialiseUIEvent>(InitialiseMerchantUI);
        EventManager.AddListener<OpenMerchantEvent>(Open);
    }

    private void InitialiseMerchantUI(InitialiseUIEvent evt)
    {
        _merchantExists = true;

        _merchantUI = UIManager.instance.MerchantUI;

        _merchantUI.SetActive(true);

        _merchant = Merchant.instance;

        _merchant.onUpdateUICallback += UpdateUI;

        _itemsParent = GameObject.Find("MerchantItems").transform;

        _merchantUI.SetActive(false);
    }

    private void UpdateUI()
    {
        if (!_merchantExists) return;

        if (_itemsParent.transform.childCount > 0)
        {
            foreach (Transform child in _itemsParent.transform)
            {
                Destroy(child.gameObject);
            }
        }

        _merchantMessage.SetActive(false);

        int numItems = _merchant.itemsToSell.Count;

        if (numItems == 0)
        {
            _merchantMessage.SetActive(true);
        }

        for (int i = 0; i < numItems; i++)
        {
            GameObject merchantItem = Instantiate(Resources.Load<GameObject>("UI/Shop/MerchantItem"));
            merchantItem.transform.SetParent(_itemsParent);

            MerchantItem item = merchantItem.GetComponent<MerchantItem>();
            item.GetComponent<MerchantItem>().AddItem(_merchant.itemsToSell[i]);
        }
    }

    private void Open(OpenMerchantEvent evt)
    {
        Merchant.instance.onUpdateUICallback?.Invoke();

        if (_merchantExists)
        {
            _merchantUI.SetActive(true);
        }
    }

    public void Close()
    {
        if (_merchantExists)
        {
            _merchantUI.SetActive(false);
        }
    }
}

