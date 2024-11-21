using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorManager : MonoBehaviour
{
    [SerializeField] Controller controller;
    [SerializeField] Animator animator;
    [SerializeField] AttackManager myAM;

    private void Start()
    {
        if (animator == null) animator = this.GetComponent<Animator>();

        PauseManager.instance.Subscribe(ArtificialUpdate);
    }

    private void ArtificialUpdate()
    {
        if (controller.GetMovementInput().magnitude != 0)
        {
            animator.SetBool("isMoving", true);
            animator.SetFloat("speed", Mathf.Clamp01(controller.GetMovementInput().normalized.z));
            //Debug.Log(Mathf.Clamp01(controller.GetMovementInput().normalized.z));
        }
        else animator.SetBool("isMoving", false);
    }

    private void OnDestroy()
    {
        PauseManager.instance.Unsubscribe(ArtificialUpdate);
    }

    public void ButtonA(string triggerName)
    {
        if (myAM.isReady0)
            animator.SetTrigger(triggerName);
    }

    public void ButtonB(string triggerName)
    {
        if (myAM.isReady1)
            animator.SetTrigger(triggerName);
    }

    public void ButtonC(string triggerName)
    {
        if (myAM.isReady2)
            animator.SetTrigger(triggerName);
    }

    public void ButtonD(string triggerName)
    {
        if(myAM.isReady3)
            animator.SetTrigger(triggerName);
    }
}
