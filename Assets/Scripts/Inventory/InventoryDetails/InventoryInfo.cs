using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryInfo : MonoBehaviour
{

    [SerializeField] private TMP_Text infoText; 

    [SerializeField] private GameObject infoBox;

    private InventoryManager inventoryManager;

    private ItemData itemData;

    public bool IsOpen = false;

    public string objectTag = "Slots";

    

    

    void RemoveInfo()
    {
        infoText.text = string.Empty;
    }

    void SetInfo()
    {
        inventoryManager = GetComponent<InventoryManager>();
        TMP_Text tempText = Instantiate(inventoryManager.inventorySlots[0].labelText);
        infoText.text = tempText.text;
    }

    public void ShowInfo()
    {
        Debug.Log("Am I being clicked");
        if(IsOpen == false)
        {
            IsOpen = true;
            infoBox.SetActive(true);
            
            //SetInfo();
        }
        else
        {
            IsOpen = false;
            infoBox.SetActive(false);
            //RemoveInfo();
        }
    }

    
}
