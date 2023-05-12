using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlayer : MonoBehaviour
{ 
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Player").SetActive(false);
    }
}
