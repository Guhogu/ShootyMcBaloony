using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletColliderScript : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    Player_Script player;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            player.GetShotSon(collision);
        }
    }

}
