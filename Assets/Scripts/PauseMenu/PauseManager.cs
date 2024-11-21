using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static PauseManager instance;
    public Action ArtificialUpdate; //Delegate donde todos los updates suman y se dejan de ejecutar si esta pausado el juego

    public event Action TotalUpdates = delegate { };
    private void Awake()
    {
        ArtificialUpdate = TotalUpdates;
        
        if (instance == null) instance = this; // Asignar esta instancia como la única
            //DontDestroyOnLoad(gameObject); // Opcional: para que persista entre escenas
        else
        {
            Debug.LogWarning("Más de una instancia de MySingleton detectada. Eliminando esta instancia.");
            Destroy(gameObject); // Destruir duplicados
        }
    }
    //SUSCRIBO MI UPDATE
    public void Subscribe(Action callback)
    {
        TotalUpdates += callback;
        ArtificialUpdate = TotalUpdates;
    }
    //DESUSCRIBO MI UPDATE
    public void Unsubscribe(Action callback)
    {
        TotalUpdates -= callback;
        ArtificialUpdate = TotalUpdates;
    }

    private void Update()
    {
        ArtificialUpdate();
    }

    public void Pause(bool active)
    {
        if (active)
        {
            Debug.Log("JUEGO PAUSADO");
            Time.timeScale = 0f;
            //Camera.main.GetComponent<AudioSource>().Pause();
            ArtificialUpdate = delegate { };
        }
        else
        {
            Time.timeScale = 1f;
            //Camera.main.GetComponent<AudioSource>().Play();
            ArtificialUpdate = TotalUpdates;
        }
    }
}
