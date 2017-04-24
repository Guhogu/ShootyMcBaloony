using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Vector2 offset;
    private Vector3 velocity = Vector3.zero;
    public float dampTime = .6f;

    Transform player;
    Camera cam;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        cam = GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector2 player_sp = cam.WorldToScreenPoint(player.position);
        Vector2 cam_sp = cam.WorldToScreenPoint(transform.position);
        Vector2 move = new Vector2();
        if (Mathf.Abs(cam_sp.x - player_sp.x) > offset.x)
            move.x = (player_sp - cam_sp).x;
        if (Mathf.Abs(cam_sp.y - player_sp.y) > offset.y)
            move.y = (player_sp - cam_sp).y;
       

        
        transform.position = Vector3.SmoothDamp(transform.position, cam.ScreenToWorldPoint((Vector3)(move + cam_sp)), ref velocity, dampTime / (move.magnitude / 100 ));

    }
}
