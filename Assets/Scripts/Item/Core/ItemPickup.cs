using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public int quantity = 1;
    public Inventory targetInventory;

    private void Start()
    {
        targetInventory = GameObject.Find(item.targetInventoryName).GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D");
        if (other.CompareTag("Player"))
        {
            if (targetInventory != null)
            {
                if (item.itemType == Item.ItemType.Rune && 
                    targetInventory.inventoryType == Inventory.InventoryType.Equipment)
                {
                    targetInventory.AddItem(item,1 );
                }
            }
            else
            {
                targetInventory.AddItem(item, quantity);
            }
            Destroy(gameObject);
        }
    }
}
