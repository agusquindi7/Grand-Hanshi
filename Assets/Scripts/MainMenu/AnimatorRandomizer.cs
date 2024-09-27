using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorRandomizer : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetInteger("RandomCombo", Random.Range(0, 3));
    }
}
