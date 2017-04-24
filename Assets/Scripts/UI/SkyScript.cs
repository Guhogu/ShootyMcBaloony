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

    private void Start()
    {

        Camera.main.GetComponent<InfiniteCamera>().SetBounds(Mathf.Abs(sprite.bounds.min.y) + 32);
    }

    // Update is called once per frame

	// Update is called once per frame
	void Update () {
        if (!cam)
            cam = Camera.main;
        transform.localPosition = (Vector3)origin + -transform.parent.position * multiplier;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 10);

        
        

        if(!createdNext)
        { 
            float screen_pos = cam.WorldToScreenPoint(transform.position).x;
            if(screen_pos < 1000)
            {
                Transform newSky = Instantiate(sky, transform.parent).transform;
                newSky.localPosition = (Vector3)origin + sprite.sprite.rect.width * Vector3.right;
                newSky.GetComponent<SkyScript>().origin = newSky.localPosition;
                newSky.GetComponent<SpriteRenderer>().sprite = sprite.sprite;
                createdNext = true;
            }
        }

    }
}
