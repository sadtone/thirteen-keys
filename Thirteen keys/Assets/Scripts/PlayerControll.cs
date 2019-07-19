using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    private Rigidbody2D rigid2d;
    private PlayerFoot foot;
    private bool doubleJump;

    public Transform body;
    public float v;
    public float jumpPower;


    void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
        foot = GetComponentInChildren<PlayerFoot>();
    }


    void FixedUpdate()
    {
        v = Input.GetAxisRaw("Vertical");

        if((Input.GetKey(KeyCode.Space))){
            
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Door"))
        {
            Time.timeScale = 0.2f; //5초에 trigger raius만큼 움직이게 해야해요 아시겠죠
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
}
