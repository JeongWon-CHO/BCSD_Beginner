using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;  // 유니티 이벤트를 사용하기 위해 필요합니다.

public class PlayerHp : MonoBehaviour
{
    public UnityEvent PlayerHP;


    private void Descreate()
    {
        PlayerHP.Invoke();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Descreate();
        }
    }
}
