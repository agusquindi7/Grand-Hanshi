using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorManager : MonoBehaviour , IDamageable
{
    public Animator animator;

    public void TakeDamage(float dmg)
    {
        animator.SetTrigger("isHit");
        Debug.Log("You hit " + gameObject.name + " for " + dmg + " damage");
    }

    void Awake()
    {
        if (animator == null) animator = this.GetComponent<Animator>();
    }
    

}
