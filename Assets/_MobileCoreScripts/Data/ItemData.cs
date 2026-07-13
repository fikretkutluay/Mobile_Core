using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemID;
    public string itemName;

    public int gridWidth;
    public int gridHeight;
    public int targetScore;
    public Sprite itemIcon;
    public GameObject itemPrefab;
    
}
