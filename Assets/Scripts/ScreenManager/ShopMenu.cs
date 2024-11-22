using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    public Canvas targetCanvas;

    private void Start()
    {
        targetCanvas.gameObject.SetActive(false); //al inicio del menu me aseguro de apagar el canvas
    }

    public void OnPointerDown()
    {
        if (targetCanvas)
        {
            targetCanvas.gameObject.SetActive(true);
            Debug.Log("Canvas activado");
        }
        else if (!targetCanvas)
        {
            targetCanvas.gameObject.SetActive(false);
            Debug.Log("Canvas desactivado");
        }
    }
}
