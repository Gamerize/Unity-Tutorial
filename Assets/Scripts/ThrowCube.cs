using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCube : MonoBehaviour
{
    [SerializeField] private GameObject m_physCube;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject tempCube = Instantiate<GameObject>(m_physCube, transform.position + (transform.forward *GetComponent<Camera>().nearClipPlane * 2f) + transform.InverseTransformDirection(GetMouseScreenPos()), Quaternion.identity);
            tempCube.GetComponent<Rigidbody>().AddForce((tempCube.transform.position - transform.position).normalized * 20f, ForceMode.Impulse);
            tempCube.GetComponent<Rigidbody>().AddTorque(Random.insideUnitSphere * 500f, ForceMode.Impulse);
        }
    }

    private Vector2 GetMouseScreenPos()
    {
        return new Vector2((Input.mousePosition.x / Screen.width)- 0.5f, (Input.mousePosition.y / Screen.height) - 0.5f);
    }
}
