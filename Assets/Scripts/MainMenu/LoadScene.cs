using UnityEngine;
using UnityEngine.SceneManagement;
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
    
