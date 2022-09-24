using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// Player、enemy、ObjectなどのHPを制御する
/// </summary>

public class HealthComponent : MonoBehaviour
{
    /// <summary>
    /// 最大HP
    /// </summary>
    protected float _maxHp;
    /// <summary>
    /// 現在のHP
    /// </summary>
    protected float _life;
    /// <summary>
    /// 無敵中の判定
    /// </summary>
    protected bool _damageState;
    /// <summary>
    /// 継続系
    /// </summary>
    protected float _timer;

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

        if( _life <= 0)
        {
            GameManager.instance.GameOver();
        }
    }
    /// <summary>
    /// 回復アイテムを使用した時
    /// </summary>
    /// <param name="heelPoint">回復量</param>
    /// <param name="lifePoint">今の体力</param>
    public void Heel(float heelPoint)
    {
        if (_maxHp >= _life)
        {
            _life += heelPoint;
        }
        else
        {
            _life = _maxHp;
        }
    }

    /// <summary>
    /// 継続ダメージと回復スピードの処理
    /// </summary>
    public void Continuous(float timer)
    {
        _timer +=  timer*Time.deltaTime;


    }

    /// <summary>
    /// ダメージを受けた瞬間の無敵時間のタイマー
    /// </summary>
    public IEnumerator DamageTimer()
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
