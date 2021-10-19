using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Char_Phys_Float : MonoBehaviour
{
    [Header("Floating")]
    [SerializeField] [Min(0f)] [Tooltip("The length of the ray")] private float m_RayLength;
    [SerializeField] [Min(0f)] private float m_RideHeight;
    [SerializeField] [Min(0f)] private float m_RideSpringStrength;
    [SerializeField] [Min(0f)] private float m_RideSpringDamper;

    [Header("Self-righting")]
    private Quaternion m_UprightJointTargetRot = Quaternion.identity;
    [SerializeField] [Min(0f)] private float m_UprightJointSpringStrength;
    [SerializeField] [Min(0f)] private float m_UprightJointSpringDamper;

    private Rigidbody m_RB;

    private void Awake()
    {
        m_RB = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        RaycastHit outHit;
        if(Physics.Raycast(transform.position, Vector3.down, out outHit, m_RayLength))
        {
            //Float Spring
            Vector3 vel = m_RB.velocity;
            Vector3 rayDir = Vector3.down;
            Vector3 otherVel = Vector3.zero;
            Rigidbody hitBody = outHit.rigidbody;
            if(hitBody != null)
            {
                otherVel = hitBody.velocity;
            }

            float rayDirVel = Vector3.Dot(rayDir, vel);
            float otherDirVel = Vector3.Dot(rayDir, otherVel);

            float relVel = rayDirVel - otherDirVel;

            float x = outHit.distance - m_RideHeight;

            float springForce = (x * m_RideSpringStrength) - (relVel * m_RideSpringDamper);

            Debug.DrawLine(transform.position, transform.position + (rayDir * springForce), Color.yellow);

            m_RB.AddForce(rayDir * springForce, ForceMode.Force);

            if(hitBody != null)
            {
                hitBody.AddForceAtPosition(rayDir * -springForce, outHit.point, ForceMode.Force);
            }
        }

        Quaternion charCurrent = transform.rotation;
        Quaternion toGoal = m_UprightJointTargetRot * Quaternion.Inverse(charCurrent);

        Vector3 rotAxis;
        float rotDegrees;

        toGoal.ToAngleAxis(out rotDegrees, out rotAxis);
        rotAxis.Normalize();

        float rotRadians = rotDegrees * Mathf.Deg2Rad;

        m_RB.AddTorque((rotAxis * (rotRadians * m_UprightJointSpringStrength)) - (m_RB.angularVelocity * m_UprightJointSpringDamper));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color32(255, 0, 0, 150);
        Gizmos.DrawCube(transform.position + (Vector3.down * m_RayLength * 0.5f), new Vector3(0.1f, m_RayLength, 0.1f));
        Gizmos.color = new Color32(255, 120, 20, 150);
        Gizmos.DrawCube(transform.position + (Vector3.down * m_RideHeight), new Vector3(0.2f, 0.05f, 0.2f));
    }
}
