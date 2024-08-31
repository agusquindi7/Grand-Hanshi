using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Controller _controller;


    void Update()
    {
        transform.position += _controller.GetMovementInput() * _speed * Time.deltaTime; 
    }
}
