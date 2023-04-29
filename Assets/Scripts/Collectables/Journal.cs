using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Journal : MonoBehaviour, ICollectable
{

    public static event HandleJournalCollected OnJournalCollected;

    //void Add(ItemData itemData)

    public delegate void HandleJournalCollected(ItemData itemData);
    public ItemData journalData;
    public void Collect()
    {
        Debug.Log("You collected a Journal");
        Destroy(gameObject);
        OnJournalCollected?.Invoke(journalData);

    }
    
}
