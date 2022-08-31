using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �񕜃A�C�e������������̏���
/// </summary>
public class Heel : ItemBase
{
    [SerializeField] float _heelPoint;
    [SerializeField] float _lifePoint;
    [SerializeField] ParticleSystem _particleSystem;

    public override void Activate()
    {
        FindObjectOfType<HealthComponent>().Heel(_heelPoint,_lifePoint);
    }
}
