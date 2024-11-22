using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadScene : MonoBehaviour
{ 
    public void SceneLoad(string scene)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

/*public class LoadScene : MonoBehaviour
{
    public void SceneLoad(string scene)
    {
        StartCoroutine(DelayedLoad(scene, 0.5f));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator DelayedLoad(string scene, float delay)
    {
        // Esperar por el tiempo especificado
        yield return new WaitForSeconds(delay);

        // Reiniciar el tiempo del juego a la velocidad normal
        Time.timeScale = 1f;

        // Cargar la nueva escena
        SceneManager.LoadScene(scene);
    }
}*/

//Habia echo esto para retrasar la recarga de la escena y que se escuche el sonido del boton pero rompia el volver al menu de la pausa dentro del nivel 1



