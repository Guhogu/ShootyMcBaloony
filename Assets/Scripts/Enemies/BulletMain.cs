using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMain : MonoBehaviour {

    [Header("References")]
    #region References
    [SerializeField]
    private Transform BulletTransfom;
    #endregion

    [Header("Properties")]
    #region Properties
    [SerializeField]
    private float Speed = 20f;
    [SerializeField]
    private float LifeSpan = 5.0f;
    #endregion

    public Vector3 Velocity;

    void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        BulletTransfom.position = BulletTransfom.position + Velocity * Time.deltaTime * Speed;
    }
}
