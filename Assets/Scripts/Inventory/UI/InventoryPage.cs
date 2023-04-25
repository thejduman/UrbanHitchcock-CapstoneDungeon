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

    [SerializeField]
    private InventoryDescription itemDescription;

    [SerializeField]
    private MouseFollower mouseFollower;

    List<InventoryItem> listOfItems = new List<InventoryItem>();

    public event Action<int> OnDescriptionRequested, OnItemActionRequested, OnStartDragging;
    public event Action<int, int> OnSwapItems;

    private int currentlyDraggedItemIndex = -1;

    private void Awake()
    {
        Hide();
        mouseFollower.Toggle(false);
        itemDescription.ResetDescription();
    }

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

    public void UpdateData(int itemIndex, Sprite itemImage, int itemQuantity)
    {
        if (listOfItems.Count > itemIndex)
        {
            listOfItems[itemIndex].SetData(itemImage, itemQuantity);
        }
    }
    
    private void HandleShowItemActions(InventoryItem inventoryItemUI)
    {
        throw new NotImplementedException();
    }

    //remove an item from the drag state
    private void HandleEndDrag(InventoryItem inventoryItemUI)
    {
        ResetDraggedItem();
    }

    //logic for swapping an item in the drag state with another item
    private void HandleSwap(InventoryItem inventoryItemUI)
    {
        int index = listOfItems.IndexOf(inventoryItemUI);
        if (index == -1)
        {
            return;
        }
        OnSwapItems?.Invoke(currentlyDraggedItemIndex, index);
    }

    
    //reset properties when item exits drag state
    private void ResetDraggedItem()
    {
        mouseFollower.Toggle(false);
        currentlyDraggedItemIndex = -1;
    }

    //change an item to the drag state
    private void HandleBeginDrag(InventoryItem inventoryItemUI)
    {
        int index = listOfItems.IndexOf(inventoryItemUI);
        if (index == -1)
            return;
        currentlyDraggedItemIndex = index;
        HandleItemSelection(inventoryItemUI);
        OnStartDragging?.Invoke(index);
       
    }

    //re-create the dragged item
    public void CreateDraggedItem(Sprite sprite, int quantity)
    {
        mouseFollower.Toggle(true);
        mouseFollower.SetData(sprite, quantity);
    }

    //set the description when an item is selected
    private void HandleItemSelection(InventoryItem inventoryItemUI)
    {
        int index = listOfItems.IndexOf(inventoryItemUI);
        if (index == -1)
            return;
        OnDescriptionRequested?.Invoke(index);
    }

    //show the inventory
    public void Show()
    {
        gameObject.SetActive(true);
        ResetSelection();
    }

    private void ResetSelection()
    {
        itemDescription.ResetDescription();
        DeselectAllItems();
    }

    private void DeselectAllItems()
    {
        foreach (InventoryItem item in listOfItems)
        {
            item.Deselect();
        }
    }

    //hide the inventory
    public void Hide()
    {
        gameObject.SetActive(false);
        ResetDraggedItem();
    }
}
