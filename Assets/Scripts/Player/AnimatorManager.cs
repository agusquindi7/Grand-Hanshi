using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorManager : MonoBehaviour
{
    [SerializeField] Controller controller;
    [SerializeField] Animator animator;

    private void Start()
    {
        if (animator == null) animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        if (controller.GetMovementInput().magnitude != 0)
        {
            animator.SetBool("isMoving", true);
            animator.SetFloat("speed", Mathf.Clamp01(controller.GetMovementInput().normalized.z));
            Debug.Log(Mathf.Clamp01(controller.GetMovementInput().normalized.z));
        }
        else animator.SetBool("isMoving", false);
    }
}
