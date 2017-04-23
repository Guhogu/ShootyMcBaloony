using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyScript : MonoBehaviour {

    public float multiplier;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = -transform.parent.position * multiplier;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 10);
	}
}
