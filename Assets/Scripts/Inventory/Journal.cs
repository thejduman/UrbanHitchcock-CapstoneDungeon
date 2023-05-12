using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour, ICollectable
{
    public static event HandleJournalCollected OnJournalCollected;
    public delegate void HandleJournalCollected(ItemData itemData);
    public ItemData journalData;

    public void Collect()
    {
        Debug.Log("You collected a journal");
        Destroy(gameObject);
        OnJournalCollected?.Invoke(journalData);
    }
}
