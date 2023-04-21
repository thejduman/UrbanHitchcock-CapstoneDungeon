using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [SerializeField]
    private Image itemImage;

    [SerializeField]
    private TMP_Text quantityTxt;

    [SerializeField]
    private Image borderImage;

    public event Action<InventoryItem> OnItemClicked, OnItemDroppedOn, 
        OnItemBeginDrag, OnItemEndDrag, OnRightMouseBtnClick;
    private bool empty = true;

    public void Awake()
    {
        ResetData();
        Deselect();
    }

    //disable border image when slot is deselected
    public void Deselect()
    {
        borderImage.enabled = false;
    }

   //enable border image when slot is selected
    public void Select()
    {
        borderImage.enabled = true;
    }

    //set an empty slot
    public void ResetData()
    {
        this.itemImage.gameObject.SetActive(false);
        empty = true;
    }

    //fill a slot with an item
    public void SetData(Sprite sprite, int quantity)
    {
        this.itemImage.gameObject.SetActive(true);
        this.itemImage.sprite = sprite;
        this.quantityTxt.text = quantity + "";
        empty = false;
    }

    //these methods invoke the actions which are defined in InventoryPage
    public void OnBeginDrag()
    {
        if (empty)
            return;
        OnItemBeginDrag?.Invoke(this);
    }

    public void OnDrop()
    {
        OnItemDroppedOn?.Invoke(this);
    }

    public void OnEndDrag()
    {
        OnItemEndDrag?.Invoke(this);
    }

    //check that mouse was clicked before calling the event
    public void OnPointerClick(BaseEventData data)
    {
        if (empty)
            return;
        PointerEventData pointerData = (PointerEventData)data;
        if (pointerData.button == PointerEventData.InputButton.Right)
        {
            OnRightMouseBtnClick?.Invoke(this);
        }
        else
        {
            OnItemClicked?.Invoke(this);
        }
    }

}
