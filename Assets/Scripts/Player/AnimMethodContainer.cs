using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMethodContainer : AttackManager
{
    public AudioClip attackSound0; 
    public AudioClip attackSound1; 
    public AudioClip attackSound2; 
    public AudioClip attackSound3; 

    public AudioSource audioSource;

    void newStart() 
    {
        audioSource = GetComponent<AudioSource>(); 
    }
    public void ButtonAMethod()
    {
        if (cds[0] == mcds[0] && !isOnMenu)
        {
            //cds[0] = 0;
            attacks[0].Execute(transform.position, 1.2f);
            PlayAttackSound(attackSound0);
        }
    }
    public void ButtonBMethod()
    {
        if (cds[1] == mcds[1] && !isOnMenu)
        {
            //cds[1] = 0;
            attacks[1].Execute(transform.position, 1.35f);
            PlayAttackSound(attackSound1);
        }
    }
    public void ButtonCMethod()
    {
        if (cds[2] == mcds[2] && !isOnMenu)
        {
            //cds[2] = 0;
            attacks[2].Execute(transform.position, 1.7f);
            PlayAttackSound(attackSound2);
        }
    }
    public void ButtonDMethod()
    {
        if (cds[3] == mcds[3] && !isOnMenu)
        {
            //cds[3] = 0;
            attacks[3].Execute(transform.position, 1.5f);
            PlayAttackSound(attackSound3);
        }
    }
    private void PlayAttackSound(AudioClip clip) 
    { 
        if (audioSource != null && clip != null) 
        { 
            audioSource.PlayOneShot(clip); 
        } 
    }
}
