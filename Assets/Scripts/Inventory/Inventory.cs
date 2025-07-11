using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    public InventoryType inventoryType = InventoryType.Main;
    public List<ItemInstance> content = new List<ItemInstance>();
    
    public int maxRuneCapacity;
    public int currentRuneCapacity = 0;
    public int currency;
    
    public event System.Action OnInventoryChanged;
    
    public enum InventoryType
    {
        Main,
        Equipment
    }
    
    public bool AddItem(Item item, int quantity = 1)
    {
        if (item == null) return false;

        foreach (ItemInstance itemInstance in content)
        {
            if (itemInstance.item == item && itemInstance.item.itemType != Item.ItemType.Rune)
            {
                itemInstance.AddQuantity(quantity);
                OnInventoryChanged?.Invoke();
                return true;
            }
        }
        
        ItemInstance itemInstanceToAdd = new ItemInstance(item, quantity);

        if (item.itemType == Item.ItemType.Rune)
        {
            itemInstanceToAdd = GenerateRune(item as EquipmentItem);
        }

        content.Add(itemInstanceToAdd);
        OnInventoryChanged?.Invoke();
        return true;
    }

    public bool RemoveItem(Item item, int quantity = 1)
    {
        if (item == null) return false;
        
        ItemInstance itemInstanceToRemove = null;
        foreach (ItemInstance itemInstance in content)
        {
            if (itemInstance.item == item)
            {
                itemInstanceToRemove = itemInstance;
                break;
            }
        }

        if (itemInstanceToRemove != null)
        {
            itemInstanceToRemove.RemoveQuantity(quantity);

            if (itemInstanceToRemove.quantity <= 0)
            {
                content.Remove(itemInstanceToRemove);
            }
            OnInventoryChanged?.Invoke();
            return true;
        }
        
        return false;
    }

    public bool EquipItem(ItemInstance itemInstance)
    {
        EquipmentItem runeItem = itemInstance.item as EquipmentItem;
        
        runeItem.Equip(itemInstance);
        
        itemInstance = new ItemInstance(runeItem, itemInstance.runeLevel, itemInstance.runeCost);
        
        OnInventoryChanged?.Invoke();
        return true;
    }
    
    public bool UnequipItem(ItemInstance itemInstance)
    {
        EquipmentItem runeItem = itemInstance.item as EquipmentItem;
        
        runeItem.Unequip(itemInstance);
        
        itemInstance = new ItemInstance(runeItem, itemInstance.runeLevel, itemInstance.runeCost);
        
        OnInventoryChanged?.Invoke();
        return true;
    }

    public bool SellItem(ItemInstance itemInstance)
    {
        currency += itemInstance.item.itemValue;
        
        return RemoveItem(itemInstance.item, itemInstance.quantity);
    }
    
    public ItemInstance GenerateRune(EquipmentItem runeItem)
    {
        if(runeItem == null || runeItem.itemType != Item.ItemType.Rune) return null;
        
        float generatedCost = Random.Range(runeItem.minRuneCost, runeItem.maxRuneCost);
        return new ItemInstance(runeItem, 1, (int)generatedCost);
    }

    public int GetQuantity(Item item)
    {
        foreach (ItemInstance itemInstance in content)
        {
            if (itemInstance.item == item)
            {
                return itemInstance.quantity;
            }
        }
        
        return 0;
    }

    public List<ItemInstance> GetContent()
    {
        return new List<ItemInstance>(content);
    }

    public int GetSize()
    {
        return content.Count;
    }
}
