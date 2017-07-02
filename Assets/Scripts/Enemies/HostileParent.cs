using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HostileParent : MovingEntity {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected new bool canMove()
    {
        bool can = GameController.hostileCanMove && base.canMove();
        Animator anim = GetComponent<Animator>();
        if (anim)
            anim.speed = can ? 1 : 0;
        return can;
    }
}
