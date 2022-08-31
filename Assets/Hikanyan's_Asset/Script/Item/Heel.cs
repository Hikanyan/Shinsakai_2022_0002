using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heel : ItemBase
{
    [SerializeField] float _heelPoint;
    [SerializeField] ParticleSystem _particleSystem;

    public override void Activate()
    {
        FindObjectOfType<HealthComponent>().Heel(_heelPoint);
    }
}
