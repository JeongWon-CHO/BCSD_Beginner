using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;  // 유니티 이벤트를 사용하기 위해 필요합니다.

public class BossHp : MonoBehaviour
{
    public UnityEvent MonsterHP;


    private void Descreate()
    {
        MonsterHP.Invoke();
    }


    private void OnTriggerEnter(Collider other)
    {
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S)) && other.CompareTag("Melee"))
        {
            Descreate();
        }
    }
}
