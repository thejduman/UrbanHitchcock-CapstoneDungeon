using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public List<InventorySlot> inventorySlots = new List<InventorySlot>(22);

    //GameObject inventoryMenu = Resources.Load("OBJECTS/INVENTORYPANEL") as GameObject;

    private void OnEnable()
    {
        Inventory.OnInventoryChange += UpdateInventorySlot;
    }

    private void OnDisable()
    {
        Inventory.OnInventoryChange -= UpdateInventorySlot;
    }

    void ResetInventory()
    {
        foreach(Transform childTransform in transform) 
        {
            Destroy(childTransform.gameObject);
        }
        inventorySlots = new List<InventorySlot>(22);
    }

    void DrawInventory(List<InventoryItem> inventory)
    {
        ResetInventory();

        for (int i = 0; i< inventorySlots.Capacity; i++)
        {
            CreateInventorySlot(i);
        }

        for (int i = 0; i < inventory.Count; i++)
        {
            inventorySlots[i].DrawSlot(inventory[i]);
        }
    }

    void CreateInventorySlot(int num)
    {
        GameObject newSlot = Instantiate(slotPrefab);
        newSlot.name = "Slot" + num;
        newSlot.transform.SetParent(transform, false);

        InventorySlot newSlotComponent = newSlot.GetComponent<InventorySlot>();
        newSlotComponent.ClearSlot();

        inventorySlots.Add(newSlotComponent);
    }

    void UpdateInventorySlot(List<InventoryItem> inventory)
    {
        inventorySlots = new List<InventorySlot>(22);
        for (int i = 0; i< inventorySlots.Capacity; i++)
        {
            GameObject Slot;
            if(i == 0)
            {
                 Slot = GameObject.Find("Slot");
            }
            else
            {
                 Slot = GameObject.Find("Slot (" + i + ")");
            }
            InventorySlot newSlotComponent = Slot.GetComponent<InventorySlot>();
            newSlotComponent.ClearSlot();
            inventorySlots.Add(newSlotComponent);         

        }

        

        for (int i = 0; i < inventory.Count; i++)
        {
            inventorySlots[i].DrawSlot(inventory[i]);
        }
    }
}

