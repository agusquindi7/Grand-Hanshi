using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour , IDamageable
{
    [SerializeField] float life;

    public void Start()
    {
        life = MyRemoteConfig.Instance.playerLife;
    }

    public void TakeDamage(float dmg)
    {
        life -= dmg;

        if(life<=0)
        {
            SceneManager.LoadScene("AnimatedMenu");
        }
    }
}
