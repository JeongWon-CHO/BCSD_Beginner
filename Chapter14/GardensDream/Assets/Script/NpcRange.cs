using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NpcRange : MonoBehaviour
{

    public UnityEvent onPlayerEntered;


    // Update is called once per frame
    void Update()
    {
        NpcMove();
    }

    public void NpcMove()
    {
        Vector3 dir;
        double acceleration;
        double velocity = 0;
        GameObject playerpos = GameObject.FindWithTag("Player");


        dir = (playerpos.transform.position - transform.position).normalized;

        acceleration = 0.2f;

        velocity = (velocity + (acceleration * Time.deltaTime));

        float distance = Vector3.Distance(playerpos.transform.position, transform.position);



        if (distance <= 3.0f)
        {
            onPlayerEntered.Invoke();

            /*
            transform.position = new Vector3((float)(transform.position.x + (dir.x * velocity)),

                                                   transform.position.y,

                                                     (float)(transform.position.z + (dir.z * velocity)));
            */
        }
        else
        {
            velocity = 0.0f;
            GameObject canvas = GameObject.FindWithTag("Canvas");

            if (canvas == null)
            {
                return;
            }


            Transform transform = canvas.transform; // The Transform Attached to this GameObject
            GameObject panel = transform.Find("StartBtn_Triger").gameObject;

            if (panel == null)
            {
                return;
            }

            panel.SetActive(false);

        }
    }



}
