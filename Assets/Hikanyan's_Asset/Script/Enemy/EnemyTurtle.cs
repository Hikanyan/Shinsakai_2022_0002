using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurtle : EnemyBase
{
    protected override void Activate()
    {
        base.Start();
        base.Update();
    }
}
