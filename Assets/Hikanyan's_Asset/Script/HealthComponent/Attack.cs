using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ダメージを与える
/// </summary>
public class Attack : MonoBehaviour
{
    /// <summary>
    /// 最大HP
    /// </summary>
    [SerializeField] protected float _damage;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out HealthComponent Damage))
        {
            Damage.Damage(_damage);
        }
        //FindObjectOfType<HealthComponent>().Damage(_damage);//全体攻撃
    }
}
