using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotate : MonoBehaviour
{

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
        if (pointing.y < 0)
        {
            int direction = pointing.x > 0 ? 1 : 0;
            TurretAnimator.SetFloat("Angle", 180 * direction);
        }
        else
        {

            float angle = Vector3.Angle(Vector3.left, pointing);
            TurretAnimator.SetFloat("Angle", GetAnimationAngle(angle));
        }
    }

    int GetAnimationAngle(float angle)
    {
        if (angle < 22.5)
        {
            return 0;
        }
        if (angle < 67.5)
        {
            return 45;
        }
        if (angle < 90)
        {
            return 85;
        }
        if (angle < 112.5)
        {
            return 95;
        }
        if (angle < 157.5)
        {
            return 135;
        }
        return 180;
    }

    void GetPlayerReference()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
