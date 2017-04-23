using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour {

    public float bullet_per_second;
    public int current_pattern;
    public int bullets_remaining;

    public GameObject bullet_prefab;

    public Transform bullet_origin;
    public Transform bullet_parent;


    float next_bullet_time = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(next_bullet_time >= Time.time)
        { 
		    if(bullets_remaining > 0)
            {
                GameObject bullet = Instantiate(bullet_prefab, bullet_parent);
                bullet.transform.position = bullet_origin.position;
                BulletScript script = bullet.GetComponent<BulletScript>();

                script.velocity = new Vector2(Mathf.Sin(Time.time), Mathf.Cos(Time.time));
                next_bullet_time = Time.time + 1 / bullet_per_second;
            }
        }
    }
}
