using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private InventoryPage inventoryUI;

    public int inventorySize = 10;

    //hide the inventory at the start
    private void Start()
    {
        inventoryUI.Hide();
        inventoryUI.InitializeInventory(inventorySize);
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
