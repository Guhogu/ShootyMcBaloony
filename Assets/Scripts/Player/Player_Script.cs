using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour {

    public Vector2 velocity_max;
    public Vector2 velocity_increment;
    public float gravity;
    public bool grounded;


    Animator anim;
    Rigidbody2D rb;
    float last_flap;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        
   
        if (Input.GetButtonDown("Flap"))
        {
            last_flap = Time.time;
            rb.velocity += new Vector2(velocity_increment.x * Input.GetAxis("Horizontal"), velocity_increment.y);
            //         velocity += ;
        }

        anim.speed = (Time.time - last_flap > 0.2 && rb.velocity.y > 0) ? 0 : 1;

        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -velocity_max.x, velocity_max.x), Mathf.Clamp(rb.velocity.y, -velocity_max.y, velocity_max.y));

        anim.SetBool("FacingLeft", rb.velocity.x < 0);
        anim.SetFloat("velocity_y", rb.velocity.y);

        //transform.position = transform.position + (Vector3)velocity * Time.deltaTime;


    }
}
