using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float m_lifespan = 5f;

    // Update is called once per frame
    void Update()
    {
        m_lifespan -= Time.deltaTime;
        if(m_lifespan < 0f)
        {
            Destroy(gameObject);
        }
    }
}
