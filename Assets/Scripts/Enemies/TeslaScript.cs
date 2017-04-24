using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaScript : MonoBehaviour {

    [SerializeField]
    float firingTime;

    [SerializeField]
    float firing = 0;

    [SerializeField]
    float cooldownTime;

    float angle;
    float angleGoal;

    [SerializeField]
    Animator anim;

    [SerializeField]
    GameObject laser_prefab;

    [SerializeField]
    Transform laser_position;

    Transform player;
    Transform laser;


	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (!player)
            player = GameObject.FindGameObjectWithTag("Player").transform;



        firing -= Time.deltaTime;

        if (firing < 0 && laser)
            Destroy(laser.gameObject);

        if (firing <= -cooldownTime)
        {
            firing = firingTime;
            angle = 90;
            angleGoal = (player.position.x > transform.position.x) ? 20 : 160;
            laser = Instantiate(laser_prefab, transform).transform;
            laser.rotation = Quaternion.Euler(0, 0, angle);
            laser.localPosition = laser_position.localPosition;
        }
        else if (laser)
        {
            float cur_angle = Mathf.Lerp(angle, angleGoal, (firingTime - firing) / firingTime);
            laser.localRotation = Quaternion.Euler(0, 0, cur_angle);
        }
        anim.SetBool("Firing", firing > 0 || firing < -cooldownTime + 0.4);
    }

    public void Fire()
    {
        
    }
}
