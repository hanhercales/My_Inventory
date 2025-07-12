using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMaterialItem", menuName = "Inventory/Item/Material Item")]
public class MaterialItem : Item
{
    public MaterialTier materialTier = MaterialTier.Common;
    
    public enum MaterialTier
    {
        Common,
        Uncommon,
        Rare,
        Epic
    }
    
    public override string GetInfo()
    {
        return materialTier + "\n" + itemDescription;
    }
}
