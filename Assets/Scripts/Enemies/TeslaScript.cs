using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaScript : MonoBehaviour {

    [SerializeField]
    bool attacking;
    bool wasAttacking = false;

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!wasAttacking && attacking)
            anim.SetTrigger("Attack");
        wasAttacking = attacking;

    }

    public void Fire()
    { }
}
