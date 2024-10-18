using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitDEMO : MonoBehaviour
{
    public Animator anim;
    public float life;

    private void Awake()
    {
        if (anim == null) anim = this.GetComponent<Animator>();
    }

    public void OnHitEnemy(float dmg)
    {
        anim.SetTrigger("isHit");
        life -= dmg;
    }

    private void Update()
    {
        //Temporalmente se destruye pero tendriamos que poner una animacion de como que se sienta, no que se muera porque no queremos matarlo
        if (life < 1) Destroy(gameObject);
    }
}
