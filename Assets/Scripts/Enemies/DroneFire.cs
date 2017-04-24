using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneFire : MonoBehaviour
{

    [Header("References")]
    #region References
    [SerializeField]
    private Transform[] DroneGunOutputTransforms;
    [SerializeField]
    private Transform DroneProjectilesPoolTransform;
    [SerializeField]
    private Animator DroneAnimator;
    #endregion

    [Header("Prefabs")]
    #region Prefabs
    [SerializeField]
    private GameObject BulletPrefab;
    #endregion

    [Header("Properties")]
    #region Properties
    [SerializeField]
    [Tooltip("Idle time between shots")]
    private float FireRate;
    #endregion

    void Start()
    {
        StartCoroutine(ShootLoop());
    }

    IEnumerator ShootLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(FireRate);
            DroneAnimator.SetTrigger("Reload");
            Shoot();
        }
    }

    void Shoot()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject Projectile = Instantiate(BulletPrefab, DroneProjectilesPoolTransform);
            Projectile.transform.position = DroneGunOutputTransforms[i].position;
            Projectile.GetComponent<BulletMain>().Velocity = DroneGunOutputTransforms[i].right;
            Projectile.SetActive(true);
        }
    }
}
