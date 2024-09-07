using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "High Kick" , menuName = "MeleeAttacks")]
public class MeleeAttacks : ScriptableObject , IAttacks
{
    public float dmg, currentCD, maxCD;
    public string triggerName;

    public void EventHBox()
    {

    }

    public void Execute()
    {
        
    }

}
