﻿using UnityEngine;

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
        Equipment.instance.Equip(this);
    }

    public virtual void Buy()
    {
        // Buy the item
        Shop.instance.Purchase(this);
    }
}
