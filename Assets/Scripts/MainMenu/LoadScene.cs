using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private Slider loadbar;
    [SerializeField] private GameObject loadPanel;
    [SerializeField] private float cooldownTime = 2.0f; // Tiempo de cooldown en segundos

    void Start()
    {
        loadPanel.SetActive(false);  // Asegúrate de que el panel esté apagado al inicio.
    }

    public void SceneLoad(string scene)
    {
        StartCoroutine(LoadWithCooldown(scene));
    }

    private IEnumerator LoadWithCooldown(string scene)
    {
        Debug.Log("entre a la corrutina LOADCOOLDOWN");
        // Activa el panel primero.
        loadPanel.SetActive(true);
        // Espera el tiempo de cooldown antes de comenzar a cargar la escena.
        Debug.Log("TIMESCALE CAMBIADO A 1");
        Time.timeScale = 1f;
        yield return new WaitForSeconds(cooldownTime);
        Debug.Log("saliendo de la corrutina LoadWithCooldowns");
        StartCoroutine(LoadAsync(scene));
    }

    private IEnumerator LoadAsync(string scene)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene);
        Debug.Log("entre a la corrutina LOADASYNC");
        while (!asyncOperation.isDone)
        {
            Debug.Log(asyncOperation.progress);
            loadbar.value = asyncOperation.progress / 0.9f;
            yield return null;
        }
        loadbar.value = 1f; // Asegúrate de que la barra de carga esté llena al terminar la carga.
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
