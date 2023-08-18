using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public int maxHP;
    public int currentHP;
    public Slider playerslider;

    [SerializeField]
    private float walkSpeed;

    [SerializeField]
    private float runSpeed;

    [SerializeField]
    private float crouchSpeed;

    private float applySpeed;

    [SerializeField]
    private float jumpForce;

    
    
    private bool isRun = false;
    private bool isCrouch = false;
    private bool isGround = true;
    private bool Die = false;

    
    [SerializeField]
    private float crouchPosY;
    private float originPosY;
    private float applyCrouchPosY;



    // �� ���� ����
    private CapsuleCollider capsuleCollier;



    [SerializeField]
    private Camera theCamera;
    private Rigidbody myRigid;




    private float hAxis;
    private float vAxis;
    public float speed;

    Vector3 moveVec;

    //[SerializeField]
    private Animator anim;


    Weapon equipWeapon;


    void Start()
    {
        capsuleCollier = GetComponent<CapsuleCollider>();
        myRigid = GetComponent<Rigidbody>();
        applySpeed = walkSpeed;
        originPosY = theCamera.transform.localPosition.y;
        applyCrouchPosY = originPosY;

    }

    // Update is called once per frame
    void Update()
    {
        //IsGround();
        TryJump();
        TryRun();
        TryCrouch();
        Move();
        playerslider.value = (float)currentHP / maxHP;
        CheackDie();
    }

    void CheackDie()
    {
        if (currentHP <= 0)
        {
            Destroy(gameObject);
            anim.SetBool("Die", true);
            Debug.Log("GameOver");
        }
    }

    private void TryCrouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch();
        }
    }


    private void Crouch()
    {
        isCrouch = !isCrouch;

        if (isCrouch)
        {
            applySpeed = crouchSpeed;
            applyCrouchPosY = originPosY;
        }
        else
        {
            applySpeed = walkSpeed;
        }

        StartCoroutine(CrouchCoroutine());
        theCamera.transform.localPosition = new Vector3(theCamera.transform.localPosition.x, applyCrouchPosY, theCamera.transform.localPosition.z);

    }

    IEnumerator CrouchCoroutine()
    {
        float _posY = theCamera.transform.localPosition.y;

        while (_posY != applyCrouchPosY)
        {
            _posY = Mathf.Lerp(_posY, applyCrouchPosY, 0.3f);
            theCamera.transform.localPosition = new Vector3(0, _posY, 0);
            yield return null;
        }

        //yield return new WaitForSeconds(1f);
    }


    /*
    public void IsGround()
    {
        isGround = Physics.Raycast(transform.position, Vector3.down, capsuleCollier.bounds.extents.y + 0.1f);
    }
    */

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            anim.SetTrigger("OnGround");
        }
    }

    private void TryJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
        }
    }

    private void Jump()
    {
        myRigid.velocity = transform.up * jumpForce;

        isGround = false;

        anim.SetTrigger("Jump");
        
    }



    private void TryRun()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Running();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            RunningCancle();
        }
    }

    private void Running()
    {
        isRun = true;
        applySpeed = runSpeed;
    }

    private void RunningCancle()
    {
        isRun = false;
        applySpeed = walkSpeed;
    }



    public void Move()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * speed * Time.deltaTime;

        

        transform.LookAt(transform.position + moveVec);
    }


    public void StopMoving()
    {
        Debug.Log("StopMoving!");
        speed = 0;
    }


    public void ContinueMoving()
    {
        Debug.Log("계속 진행...");
        speed = 5;
    }


    public void PlayerHpRisk()
    {
        currentHP -= 10;
    }


}