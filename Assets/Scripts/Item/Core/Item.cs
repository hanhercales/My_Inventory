using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public abstract class Item : ScriptableObject
{
    [Header("Item Info")]
    public string itemID;
    public string itemName;
    public string itemDescription;
    public Sprite itemIcon;
    public ItemType itemType;

    [Header("Inventory Info")] public string targetInventoryName = "Inventory";
    
    public enum ItemType
    {
        Rune,
        Consumable,
        Material
    }

    public virtual string GetInfo()
    {
        return itemDescription;
    }
}

