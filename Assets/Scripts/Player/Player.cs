using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Controller _controller;

    [SerializeField] MyRemoteConfig myRC;
    //StateMachine<IState> statemachine;
    public void PlayerLateStart()
    {
        _speed = myRC.playerSpeed;

        //statemachine.AddState(new FlavioIdleState());
        //statemachine.AddState(new FlavioIdleState());
        //statemachine.AddState(new FlavioIdleState());
        //statemachine.AddState(new FlavioIdleState());

        //statemachine.SetState<FlavioIdleState>();
    }

    void Update()
    {
        //statemachine.Update();
        transform.position += _controller.GetMovementInput() * _speed * Time.deltaTime; 
    }
}
