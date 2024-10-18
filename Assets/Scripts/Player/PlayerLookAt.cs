using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAt : MonoBehaviour
{
    [SerializeField] float radius, rotationSpeed;
    [SerializeField] LayerMask layerMask;
    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, layerMask);
        foreach(var hit in colliders)
        {
            if(hit.GetComponent<EnemyLife>())
            {
                Vector3 dir = (hit.transform.position - transform.position);
                dir.y = 0;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
