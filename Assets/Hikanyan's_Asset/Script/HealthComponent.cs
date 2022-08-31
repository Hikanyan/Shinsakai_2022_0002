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

    public bool _damageState;

    /// <summary>
    /// ダメージを受けた時の処理
    /// </summary>
    /// <param name="damegePoint">ダメージ量</param>
    /// <param name="lifePoint">今の体力</param>
    public void Damege(float damegePoint)
    {
        if (_damageState)
        {
            return;
        }

        _life -= damegePoint;
    }
    /// <summary>
    /// 回復アイテムを使用した時
    /// </summary>
    /// <param name="heelPoint">回復量</param>
    /// <param name="lifePoint">今の体力</param>
    public void Heel(float heelPoint)
    {
        if (_maxHp > _life)
        {
            _life += heelPoint;
        }
    }

    /// <summary>
    /// 継続ダメージと回復スピードの処理
    /// </summary>
    public void Continuous()
    {

    }

    /// <summary>
    /// ダメージを受けた瞬間の無敵時間のタイマー
    /// </summary>
    protected IEnumerator DamageTimer()
    {
        if (_damageState)//既にダメージ状態であれば終了
        {
            yield break;
        }

        _damageState = true;

        //この間に無敵中の処理を書く

        _damageState = false;
    }
}
