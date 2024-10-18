using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlavioAttackState : FSMBaseState
{
    public override void Awake(FSMStateManager fsm)
    {
        Debug.Log("ENTER ATTACK STATE");
    }

    public override void Execute(FSMStateManager fsm)
    {
        if (fsm.GetDistance() > fsm.attackRadius)
        {
            fsm.SwitchState(fsm.followState);
        }
        else
        {
            //Activo el cooldown
            fsm.cooldown = Mathf.Clamp(fsm.cooldown += Time.deltaTime, 0, fsm.maxCD);
            if (fsm.cooldown == fsm.maxCD)
            {
                fsm.cooldown = 0f;
                fsm.anim.SetTrigger("isAttacking");
            }
        }
        //if (fsm.enemyLife.TakeDamage(0f))
        //{
        //    Debug.Log("El enemigo recibio da�o");
        //    fsm.SwitchState(fsm.onHitState);
        //}
    }

    public override void Sleep(FSMStateManager fsm)
    {
        Debug.Log("EXIT ATTACK STATE");
    }
}
