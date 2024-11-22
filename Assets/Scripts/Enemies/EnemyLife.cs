using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyLife : EntityLife , IDamageable
{
    [SerializeField] Animator anim;
    private void Start()
    {
        life = MyRemoteConfig.Instance.maxEnemyLife;
    }

    public void TakeDamage(float dmg)
    {
        life -= dmg;

        //Por si no llego
        if(life <30)
        {
            PlayerPrefsSave.instance.CompleteLevel(250, 25);
        }

        if (life < 1)
        {
            SceneManager.LoadScene("AnimatedMenu");
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    //public void OnEnable()
    //{
    //    life = MyRemoteConfig.Instance.maxEnemyLife;
    //}
}
