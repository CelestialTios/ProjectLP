using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyControler : MonoBehaviour
{
    [SerializeField] ConstanteWorld constantes;
    #region EnemyComponent
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private EnemyScriptableObject EnemyScriptableObject;
    float weight;

    #endregion
    
    #region FieldOfView
    FieldOfView fieldOfView;
    int raycount;
    float fov;
    float ViewDistance;
    #endregion

    #region Patrolling
    [SerializeField] private Transform[] waypoints;
    Transform target;
    private float speed;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private RaycastHit2D hit;
    #endregion

    private SpriteRenderer sr;
    private bool Next = true;
    private bool isFacingRight;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        constantes = ConstanteWorld.instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        weight = EnemyScriptableObject.weight;

        fov = EnemyScriptableObject.fov;
        raycount = EnemyScriptableObject.raycount;
        ViewDistance = EnemyScriptableObject.ViewDistance;

        //target = waypoints[0];
        sr.sprite = EnemyScriptableObject.sprite;
        isFacingRight = true;
        constantes = ConstanteWorld.instance;
        //var fieldObject = Instantiate(EnemyScriptableObject.pfieldOfView);
        //fieldOfView = fieldObject.GetComponent<FieldOfView>();
        //fieldOfView.SetDirection(sr.flipX ? 0 : 180);
    }

    // Update is called once per frame
    void Update()
    {
        hit = Physics2D.Raycast(groundCheck.position, -transform.up, 1f, groundLayer);
    }

    public void LateUpdate()
    {
        if(hit.collider != null)
        {
            speed = isFacingRight ? (constantes.characterSpeed / weight) : -(constantes.characterSpeed / weight);    //Set direction of the enemy
            rb.velocity = new Vector2(speed, rb.velocity.y);
            //fieldOfView.SetOrigin(rb.position);                                                                 //Move FieldofView with enemy position
            /*if(Vector3.Distance(rb.position, target.position) < .5f)                                            // Verify if enemy is at target position
            {
                Turn();
            }*/
        }
        else
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
        }
    }

    private void Turn()
    {
        Flip();
        GoToNextPoint();
    }

    private void Flip()
    {
        //fieldOfView.SetDirection(isFacingRight ? 0 : 180);
    }

    private void GoToNextPoint()
    {
        target = waypoints[Next ? 1 : 0];
        Next = !Next;
    }
}
