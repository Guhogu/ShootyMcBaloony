using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyScript : MonoBehaviour {

    [SerializeField]
    float multiplier;

    [SerializeField]
    Camera cam;

    [SerializeField]
    SpriteRenderer sprite;

    [SerializeField]
    GameObject sky;

    bool createdNext;

    public Vector2 origin;

	// Update is called once per frame
	void Update () {
        transform.localPosition = (Vector3)origin + -transform.parent.position * multiplier;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 10);

        if(!createdNext)
        { 
            float screen_pos = cam.WorldToScreenPoint(transform.position).x;
            if(screen_pos < 100)
            {
                Transform newSky = Instantiate(sky, transform.parent).transform;
                newSky.localPosition = (Vector3)origin + sprite.sprite.rect.width * Vector3.right;
                newSky.GetComponent<SkyScript>().origin = newSky.localPosition;
                createdNext = true;
            }
        }

    }
}
