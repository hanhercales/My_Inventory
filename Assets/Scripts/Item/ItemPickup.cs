using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public int quantity;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D");
        if (other.CompareTag("Player"))
        {
            Inventory inventory = other.GetComponent<Inventory>();

            if (inventory != null)
            {
                if (item.itemType == Item.ItemType.Rune)
                {
                    inventory.AddItem(item,1 );
                }
            }
            else
            {
                inventory.AddItem(item,1);
            }
            Destroy(gameObject);
        }
    }
}
