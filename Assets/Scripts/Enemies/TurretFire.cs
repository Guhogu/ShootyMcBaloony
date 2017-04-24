﻿using System.Collections;
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
        Projectile.GetComponent<TurretProjectileMain>().Velocity = (PlayerTransform.position - TurretGunOutputTransform.position).normalized;
        Projectile.SetActive(true);
    }

    void GetPlayerReference()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
