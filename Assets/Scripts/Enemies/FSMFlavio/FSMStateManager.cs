using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMStateManager : MonoBehaviour, IDamageable
{
    //Declaro un estado actual de tipo FSMBaseState que es el estado del que heredan todos los estados
    FSMBaseState _currentState;
    //Le doy referencia de todos los estados
    public FlavioIdleState idleState = new FlavioIdleState();
    public FlavioFollowState followState = new FlavioFollowState();
    public FlavioAttackState attackState = new FlavioAttackState();
    public FlavioOnHitState onHitState = new FlavioOnHitState();
    [Header("References")]
    public Animator anim;
    public Rigidbody rigidBody;
    public Transform target;
    public Transform hitboxFlavio;
    public IDamageable enemyLife;
    [Header("Values")]
    public float followRadius;
    public float attackRadius;
    public float rotationSpeed;
    public float moveSpeed;
    public float cooldown; 
    public float maxCD;
    public LayerMask layerMask;
    public float dmg;
    public float timeToRecover = 1.5f;
    //public bool isGettingHit;
    public float onHitCD;

    private void Awake()
    {
        moveSpeed = MyRemoteConfig.Instance.enemySpeed;

        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        enemyLife = GetComponent<EnemyLife>();
    }

    private void Start()
    {
        _currentState = idleState;

        _currentState.Awake(this);
    }

    private void Update()
    {
        _currentState.Execute(this);
    }

    public void SwitchState(FSMBaseState state)
    {
        _currentState.Sleep(this);
        _currentState = state;
        _currentState.Awake(this);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, followRadius);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    public float GetDistance()
    {
        float distance = Vector3.Distance(target.position,transform.position);
        return distance;
    }

    public void PunchHitbox()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f, layerMask);
        foreach (var hit in colliders)
        {
            if(hit.GetComponent<PlayerLife>())
            {
                hit.GetComponent<PlayerLife>().TakeDamage(dmg);
            }
        }
    }

    public void TakeDamage(float dmg)
    {
        SwitchState(onHitState);
    }
}
