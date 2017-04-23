using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Vector2 offset;
    public float speed;

    Transform player;
    Camera cam;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("player").transform;
        cam = GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 player_screen_position = cam.WorldToScreenPoint(player.position);
	}
}
