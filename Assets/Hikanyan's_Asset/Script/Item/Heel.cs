using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 回復アイテムを取った時の処理
/// </summary>
public class Heel : ItemBase
{
    [SerializeField] float _heelPoint;
    [SerializeField] ParticleSystem _particleSystem;

    protected override void Activate()
    {
        if(this.TryGetComponent(out HealthComponent Heel))
        {
            Heel.Heel(_heelPoint);
        }
        //FindObjectOfType<HealthComponent>().Heel(heelPoint: _heelPoint);//全体回復
    }
}
