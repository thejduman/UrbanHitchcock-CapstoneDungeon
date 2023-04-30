using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI labelText;

    public void ClearSlot()
    {
        icon.enabled = false;
        labelText.enabled = false;
    }

    public void DrawSlot(InventoryItem item)
    {
        if(item == null)
        {
            ClearSlot();
            return;
        }

        Debug.Log("Hey I made it here!");

        icon.enabled = true;
        labelText.enabled = true;

        icon.sprite = item.itemData.icon;
        labelText.text = item.itemData.displayName;

        Debug.Log("Testing to see if it's actually running");
    }

    
}
