using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Controller _controller;

    public void Start()
    {
        _speed = MyRemoteConfig.Instance.playerSpeed;
    }

    void Update()
    {
        transform.position += _controller.GetMovementInput() * _speed * Time.deltaTime; 
    }
}
