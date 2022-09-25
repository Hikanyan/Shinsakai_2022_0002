using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �񕜃A�C�e������������̏���
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
        //FindObjectOfType<HealthComponent>().Heel(heelPoint: _heelPoint);//�S�̉�
    }
}
