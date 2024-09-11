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
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                Debug.Log(colliders[i].name);
                IDamageable[] damageable = colliders[i].GetComponents<IDamageable>();
                foreach (IDamageable damageableEntity in damageable)
                {
                    damageableEntity.TakeDamage(dmg);
                }
            }
            //myOH.OnHitEnemy(dmg);
        }
    }

}
