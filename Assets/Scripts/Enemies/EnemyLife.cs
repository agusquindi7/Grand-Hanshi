using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyLife : EntityLife, IDamageable
{
    public AudioClip damageSound;
    public Slider healthSlider;

    private AudioSource audioSource;

    private void Start()
    {
        life = MyRemoteConfig.Instance.maxEnemyLife;
        audioSource = GetComponent<AudioSource>();
        healthSlider.maxValue = life;
        healthSlider.value = life;
    }

    public void TakeDamage(float dmg)
    {
        life -= dmg;
        healthSlider.value = life;

        PlayDamageSound();

        if (life < 1)
        {
            SceneManager.LoadScene("AnimatedMenu");
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


    // Start is called before the first frame update
    //public void OnEnable()
    //{
    //    life = MyRemoteConfig.Instance.maxEnemyLife;
    //}
}


