using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player、enemy、ObjectなどのHPを制御する
/// </summary>

public class HealthComponent
{
    /// <summary>
    /// 最大HP
    /// </summary>
    public float _maxHp;
    /// <summary>
    /// 現在のHP
    /// </summary>
    public float _life;

    /// <summary>
    /// ダメージを受けた時の処理
    /// </summary>
    public void Damege(float damegePoint, float lifePoint)
    {
        lifePoint -= damegePoint;
    }

}
