using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public GameObject initialPanel; // El panel inicial activo
    public GameObject hiddenPanel; // El panel que se activa al alternar
    public GameObject thirdPanel; // El nuevo panel que se activará al colisionar
    public GameObject cylinder; // El cilindro con el que el jugador colisiona
    public Button toggleButton; // El botón para alternar los paneles

    void Start()
    {
        // Validar referencias
        if (initialPanel == null || hiddenPanel == null || toggleButton == null || cylinder == null || thirdPanel == null)
        {
            Debug.LogError("Faltan referencias en el CanvasController.");
            return;
        }

        // Configuración inicial
        initialPanel.SetActive(true);
        hiddenPanel.SetActive(false);
        thirdPanel.SetActive(false);
        cylinder.SetActive(false); // El cilindro empieza desactivado

        // Asigna la función TogglePanel al botón
        toggleButton.onClick.AddListener(TogglePanel);
    }

    // Alternar entre el panel inicial y oculto
    void TogglePanel()
    {
        bool isInitialPanelActive = initialPanel.activeSelf;
        initialPanel.SetActive(!isInitialPanelActive);
        hiddenPanel.SetActive(isInitialPanelActive);

        if (hiddenPanel.activeSelf)
        {
            cylinder.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == cylinder)
        {
            hiddenPanel.SetActive(false);
            thirdPanel.SetActive(true);
            cylinder.SetActive(false);
        }
    }

}
