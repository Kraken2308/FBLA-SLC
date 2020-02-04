using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator myAnimator;
    public CharacterController2D controller;
    public float sprintSpeed = 60f;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * sprintSpeed;
            myAnimator.SetFloat("RunningSpeed", Mathf.Abs(horizontalMove));
        }
        else
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            myAnimator.SetFloat("RunningSpeed", Mathf.Abs(horizontalMove));
        }

       

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            myAnimator.SetBool("IsJumping", true);

        }


    }

   public void OnLanding()
    {

        myAnimator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
        
    }
}