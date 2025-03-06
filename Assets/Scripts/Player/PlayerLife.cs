using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour, IDamageable
{
    public float life;
    public AudioClip damageSound;
    public Slider healthSlider;
    public BarraDeVidaScr barraDeVida;

    private AudioSource audioSource;

    public void Start()
    {
        life = MyRemoteConfig.Instance.playerLife;
        audioSource = GetComponent<AudioSource>();
        healthSlider.maxValue = life;
        healthSlider.value = life;

        barraDeVida = FindObjectOfType<BarraDeVidaScr>();
    }

    public void TakeDamage(float dmg)
    {
        life -= dmg;
        life = Mathf.Clamp(life, 0, healthSlider.maxValue);
        healthSlider.value = life;

        if (barraDeVida != null)
        {
            barraDeVida.ActualizarBarraDeVida(life, healthSlider.maxValue);
        }

        PlayDamageSound();

        if (life <= 0)
        {
            SceneManager.LoadScene("AnimatedMenu");
        }
    }

    private void PlayDamageSound()
    {
        if (audioSource != null && damageSound != null)
        {
            audioSource.PlayOneShot(damageSound);
        }
    }
}
