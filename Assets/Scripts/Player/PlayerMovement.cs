using Assets.Scripts.System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Joystick joystick;
    public Animator animator;

    public float runSpeed = 40f;

    float HorizontalMove = 0f;

    bool Crouch = false;
    bool Jump = false;

    public void Start()
    {
        gameObject.transform.position = LevelManager.instance.DefaultSpawnPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.Horizontal >= 0.3f)
        {
            HorizontalMove = runSpeed;
        }else if (joystick.Horizontal <= -0.3f)
        {
            HorizontalMove = -runSpeed;
        }
        else
        {
            HorizontalMove = Input.GetAxis("Horizontal") * runSpeed;
        }

        if (Input.GetButtonDown("Jump")) 
        { 
            Jump = true;
            //animator.SetBool("IsJumping", true);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            Crouch = true;
        }
        else if (Input.GetButtonUp("Crouch")) 
        {
            Crouch = false;
        }
    }

    public void ClickJump()
    {
        Jump = true;
        //animator.SetBool("IsJumping", true);
    }

    void FixedUpdate()
    {
        var speed = HorizontalMove * Time.fixedDeltaTime;
        animator.SetFloat("Speed", Mathf.Abs(speed));
        controller.Move(speed, Crouch, Jump);
        Jump = false;
    }

    public void OnLand()
    {
        //animator.SetBool("isJumping", false);
    }

    public void OnCrouch(bool crouching)
    {
        animator.SetBool("IsCrouching", crouching);
    }
}
