using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class ItemInstance
{
    public Item item;
    public int quantity;
    
    public int runeLevel;
    public int runeCost;
    public bool isEquipped;

    public ItemInstance(Item item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
        this.runeLevel = 0;
        this.runeCost = 0;
    }

    public ItemInstance(EquipmentItem runeItem, int level, int cost) : this(runeItem, 1)
    {
        if (runeItem.itemType == Item.ItemType.Rune)
        {
            this.runeLevel = level;
            this.runeCost = cost;
        }
    }

    public void AddQuantity(int amount)
    {
        quantity += amount;
    }

    public void RemoveQuantity(int amount)
    {
        quantity -= amount;
        if (quantity < 0)
        {
            quantity = 0;
        }
    }
    
    public string GetDetailedInfo()
    {
        string info = item.GetInfo();
        
        if (item is EquipmentItem)
        {
            if (runeLevel > 0)
            {
                item.itemName += " + " + runeLevel;
            }
            
            info += "\n" + runeCost;
        }
        
        return info;
    }
}
