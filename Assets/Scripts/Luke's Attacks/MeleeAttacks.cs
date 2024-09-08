using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "High Kick" , menuName = "MeleeAttacks")]
public class MeleeAttacks : ScriptableObject , IAttacks
{
    public float dmg, currentCD, maxCD;
    public string triggerName;
    public LayerMask layerMask;

    public void EventHBox()
    {

    }

    public void Execute(Vector3 pos, float radius)
    {
        Collider[] colliders = Physics.OverlapSphere(pos, radius, layerMask);
        //Debug.Log(colliders[0].name);
        //OnHitDEMO myOH = colliders[0].GetComponent<OnHitDEMO>();
        //myOH.OnHitEnemy(dmg);
    }

}
