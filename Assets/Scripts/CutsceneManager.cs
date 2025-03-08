using UnityEngine;
using UnityEngine.Playables;

public class CutsceneManager : MonoBehaviour
{
    public GameObject cutsceneParent;
    public GameObject levelParent;
    public PlayableDirector timeline;

    public void OnCutsceneEnd()
    {
        cutsceneParent.SetActive(false);
        levelParent.SetActive(true);  // Activa el nivel para seguir jugando
    }

    private void Update()
    {
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0)) // Para Mobile y PC
        {
            OnCutsceneEnd();
        }
    }
}
