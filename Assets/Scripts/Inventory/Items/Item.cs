using UnityEngine;

[CreateAssetMenu(fileName="New Item", menuName="Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName = "New Item";
    public Sprite icon = null;
    public GameObject itemObject;
    public int price;
    public bool purchasable;

    public virtual void Use()
    {
        // Use the item
        Debug.Log($"Using {name}");
    }

    public virtual void Buy()
    {
        // Buy the item
        Shop.instance.Purchase(this);
    }
}
