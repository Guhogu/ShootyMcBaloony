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

    Rigidbody2D player_rb;


    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void LateUpdate () {

        if (!GameController.hostileCanMove)
            return;
        if (!player)
            player = GameObject.FindGameObjectWithTag("Player").transform;
        if (!player_rb)
            player_rb = player.GetComponent<Player_Script>().rb;
        transform.position += (Vector3)velocity * Time.deltaTime;
        Vector2 player_position = cam.WorldToScreenPoint(player.position);


        //if (player_position.x <= offset.x || player_position.x >= cam.pixelWidth - offset.x)
        //{
        //    player_rb.velocity = new Vector2(0, player_rb.velocity.y);
        //}
        //if (player_position.y <= offset.y || player_position.y >= cam.pixelWidth - offset.y)
        //{
        //    player_rb.velocity = new Vector2(player_rb.velocity.x , 0);
        //}


        Vector3 new_player_positon = cam.ScreenToWorldPoint(
                                                  new Vector3(
                                                    Mathf.Clamp(player_position.x, offset.x, cam.pixelWidth - offset.x),
                                                    Mathf.Clamp(player_position.y, offset.y, cam.pixelHeight - offset.y),
                                                    0));

        new_player_positon.Set(new_player_positon.x, new_player_positon.y, player.position.z);


        player.position = new_player_positon;

    }

    public void SetBounds(float y)
    {
        offset = new Vector2(offset.x, y);
    }
}
