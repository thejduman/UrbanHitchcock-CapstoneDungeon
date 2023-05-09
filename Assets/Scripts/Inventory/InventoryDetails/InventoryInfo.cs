using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryInfo : MonoBehaviour
{

    [SerializeField] private TMP_Text infoText; 

    [SerializeField] GameObject infoBox;

    private Inventory inventory;

    private ItemData itemData;
    private GameObject journalBox; // it WILL(from code) be instantiated object from prefab
    

    void Start() 
    {
    }

    void Update()
    {

    }

    void RemoveInfo()
    {
        infoText.text = string.Empty;
    }

    void SetInfo(int index)
    {
        inventory = GameObject.FindWithTag("Inventory").GetComponent<Inventory>();
        if(index < inventory.inventory.Count)
        {
            infoText.text = inventory.inventory[index].itemData.information;
        }
        else
        {
            infoText.text = "This Slot is empty";
        }
    }

    public void whenButtonClicked()
    {

    }

    public void ShowInfo(int index)
    {
        Debug.Log("Am I being clicked");

        if(infoBox.activeInHierarchy == false)
        {
            Debug.Log("If stated being read?");
            infoBox.SetActive(true);
            
            SetInfo(index);
        }
        else
        {
            RemoveInfo();
            infoBox.SetActive(false);
        }
    }

    
}
