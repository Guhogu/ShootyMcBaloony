using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LIGHTNINGScript : MonoBehaviour {

    [SerializeField]
    Vector2 velocity;

    [SerializeField]
    Vector2 inPlaceScale;

    [SerializeField]
    float inPlaceSpeed;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position += (Vector3)velocity * Time.deltaTime;
        if (inPlaceScale.x != 0)
            transform.position += (Vector3)Vector2.right * Mathf.Cos(Time.time / inPlaceScale.x) * inPlaceSpeed * Time.deltaTime;

        if (inPlaceScale.y != 0)
            transform.position += (Vector3)Vector2.down * Mathf.Sin(Time.time / inPlaceScale.y) * inPlaceSpeed * Time.deltaTime;


    }
}
