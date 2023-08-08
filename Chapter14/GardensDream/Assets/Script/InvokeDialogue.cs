using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InvokeDialogue : MonoBehaviour
{
    public void DialogueInvoke()
    {
        GameObject canvas = GameObject.FindWithTag("Canvas");
        Transform transform = canvas.transform;
        GameObject panel = transform.Find("Panel").gameObject;

        if (panel == null)
        {
            return;
        }

        panel.SetActive(true);
    }

    /*
    private void OnTriggerEnter(Collider other)
    {

        GameObject btn = transform.Find("Btn_Triger").gameObject;

        if (btn.activeSelf == true)
        {
            GameObject canvas = GameObject.FindWithTag("Canvas");

            if (canvas == null)
            {
                return;
            }


            Transform transform = canvas.transform;
            GameObject panel = transform.Find("Panel").gameObject;

            if (panel == null)
            {
                return;
            }

            panel.SetActive(true);
        }

    }
    */

}