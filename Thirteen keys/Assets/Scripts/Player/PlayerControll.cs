using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    private Rigidbody2D rigid2d;
    private PlayerFoot foot;
    private Animator anim;
    private bool doubleJump;

    public DoorDetect doorDetect, doorDetect1;
    public SpriteRenderer keyImage;
    public Transform body;
    public CameraControll main;
    public int keyCodeNow;
    public float v, jumpPower;
    public Sprite[] key;
    public AudioClip keyChangeSound;

    void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
        foot = GetComponentInChildren<PlayerFoot>();
        anim = GetComponentInChildren<Animator>();

        keyCodeNow = 0;
        keyImage.sprite = key[keyCodeNow];
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
                    StartCoroutine(Jump(true));
            }
        }
        if(v == -1)
        {
            if (foot.isGround)
                anim.SetInteger("isJumpUp", 3);
        }

        if (doorDetect1.isDoor)
            main.DoorDetected();
        else
            main.BackToOrigin();
            
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


    public void KeyChange(int keyCode)
    {
        keyImage.sprite = key[keyCode];
        keyCodeNow = keyCode;
        SoundManager.instance.PlaySound(keyChangeSound);
    }
}
