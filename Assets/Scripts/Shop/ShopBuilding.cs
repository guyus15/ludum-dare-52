using UnityEngine;

public class ShopBuilding : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        OpenShopEvent openShopUIEvt = Events.s_OpenShopEvent;
        EventManager.Broadcast(openShopUIEvt);
    }
}
