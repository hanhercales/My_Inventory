using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemID;
    public string itemName;
    public string itemDescription;
    public Sprite itemIcon;
    public ItemType itemType;
    
    public enum ItemType
    {
     Rune,
     Consumable,
     Material
    }
}

