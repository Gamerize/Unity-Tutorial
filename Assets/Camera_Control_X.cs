using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control_X : MonoBehaviour
{
    public float m_Sensitivity = 5f;
    public bool m_Inverted = false;

    // Update is called once per frame
    void LateUpdate()
    {
        if(m_Inverted)
        {
            transform.Rotate(Vector3.right, Input.GetAxis("Mouse Y") * m_Sensitivity, Space.Self);
        }
        else
        {
            transform.Rotate(Vector3.right, Input.GetAxis("Mouse Y") * -m_Sensitivity, Space.Self);
        }
    }
}
