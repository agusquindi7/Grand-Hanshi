using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : AttackController
{
    //Utilizo un array de scripts que posean la interfaz IAttacks
    //Tambien dando la posibilidad al GD para cambiar animaciones a gusto
    public MeleeAttacks[] attacks;

    public float[] cds = new float[4];
    public float[] mcds = new float[4];

    public bool isReady0, isReady1, isReady2, isReady3;
    //Almaceno los datos de los SO, para poder modificarlos 
    public void Start()
    {
        for (int i = 0; i < mcds.Length; i++)
        {
            cds[i] = attacks[i].currentCD;
            mcds[i] = attacks[i].maxCD;
        }
    }

    public void Update()
    {
        if (cds[0] < mcds[0])
        {
            cds[0] += Time.deltaTime;
            isReady0 = false;
        }
        else isReady0 = true;
        cds[0] = Mathf.Clamp(cds[0], 0, mcds[0]);

        if (cds[1] < mcds[1])
        {
            cds[1] += Time.deltaTime;
            isReady1 = false;
        }
        else isReady1 = true;
        cds[1] = Mathf.Clamp(cds[1], 0, mcds[1]);

        if (cds[2] < mcds[2])
        {
            cds[2] += Time.deltaTime;
            isReady2 = false;
        }
        else isReady2 = true;
        cds[2] = Mathf.Clamp(cds[2], 0, mcds[2]);

        if (cds[3] < mcds[3])
        {
            cds[3] += Time.deltaTime;
            isReady3 = false;
        }
        else isReady3 = true;
        cds[3] = Mathf.Clamp(cds[3], 0, mcds[3]);
    }

    public override void ButtonA()
    {
        if (cds[0] == mcds[0])
        {
            cds[0] = 0;
            Debug.Log("Execute");
        }
    }

    public override void ButtonB()
    {
        if (cds[1] == mcds[1])
        {
            cds[1] = 0;
            Debug.Log("Execute");
        }
    }

    public override void ButtonC()
    {
        if (cds[2] == mcds[2])
        {
            cds[2] = 0;
            Debug.Log("Execute");
        }
    }

    public override void ButtonD()
    {
        if (cds[3] == mcds[3])
        {
            cds[3] = 0;
            Debug.Log("Execute");
        }
    }
}
