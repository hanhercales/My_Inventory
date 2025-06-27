using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewConsumableItem", menuName = "Inventory/Item/Consumable Item")]
public class ConsumableItem : Item
{
    public PotionEffect potionEffect;
    
    public enum PotionEffect
    {
        None,
        PoisonCure,
        BlindCure,
        SilenceCure
    }

    public override string GetInfo()
    {
        return itemDescription;
    }
    
    public void Use()
    {
        return;
    }
}
