using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static UnityEditor.Progress;
using static ItemDropTable;

[CreateAssetMenu]
public class ItemDropTable : ScriptableObject
{
    [System.Serializable]
    public class DropItems
    {
        public DropItem dropItem;
        public int weight; // 드랍할 확률
    }

    public List<FieldItems> itemss = new List<FieldItems>();

    
    protected FieldItems PickItem()
    {
        int sum = 0;
        foreach (var item in itemss)
        {
            sum += item.weight;
        }

        var rnd = Random.Range(0, sum);

        for (int i = 0; i < itemss.Count; i++)
        {
            var item = itemss[i];
            if (item.weight > rnd)
                return itemss[i].dropItem;
            else rnd -= item.weight;
        }

        return null;
    }
    
    

    public void ItemDrop(Vector3 pos)
    {
        var item = PickItem();
        if (item == null) return;


        Instantiate(item.prefab, pos, Quaternion.identity);
    }
}
