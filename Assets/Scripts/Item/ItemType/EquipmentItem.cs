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

    public void Equip(int level, int cost)
    {
        
    }

    public override string GetInfo()
    {
        return itemDescription + "\n" + runeStatType + "\n" + runeEffectDescription;
    }
}
