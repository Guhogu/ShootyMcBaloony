using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotate : MonoBehaviour {

    [Header("References")]
    #region References
    [SerializeField]
    private Transform TurretTransform;
    [SerializeField]
    private Transform TurretRotationCenterTransform;
    [SerializeField]
    private Animator TurretAnimator;
    #endregion

    private Transform PlayerTransform;

    void Update()
    {
        PointAtPlayer();
    }

    void PointAtPlayer()
    {
        if (!PlayerTransform)
        {
            GetPlayerReference();
        }
        Vector3 pointing = (PlayerTransform.position - TurretRotationCenterTransform.position).normalized;
        float angle = Vector3.Angle(Vector3.left, pointing);
        TurretAnimator.SetFloat("Angle", angle);
    }

    void GetPlayerReference()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
