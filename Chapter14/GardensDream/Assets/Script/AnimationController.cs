using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    GameObject obj;
    private Animator anim;
    private PlayerController player;
    //private bool Run = false;
    //private bool Jump = false;
    private bool isGround = true;

    //�� ���� ����
    private CapsuleCollider capsuleCollier;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerController>();
        capsuleCollier = GetComponent<CapsuleCollider>();
    }


    // Update is called once per frame
    void Update()
    {
        
        if ((Input.GetAxisRaw("Horizontal") != 0) || (Input.GetAxisRaw("Vertical") != 0))
        {
            anim.SetBool("Walk", true);
        }
        else if((Input.GetAxisRaw("Horizontal") == 0) && (Input.GetAxisRaw("Vertical") == 0))
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Idle", true);
        }


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetBool("Run", true);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("Run", false);
        }



        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            isGround = false;
            anim.SetTrigger("Jump");

            //if (isGround) anim.SetTrigger("OnGround");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger("Attack");
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetTrigger("Attack_S");
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            anim.SetTrigger("OnGround");
        }
    }

}
