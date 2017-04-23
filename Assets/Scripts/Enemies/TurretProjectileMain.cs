using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectileMain : MonoBehaviour {

    [Header("References")]
    #region References
    [SerializeField]
    private Transform ProjectileTransfom;
    #endregion

    [Header("Properties")]
    #region Properties
    [SerializeField]
    private float Speed = 0.1f;
    [SerializeField]
    private float LifeSpan = 5.0f;
    #endregion

    private float ExpireTime;
    public Vector3 Velocity;

    void Start()
    {
        ExpireTime = Time.time + LifeSpan;
        StartCoroutine(CheckForExpiry());
    }

    void Update()
    {
        MoveProjectile();
    }

    void OnDestroy()
    {
        StopAllCoroutines();
    }

    void MoveProjectile()
    {
        ProjectileTransfom.position = ProjectileTransfom.position + Velocity * Time.deltaTime;
    }

    IEnumerator CheckForExpiry()
    {
        while (true)
        {
            if (Time.time > ExpireTime)
            {
                Destroy(gameObject);
            }
            yield return new WaitForSeconds(1.0f);
        }
    }

}
