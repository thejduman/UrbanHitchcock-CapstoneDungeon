using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private InventoryPage inventoryUI;

    [SerializeField]
    private InventorySO inventoryData;

    //hide the inventory when the game starts
    private void Start()
    {
        inventoryUI.Hide();
        PrepareUI();
        //inventoryData.Initialize();
    }

    //initialize the events for the UI
    private void PrepareUI()
    {
        inventoryUI.InitializeInventory(inventoryData.Size);
        this.inventoryUI.OnDescriptionRequested += HandleDescriptionRequest;
        this.inventoryUI.OnSwapItems += HandleSwapItems;
        this.inventoryUI.OnStartDragging += HandleDragging;
        this.inventoryUI.OnItemActionRequested += HandleItemActionRequest;

    }

    private void HandleItemActionRequest(int itemIndex)
    {
        throw new NotImplementedException();
    }

    private void HandleDragging(int itemIndex)
    {
        throw new NotImplementedException();
    }

    private void HandleSwapItems(int itemIndex1, int itemIndex2)
    {
        throw new NotImplementedException();
    }

    //update the description
    private void HandleDescriptionRequest(int itemIndex)
    {
        InventoryItemModel inventoryItem = inventoryData.GetItemAt(itemIndex);
        if (inventoryItem.IsEmpty)
            return;
        ItemSO item = inventoryItem.item;
        inventoryUI.UpdateDescription(itemIndex, item.ItemImage, item.name, item.Description);
    }

    //open the inventory and update its contents
    public void OpenInventory()
    {
        inventoryUI.Show();
        foreach (var item in inventoryData.GetCurrentInventoryState())
        {
            inventoryUI.UpdateData(item.Key, item.Value.item.ItemImage, item.Value.quantity);
        }
    }

    //a way to exit the inventory when accessed from the pause menu
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (inventoryUI.isActiveAndEnabled == true)
            {
                inventoryUI.Hide();
            }
        }
    }


}
