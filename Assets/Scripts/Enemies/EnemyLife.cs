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
<<<<<<< Updated upstream
            deathPanel.SetActive(true);
            Destroy(gameObject);
=======

            PlayerPrefsSave.instance.CompleteLevel(250, 25);
            //SceneManager.LoadScene("AnimatedMenu");
            //panelVictory.SetActive(true);
            //Destroy(gameObject);
            anim.SetTrigger("isDead");
            fsm.moveSpeed = 0;
            //PauseManager.instance.Pause(true);
            //PauseFlavio();
>>>>>>> Stashed changes
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