using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipment,
    Consumables,
    Etc
}


//[CreateAssetMenu]
[System.Serializable]
public class Item2
{
    public ItemType itemType;
    public string itemName;
    public Sprite itemImage;

    //public Transform prefab; // 드랍 아이템 만들기 위해

    public bool Ues()
    {
        return false;
    }
}