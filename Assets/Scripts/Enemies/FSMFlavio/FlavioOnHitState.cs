using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlavioOnHitState : FSMBaseState
{
    public override void Awake(FSMStateManager fsm)
    {
        Debug.Log("ENTER ON HIT STATE");
        fsm.anim.SetTrigger("isHit");
        fsm.rigidBody.AddForce((fsm.transform.forward*-1f), ForceMode.Impulse);
    }

    public override void Execute(FSMStateManager fsm)
    {
        //Hago un contador para que espere un poco para recuperarse
        /*fsm.transform.position = Vector3.MoveTowards(fsm.transform.position, fsm.target.position, (fsm.moveSpeed / 100f)*-1f);*/ //Hago que retroceda
        fsm.onHitCD = Mathf.Clamp(fsm.onHitCD += Time.deltaTime, 0, fsm.timeToRecover);
        Debug.Log(fsm.onHitCD);
        if (fsm.onHitCD == fsm.timeToRecover)
        {
            fsm.SwitchState(fsm.idleState);
        }
    }

    public override void Sleep(FSMStateManager fsm)
    {
        Debug.Log("EXIT ON HIT STATE");
    }
}
