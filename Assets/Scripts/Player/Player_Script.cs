using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour {

    [SerializeField]
    Vector2 velocity_max;

    [SerializeField]
    Vector2 velocity_increment;

    [SerializeField]
    float dive_gravity;

    [SerializeField]
    float walkingSpeed;

    [SerializeField]
    float walking_ldrag;


    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer sprite;

    bool facingLeft;
    float last_flap;
    float default_gravity;
    float default_ldrag;


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        default_gravity = rb.gravityScale;
        default_ldrag = rb.drag;
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        bool diving = Input.GetButton("Dive");
        bool walking = isGrounded();

        if (Input.GetButtonDown("Flap"))
        {
            last_flap = Time.time;
            rb.velocity += new Vector2(velocity_increment.x * Input.GetAxis("Horizontal"), velocity_increment.y);
            if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f)
                facingLeft = Input.GetAxis("Horizontal") < 0;
        }
        else if(walking)
        {
            rb.velocity += Vector2.right * Input.GetAxis("Horizontal") * walkingSpeed;
            if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f)
                facingLeft = Input.GetAxis("Horizontal") < 0;
        }

        rb.gravityScale = diving ? dive_gravity : default_gravity;
        rb.drag = walking ? walking_ldrag : default_ldrag;

        AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);
        anim.speed = (currentState.IsName("Flying") && Time.time - last_flap > 0.2 && rb.velocity.y > 0) ? 0 : 1;

        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -velocity_max.x, velocity_max.x), Mathf.Clamp(rb.velocity.y, -velocity_max.y, velocity_max.y));

        sprite.flipX = facingLeft;
        anim.SetFloat("velocity_y", rb.velocity.y);
        anim.SetFloat("velocity_x_abs", Mathf.Abs(rb.velocity.x));
        anim.SetBool("Diving", diving);
        anim.SetBool("Walking", walking);
        
        
    }

    bool isGrounded()
    {
        return Physics2D.Raycast(transform.position + 10 * (Vector3)Vector2.down, Vector2.down, 5f, 1 << LayerMask.NameToLayer("Ground"));
    }
}
