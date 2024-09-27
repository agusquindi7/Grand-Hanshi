using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporalPlayerLookAt : MonoBehaviour
{
    public Transform target;
    public float followSpeed;

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * followSpeed);
    }
}
