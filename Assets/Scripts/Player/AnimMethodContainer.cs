using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMethodContainer : AttackManager
{
    public void ButtonAMethod()
    {
        if (cds[0] == mcds[0])
        {
            //cds[0] = 0;
            attacks[0].Execute(transform.position, 3f);
        }
    }
    public void ButtonBMethod()
    {
        if (cds[1] == mcds[1])
        {
            //cds[1] = 0;
            attacks[1].Execute(transform.position, 3f);
        }
    }
    public void ButtonCMethod()
    {
        if (cds[2] == mcds[2])
        {
            //cds[2] = 0;
            attacks[2].Execute(transform.position, 3f);
        }
    }
    public void ButtonDMethod()
    {
        if (cds[3] == mcds[3])
        {
            //cds[3] = 0;
            attacks[3].Execute(transform.position, 3f);
        }
    }
}
