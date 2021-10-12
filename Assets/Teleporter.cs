using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public bool m_Active = true;
    public Teleporter m_Destination;

    private void OnTriggerEnter(Collider other)
    {
        if(m_Active && other.tag == "Player")
        {
            m_Destination.m_Active = false;
            other.transform.position = m_Destination.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "player")
        {
            m_Active = true;
        }
    }
}
