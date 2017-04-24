using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PibbitScript : HostileParent {

    bool hopping = true;

    [SerializeField]
    float hoppingSpeed;

    float aiming = 0;

    [SerializeField]
    float aimingTime;

    int currentPoint = 0;

    [SerializeField]
    Transform[] navPoints;

    Transform player;

    [SerializeField]
    Animator anim;

    [SerializeField]
    int fireShots;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    SpriteRenderer sprite_renderer;

    [SerializeField]
    Transform nuzzle_position;

    int currentShot = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!canMove())
            return;

        Vector3 destination ;
        if (hopping)
        {
            if (navPoints != null && navPoints.Length > 0)
            { 
                destination = new Vector3(navPoints[currentPoint].position.x, transform.position.y);

                sprite_renderer.flipX = destination.x > transform.position.x;

                if ((destination - transform.position).magnitude < 1)
                {
                    hopping = false;
                    PointAtPlayer();
                    aiming = aimingTime;
                    currentShot = 0;
                    sprite_renderer.flipX = false;
                }

                transform.position += hoppingSpeed * (destination - transform.position).normalized * Time.deltaTime;
            }
        }
        else
        {
            aiming -= Time.deltaTime;
            if (aiming < 0)
            {
                aiming = 0;
                hopping = true;
                currentPoint = (currentPoint + 1) % navPoints.Length;   
            }

            if ( (aimingTime - aiming) / aimingTime >= (currentShot + 1f) / fireShots)
            {
                Shoot();
                ++currentShot;
            }

            PointAtPlayer();
        }
        anim.SetBool("Aiming", aiming > 0);
        
	}

    void Shoot()
    {
        GameObject Projectile = Instantiate(bullet);
        Projectile.transform.position = nuzzle_position.position;
        Projectile.GetComponent<BulletMain>().Velocity = -nuzzle_position.right;
        Projectile.SetActive(true);
    }

    void PointAtPlayer()
    {
        if (!player)
        {
            GetPlayerReference();
        }
        Vector3 pointing = (player.position - transform.position).normalized;
        if (pointing.y < 0)
        {
            int direction = pointing.x > 0 ? 1 : 0;
            anim.SetFloat("Angle", 180 * direction);
        }
        else
        {

            float angle = Vector3.Angle(Vector3.left, pointing);
            anim.SetFloat("Angle", GetAnimationAngle(angle));
        }
    }

    int GetAnimationAngle(float angle)
    {
        if (angle < 22.5)
        {
            return 0;
        }
        if (angle < 67.5)
        {
            return 45;
        }
        if (angle < 90)
        {
            return 85;
        }
        if (angle < 112.5)
        {
            return 95;
        }
        if (angle < 157.5)
        {
            return 135;
        }
        return 180;
    }

    void GetPlayerReference()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

}
