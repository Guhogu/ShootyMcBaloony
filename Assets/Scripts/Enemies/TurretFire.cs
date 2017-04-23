using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script used to
/// </summary>
public class TurretFire : MonoBehaviour {

    [Header("References")]
    #region References
    [SerializeField]
    private Transform TurretGunOutputTransform;
    [SerializeField]
    private Transform TEST_CurrentPlayerTransform;
    #endregion

    public void Cmd_Shoot()
    {
        Vector3 targetPosition = TEST_CurrentPlayerTransform.position;

    }

}
