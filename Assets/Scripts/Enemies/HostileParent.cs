using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileParent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected bool canMove()
    {
        bool can = GameController.hostileCanMove && !GameController.paused ;
        Animator anim = GetComponent<Animator>();
        if (anim)
            anim.speed = can ? 1 : 0;
        return can;
    }
}
