using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMBaseState
{
    public abstract void Awake(FSMStateManager fsm);

    public abstract void Execute(FSMStateManager fsm);

    public abstract void Sleep(FSMStateManager fsm);
}
