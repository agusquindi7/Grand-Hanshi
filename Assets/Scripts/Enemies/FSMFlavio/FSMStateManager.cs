using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMStateManager : MonoBehaviour
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
    [Header("Values")]
    public float followRadius, attackRadius, rotationSpeed, moveSpeed;
    public float cooldown; 
    public float maxCD;
    public LayerMask layerMask;
    public float dmg;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
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
}
