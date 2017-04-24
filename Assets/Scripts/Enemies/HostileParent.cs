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
        return GameController.hostileCanMove;
    }
}
