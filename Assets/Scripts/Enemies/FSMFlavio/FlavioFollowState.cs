using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlavioFollowState : FSMBaseState
{
    public override void Awake(FSMStateManager fsm)
    {
        Debug.Log("ENTER FOLLOW STATE");
        fsm.anim.SetBool("isIdle", false);
    }

    public override void Execute(FSMStateManager fsm)
    {
        if (fsm.GetDistance() > fsm.followRadius)
        {
            fsm.SwitchState(fsm.idleState);
        }
        else 
        {
            //Si entro en rango de seguir entonces miro a Luke
            Vector3 dir = (fsm.target.position - fsm.transform.position);
            dir.y = 0;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            fsm.transform.rotation = Quaternion.Slerp(fsm.transform.rotation,lookRotation,Time.deltaTime*fsm.rotationSpeed);
            //y tambien lo sigo si esta en mi rango de seguir
            fsm.transform.position = Vector3.MoveTowards(fsm.transform.position,fsm.target.position,fsm.moveSpeed/100f);
        }
        if(fsm.GetDistance() < fsm.attackRadius)
        {
            fsm.SwitchState(fsm.attackState);
        }

        //if (fsm.enemyLife.TakeDamage(0f))
        //{
        //    Debug.Log("El enemigo recibio daño");
        //    fsm.SwitchState(fsm.onHitState);
        //}
    }

    public override void Sleep(FSMStateManager fsm)
    {
        Debug.Log("EXIT FOLLOW STATE");
    }
}
