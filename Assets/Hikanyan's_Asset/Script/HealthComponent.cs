using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player、enemy、ObjectなどのHPを制御する
/// </summary>

public class HealthComponent : MonoBehaviour 
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
    /// <param name="damegePoint">ダメージ量</param>
    /// <param name="lifePoint">今の体力</param>
    public void Damege(float damegePoint, float lifePoint)
    {
        lifePoint -= damegePoint;
    }
    /// <summary>
    /// 回復アイテムを使用した時
    /// </summary>
    /// <param name="heelPoint">回復量</param>
    /// <param name="lifePoint">今の体力</param>
    public void Heel(float heelPoint, float lifePoint)
    {
        lifePoint += heelPoint;
    }

}
