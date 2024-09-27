using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporalEnemyBehaviour : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Rigidbody enemyRB;
    [SerializeField] float speed;
    [SerializeField] Animator animator;
    [SerializeField] float dmg = 3f;
    [SerializeField] float attackRange = 0.5f;
    [SerializeField] float followRange = 5f;

    private float cooldownDuration = 2f;
    private float cooldownTimer = 0f;

    //Unity Remote Config
    [SerializeField] MyRemoteConfig myRC;
    public void LateStart()
    {
        if (animator == null) animator = GetComponent<Animator>();
        if (enemyRB == null) enemyRB = GetComponent<Rigidbody>();
        cooldownTimer = 0f;

        speed = myRC.enemySpeed;
    }

    void Update()
    {
        // Actualiza el cooldown
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        // LookAt el jugador
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }

        // Follow
        if (target != null)
        {
            animator.SetBool("isIdle", false);
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance > attackRange && distance < followRange) // Solo se mueve si está fuera del rango de ataque y dentro del rango de seguimiento
            {
                Vector3 newPosition = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                transform.position = newPosition;
            }
        }

        // Ataca si está dentro del rango de ataque y el cooldown ha terminado
        if (Vector3.Distance(transform.position, target.position) < attackRange && cooldownTimer <= 0)
        {
            TemporalAttack();
        }
    }

    public void TemporalAttack()
    {
        cooldownTimer = cooldownDuration; // Reinicia el cooldown
        animator.SetTrigger("isAttacking");
        Collider[] colliders = Physics.OverlapSphere(transform.position, 3f);
        for (int i = 0; i < colliders.Length; i++)
        {
            PlayerLife player = colliders[i].GetComponent<PlayerLife>();
            if (player != null) // Verifica si se encontró el componente
            {
                player.TakeDamage(dmg);
            }
        }
    }
}