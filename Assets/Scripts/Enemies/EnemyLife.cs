using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyLife : EntityLife , IDamageable
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject panelVictory;
    [SerializeField] FSMStateManager fsm;
    private void Start()
    {
        life = MyRemoteConfig.Instance.maxEnemyLife;
    }

    public void TakeDamage(float dmg)
    {
        life -= dmg;


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

    // Start is called before the first frame update
    //public void OnEnable()
    //{
    //    life = MyRemoteConfig.Instance.maxEnemyLife;
    //}
}
