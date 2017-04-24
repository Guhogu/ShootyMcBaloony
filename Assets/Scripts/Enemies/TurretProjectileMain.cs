using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectileMain : MonoBehaviour
{

    [Header("References")]
    #region References
    [SerializeField]
    private Transform ProjectileTransfom;
    [SerializeField]
    private SpriteRenderer ProjectileRenderer;
    #endregion

    [Header("Prefabs")]
    #region Prefabs
    [SerializeField]
    private GameObject BulletPrefab;
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
        ExpireTime = Time.time + LifeSpan + Random.Range(-0.5f,0.5f);
        StartCoroutine(CheckForExpiry());
        StartCoroutine(SetHigherLayerAfterSeconds());
    }

    void Update()
    {
        MoveProjectile();
    }

    void MoveProjectile()
    {
        ProjectileTransfom.position = ProjectileTransfom.position + Velocity * Time.deltaTime * Speed;
    }

    void ExplodeProjectile()
    {
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (!(i == j && j == 0))
                {
                    GameObject Bullet = Instantiate(BulletPrefab, ProjectileTransfom.parent);
                    Bullet.transform.position = ProjectileTransfom.position;
                    Bullet.GetComponent<BulletMain>().Velocity = new Vector3(i, j).normalized;
                    Bullet.SetActive(true);
                }
            }
        }
        Destroy(gameObject);
    }

    IEnumerator CheckForExpiry()
    {
        while (true)
        {
            if (Time.time > ExpireTime)
            {
                ExplodeProjectile();
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator SetHigherLayerAfterSeconds()
    {
        yield return new WaitForSeconds(1.0f);
        ProjectileRenderer.sortingOrder = 140;
    }

}
