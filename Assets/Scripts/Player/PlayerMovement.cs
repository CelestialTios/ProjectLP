using Assets.Scripts.System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    public CharacterController2D controller;
    public Joystick joystick;
    public Animator animator;
    private Rigidbody2D rb2d;

    [Header("Parameters")]
    public float runSpeed = 40f;

    float HorizontalMove = 0f;
    bool Crouch = false;
    bool Jump = false;

    public void Start()
    {
        gameObject.transform.position = LevelManager.instance.DefaultSpawnPoint.position;
        rb2d = GetComponent<Rigidbody2D>();
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
            ClickJump();
        }
        if (Input.GetButtonDown("Crouch"))
        {
            Crouch = true;
        }
        else if (Input.GetButtonUp("Crouch")) 
        {
            Crouch = false;
        }
        
        if(rb2d.velocity.y < 0f)
        {
            animator.SetBool("falling", true);
        }
    }

    public void ClickJump()
    {
        Jump = true;
        animator.SetTrigger("jump");
    }

    void FixedUpdate()
    {
        var speed = HorizontalMove * Time.fixedDeltaTime;
        animator.SetFloat("speed", Mathf.Abs(speed));
        controller.Move(speed, Crouch, Jump);
        Jump = false;
    }

    public void OnLand()
    {
        animator.SetBool("falling", false);
    }

    public void OnCrouch(bool crouching)
    {
        animator.SetBool("IsCrouching", crouching);
    }
}
