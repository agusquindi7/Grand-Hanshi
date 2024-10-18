using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyLife : EntityLife , IDamageable
{
    private void Start()
    {
        life = MyRemoteConfig.Instance.maxEnemyLife;
    }

    public void TakeDamage(float dmg)
    {
        life -= dmg;

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
