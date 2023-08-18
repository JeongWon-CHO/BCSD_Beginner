using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class Tree : MonoBehaviour
{
    public TreeInfo tree;

    public int level;

    public Slider TreeHpSlider;

    public int hpFull;

    [HideInInspector]
    public int hp;

    // Start is called before the first frame update
    void Start()
    {
        hp = level * tree.con;
        hpFull = 100;
    }

    public void Update()
    {
        TreeHpSlider.value = (float)hp / hpFull;
        DropTheItem();

    }

    public void OnClickButton()
    {
        hp -= 10;
    }


    public int DropTheItem()
    {
        if (hp <= 0)
        {
            
            // 몬스터가 죽으면 Item Drop Table 을 이용해 아이템 드랍
            tree.itemDropTable.ItemDrop(transform.position); // 원래 괄호 안에 transform.position
            Destroy(this.gameObject);
            BtnNotActiviting();
            
        }

        return hp;
    }


    public void BtnNotActiviting()
    {
        GameObject canvas = GameObject.FindWithTag("Canvas");

        if (canvas == null)
        {
            return;
        }


        Transform transform = canvas.transform;
        GameObject panel = transform.Find("LoggingBtn").gameObject;

        if (panel == null)
        {
            return;
        }

        panel.SetActive(false);
    }


}