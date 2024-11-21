using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    bool isON;
    public GameObject panel;
    public void TurnOn()
    {
        isON = !isON;
        PauseManager.instance.Pause(isON);
        panel.SetActive(isON);
    }

    //private void Update()
    //{
    //    panel.SetActive(isON);
    //}
}
