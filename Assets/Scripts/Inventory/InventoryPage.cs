using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPage : MonoBehaviour
{
    [SerializeField]
    private InventoryItem itemPrefab;

    [SerializeField]
    private RectTransform contentPanel;

    List<InventoryItem> listOfItems = new List<InventoryItem>(); 

    //create item prefabs for all items in inventory
    public void InitializeInventory(int inventorysize)
    {
        for (int i = 0; i < inventorysize; i++)
        {
            InventoryItem item = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            item.transform.SetParent(contentPanel);
            listOfItems.Add(item);
            
            //define methods for user interactions with the inventory UI
            item.OnItemClicked += HandleItemSelection;
            item.OnItemBeginDrag += HandleBeginDrag;
            item.OnItemDroppedOn += HandleSwap;
            item.OnItemEndDrag += HandleEndDrag;
            item.OnRightMouseBtnClick += HandleShowItemActions;
        }
    }

    private void HandleShowItemActions(InventoryItem obj)
    {
        throw new NotImplementedException();
    }

    private void HandleEndDrag(InventoryItem obj)
    {
        throw new NotImplementedException();
    }

    private void HandleSwap(InventoryItem obj)
    {
        throw new NotImplementedException();
    }

    private void HandleBeginDrag(InventoryItem obj)
    {
        throw new NotImplementedException();
    }

    private void HandleItemSelection(InventoryItem obj)
    {
        Debug.Log(obj.name);
    }

    //show the inventory
    public void Show()
    {
        gameObject.SetActive(true);
    }

    //hide the inventory
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
