using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control_Y : MonoBehaviour
{
    public float m_Sensitivity = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * m_Sensitivity, Space.World);
    }
}
