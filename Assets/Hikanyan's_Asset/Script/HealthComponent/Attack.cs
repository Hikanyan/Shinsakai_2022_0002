using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// �_���[�W��^����
/// </summary>
public class Attack : MonoBehaviour
{
    /// <summary>
    /// �ő�HP
    /// </summary>
    [SerializeField] protected float _damage;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out HealthComponent Damage))
        {
            Damage.Damage(_damage);
        }
        //FindObjectOfType<HealthComponent>().Damage(_damage);//�S�̍U��
    }
}
