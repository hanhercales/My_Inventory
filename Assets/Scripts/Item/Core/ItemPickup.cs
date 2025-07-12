using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private int quantity = 1;
    [SerializeField] private Inventory targetInventory;
    [SerializeField] private InventoryDisplay inventoryDisplay;

    private void Start()
    {
        targetInventory = FindObjectOfType<Inventory>();
        inventoryDisplay = FindObjectOfType<InventoryDisplay>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
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
            
            inventoryDisplay.SetupUI();
            
            Destroy(gameObject);
        }
    }
}
