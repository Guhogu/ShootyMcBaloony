using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour {

    Player_Script player;
    public int toWorld;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player && Input.GetButtonDown("Dive"))
        {

            player.TakePortal(toWorld);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") || collision.gameObject.transform.parent.CompareTag("Player"))
        {

            player = collision.gameObject.GetComponentInParent<Player_Script>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.transform.parent.CompareTag("Player"))
        {
            player = null;
        }
    }
}
