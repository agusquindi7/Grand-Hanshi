using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{ 
    public void SceneLoad(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
    
