using System;
using System.Collections.Generic;
using UnityEngine;

// Clase genérica StateMachine, donde StateType debe implementar IState
public class StateMachine<StateType> where StateType : IState
{
    // Estado actual de la máquina de estados
    private StateType _currentState;
    // Lista de todos los estados disponibles
    private List<StateType> _states = new List<StateType>();

    // Propiedad que devuelve el tipo del estado actual (la clase del estado)
    public Type currentState
    {
        get { return _currentState.GetType(); }
    }

    // Constructor por defecto, no inicializa con un estado
    public StateMachine() { }

    // Constructor que inicializa con un estado específico
    public StateMachine(StateType initState)
    {
        // Agrega el estado inicial a la lista de estados
        AddState(initState);
    }

    // Método que se llamará cada frame para ejecutar el estado actual
    public void Update()
    {
        // Si hay un estado activo, ejecuta su lógica
        if (_currentState != null) _currentState.Execute();

        // Muestra en la consola el tipo del estado actual
        Debug.Log(currentState);
    }

    // Agrega un nuevo estado a la lista de estados
    public void AddState(StateType newState)
    {
        // Si el estado ya está en la lista, no lo agrega
        if (_states.Contains(newState)) return;

        // Agrega el nuevo estado a la lista
        _states.Add(newState);

        // Si no hay un estado actual, asigna este nuevo como el estado actual
        if (_currentState == null) _currentState = newState;
    }

    // Cambia el estado actual a un estado de tipo T
    public void SetState<T>() where T : StateType
    {
        // Busca el estado cuyo tipo coincide con T
        foreach (var state in _states)
        {
            if (state.GetType() == typeof(T))
            {
                // Llama al método Sleep del estado actual antes de cambiar
                _currentState.Sleep();
                // Cambia al nuevo estado
                _currentState = state;
                // Llama al método Awake del nuevo estado para activarlo
                _currentState.Awake();
            }
        }
    }
}