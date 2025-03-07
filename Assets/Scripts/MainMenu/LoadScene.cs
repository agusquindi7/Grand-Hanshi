using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private Slider loadbar;
    [SerializeField] private GameObject loadPanel;
    [SerializeField] private float cooldownTime = 1.0f; // Tiempo de cooldown en segundos

    void Start()
    {
<<<<<<< Updated upstream
        loadPanel.SetActive(false);  // Aseg˙rate de que el panel estÈ apagado al inicio.
=======
        loadPanel.SetActive(false);  // Aseg√∫rate de que el panel est√© apagado al inicio.
>>>>>>> Stashed changes
    }

    public void SceneLoad(string scene)
    {
        if (staminaSys.HasEnoughStamina(3))
        {
            StartCoroutine(LoadWithCooldown(scene));
        }
        else
        {
            panel.SetActive(true);
        }
    }

    private IEnumerator LoadWithCooldown(string scene)
    {
        Debug.Log("entre a la corrutina LOADCOOLDOWN");
        Debug.Log($"loadPanel: {loadPanel}, PauseManager: {PauseManager.instance}, staminaSys: {staminaSys}");

        if (loadPanel != null)
        {
            loadPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("loadPanel no est√° asignado");
        }

        Debug.Log("TIMESCALE CAMBIADO A 1");
        Time.timeScale = 1f;
<<<<<<< Updated upstream
=======

        if (PauseManager.instance != null)
        {
            PauseManager.instance.Pause(false);
        }
        else
        {
            Debug.LogError("PauseManager.instance no est√° asignado");
        }

        if (staminaSys != null)
        {
            staminaSys.UseStamina(3); // Reduce la estamina
        }
        else
        {
            Debug.LogError("staminaSys no est√° asignado");
        }

>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        loadbar.value = 1f; // Aseg˙rate de que la barra de carga estÈ llena al terminar la carga.
=======
        loadbar.value = 1f; // Aseg√∫rate de que la barra de carga est√© llena al terminar la carga.
>>>>>>> Stashed changes
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
