using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour {

    Animator anim;
    Rigidbody2D rb;
    float maxSpeed = 150f;
    bool facingRight = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (Input.GetMouseButton(0) || anim.GetCurrentAnimatorStateInfo(0).IsName("US-thompson-Firing")) 
        {
            anim.SetFloat("Speed", 0);
            rb.velocity = new Vector2(0, rb.velocity.y);
            anim.SetTrigger("Fire");
        }
        else
        {
            anim.ResetTrigger("Fire");
            float move = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
            anim.SetFloat("Speed", Mathf.Abs(move));

            if (move > 0 && !facingRight)
            {
                Flip();
            }
            else if (move < 0 && facingRight)
            {
                Flip();
            }
        }      
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
