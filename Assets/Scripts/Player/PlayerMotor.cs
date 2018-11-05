using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public PlayerController controller;
    public Animator animator;


    public float speed = 40f;
    public float maxJump = 100f;

    float horizontalMove = 0f;
    float verticalMove = 0f;

    bool jump = false;


    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
            animator.SetBool("isJumping", true);
        }
 

    }

    public void Jump()
    {
        jump = true;
    }
    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    void FixedUpdate()
    {
        animator.SetBool("isRunning", false);
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump, animator);
        jump = false;
    }

}
