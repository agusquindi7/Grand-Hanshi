using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxTrainingLife : EntityLife, IDamageable
{
    public AudioClip damageSound;
    public Slider healthSlider;
    public GameObject endTuto;
    public GameObject otherPanel;

    private AudioSource audioSource;

    private void Start()
    {
        life = MyRemoteConfig.Instance.maxEnemyLife;
        audioSource = GetComponent<AudioSource>();
        healthSlider.maxValue = life;
        healthSlider.value = life;

        if (endTuto != null) endTuto.SetActive(false);
    }

    public void TakeDamage(float dmg)
    {
        life -= dmg;
        healthSlider.value = life;

        PlayDamageSound();

        if (life <= 0)
        {
            life = 0;
            if (endTuto != null) endTuto.SetActive(true);
            if (otherPanel != null) otherPanel.SetActive(false);
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
