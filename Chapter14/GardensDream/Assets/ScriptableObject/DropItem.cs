using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DropItem : ScriptableObject
{
    public string itemName;

    [System.Serializable]
    public struct STAT
    {
        public string name;
        public int value;
    }


    public List<STAT> stats = new List<STAT>();

    public int maxStack;
    public int price;

    public Sprite icon;
    public Transform prefab;

    [Multiline]
    public string description;
}


