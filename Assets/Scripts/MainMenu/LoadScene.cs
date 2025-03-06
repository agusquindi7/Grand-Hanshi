using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    [SerializeField] StaminaSystem staminaSys;
    [SerializeField] GameObject panel;
    [SerializeField] private Slider loadbar;
    [SerializeField] private GameObject loadPanel;
    [SerializeField] private float cooldownTime = 2.0f; // Tiempo de cooldown en segundos

    void Start()
    {
        loadPanel.SetActive(false);  // Aseg�rate de que el panel est� apagado al inicio.
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
        PauseManager.instance.Pause(false);
        SceneManager.LoadScene(scene);
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
        loadbar.value = 1f; // Aseg�rate de que la barra de carga est� llena al terminar la carga.
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
