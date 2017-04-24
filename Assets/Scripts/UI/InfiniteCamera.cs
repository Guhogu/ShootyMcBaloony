using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteCamera : MonoBehaviour {

    [SerializeField]
    Vector2 velocity;

    [SerializeField]
    Camera cam;

    [SerializeField]
    Vector2 offset;

    Transform player;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (!player)
            player = GameObject.FindGameObjectWithTag("Player").transform;

        transform.position += (Vector3)velocity * Time.deltaTime;
        Vector2 player_position = cam.WorldToScreenPoint(player.position);

        Vector3 new_player_positon = cam.ScreenToWorldPoint(
                                                  new Vector3(
                                                    Mathf.Clamp(player_position.x, offset.x, cam.pixelWidth - offset.x),
                                                    Mathf.Clamp(player_position.y, offset.y, cam.pixelHeight - offset.y),
                                                    0));

        new_player_positon.Set(new_player_positon.x, new_player_positon.y, player.position.z);

        player.position = new_player_positon;

    }
}
