using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject HotbarUI { get; private set; }
    public GameObject ShopUI { get; private set; }
    public GameObject MerchantUI { get; private set; }

    private GameObject _canvas;

    #region Singleton
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one UIManager instance is active.");
            return;
        }

        instance = this;

        _canvas = GameObject.Find("Canvas");
    }
    #endregion

    public void InitialiseUI()
    {
        var hotbarContainer = Resources.Load<GameObject>("UI/Inventory/HotbarContainer");
        HotbarUI = Instantiate(hotbarContainer);
        HotbarUI.transform.SetParent(_canvas.transform, false);
        HotbarUI.SetActive(false);

        var shopUI = Resources.Load<GameObject>("UI/Shop/ShopUI");
        ShopUI = Instantiate(shopUI);
        ShopUI.transform.SetParent(_canvas.transform, false);
        ShopUI.SetActive(false);

        var merchantUI = Resources.Load<GameObject>("UI/Shop/MerchantUI");
        MerchantUI = Instantiate(merchantUI);
        MerchantUI.transform.SetParent(_canvas.transform, false);
        MerchantUI.SetActive(false);

        InitialiseUIEvent initialiseUiEvt = Events.s_InitialiseUIEvent;
        EventManager.Broadcast(initialiseUiEvt);
    }
}