using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadScene : MonoBehaviour
{
    [SerializeField] StaminaSystem staminaSys;
    [SerializeField] GameObject panel;

    public void SceneLoad(string scene)
    {
        Time.timeScale = 1f;
        PauseManager.instance.Pause(false);
        SceneManager.LoadScene(scene);
    }

    public void PlayLoadAsync(string scene)
    {
        if (staminaSys.currentStamina>=3)
        {
            Time.timeScale = 1f;
            SceneManager.LoadSceneAsync(scene);
        }
        else
        {
            panel.SetActive(true);
        }
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



