using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R_Btn : MonoBehaviour
{
    public Button btnDialogueStart;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            btnDialogueStart.onClick.Invoke();
        }
    }
}