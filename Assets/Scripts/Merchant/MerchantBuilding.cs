using UnityEngine;

public class MerchantBuilding : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        OpenMerchantEvent openMerchantUIEvt = Events.s_OpenMerchantEvent;
        EventManager.Broadcast(openMerchantUIEvt);
    }
}