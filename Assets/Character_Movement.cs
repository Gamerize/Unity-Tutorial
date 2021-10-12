using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{
    public float m_MoveSpeed = 5f;

    private Rigidbody m_RB;

    // Start is called before the first frame update
    void Start()
    {
        m_RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            //transform.Translate(0f, 0f,Time.deltaTime * m_MoveSpeed);
            m_RB.AddForce(transform.forward * m_MoveSpeed, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //transform.Translate(0f, 0f, Time.deltaTime * -m_MoveSpeed);
            m_RB.AddForce(-transform.forward * m_MoveSpeed, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //transform.Translate(Time.deltaTime * m_MoveSpeed, 0f, 0f);
            m_RB.AddForce(transform.right * m_MoveSpeed, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //transform.Translate(Time.deltaTime * -m_MoveSpeed, 0f, 0f);
            m_RB.AddForce(-transform.right * m_MoveSpeed, ForceMode.Force);
        }
    }
}
