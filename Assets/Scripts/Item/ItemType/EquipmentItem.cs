using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEquipmentItem", menuName = "Inventory/Item/Equipment Item")]
public class EquipmentItem : Item
{
    public RuneStatType runeStatType;
    public string runeEffectDescription;
    public int minRuneCost;
    public int maxRuneCost;
    
    public enum RuneStatType
    {
        None,
        Health,
        Strength,
        Defense,
        Speed,
    }

    public bool Equip(ItemInstance itemInstance)
    {
        Inventory targetInventory = GameObject.Find(targetInventoryName).GetComponent<Inventory>();
        
        if(itemInstance == null || itemInstance.item.itemType != Item.ItemType.Rune) return false;
        
        if (targetInventory.currentRuneCapacity >= targetInventory.maxRuneCapacity || 
            targetInventory.maxRuneCapacity - targetInventory.currentRuneCapacity < itemInstance.runeCost) 
            return false;
        
        itemInstance.isEquipped = true;
        targetInventory.currentRuneCapacity += itemInstance.runeCost;
        return true;
    }

    public bool Unequip(ItemInstance itemInstance)
    {
        Inventory targetInventory = GameObject.Find(targetInventoryName).GetComponent<Inventory>();
        
        if(itemInstance == null || itemInstance.item.itemType != Item.ItemType.Rune) return false;
        
        if (targetInventory.currentRuneCapacity >= targetInventory.maxRuneCapacity || 
            targetInventory.currentRuneCapacity < itemInstance.runeCost) 
            return false;
        
        itemInstance.isEquipped = false;
        targetInventory.currentRuneCapacity -= itemInstance.runeCost;
        return true;
    }

    public override string GetInfo()
    {
        return itemDescription + "\n" + runeStatType + "\n" + runeEffectDescription;
    }
}
