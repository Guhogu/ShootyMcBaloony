using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneFire : MonoBehaviour
{

    [Header("References")]
    #region References
    [SerializeField]
    private Transform DroneGunOutputTransform;
    [SerializeField]
    private Transform[] DroneGunOutputTransforms;
    [SerializeField]
    private Transform DroneProjectilesPoolTransform;
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
            Shoot();
        }
    }

    void Shoot()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject Projectile = Instantiate(BulletPrefab, DroneProjectilesPoolTransform);
            Projectile.transform.position = DroneGunOutputTransforms[i].position;
            Vector3 direction = (DroneGunOutputTransforms[i].position - DroneGunOutputTransform.position).normalized;
            Projectile.GetComponent<BulletMain>().Velocity = direction;
            Projectile.SetActive(true);
        }
    }
}
