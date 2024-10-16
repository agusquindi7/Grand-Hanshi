using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlavioIdleState : FSMBaseState
{
    public override void Awake(FSMStateManager fsm)
    {
        Debug.Log("ENTER IDLE STATE");
        fsm.anim.SetBool("isIdle", true);
    }

    public override void Execute(FSMStateManager fsm)
    {
        if(fsm.GetDistance()<fsm.followRadius) //Si la distancia es menor al radio cambio a estado Follow
        {
            fsm.SwitchState(fsm.followState);
        }
    }

    public override void Sleep(FSMStateManager fsm)
    {
        Debug.Log("EXIT IDLE STATE");
    }
}
