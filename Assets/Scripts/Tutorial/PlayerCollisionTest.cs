using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerCollisionTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colisión detectada con: " + other.gameObject.name);
    }
}
