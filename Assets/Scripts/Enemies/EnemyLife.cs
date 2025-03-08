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
    public GameObject deathPanel;
    public bool isDead = false;

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
            PlayerPrefsSave.instance.CompleteLevel(250, 25);
            PlayerPrefsSave.instance.SaveGame();
            //SceneManager.LoadScene("AnimatedMenu");
            //panelVictory.SetActive(true);
            //Destroy(gameObject);
            anim.SetTrigger("isDead");
            
            fsm.moveSpeed = 0;
            //PauseManager.instance.Pause(true);
        }
    }

    private void Update()
    {
        if (life <= 0) isDead = true;
        else isDead = false;
    }

    public void PauseFlavio()
    {
        if (gameObject.name == "Dimples")
        {
            //PauseManager.instance.Pause(true);
            panelVictory.SetActive(true);
        }
        else
        {
            PauseManager.instance.Pause(true);
            panelVictory.SetActive(true);
        }
    }

    // Start is called before the first frame update
    //public void OnEnable()
    //{
    //    life = MyRemoteConfig.Instance.maxEnemyLife;
    //}
//    }
//            deathPanel.SetActive(true);
//            Destroy(gameObject);
//        }
//    }

    private void PlayDamageSound()
    {
        if (audioSource != null && damageSound != null)
        {
            audioSource.PlayOneShot(damageSound);
        }
    }

    //public void Death()
    //{
    //    gameObject.GetComponent<Rigidbody>().useGravity = false;
    //    gameObject.GetComponent<Collider>().enabled = false;
    //}
}
