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
    [SerializeField] private float cooldownTime = 2.0f;

    void Start()
    {
        loadPanel.SetActive(false);
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
        loadPanel.SetActive(true);
        Debug.Log("TIMESCALE CAMBIADO A 1");
        Time.timeScale = 1f;
        PauseManager.instance.Pause(false);
        staminaSys.UseStamina(3);
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
