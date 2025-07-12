using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI quantityText;
    [SerializeField] private GameObject quantityTextPanel;
    [SerializeField] private GameObject clickedBorder;
    
    private ItemInstance currentItemInstance;
    private bool isClicked;

    public void UpdateSlot(ItemInstance itemInstance)
    {
        currentItemInstance = itemInstance;

        if (itemInstance != null && itemInstance.item != null)
        {
            icon.sprite = itemInstance.item.itemIcon;
            icon.enabled = true;

            if (itemInstance.quantity > 1)
            {
                quantityText.text = itemInstance.quantity.ToString();
                quantityTextPanel.SetActive(true);
            }
            else
            {
                quantityTextPanel.SetActive(false);
            }
        }
        else
        {
            icon.sprite = null;
            icon.enabled = false;
            quantityTextPanel.SetActive(false);
            quantityText.text = "";
        }
    }

    public void OnSlotClicked()
    {
        if (isClicked)
        {
            isClicked = false;
            clickedBorder.SetActive(false);
            return;
        }
        
        clickedBorder.SetActive(true);
        isClicked = true;
    }
}
