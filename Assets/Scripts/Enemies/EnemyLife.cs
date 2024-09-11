using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : EntityLife , IDamageable
{
    public void TakeDamage(float dmg)
    {
        life -= dmg;
    }

    // Start is called before the first frame update
    void Start()
    {
        life = maxLife;
    }

    private void Update()
    {
        if (life < 1) Destroy(gameObject);
    }
}
