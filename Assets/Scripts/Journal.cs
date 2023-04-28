using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour, ICollectable
{

    public void Collect()
    {
        Debug.Log("You collected a Journal");
    }
    
}
