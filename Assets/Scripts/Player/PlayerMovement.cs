using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _speed = 4f;
    [SerializeField] Controller _controller;

    public void Start()
    {
        //_speed = MyRemoteConfig.Instance.playerSpeed;

        PauseManager.instance.Subscribe(ArtificialUpdate);
    }

    void ArtificialUpdate()
    {
        transform.position += _controller.GetMovementInput() * _speed * Time.deltaTime;
    }

    private void OnDestroy()
    {
        PauseManager.instance.Unsubscribe(ArtificialUpdate);
    }
}
