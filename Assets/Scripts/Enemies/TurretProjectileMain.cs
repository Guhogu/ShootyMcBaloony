using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectileMain : HostileParent
{

    [Header("References")]
    #region References
    [SerializeField]
    private Transform ProjectileTransfom;
    [SerializeField]
    private SpriteRenderer ProjectileRenderer;
    [SerializeField]
    private SpriteRenderer ProjectileSpriteRenderer;
    #endregion

    [Header("Prefabs")]
    #region Prefabs
    [SerializeField]
    private GameObject BulletPrefab;
    #endregion

    [Header("Properties")]
    #region Properties
    [SerializeField]
    private float Speed = 20.0f;
    [SerializeField]
    [Range(0.0f, 30.0f)]
    private float SpeedOffset = 0.0f;
    [SerializeField]
    private float LifeSpan = 2.0f;
    #endregion

    private float ExpireTime;
    public Vector3 Velocity;

    void Start()
    {
        ExpireTime = Time.time + LifeSpan;
        SpeedOffset = Random.Range(0.0f, 30.0f);
        StartCoroutine(CheckForExpiry());
        StartCoroutine(SetHigherLayerAfterSeconds());
        StartCoroutine(FlashBeforeExpiry());
    }

    void Update()
    {
        if (!canMove())
        {
            ProjectileRenderer.GetComponent<Animator>().speed = 0;
            return;

        }
        MoveProjectile();
    }

    void MoveProjectile()
    {
        ProjectileTransfom.position = ProjectileTransfom.position + Velocity * Time.deltaTime * (Speed + SpeedOffset);
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

    IEnumerator FlashBeforeExpiry()
    {
        bool latch = false;
        while (true)
        {
            if (Time.time > ExpireTime - 0.5f)
            {
                if (latch)
                {
                    ProjectileSpriteRenderer.color = Color.white;
                    latch = false;
                }
                else
                {
                    ProjectileSpriteRenderer.color = Color.gray;
                    latch = true;
                }
            }
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator SetHigherLayerAfterSeconds()
    {
        yield return new WaitForSeconds(1.0f);
        ProjectileRenderer.sortingOrder = 140;
    }

}
