using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVidaScr : MonoBehaviour
{
    public Image circulo;

    private PlayerLife playerLife;

    void Start()
    {
        playerLife = FindObjectOfType<PlayerLife>();
        if (playerLife != null)
        {
            ActualizarBarraDeVida(playerLife.life, playerLife.healthSlider.maxValue);
        }
        circulo.fillAmount = 1;
    }

    public void ActualizarBarraDeVida(float nuevaVida, float vidaMaxima)
    {
        float proporcionVida = nuevaVida / vidaMaxima;
        circulo.fillAmount = proporcionVida;
    }
}
