using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItems : MonoBehaviour
{
    public Item2 item;
    public SpriteRenderer image;
    public Transform prefab;



    public FieldItems dropItem;
    public int weight; // 드랍할 확률




    public void SetItem(Item2 _item)
    {
        item.itemName = _item.itemName;
        item.itemImage = _item.itemImage;
        item.itemType = _item.itemType;

        image.sprite = item.itemImage;
    }

    public Item2 GetItem()
    {
        return item;
    }

    public void DestroyItem()
    {
        Destroy(gameObject);
    }
}
