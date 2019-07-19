using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    private Rigidbody2D rigid2d;
    private PlayerFoot foot;
    private DoorDetect doorDetect;
    private Animator anim;
    private bool doubleJump;
    private bool isDoor;

    public Transform body;
    public CameraControll main;
    public float v;
    public float jumpPower;


    void Start()
    {
        doorDetect = GetComponentInChildren<DoorDetect>();
        rigid2d = GetComponent<Rigidbody2D>();
        foot = GetComponentInChildren<PlayerFoot>();
        anim = GetComponentInChildren<Animator>();
    }


    void FixedUpdate()
    {
        v = Input.GetAxisRaw("Vertical");
        Vector2 velocity = rigid2d.velocity;

        if (velocity.y > 1)
            anim.SetInteger("isJumpUp", 1);
        else if (velocity.y < 1)
            anim.SetInteger("isJumpUp", 2);
            
        if(foot.isGround)
            anim.SetInteger("isJumpUp", 0);


        if ((Input.GetKey(KeyCode.Space))){
            
            if (foot.isGround)
            {
                StartCoroutine(Jump(false));
            }
            else
            {
                if(foot.groundCnt > 0)
                {
                    StartCoroutine(Jump(true));
                }
            }
        }
        if(v == -1)
        {
            if (foot.isGround)
                Slide(foot.isGround);
            else
                Slide(false);
        }
        else
        {
            Slide(false);
        }

        if (isDoor)
        {
            main.DoorDetected();
        }
        else
        {
            main.BackToOrigin();
        }
            
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Door"))
        {
            isDoor = true;
        }
        if (other.CompareTag("OpenedDoor"))
        {
            isDoor = false;
        }
    }

    private IEnumerator Jump(bool isDouble)
    {
        if (doubleJump)
            yield break;

        if (isDouble)
        {
            foot.groundCnt = 0;   
        }
        else
        {
            doubleJump = true;
            foot.groundCnt = 1;
        }

        rigid2d.velocity = Vector2.zero;
        rigid2d.AddForce(Vector2.up * jumpPower);

        yield return new WaitForSeconds(0.2f);
        doubleJump = false;
        yield break;
    }

    private void Slide(bool isGround)
    {
        if (isGround)
            body.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        else
            body.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    private void Attacked()
    {

    }

    
}
