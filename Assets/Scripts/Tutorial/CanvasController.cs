using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public GameObject initialPanel; // El panel que está activo al inicio
    public GameObject hiddenPanel; // El panel que está desactivado por defecto
    public Button toggleButton; // El botón para alternar los paneles

    void Start()
    {
        // Asegúrate de que el panel inicial esté activo y el otro panel esté desactivado al inicio del nivel
        initialPanel.SetActive(true);
        hiddenPanel.SetActive(false);

        // Asigna la función TogglePanel al evento onClick del botón
        toggleButton.onClick.AddListener(TogglePanel);
    }

    // Función para alternar los paneles
    void TogglePanel()
    {
        // Cambia el estado activo/inactivo de los paneles
        bool isInitialPanelActive = initialPanel.activeSelf;
        initialPanel.SetActive(!isInitialPanelActive);
        hiddenPanel.SetActive(isInitialPanelActive);
    }
}
