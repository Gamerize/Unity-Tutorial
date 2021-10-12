using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Firing : MonoBehaviour
{
    public GameObject m_prefab;
    public float m_firingforce = 10f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject tempref = Instantiate<GameObject>(m_prefab, transform.position + (transform.forward * 1.5f), Quaternion.identity);
            Vector3 direction = transform.forward + transform.up;
            tempref.GetComponent<Rigidbody>().AddForce(direction * m_firingforce, ForceMode.Impulse);
        }
    }
}
