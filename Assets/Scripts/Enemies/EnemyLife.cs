using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyLife : EntityLife, IDamageable
{
    public AudioClip damageSound;
    public Slider healthSlider;
    public GameObject deathPanel;

    private AudioSource audioSource;

    private void Start()
    {
        life = MyRemoteConfig.Instance.maxEnemyLife;
        audioSource = GetComponent<AudioSource>();
        healthSlider.maxValue = life;
        healthSlider.value = life;
        deathPanel.SetActive(false);
    }

    public void TakeDamage(float dmg)
    {
        life -= dmg;
        healthSlider.value = life;

        PlayDamageSound();

        if (life < 1)
        {
            deathPanel.SetActive(true);
            Destroy(gameObject);
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