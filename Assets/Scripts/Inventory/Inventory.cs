using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public event System.Action OnInventoryChanged;
    
    public List<ItemInstance> content = new List<ItemInstance>();

    public bool AddItem(Item item, int quantity = 1)
    {
        if(item == null) return false;

        foreach (ItemInstance itemInstance in content)
        {
            if (itemInstance.item == item)
            {
                itemInstance.AddQuantity(quantity);
                OnInventoryChanged?.Invoke();
                return true;
            }
        }
        
        content.Add(new ItemInstance(item, quantity));
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

            if (itemInstanceToRemove.quantity < 0)
            {
                content.Remove(itemInstanceToRemove);
            }
            OnInventoryChanged?.Invoke();
            return true;
        }
        
        return false;
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
}
