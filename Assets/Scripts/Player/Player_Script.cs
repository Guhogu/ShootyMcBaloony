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

    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer sprite;

    float last_flap;
    float default_gravity;
    

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        default_gravity = rb.gravityScale;

        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        bool diving = Input.GetButton("Dive");

        if (Input.GetButtonDown("Flap"))
        {
            last_flap = Time.time;
            rb.velocity += new Vector2(velocity_increment.x * Input.GetAxis("Horizontal"), velocity_increment.y);
        }
        rb.gravityScale = diving ? dive_gravity : default_gravity;


        anim.speed = (Time.time - last_flap > 0.2 && rb.velocity.y > 0 && !diving) ? 0 : 1;

        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -velocity_max.x, velocity_max.x), Mathf.Clamp(rb.velocity.y, -velocity_max.y, velocity_max.y));

        sprite.flipX = rb.velocity.x < 0;
        anim.SetFloat("velocity_y", rb.velocity.y);
        anim.SetBool("Diving", diving);

    }
}
