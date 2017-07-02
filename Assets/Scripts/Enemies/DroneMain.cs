using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMain : HostileParent
{

    [Header("References")]
    #region References
    [SerializeField]
    private Transform DroneTransform;
    [SerializeField]
    private Transform DroneProjectilesPool;
    private Transform PlayerTransform;
    #endregion

    [Header("Properties")]
    #region Properties
    [SerializeField]
    private float Speed;
    [SerializeField]
    [Range(-20, 20)]
    private int XOffset;
    [SerializeField]
    [Range(40, 80)]
    private int YOffset;
    #endregion

    void Start()
    {
        YOffset = Random.Range(40, 81);
        XOffset = Random.Range(-20, 21);
    }

    void Update()
    {
        if (!canMove())
            return;
        MoveAbovePlayer();
    }

    public void KillDrone()
    {
        // TODO : Explosion
        DroneProjectilesPool.SetParent(null);
        Destroy(DroneProjectilesPool.gameObject, 10.0f);
        Destroy(gameObject);
    }

    void MoveAbovePlayer()
    {
        if (!PlayerTransform)
        {
            GetPlayerReference();
        }
        Vector3 TargetPosition = PlayerTransform.position + Vector3.up * YOffset + Vector3.right * XOffset;
        Vector3 Direction = (TargetPosition - DroneTransform.position);
        // Do not move if close enough to the player
        if(Direction.magnitude < 5.0f)
        {
            return;
        }
        if (Direction.magnitude > 200.0f)
        {
            return;
        }
        Vector3 Velocity = Direction.normalized;
        DroneTransform.position += Velocity * Time.deltaTime * Speed;
        DroneProjectilesPool.position -= Velocity * Time.deltaTime * Speed;
    }

    void GetPlayerReference()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void divedOnto(Collision2D collision) {
        KillDrone();
    }
}
