using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCAreaController : MonoBehaviour
{

    public UnityEvent onPlayerEntered;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            onPlayerEntered.Invoke();
            /*
            GameObject canvas = GameObject.FindWithTag("Canvas");

            if (canvas == null)
            {
                return;
            }


            Transform transform = canvas.transform; // The Transform Attached to this GameObject
            GameObject panel = transform.Find("Panel").gameObject;

            if (panel == null)
            {
                return;
            }

            panel.SetActive(true);
            */
        };
    }
}