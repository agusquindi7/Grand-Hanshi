using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlavioFollowState : IState
{
    Animator _anim;
    Rigidbody _enemyRB;
    Transform _target;

    public FlavioFollowState(Animator anim , Rigidbody rigidbody, Transform target)
    {
        _anim = anim;
        _enemyRB = rigidbody;
        _target = target;
    }

    public void Awake()
    {
        _anim.SetBool("isIdle", false);
        Debug.Log("ENTERING FOLLOW STATE");
    }

    public void Execute()
    {
    }

    public void Sleep()
    {
        Debug.Log("EXITING FOLLOW STATE");
    }
}
