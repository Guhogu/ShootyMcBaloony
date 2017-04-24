using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script used to
/// </summary>
public class TurretFire : MonoBehaviour
{

    [Header("References")]
    #region References
    [SerializeField]
    private Transform TurretGunOutputTransform;
    [SerializeField]
    private Transform TurretProjectilesPoolTransform;
    [SerializeField]
    private Animator TurretAnimator;
    #endregion

    [Header("Prefabs")]
    #region Prefabs
    [SerializeField]
    private GameObject TurretProjectilePrefab;
    #endregion

    [Header("Properties")]
    #region Properties
    [SerializeField]
    [Tooltip("Idle time between shots")]
    private float FireRate;
    #endregion

    private Transform PlayerTransform;

    void Start()
    {
        StartCoroutine(ShootLoop());
    }

    IEnumerator ShootLoop()
    {
        while (true)
        {
            ShootAtPlayer();
            yield return new WaitForSeconds(FireRate);
        }
    }

    void ShootAtPlayer()
    {
        if (!PlayerTransform)
        {
            GetPlayerReference();
        }
        GameObject Projectile = Instantiate(TurretProjectilePrefab, TurretProjectilesPoolTransform);
        Projectile.transform.position = TurretGunOutputTransform.position;
        float angle = TurretAnimator.GetFloat("Angle") * Mathf.PI / 180;
        Projectile.GetComponent<TurretProjectileMain>().Velocity = new Vector2(-Mathf.Cos(angle), Mathf.Sin(angle));
        Projectile.SetActive(true);
    }

    void GetPlayerReference()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
