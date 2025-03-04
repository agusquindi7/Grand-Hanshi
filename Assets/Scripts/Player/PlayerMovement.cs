using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _speed = 4f;
    [SerializeField] Controller _controller;

    public void Start()
    {
        PauseManager.instance.Subscribe(ArtificialUpdate);
    }

    void ArtificialUpdate()
    {
        Vector3 movementInput = _controller.GetMovementInput();

        // Ajustar la dirección de movimiento según la rotación del jugador
        movementInput = transform.TransformDirection(movementInput);

        transform.position += movementInput * _speed * Time.deltaTime;
    }

    private void OnDestroy()
    {
        PauseManager.instance.Unsubscribe(ArtificialUpdate);
    }
    //Vercion Funcinal del script
}
