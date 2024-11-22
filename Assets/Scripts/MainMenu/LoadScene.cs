using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
    [SerializeField] StaminaSystem staminaSys;
    [SerializeField] GameObject panel;

    public void SceneLoad(string scene)
    {
        Time.timeScale = 1f;
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
    
