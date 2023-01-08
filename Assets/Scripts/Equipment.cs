using UnityEngine;

public class Equipment : MonoBehaviour
{
    #region Singleton
    public static Equipment instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one Equipment instance is active.");
            return;
        }

        instance = this;
    }
    #endregion

    public Item CurrentlyActiveItem { get; private set; }

    public void Equip(Item item)
    {
        CurrentlyActiveItem = item;
    }
}