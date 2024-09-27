using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlavioIdleState : IState
{
    Animator _anim;

    public FlavioIdleState(Animator anim)
    {
        _anim = anim;
    }

    public void Awake()
    {
        _anim.SetBool("isIdle",true);
        Debug.Log("ENTERING IDLE STATE");
    }

    public void Execute()
    {
        throw new System.NotImplementedException();
    }

    public void Sleep()
    {
        Debug.Log("EXITING IDLE STATE");
    }
}
