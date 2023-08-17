using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InvokeInteract : MonoBehaviour
{
    public void DialogueInvoke()
    {
        GameObject canvas = GameObject.FindWithTag("Canvas");
        Transform transform = canvas.transform;
        GameObject panel = transform.Find("Interaction").gameObject;

        if (panel == null)
        {
            return;
        }

        panel.SetActive(true);
    }

}