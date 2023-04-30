using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public static event Action<List<InventoryItem>> OnInventoryChange;
    
    public List<InventoryItem> inventory = new List<InventoryItem>();


    private void OnEnable()
    {
        Journal.OnJournalCollected += Add;
    }
    public void Add(ItemData itemData)
    {
        InventoryItem newItem = new InventoryItem(itemData);
        inventory.Add(newItem);
        Debug.Log("Added" + itemData.displayName + " to the inventory");
        OnInventoryChange?.Invoke(inventory);
    }






}
