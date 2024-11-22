using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyLife : EntityLife, IDamageable
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject panelVictory;
    [SerializeField] FSMStateManager fsm;
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

            PlayerPrefsSave.instance.CompleteLevel(250, 25);
            //SceneManager.LoadScene("AnimatedMenu");
            //panelVictory.SetActive(true);
            //Destroy(gameObject);
            anim.SetTrigger("isDead");
            fsm.moveSpeed = 0;
            //PauseManager.instance.Pause(true);
        }
    }

    public void PauseFlavio()
    {
        PauseManager.instance.Pause(true);
        panelVictory.SetActive(true);
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


