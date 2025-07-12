using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private GameObject inventorySlotPrefab;
    [SerializeField] private Transform slotParent;
    [SerializeField] private Inventory inventory;
    
    private List<InventorySlotUI> inventorySlots = new List<InventorySlotUI>();

    private void Awake()
    {
        if (inventory == null)
        {
            inventory = FindObjectOfType<Inventory>();
        }

        if (inventory == null) return;
        
        inventory.OnInventoryChanged += UpdateInventoryUI;

        SetupUI();
    }

    private void OnDestroy()
    {
        if (inventory != null)
        {
            inventory.OnInventoryChanged -= UpdateInventoryUI;
        }
    }

    public void SetupUI()
    {
        foreach (Transform slot in slotParent)
        {
            Destroy(slot.gameObject);
        }
        inventorySlots.Clear();

        for (int i = 0; i < inventory.GetSize(); i++)
        {
            GameObject slotGO = Instantiate(inventorySlotPrefab, slotParent);
            InventorySlotUI slotUI = slotGO.GetComponent<InventorySlotUI>();
            if (slotUI != null)
            {
                inventorySlots.Add(slotUI);
                Button slotButton = slotGO.GetComponent<Button>();
                if(slotButton == null) slotButton = slotGO.GetComponent<Button>();
                slotButton.onClick.AddListener(slotUI.OnSlotClicked);
            }
        }
        
        UpdateInventoryUI();
    }

    private void UpdateInventoryUI()
    {
        List<ItemInstance> content = inventory.GetContent();

        for (int i = 0; i < content.Count; i++)
        {
            if (i < content.Count)
            {
                inventorySlots[i].UpdateSlot(content[i]);
            }
            else
            {
                inventorySlots[i].UpdateSlot(null);
            }
        }
    }
}
