using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] //can create game objects of this type in Unity

public class ItemSO : ScriptableObject
{
    [field: SerializeField]
    public bool IsStackable { get; set; } //for items that are stackable

    public int ID => GetInstanceID(); //each item has an ID

    [field: SerializeField]
    public int MaxStackSize { get; set; } = 1; //how many objects can be stacked

    [field: SerializeField]
    public string Name { get; set; } //name of the item

    [field: SerializeField]
    [field: TextArea]
    public string Description { get; set; } //description of the item

    [field: SerializeField]
    public Sprite ItemImage { get; set; } //item sprite
}
