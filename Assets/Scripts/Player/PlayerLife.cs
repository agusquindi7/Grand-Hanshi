using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] float life;
    [SerializeField] float maxLife;

    [SerializeField] MyRemoteConfig myRC;
    public void LateStart()
    {
        life = myRC.playerLife;
    }

    public void TakeDamage(float dmg)
    {
        life -= dmg;
        if (life <= 0) SceneManager.LoadScene("AnimatedMenu");
    }
}
