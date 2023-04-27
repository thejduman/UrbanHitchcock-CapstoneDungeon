using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] //can create game objects of this type in Unity

public class InventorySO : ScriptableObject
{
    [SerializeField]
    private List<InventoryItemModel> inventoryItems;

    [field: SerializeField]
    public int Size { get; private set; } = 10; //for setting the size of the inventory

    //create empty inventory items for the size of the inventory
    public void Initialize()
    {
        inventoryItems = new List<InventoryItemModel>();
        for (int i = 0; i < Size; i++)
        {
            inventoryItems.Add(InventoryItemModel.GetEmptyItem());
        }
    }

    //add an item to the inventory
    public void AddItem(ItemSO item, int quantity)
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].IsEmpty)
            {
                inventoryItems[i] = new InventoryItemModel
                {
                    item = item,
                    quantity = quantity
                };
            }
        }
    }

    //returns the current state of the inventory as a dictionary
    public Dictionary<int, InventoryItemModel> GetCurrentInventoryState()
    {
        Dictionary<int, InventoryItemModel> returnValue = new Dictionary<int, InventoryItemModel>();

        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].IsEmpty)
                continue;
            returnValue[i] = inventoryItems[i];
        }
        return returnValue;
    }

    //get an item from the backend
    public InventoryItemModel GetItemAt(int itemIndex)
    {
        return inventoryItems[itemIndex];
    }
}



//a struct is being used so that the inventory items cannot be modified by other classes
[Serializable]
public struct InventoryItemModel
{
    public int quantity;
    public ItemSO item;
    public bool IsEmpty => item == null;

    //adjust the quantity of an item
    //because this is a struct a new item must be created that replaces the old item
    public InventoryItemModel ChangeQuantity(int newQuantity)
    {
        return new InventoryItemModel
        {
            item = this.item,
            quantity = newQuantity
        };
    }

    //set an empty item
    public static InventoryItemModel GetEmptyItem()
         => new InventoryItemModel
         {
             item = null,
             quantity = 0,
         };
}