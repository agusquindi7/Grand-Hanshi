using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryMusic : MonoBehaviour
{
    public AudioSource audioSourceMain, audioSourceVictory;
    public EnemyLife enemy;

    private void Start()
    {
        audioSourceVictory.mute = true;
    }

    public void Update()
    {
        if(enemy.life<=0)
        {
            audioSourceMain.mute = true;
            audioSourceVictory.mute = false;
        }
    }

    private void OnDisable()
    {
        audioSourceMain.mute = false;
        audioSourceVictory.mute = true;
    }
}
