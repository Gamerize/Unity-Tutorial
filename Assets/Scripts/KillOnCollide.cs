using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnCollide : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(Countdown(1f));
    }

    private IEnumerator Countdown(float life)
    {
        yield return new WaitForSeconds(life);
        Destroy(gameObject);
    }
}
