using Assets.Scripts.System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("- Components ")]
    public Joystick joystick;
    private Rigidbody2D rb2d;

    [Header("- Animation")]
    public Animator animator;
    [SerializeField] private string _CurrentState;

    [Header("- Parameters ")]
    private bool canMove = false;
    [SerializeField] private bool _facingRight = true;

    private float HorizontalMove = 0f;
    [SerializeField] private float runSpeed = 40f;

    bool Crouch = false;

    [Header("--- Jump ")]
    [SerializeField] private float JumpForce = 100f;
    [SerializeField] private bool Jump = false;
    [SerializeField] private bool wasGrounded;
    [Header("--- Ground ")]
    [SerializeField] private Transform _GroundCheck;
    [SerializeField] private float _GroundRadius = .3f;
    [SerializeField] private LayerMask _groundLayers;
    [SerializeField] private bool _Grounded;

    [SerializeField] private Vector2 refVelo;

    public void Start()
    {
        gameObject.transform.position = LevelManager.instance.DefaultSpawnPoint.position;
        rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine(WaitAnimation(PLAYER_ENTERLEVEL));
    }


    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;
        if (joystick.Horizontal != 0f)
        {
            HorizontalMove = joystick.Horizontal;
        }
        else
        {
            HorizontalMove = Input.GetAxis("Horizontal");
        }
        if (Input.GetButtonDown("Jump") && _Grounded)
        {
            Jump = true;
        }

    }

    //=====================================================
    // Physics based time step loop
    //=====================================================
    private void FixedUpdate()
    {
        //check if player is on the ground
        wasGrounded = _Grounded;
        _Grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_GroundCheck.position, _GroundRadius, _groundLayers);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                _Grounded = true;
                //If player land, play landing animation
                if (!wasGrounded && _Grounded)
                {
                    StartCoroutine(WaitAnimation(PLAYER_LAND));
                }
            }
        }
        
        //Animation on movement X axis
        if (_Grounded)
        {
            if (HorizontalMove != 0f)
            {
                ChangeAnimationState(PLAYER_RUN);
            }
            else
            {
                ChangeAnimationState(PLAYER_IDLE);
            }
        }

        if (!_Grounded)
        {
            if (rb2d.velocity.y > 0f) ChangeAnimationState(PLAYER_JUMPSTATE);
            else ChangeAnimationState(PLAYER_FALLSTATE);
        }
        
        // Movement on X axis
        rb2d.velocity = new Vector2(HorizontalMove * runSpeed, rb2d.velocity.y);
        Flip(HorizontalMove);

        //Movement on Y axis
        if (Jump && _Grounded)
        {
            rb2d.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            Jump = false;
        }
    }

    /*
    void FixedUpdate()
    {
        if (_Grounded)
        {
            if( HorizontalMove != 0f)
            {
                ChangeAnimationState(PLAYER_RUN);
            }
            else 
            {
                ChangeAnimationState(PLAYER_IDLE);
            }
        }
        Movement();
        if(Jump)
        {
            if( rb2d.velocity.y > 0f)
            {
                Debug.Log(rb2d.velocity.y);
                ChangeAnimationState(PLAYER_JUMPSTATE);
            }
            else if(rb2d.velocity.y < 0f)
            {
                Debug.Log(rb2d.velocity.y);
                ChangeAnimationState(PLAYER_FALLSTATE);
            }
            else
            {
                Debug.Log(rb2d.velocity.y);
                ChangeAnimationState(PLAYER_LAND);
            }
        }
    }
    */


    /// <summary>
    /// Check if the player is on the ground or other place with Ground layer
    /// </summary>
    private void IsGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(_GroundCheck.position, _GroundRadius, _groundLayers);
        if(collider != null)
        {
            _Grounded = true;
        }else
        {
            _Grounded = false;
        }
    }

    /// <summary>
    /// Make player move depends on user's input.
    ///  - Horizontal Movement
    ///  - Vertical Movement
    /// </summary>
    private void Movement()
    {
        rb2d.velocity = new Vector2(HorizontalMove * runSpeed, rb2d.velocity.y);
        if (Jump)
        {
            StartCoroutine(WaitAnimation(PLAYER_START_JUMP));
            rb2d.gravityScale = 1f;
            rb2d.AddForce( new Vector2(0, JumpForce), ForceMode2D.Impulse );
            Jump = false;
        }
        refVelo = rb2d.velocity;
    }

    /// <summary>
    /// Flip the player Left-Right from the value of the direction
    /// </summary>
    /// <param name="_direction"> Horizontal input </param>
    private void Flip(float _direction)
    {
        if(_direction > 0.01f)
        {
            transform.localScale = Vector3.one;
            _facingRight = true;
        }
        else if (_direction < -0.01f) 
        {
            transform.localScale = new Vector3(-1, 1, 1);
            _facingRight = false;
        }
    }

    public void ClickJump()
    {
        Jump = true;
    }

    /// <summary>
    /// Set animator on state animation, can pass to another
    /// </summary>
    /// <param name="newState">Animation to play</param>
    public void ChangeAnimationState(string newState)
    {
        if (_CurrentState == newState) return;

        animator.Play(newState);

        _CurrentState = newState;
    }

    /// <summary>
    /// Set animator on state animation and wait for it to finish to play
    /// </summary>
    /// <param name="state"> Animation to play</param>
    /// <returns></returns>
    private IEnumerator WaitAnimation(string state)
    {
        canMove = false;
        ChangeAnimationState(state);
        float animationLength;
        switch (_CurrentState)
        {
            case PLAYER_ENTERLEVEL:
                animationLength = PLAYER_ENTER_LENGTH;
                break;
            case PLAYER_LAND:
                animationLength = PLAYER_LAND_LENGTH;
                break;
            default:
                animationLength = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
                break;
        }
        Debug.Log(animationLength);
        yield return new WaitForSeconds(animationLength);
        canMove = true;
    }


    //  ANIMATION STATE
    public const string PLAYER_ENTERLEVEL = "Gus_EnterLevel";
    public const float PLAYER_ENTER_LENGTH = 1.850f;
    public const string PLAYER_IDLE = "Gus_Idle";
    public const string PLAYER_START_RUN = "Gus_Idle_To_Run";
    public const string PLAYER_RUN = "Gus_Run";
    public const string PLAYER_STOP_RUN = "Gus_Run_To_Idle";
    public const string PLAYER_START_JUMP = "Gus_Jump_Start";
    public const string PLAYER_JUMPSTATE = "Gus_Jump_State";
    public const string PLAYER_FALLSTATE = "Gus_Fall_State";
    public const string PLAYER_LAND = "Gus_Jump_Landing";
    public const float PLAYER_LAND_LENGTH = 0.350f;
}
